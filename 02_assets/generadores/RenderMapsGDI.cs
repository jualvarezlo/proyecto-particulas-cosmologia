using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class RenderMapsGDI
{
    const int W = 1920;
    const int H = 1080;

    // Editorial Palette
    static readonly Color CreamBg = Color.FromArgb(255, 244, 239, 230);        // #F4EFE6
    static readonly Color OceanBg = Color.FromArgb(255, 237, 230, 216);        // #EDE6D8
    static readonly Color LandFill = Color.FromArgb(255, 226, 218, 206);       // #E2DACE
    static readonly Color LandStroke = Color.FromArgb(255, 186, 175, 158);     // #BAAF9E
    static readonly Color FrameBorder = Color.FromArgb(255, 200, 190, 175);    // #C8BEAF

    static readonly Color CardBg = Color.FromArgb(255, 252, 249, 242);         // #FCF9F2
    static readonly Color Charcoal = Color.FromArgb(255, 29, 30, 44);          // #1D1E2C
    static readonly Color CharcoalMuted = Color.FromArgb(255, 85, 94, 104);    // #555E68
    static readonly Color CyanElectric = Color.FromArgb(255, 0, 180, 216);     // #00B4D8
    static readonly Color CyanDeep = Color.FromArgb(255, 0, 119, 182);         // #0077B6
    static readonly Color AmberSolar = Color.FromArgb(255, 247, 127, 0);       // #F77F00

    static readonly Rectangle MapRect = new Rectangle(60, 60, 1800, 960);

    public static void Main()
    {
        string dataPath = @"c:\Proyectos\proyecto-particulas-cosmologia\map_data.json";
        string outDir = @"c:\Proyectos\proyecto-particulas-cosmologia\02_assets\graficos";
        string artifactDir = @"C:\Users\juanj\.gemini\antigravity\brain\40b72386-eda6-459b-83e3-8a289d6331a4";

        var jss = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
        string json = File.ReadAllText(dataPath, System.Text.Encoding.UTF8);
        var root = (Dictionary<string, object>)jss.DeserializeObject(json);

        // Render Map 1: Medellín - Valencia
        Console.WriteLine("Rendering Map 1: Medellín - Valencia...");
        RenderMap1((Dictionary<string, object>)root["map1"], outDir, artifactDir);

        // Render Map 2: Bogotá - Fermilab
        Console.WriteLine("Rendering Map 2: Bogotá - Fermilab...");
        RenderMap2((Dictionary<string, object>)root["map2"], outDir, artifactDir);

        // Render Map 3: Red Global Convergente
        Console.WriteLine("Rendering Map 3: Red Global Convergente...");
        RenderMap3((Dictionary<string, object>)root["map3"], outDir, artifactDir);

        Console.WriteLine("All 3 maps rendered and saved successfully.");
    }

    // -------------------------------------------------------------
    // MAP 1: MEDELLÍN - VALENCIA (TRANSATLÁNTICO)
    // -------------------------------------------------------------
    static void RenderMap1(Dictionary<string, object> data, string outDir, string artifactDir)
    {
        using (Bitmap bmp = new Bitmap(W, H, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);

            // 1. Background & Frame
            DrawBaseMapFrame(g);

            // 2. Graticules
            DrawGraticules(g, (object[])data["grats"]);

            // 3. Landmasses
            DrawPolygons(g, (object[])data["polys"]);

            g.ResetClip();

            // 4. Flight Arc
            PointF[] arcPts = ParsePoints((object[])data["arc"]);
            DrawGeodesicArc(g, arcPts, AmberSolar, Color.FromArgb(85, 247, 127, 0));

            // 5. Great Circle Badge along Arc
            int midIdx = arcPts.Length / 2;
            PointF midPt = arcPts[midIdx];
            DrawDistanceBadge(g, midPt.X - 110, midPt.Y - 26, "✈ 8.298 KM · TRANSATLÁNTICO", "RUTA GEODÉSICA ORTODRÓMICA", CyanElectric);

            // 6. Pins
            PointF medPt = ParsePoint((object[])data["med"]);
            PointF valPt = ParsePoint((object[])data["val"]);

            DrawNodePin(g, medPt.X, medPt.Y, CyanElectric, "MEDELLÍN (MDE)", "Origen: Universidad de Antioquia", "Coordenadas: 6°14′N · 75°34′W", "SEDE GRUPO GFIF · FÍSICA UdeA", AmberSolar, -160, 35, 320, 110);
            DrawNodePin(g, valPt.X, valPt.Y, AmberSolar, "VALENCIA, ESPAÑA (VLC)", "Destino: IFIC (CSIC - Universitat de València)", "Tesis: Violación de R-Paridad y Neutrinos", "AÑO 2001 · DOCTORADO EN FÍSICA", AmberSolar, -20, -145, 350, 120);

            // 7. Editorial Title Card Top Left
            DrawTitleCard(g, 90, 90, 480, 140, "TRAYECTORIA CIENTÍFICA", "Ruta de Formación Doctoral del Dr. Diego Restrepo", "De la Universidad pública en Antioquia a la vanguardia europea", "de la física de partículas en el Instituto de Física Corpuscular (IFIC).", Charcoal);

            // 8. Legend Bottom Right
            DrawLegendCard(g, 1440, 900, 390, 90, "Ruta Transatlántica (8.298 km)", AmberSolar, "Vuelo de Investigación Internacional (2001)", CyanElectric);

            // 9. Technical Coordinate Labels
            DrawTechnicalCoords(g, "LAT 06°14′N / LON 75°34′W [MDE] ➔ LAT 39°28′N / LON 00°22′W [VLC] · DISTANCIA ORTODRÓMICA: 8.298 KM");

            SaveDualFormats(bmp, Path.Combine(outDir, "mapa_vuelo_medellin_valencia"), Path.Combine(artifactDir, "mapa_vuelo_medellin_valencia"));
        }
    }

    // -------------------------------------------------------------
    // MAP 2: BOGOTÁ - FERMILAB (CONTINENTAL)
    // -------------------------------------------------------------
    static void RenderMap2(Dictionary<string, object> data, string outDir, string artifactDir)
    {
        using (Bitmap bmp = new Bitmap(W, H, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);

            // 1. Background & Frame
            DrawBaseMapFrame(g);

            // 2. Graticules
            DrawGraticules(g, (object[])data["grats"]);

            // 3. Landmasses
            DrawPolygons(g, (object[])data["polys"]);

            g.ResetClip();

            // 4. Flight Arc
            PointF[] arcPts = ParsePoints((object[])data["arc"]);
            DrawGeodesicArc(g, arcPts, AmberSolar, Color.FromArgb(85, 247, 127, 0));

            // 5. Great Circle Badge along Arc
            int midIdx = arcPts.Length / 2;
            PointF midPt = arcPts[midIdx];
            DrawDistanceBadge(g, midPt.X - 115, midPt.Y - 26, "✈ 4.373 KM · BOGOTÁ - IL", "CONEXIÓN CONTINENTAL", AmberSolar);

            // 6. Pins
            PointF bogPt = ParsePoint((object[])data["bog"]);
            PointF fermiPt = ParsePoint((object[])data["fermi"]);

            DrawNodePin(g, bogPt.X, bogPt.Y, CyanElectric, "BOGOTÁ (BOG)", "Universidad de los Andes", "Doble titulación en Física y Matemáticas", "PREMIO MEJOR ICFES NACIONAL", CyanElectric, 30, -50, 330, 110);
            DrawNodePin(g, fermiPt.X, fermiPt.Y, AmberSolar, "FERMILAB (BATAVIA, IL)", "Fermi National Accelerator Laboratory", "Wilson Hall · Tevatron Collider", "INICIO INVESTIGACIÓN EN LENTES DÉBILES", CyanElectric, 35, -60, 360, 120);

            // 7. Editorial Title Card Top Left
            DrawTitleCard(g, 90, 90, 490, 140, "RUTA HACIA LAS ALTAS ENERGÍAS", "Trayectoria del Dr. Andrés Plazas Malagón", "De las aulas de Uniandes en Bogotá a los colisionadores de", "partículas en Batavia, Illinois, iniciando el salto a la cosmología.", Charcoal);

            // 8. Legend Bottom Right
            DrawLegendCard(g, 1440, 900, 390, 90, "Conexión Continental (4.373 km)", AmberSolar, "Ruta Académica e Investigación de Posgrado", CyanElectric);

            // 9. Technical Coordinate Labels
            DrawTechnicalCoords(g, "LAT 04°36′N / LON 74°05′W [BOG] ➔ LAT 41°50′N / LON 88°15′W [FNAL] · DISTANCIA ORTODRÓMICA: 4.373 KM");

            SaveDualFormats(bmp, Path.Combine(outDir, "mapa_vuelo_bogota_fermilab"), Path.Combine(artifactDir, "mapa_vuelo_bogota_fermilab"));
        }
    }

    // -------------------------------------------------------------
    // MAP 3: RED GLOBAL CONVERGENTE HACIA COLOMBIA
    // -------------------------------------------------------------
    static void RenderMap3(Dictionary<string, object> data, string outDir, string artifactDir)
    {
        using (Bitmap bmp = new Bitmap(W, H, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);

            // 1. Background & Frame
            DrawBaseMapFrame(g);

            // 2. Graticules
            DrawGraticules(g, (object[])data["grats"]);

            // 3. Landmasses
            DrawPolygons(g, (object[])data["polys"]);

            g.ResetClip();

            // 4. Three Converging Threads
            PointF[] arcGen = ParsePoints((object[])data["arcGeneva"]);
            PointF[] arcSta = ParsePoints((object[])data["arcStanford"]);
            PointF[] arcPac = ParsePoints((object[])data["arcPachon"]);

            // Geneva (Amber Thread)
            DrawGeodesicArc(g, arcGen, AmberSolar, Color.FromArgb(85, 247, 127, 0));
            // Stanford (Electric Cyan Thread)
            DrawGeodesicArc(g, arcSta, CyanElectric, Color.FromArgb(85, 0, 180, 216));
            // Cerro Pachón (Deep Cyan Thread)
            DrawGeodesicArc(g, arcPac, CyanDeep, Color.FromArgb(85, 0, 119, 182));

            // 5. Nodes
            PointF genPt = ParsePoint((object[])data["gen"]);
            PointF staPt = ParsePoint((object[])data["sta"]);
            PointF pacPt = ParsePoint((object[])data["pac"]);
            PointF colPt = ParsePoint((object[])data["col"]);

            // Node Geneva
            DrawNodePinLeft(g, genPt.X, genPt.Y, AmberSolar, "CERN · GINEBRA (SUIZA)", "Gran Colisionador de Hadrones (LHC)", "Detector CMS · Exp. Tevatron & D0", "J. C. Sanabria & D. Restrepo", AmberSolar, 35, -45, 340, 100);

            // Node Stanford
            DrawNodePinRight(g, staPt.X, staPt.Y, CyanElectric, "SLAC · STANFORD (EE. UU.)", "Laboratorio Nacional de Aceleradores", "Cámara LSST (3.200 Megapíxeles)", "Andrés Plazas Malagón", CyanElectric, -360, -45, 340, 100);

            // Node Cerro Pachón
            DrawNodePinRight(g, pacPt.X, pacPt.Y, CyanDeep, "CERRO PACHÓN (CHILE)", "Observatorio Vera C. Rubin (2.700 m)", "Mapeo del 95% invisible del cosmos", "Andrés Plazas Malagón", CyanDeep, -360, -40, 340, 100);

            // 6. Central Hub: Colombia
            DrawCentralHub(g, colPt.X, colPt.Y);

            // 7. Title Card Top Center
            DrawCenterTitleCard(g, 580, 75, 760, 90, "LA RED GLOBAL DE LA FÍSICA COLOMBIANA", "Los epicentros del universo conectados con Colombia");

            // 8. Legend Bottom Right
            DrawGlobalLegendCard(g, 1370, 910, 480, 95);

            // 9. Technical Labels
            DrawTechnicalCoords(g, "COLOMBIA COSMOLOGY & HIGH-ENERGY NETWORK · GINEBRA (CERN) · STANFORD (SLAC) · CHILE (RUBIN)");

            SaveDualFormats(bmp, Path.Combine(outDir, "mapa_convergencia_global_colombia"), Path.Combine(artifactDir, "mapa_convergencia_global_colombia"));
        }
    }

    // -------------------------------------------------------------
    // DRAWING HELPER METHODS
    // -------------------------------------------------------------
    static void SetupGraphics(Graphics g)
    {
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    }

    static void DrawBaseMapFrame(Graphics g)
    {
        // Paper background
        g.Clear(CreamBg);

        // Ocean frame with shadow
        using (SolidBrush oceanBrush = new SolidBrush(OceanBg))
        using (Pen framePen = new Pen(FrameBorder, 2f))
        {
            g.FillRectangle(oceanBrush, MapRect);
            g.DrawRectangle(framePen, MapRect);
        }

        // Clip landmasses and graticules to the map frame
        g.SetClip(MapRect);
    }

    static void DrawGraticules(Graphics g, object[] grats)
    {
        using (Pen pMinor = new Pen(Color.FromArgb(35, 0, 180, 216), 1f) { DashPattern = new float[] { 4f, 4f } })
        using (Pen pMajor = new Pen(Color.FromArgb(70, 0, 180, 216), 1.5f))
        {
            foreach (var item in grats)
            {
                var dict = (Dictionary<string, object>)item;
                int x1 = Convert.ToInt32(dict["x1"]);
                int y1 = Convert.ToInt32(dict["y1"]);
                int x2 = Convert.ToInt32(dict["x2"]);
                int y2 = Convert.ToInt32(dict["y2"]);
                bool isMajor = Convert.ToBoolean(dict["isMajor"]);

                g.DrawLine(isMajor ? pMajor : pMinor, x1, y1, x2, y2);
            }
        }
    }

    static void DrawPolygons(Graphics g, object[] polys)
    {
        using (SolidBrush bLand = new SolidBrush(LandFill))
        using (Pen pLand = new Pen(LandStroke, 1.4f) { LineJoin = LineJoin.Round })
        {
            foreach (var p in polys)
            {
                var ring = (object[])p;
                if (ring.Length < 3) continue;

                PointF[] pts = new PointF[ring.Length];
                for (int i = 0; i < ring.Length; i++)
                {
                    var pt = (object[])ring[i];
                    pts[i] = new PointF(Convert.ToSingle(pt[0]), Convert.ToSingle(pt[1]));
                }

                g.FillPolygon(bLand, pts);
                g.DrawPolygon(pLand, pts);
            }
        }
    }

    static void DrawGeodesicArc(Graphics g, PointF[] pts, Color coreColor, Color glowColor)
    {
        if (pts.Length < 2) return;

        // Wide luminous glow
        using (Pen pGlow = new Pen(glowColor, 10f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
        {
            g.DrawCurve(pGlow, pts, 0.2f);
        }

        // Core dashed flight path
        using (Pen pCore = new Pen(coreColor, 3.2f) {
            DashPattern = new float[] { 8f, 6f },
            StartCap = LineCap.Round,
            EndCap = LineCap.Round
        })
        {
            g.DrawCurve(pCore, pts, 0.2f);
        }
    }

    static void DrawDistanceBadge(Graphics g, float x, float y, string line1, string line2, Color accentColor)
    {
        DrawDropShadow(g, x, y, 230, 52, 8);
        using (SolidBrush bBg = new SolidBrush(Charcoal))
        using (GraphicsPath path = RoundedRect(new RectangleF(x, y, 230, 52), 10))
        {
            g.FillPath(bBg, path);
        }

        using (Font fontSub = new Font("Consolas", 9f, FontStyle.Bold))
        using (Font fontMain = new Font("Trebuchet MS", 11.5f, FontStyle.Bold))
        using (SolidBrush bAccent = new SolidBrush(accentColor))
        using (SolidBrush bWhite = new SolidBrush(Color.White))
        using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center })
        {
            g.DrawString(line2, fontSub, bAccent, x + 115, y + 8, sf);
            g.DrawString(line1, fontMain, bWhite, x + 115, y + 25, sf);
        }
    }

    static void DrawNodePin(Graphics g, float cx, float cy, Color pinColor, string title, string sub1, string sub2, string badge, Color badgeColor, float ox, float oy, float cardW, float cardH)
    {
        // Concentric target circles
        using (SolidBrush bHalo = new SolidBrush(Color.FromArgb(60, pinColor)))
        using (SolidBrush bPin = new SolidBrush(pinColor))
        using (SolidBrush bCenter = new SolidBrush(Color.White))
        using (Pen pBorder = new Pen(Color.FromArgb(140, pinColor), 2f))
        {
            g.FillEllipse(bHalo, cx - 22, cy - 22, 44, 44);
            g.DrawEllipse(pBorder, cx - 22, cy - 22, 44, 44);
            g.FillEllipse(bPin, cx - 11, cy - 11, 22, 22);
            g.FillEllipse(bCenter, cx - 4, cy - 4, 8, 8);
        }

        // Info Card
        float cardX = cx + ox;
        float cardY = cy + oy;

        DrawDropShadow(g, cardX, cardY, cardW, cardH, 8);

        using (SolidBrush bCard = new SolidBrush(CardBg))
        using (Pen pCard = new Pen(FrameBorder, 1.5f))
        using (GraphicsPath path = RoundedRect(new RectangleF(cardX, cardY, cardW, cardH), 8))
        {
            g.FillPath(bCard, path);
            g.DrawPath(pCard, path);
        }

        // Left accent bar
        using (SolidBrush bBar = new SolidBrush(pinColor))
        using (GraphicsPath barPath = RoundedRect(new RectangleF(cardX, cardY, 8, cardH), 4))
        {
            g.FillPath(bBar, barPath);
        }

        // Text
        using (Font fTitle = new Font("Trebuchet MS", 13.5f, FontStyle.Bold))
        using (Font fSub = new Font("Segoe UI", 9.5f, FontStyle.Regular))
        using (Font fBadge = new Font("Consolas", 9f, FontStyle.Bold))
        using (SolidBrush bTitle = new SolidBrush(Charcoal))
        using (SolidBrush bSub = new SolidBrush(CharcoalMuted))
        using (SolidBrush bBadge = new SolidBrush(badgeColor))
        {
            g.DrawString(title, fTitle, bTitle, cardX + 22, cardY + 12);
            g.DrawString(sub1, fSub, bSub, cardX + 22, cardY + 36);
            g.DrawString(sub2, fSub, bSub, cardX + 22, cardY + 54);
            g.DrawString(badge, fBadge, bBadge, cardX + 22, cardY + 76);
        }
    }

    static void DrawNodePinLeft(Graphics g, float cx, float cy, Color pinColor, string title, string sub1, string sub2, string sci, Color badgeColor, float ox, float oy, float cardW, float cardH)
    {
        DrawNodePin(g, cx, cy, pinColor, title, sub1, sub2, "CIENTÍFICOS: " + sci, badgeColor, ox, oy, cardW, cardH);
    }

    static void DrawNodePinRight(Graphics g, float cx, float cy, Color pinColor, string title, string sub1, string sub2, string sci, Color badgeColor, float ox, float oy, float cardW, float cardH)
    {
        // Concentric target circles
        using (SolidBrush bHalo = new SolidBrush(Color.FromArgb(60, pinColor)))
        using (SolidBrush bPin = new SolidBrush(pinColor))
        using (SolidBrush bCenter = new SolidBrush(Color.White))
        using (Pen pBorder = new Pen(Color.FromArgb(140, pinColor), 2f))
        {
            g.FillEllipse(bHalo, cx - 20, cy - 20, 40, 40);
            g.DrawEllipse(pBorder, cx - 20, cy - 20, 40, 40);
            g.FillEllipse(bPin, cx - 10, cy - 10, 20, 20);
            g.FillEllipse(bCenter, cx - 4, cy - 4, 8, 8);
        }

        float cardX = cx + ox;
        float cardY = cy + oy;

        DrawDropShadow(g, cardX, cardY, cardW, cardH, 8);

        using (SolidBrush bCard = new SolidBrush(CardBg))
        using (Pen pCard = new Pen(FrameBorder, 1.5f))
        using (GraphicsPath path = RoundedRect(new RectangleF(cardX, cardY, cardW, cardH), 8))
        {
            g.FillPath(bCard, path);
            g.DrawPath(pCard, path);
        }

        // Right accent bar
        using (SolidBrush bBar = new SolidBrush(pinColor))
        using (GraphicsPath barPath = RoundedRect(new RectangleF(cardX + cardW - 7, cardY, 7, cardH), 3))
        {
            g.FillPath(bBar, barPath);
        }

        // Text
        using (Font fTitle = new Font("Trebuchet MS", 13.5f, FontStyle.Bold))
        using (Font fSub = new Font("Segoe UI", 9.5f, FontStyle.Regular))
        using (Font fBadge = new Font("Consolas", 9f, FontStyle.Bold))
        using (SolidBrush bTitle = new SolidBrush(Charcoal))
        using (SolidBrush bSub = new SolidBrush(CharcoalMuted))
        using (SolidBrush bBadge = new SolidBrush(badgeColor))
        {
            g.DrawString(title, fTitle, bTitle, cardX + 16, cardY + 12);
            g.DrawString(sub1, fSub, bSub, cardX + 16, cardY + 36);
            g.DrawString(sub2, fSub, bSub, cardX + 16, cardY + 54);
            g.DrawString(sci, fBadge, bBadge, cardX + 16, cardY + 74);
        }
    }

    static void DrawCentralHub(Graphics g, float cx, float cy)
    {
        // Central pulsating rings
        using (SolidBrush bRing1 = new SolidBrush(Color.FromArgb(50, AmberSolar)))
        using (SolidBrush bRing2 = new SolidBrush(Color.FromArgb(80, CyanElectric)))
        using (SolidBrush bCore = new SolidBrush(Charcoal))
        using (SolidBrush bDot = new SolidBrush(AmberSolar))
        using (Pen pAmber = new Pen(AmberSolar, 2f))
        using (Pen pCyan = new Pen(CyanElectric, 1.5f))
        {
            g.FillEllipse(bRing1, cx - 36, cy - 36, 72, 72);
            g.DrawEllipse(pAmber, cx - 36, cy - 36, 72, 72);

            g.FillEllipse(bRing2, cx - 22, cy - 22, 44, 44);
            g.DrawEllipse(pCyan, cx - 22, cy - 22, 44, 44);

            g.FillEllipse(bCore, cx - 12, cy - 12, 24, 24);
            g.FillEllipse(bDot, cx - 6, cy - 6, 12, 12);
        }

        // Hub badge
        float bx = cx + 35;
        float by = cy - 55;
        float bw = 330;
        float bh = 110;

        DrawDropShadow(g, bx, by, bw, bh, 10);

        using (SolidBrush bBg = new SolidBrush(Charcoal))
        using (GraphicsPath path = RoundedRect(new RectangleF(bx, by, bw, bh), 10))
        {
            g.FillPath(bBg, path);
        }

        using (SolidBrush bBar = new SolidBrush(AmberSolar))
        using (GraphicsPath barPath = RoundedRect(new RectangleF(bx, by, 8, bh), 4))
        {
            g.FillPath(bBar, barPath);
        }

        using (Font fHubTitle = new Font("Trebuchet MS", 14f, FontStyle.Bold))
        using (Font fHubSub = new Font("Segoe UI", 11f, FontStyle.Bold))
        using (Font fHubInst = new Font("Segoe UI", 9.5f, FontStyle.Regular))
        using (Font fHubTag = new Font("Segoe UI", 9.5f, FontStyle.Bold))
        using (SolidBrush bWhite = new SolidBrush(Color.White))
        using (SolidBrush bAmber = new SolidBrush(AmberSolar))
        using (SolidBrush bCream = new SolidBrush(LandFill))
        {
            g.DrawString("COLOMBIA · NODO CENTRAL", fHubTitle, bWhite, bx + 22, by + 12);
            g.DrawString("BOGOTÁ & MEDELLÍN", fHubSub, bAmber, bx + 22, by + 37);
            g.DrawString("UdeA · Uniandes · UNAL / OAN", fHubInst, bCream, bx + 22, by + 59);
            g.DrawString("Cuatro científicos en la frontera", fHubTag, bAmber, bx + 22, by + 80);
        }
    }

    static void DrawTitleCard(Graphics g, float x, float y, float w, float h, string title, string sub, string line1, string line2, Color accent)
    {
        DrawDropShadow(g, x, y, w, h, 8);

        using (SolidBrush bCard = new SolidBrush(CardBg))
        using (Pen pCard = new Pen(FrameBorder, 1.5f))
        using (GraphicsPath path = RoundedRect(new RectangleF(x, y, w, h), 10))
        {
            g.FillPath(bCard, path);
            g.DrawPath(pCard, path);
        }

        using (SolidBrush bBar = new SolidBrush(accent))
        using (GraphicsPath barPath = RoundedRect(new RectangleF(x, y, 9, h), 4))
        {
            g.FillPath(bBar, barPath);
        }

        using (Font fTitle = new Font("Trebuchet MS", 16.5f, FontStyle.Bold))
        using (Font fSub = new Font("Segoe UI", 11f, FontStyle.Bold))
        using (Font fBody = new Font("Segoe UI", 10f, FontStyle.Regular))
        using (Pen pLine = new Pen(FrameBorder, 1.5f))
        using (SolidBrush bTitle = new SolidBrush(Charcoal))
        using (SolidBrush bSub = new SolidBrush(CyanDeep))
        using (SolidBrush bBody = new SolidBrush(Charcoal))
        {
            g.DrawString(title, fTitle, bTitle, x + 24, y + 14);
            g.DrawString(sub, fSub, bSub, x + 24, y + 42);
            g.DrawLine(pLine, x + 24, y + 68, x + w - 24, y + 68);
            g.DrawString(line1, fBody, bBody, x + 24, y + 80);
            g.DrawString(line2, fBody, bBody, x + 24, y + 102);
        }
    }

    static void DrawCenterTitleCard(Graphics g, float x, float y, float w, float h, string title, string sub)
    {
        DrawDropShadow(g, x, y, w, h, 8);

        using (SolidBrush bCard = new SolidBrush(CardBg))
        using (Pen pCard = new Pen(FrameBorder, 1.5f))
        using (GraphicsPath path = RoundedRect(new RectangleF(x, y, w, h), 12))
        {
            g.FillPath(bCard, path);
            g.DrawPath(pCard, path);
        }

        using (Font fTitle = new Font("Trebuchet MS", 19f, FontStyle.Bold))
        using (Font fSub = new Font("Segoe UI", 12f, FontStyle.Bold))
        using (SolidBrush bTitle = new SolidBrush(Charcoal))
        using (SolidBrush bSub = new SolidBrush(CyanDeep))
        using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center })
        {
            g.DrawString(title, fTitle, bTitle, x + w / 2, y + 18, sf);
            g.DrawString(sub, fSub, bSub, x + w / 2, y + 50, sf);
        }
    }

    static void DrawLegendCard(Graphics g, float x, float y, float w, float h, string l1, Color c1, string l2, Color c2)
    {
        DrawDropShadow(g, x, y, w, h, 6);

        using (SolidBrush bCard = new SolidBrush(CardBg))
        using (Pen pCard = new Pen(FrameBorder, 1.5f))
        using (GraphicsPath path = RoundedRect(new RectangleF(x, y, w, h), 8))
        {
            g.FillPath(bCard, path);
            g.DrawPath(pCard, path);
        }

        using (Pen pDash = new Pen(c1, 3f) { DashPattern = new float[] { 6f, 4f } })
        using (SolidBrush bDot1 = new SolidBrush(c1))
        using (SolidBrush bDot2 = new SolidBrush(c2))
        using (Font fText = new Font("Segoe UI", 10.5f, FontStyle.Regular))
        using (Font fBold = new Font("Segoe UI", 10.5f, FontStyle.Bold))
        using (SolidBrush bText = new SolidBrush(Charcoal))
        {
            g.DrawLine(pDash, x + 20, y + 30, x + 75, y + 30);
            g.FillEllipse(bDot1, x + 43, y + 26, 8, 8);
            g.DrawString(l1, fBold, bText, x + 90, y + 20);

            g.FillEllipse(bDot2, x + 43, y + 56, 10, 10);
            g.DrawString(l2, fText, bText, x + 90, y + 51);
        }
    }

    static void DrawGlobalLegendCard(Graphics g, float x, float y, float w, float h)
    {
        DrawDropShadow(g, x, y, w, h, 6);

        using (SolidBrush bCard = new SolidBrush(CardBg))
        using (Pen pCard = new Pen(FrameBorder, 1.5f))
        using (GraphicsPath path = RoundedRect(new RectangleF(x, y, w, h), 8))
        {
            g.FillPath(bCard, path);
            g.DrawPath(pCard, path);
        }

        using (Pen pAmber = new Pen(AmberSolar, 3f) { DashPattern = new float[] { 6f, 4f } })
        using (Pen pCyan = new Pen(CyanElectric, 3f) { DashPattern = new float[] { 6f, 4f } })
        using (Font fBold = new Font("Segoe UI", 10f, FontStyle.Bold))
        using (Font fText = new Font("Segoe UI", 9.5f, FontStyle.Regular))
        using (SolidBrush bText = new SolidBrush(Charcoal))
        {
            g.DrawLine(pAmber, x + 18, y + 32, x + 65, y + 32);
            g.DrawString("Hilo Ámbar: CERN (Ginebra) ➔ Colombia (Física Altas Energías)", fText, bText, x + 75, y + 23);

            g.DrawLine(pCyan, x + 18, y + 64, x + 65, y + 64);
            g.DrawString("Hilo Cian: SLAC & Cerro Pachón ➔ Colombia (Cosmología)", fText, bText, x + 75, y + 55);
        }
    }

    static void DrawTechnicalCoords(Graphics g, string label)
    {
        using (Font mono = new Font("Consolas", 9f, FontStyle.Regular))
        using (SolidBrush bText = new SolidBrush(Color.FromArgb(140, 29, 30, 44)))
        {
            g.DrawString(label, mono, bText, 65, H - 35);
            g.DrawString("CARTOGRAFÍA CIENTÍFICA · EL 95% INVISIBLE", mono, bText, W - 390, H - 35);
        }
    }

    static void DrawDropShadow(Graphics g, float x, float y, float w, float h, float radius)
    {
        for (int i = 1; i <= 4; i++)
        {
            int alpha = 14 - (i * 3);
            using (SolidBrush bShadow = new SolidBrush(Color.FromArgb(alpha, 29, 30, 44)))
            using (GraphicsPath path = RoundedRect(new RectangleF(x - i, y + i * 1.5f, w + i * 2, h + i * 2), radius + i))
            {
                g.FillPath(bShadow, path);
            }
        }
    }

    static GraphicsPath RoundedRect(RectangleF bounds, float radius)
    {
        GraphicsPath path = new GraphicsPath();
        float diameter = radius * 2;
        path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
        path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();
        return path;
    }

    static PointF ParsePoint(object[] pt)
    {
        return new PointF(Convert.ToSingle(pt[0]), Convert.ToSingle(pt[1]));
    }

    static PointF[] ParsePoints(object[] arr)
    {
        PointF[] pts = new PointF[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            var p = (object[])arr[i];
            pts[i] = new PointF(Convert.ToSingle(p[0]), Convert.ToSingle(p[1]));
        }
        return pts;
    }

    static void SaveDualFormats(Bitmap bmp, string basePathNoExt, string artifactPathNoExt)
    {
        // 1. Save PNG
        string pngPath = basePathNoExt + ".png";
        bmp.Save(pngPath, ImageFormat.Png);

        // 2. Save JPG (High Quality 95)
        string jpgPath = basePathNoExt + ".jpg";
        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
        using (EncoderParameters encParams = new EncoderParameters(1))
        {
            encParams.Param[0] = new EncoderParameter(Encoder.Quality, 95L);
            bmp.Save(jpgPath, jpgEncoder, encParams);
        }

        // Copy to artifact directory
        File.Copy(pngPath, artifactPathNoExt + ".png", true);
        File.Copy(jpgPath, artifactPathNoExt + ".jpg", true);

        Console.WriteLine("Saved: " + pngPath + " and " + jpgPath);
    }

    static ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid) return codec;
        }
        return null;
    }
}
