using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

public class MuralBeat77Renderer
{
    const int W = 1920;
    const int H = 1080;

    // Paleta Editorial
    static readonly Color CreamBg = Color.FromArgb(255, 244, 239, 230);        // #F4EFE6
    static readonly Color CardBg = Color.FromArgb(255, 252, 249, 244);         // #FCF9F4
    static readonly Color Charcoal = Color.FromArgb(255, 29, 30, 44);          // #1D1E2C
    static readonly Color CharcoalMuted = Color.FromArgb(255, 75, 77, 98);     // #4B4D62
    static readonly Color CyanElectric = Color.FromArgb(255, 0, 180, 216);     // #00B4D8
    static readonly Color CyanDeep = Color.FromArgb(255, 0, 119, 182);         // #0077B6
    static readonly Color AmberSolar = Color.FromArgb(255, 247, 127, 0);       // #F77F00
    static readonly Color AmberGold = Color.FromArgb(255, 252, 191, 73);       // #FCBF49

    public static void Render(
        string imgRestrepoPath,
        string imgPlazasPath,
        string imgSanabriaPath,
        string imgCastanedaPath,
        string outputPath)
    {
        using (Bitmap bmp = new Bitmap(W, H, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // 1. Fondo de papel crema
            g.Clear(CreamBg);

            // 2. Cuadrícula blueprint astronómica
            using (Pen penMinor = new Pen(Color.FromArgb(14, 29, 30, 44), 1f))
            using (Pen penMajor = new Pen(Color.FromArgb(28, 0, 180, 216), 1.5f))
            {
                for (int x = 0; x <= W; x += 40)
                {
                    Pen p = (x % 200 == 0) ? penMajor : penMinor;
                    g.DrawLine(p, x, 0, x, H);
                }
                for (int y = 0; y <= H; y += 40)
                {
                    Pen p = (y % 200 == 0) ? penMajor : penMinor;
                    g.DrawLine(p, 0, y, W, y);
                }
            }

            // Marcas técnicas de blueprint en las esquinas
            using (Font monoSmall = new Font("Consolas", 10f, FontStyle.Regular))
            using (Brush textMuted = new SolidBrush(Color.FromArgb(120, 29, 30, 44)))
            {
                g.DrawString("LAT +04°35′53″ / LON -74°04′33″ [COLOMBIA COSMOLOGY GRID]", monoSmall, textMuted, 30, 25);
                g.DrawString("COSMIC CARTOGRAPHY & PARTICLE ASTROPHYSICS", monoSmall, textMuted, W - 440, 25);
                g.DrawString("ACELERADOR LHC / OBS. RUBIN / DETECTOR ESCOTO / f(R)", monoSmall, textMuted, 30, H - 35);
                g.DrawString("EL 95% INVISIBLE: CIENCIA COLOMBIANA DE FRONTERA", monoSmall, textMuted, W - 460, H - 35);
            }

            // 3. Dibujar hilos de energía y conexiones geométricas (detrás de las tarjetas y centro)
            DrawConnectingVectors(g);

            // 4. Núcleo Central: El 95% Invisible
            DrawCenterCore(g, W / 2, H / 2);

            // 5. Cargar las 4 fotos reales y dibujar sus tarjetas tipo collage
            using (Image imgRestrepo = Image.FromFile(imgRestrepoPath))
            using (Image imgPlazas = Image.FromFile(imgPlazasPath))
            using (Image imgSanabria = Image.FromFile(imgSanabriaPath))
            using (Image imgCastaneda = Image.FromFile(imgCastanedaPath))
            {
                // Top-Left: Diego Restrepo
                DrawScientistCard(g, 70, 120, 380, 415, -1.8f, imgRestrepo,
                    "DR. DIEGO RESTREPO",
                    "Universidad de Antioquia (Medellín)",
                    "TEORÍA CUÁNTICA · FENOMENOLOGÍA",
                    "Mecanismo escotogénico a 1 lazo cuántico que conecta la masa de los neutrinos con la materia oscura.",
                    CyanElectric, AmberSolar, true);

                // Top-Right: Andrés Plazas Malagón
                DrawScientistCard(g, W - 450, 120, 380, 415, 1.8f, imgPlazas,
                    "DR. ANDRÉS PLAZAS MALAGÓN",
                    "SLAC / Stanford Univ. · Vera C. Rubin Obs.",
                    "INSTRUMENTACIÓN · LENTES DÉBILES",
                    "Calibración de aberraciones CCD y efecto Brighter-Fatter para medir la deformación cósmica del 1%.",
                    AmberSolar, CyanElectric, false);

                // Bottom-Left: Juan Carlos Sanabria
                DrawScientistCard(g, 70, H - 475, 380, 415, 1.5f, imgSanabria,
                    "DR. JUAN CARLOS SANABRIA",
                    "Universidad de los Andes · CERN CMS · ACCEFYN",
                    "ALTAS ENERGÍAS · DETECTORES CMS",
                    "Cámaras de muones RPC y sistema de Trigger en el LHC; coautor en el hallazgo del Bosón de Higgs.",
                    CyanElectric, AmberSolar, false);

                // Bottom-Right: Leonardo Castañeda
                DrawScientistCard(g, W - 450, H - 475, 380, 415, -1.5f, imgCastaneda,
                    "DR. LEONARDO CASTAÑEDA",
                    "Observatorio Astronómico Nacional · UNAL",
                    "GRAVITACIÓN · RELATIVIDAD GENERAL",
                    "Deducción del término de frontera en gravedad modificada f(R) métrica para explicar la aceleración cósmica.",
                    AmberSolar, CyanElectric, true);
            }

            // 6. Cabecera principal (Top Center)
            DrawHeader(g);

            // Guardar imagen en alta calidad
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 96L);
            bmp.Save(outputPath, jpgEncoder, myEncoderParameters);
        }
    }

    static void DrawHeader(Graphics g)
    {
        // Título principal con colores de acento (sin referencias técnicas ni números de beat)
        using (Font fontTitle = new Font("Trebuchet MS", 40f, FontStyle.Bold))
        using (Brush bCharcoal = new SolidBrush(Charcoal))
        using (Brush bCyan = new SolidBrush(CyanElectric))
        using (Brush bAmber = new SolidBrush(AmberSolar))
        {
            string t1 = "CUATRO FRENTES, ";
            string t2 = "UNA ";
            string t3 = "MISIÓN";

            SizeF s1 = g.MeasureString(t1, fontTitle);
            SizeF s2 = g.MeasureString(t2, fontTitle);
            SizeF s3 = g.MeasureString(t3, fontTitle);

            float totalW = s1.Width + s2.Width + s3.Width;
            float startX = (W - totalW) / 2f;
            float titleY = 40f;

            g.DrawString(t1, fontTitle, bCharcoal, startX, titleY);
            g.DrawString(t2, fontTitle, bCyan, startX + s1.Width, titleY);
            g.DrawString(t3, fontTitle, bAmber, startX + s1.Width + s2.Width, titleY);
        }

        // Subtítulo
        using (Font fontSub = new Font("Segoe UI", 15f, FontStyle.Bold))
        using (Brush bSub = new SolidBrush(CharcoalMuted))
        {
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
            g.DrawString("Cuatro Físicos Colombianos en la Frontera del Universo Invisible", fontSub, bSub, W / 2f, 96f, sf);
        }
    }

    static void DrawCenterCore(Graphics g, int cx, int cy)
    {
        int r = 145;

        // Sombra suave del disco
        using (SolidBrush shadowB = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
        {
            g.FillEllipse(shadowB, cx - r + 6, cy - r + 14, (r * 2), (r * 2));
        }

        // Borde exterior blanco de papel
        using (SolidBrush borderB = new SolidBrush(CardBg))
        {
            g.FillEllipse(borderB, cx - r - 8, cy - r - 8, (r + 8) * 2, (r + 8) * 2);
        }

        // Disco principal oscuro con degradado radial
        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddEllipse(cx - r, cy - r, r * 2, r * 2);
            using (PathGradientBrush pgb = new PathGradientBrush(path))
            {
                pgb.CenterColor = Color.FromArgb(255, 34, 36, 54);
                pgb.SurroundColors = new Color[] { Color.FromArgb(255, 14, 15, 23) };
                g.FillEllipse(pgb, cx - r, cy - r, r * 2, r * 2);
            }
        }

        // Anillo cian brillante
        using (Pen pCyan = new Pen(CyanElectric, 3.5f))
        {
            g.DrawEllipse(pCyan, cx - r, cy - r, r * 2, r * 2);
        }

        // Anillo exterior discontinuo en ámbar
        using (Pen pAmber = new Pen(AmberSolar, 2f))
        {
            pAmber.DashStyle = DashStyle.Dash;
            g.DrawEllipse(pAmber, cx - r - 16, cy - r - 16, (r + 16) * 2, (r + 16) * 2);
        }

        // Textos del centro
        using (Font fontTag = new Font("Consolas", 10.5f, FontStyle.Bold))
        using (Font fontBigNum = new Font("Trebuchet MS", 46f, FontStyle.Bold))
        using (Font fontLabel = new Font("Trebuchet MS", 16f, FontStyle.Bold))
        using (Font fontDetails = new Font("Consolas", 10f, FontStyle.Regular))
        using (Brush bAmber = new SolidBrush(AmberSolar))
        using (Brush bCyan = new SolidBrush(CyanElectric))
        using (Brush bWhite = new SolidBrush(CreamBg))
        {
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            g.DrawString("EL ENIGMA CÓSMICO", fontTag, bAmber, cx, cy - 88, sf);
            g.DrawString("95%", fontBigNum, bCyan, cx, cy - 42, sf);
            g.DrawString("INVISIBLE", fontLabel, bWhite, cx, cy - 2, sf);

            // Línea divisoria
            using (Pen divPen = new Pen(Color.FromArgb(80, 244, 239, 230), 1f))
            {
                g.DrawLine(divPen, cx - 85, cy + 18, cx + 85, cy + 18);
            }

            g.DrawString("27% MATERIA OSCURA", fontDetails, bCyan, cx, cy + 38, sf);
            g.DrawString("68% ENERGÍA OSCURA", fontDetails, bAmber, cx, cy + 58, sf);
            using (Brush bFaint = new SolidBrush(Color.FromArgb(160, 244, 239, 230)))
            {
                g.DrawString("(Solo vemos el 5% visible)", fontDetails, bFaint, cx, cy + 82, sf);
            }
        }
    }

    static void DrawConnectingVectors(Graphics g)
    {
        int cx = W / 2;
        int cy = H / 2;

        // Conexiones curvas desde cada cuadrante al centro
        using (Pen penCyanThick = new Pen(Color.FromArgb(200, 0, 180, 216), 3.5f))
        using (Pen penAmberThick = new Pen(Color.FromArgb(200, 247, 127, 0), 3.5f))
        using (Pen penGlowCyan = new Pen(Color.FromArgb(50, 0, 180, 216), 12f))
        using (Pen penGlowAmber = new Pen(Color.FromArgb(50, 247, 127, 0), 12f))
        {
            penCyanThick.DashStyle = DashStyle.Dash;
            penAmberThick.DashStyle = DashStyle.Dash;

            // Restrepo (Top-Left) -> Centro
            Point p1Start = new Point(460, 310);
            Point p1Control = new Point(720, 420);
            Point p1End = new Point(cx - 130, cy - 70);
            g.DrawBezier(penGlowCyan, p1Start, p1Control, p1Control, p1End);
            g.DrawBezier(penCyanThick, p1Start, p1Control, p1Control, p1End);

            // Plazas (Top-Right) -> Centro
            Point p2Start = new Point(W - 460, 310);
            Point p2Control = new Point(W - 720, 420);
            Point p2End = new Point(cx + 130, cy - 70);
            g.DrawBezier(penGlowAmber, p2Start, p2Control, p2Control, p2End);
            g.DrawBezier(penAmberThick, p2Start, p2Control, p2Control, p2End);

            // Sanabria (Bottom-Left) -> Centro
            Point p3Start = new Point(460, 770);
            Point p3Control = new Point(720, 660);
            Point p3End = new Point(cx - 130, cy + 70);
            g.DrawBezier(penGlowCyan, p3Start, p3Control, p3Control, p3End);
            g.DrawBezier(penCyanThick, p3Start, p3Control, p3Control, p3End);

            // Castañeda (Bottom-Right) -> Centro
            Point p4Start = new Point(W - 460, 770);
            Point p4Control = new Point(W - 720, 660);
            Point p4End = new Point(cx + 130, cy + 70);
            g.DrawBezier(penGlowAmber, p4Start, p4Control, p4Control, p4End);
            g.DrawBezier(penAmberThick, p4Start, p4Control, p4Control, p4End);
        }

        // Hilos perimetrales entre científicos (Red Colaborativa)
        using (Pen penCross = new Pen(Color.FromArgb(90, 29, 30, 44), 1.5f))
        {
            penCross.DashStyle = DashStyle.Dot;
            // Superior: Restrepo <-> Plazas
            g.DrawLine(penCross, 450, 160, W - 450, 160);
            // Inferior: Sanabria <-> Castañeda
            g.DrawLine(penCross, 450, H - 160, W - 450, H - 160);
            // Lateral Izquierdo: Restrepo <-> Sanabria (Física de Partículas)
            g.DrawLine(penCross, 130, 480, 130, 660);
            // Lateral Derecho: Plazas <-> Castañeda (Cosmología y Gravitación)
            g.DrawLine(penCross, W - 130, 480, W - 130, 660);
        }
    }

    static void DrawScientistCard(
        Graphics g,
        int x, int y, int w, int h,
        float angleDeg,
        Image portrait,
        string name,
        string institution,
        string badgeText,
        string contribution,
        Color badgeColor,
        Color washiColor,
        bool washiLeft)
    {
        GraphicsState state = g.Save();

        // Trasladar y rotar según ángulo
        g.TranslateTransform(x + w / 2f, y + h / 2f);
        g.RotateTransform(angleDeg);
        g.TranslateTransform(-w / 2f, -h / 2f);

        // 1. Sombra suave de la tarjeta
        using (SolidBrush bShadow = new SolidBrush(Color.FromArgb(35, 0, 0, 0)))
        {
            FillRoundedRect(g, bShadow, new Rectangle(6, 12, w, h), 10);
        }

        // 2. Fondo de la tarjeta (blanco cálido editorial)
        using (SolidBrush bCard = new SolidBrush(CardBg))
        using (Pen pBorder = new Pen(Color.FromArgb(30, 29, 30, 44), 1f))
        {
            FillRoundedRect(g, bCard, new Rectangle(0, 0, w, h), 8);
            DrawRoundedRect(g, pBorder, new Rectangle(0, 0, w, h), 8);
        }

        // 3. Cinta Washi decorativa pegada en la esquina
        int washiW = 105;
        int washiH = 26;
        int washiX = washiLeft ? 20 : w - washiW - 20;
        int washiY = -12;

        GraphicsState washiState = g.Save();
        g.TranslateTransform(washiX + washiW / 2f, washiY + washiH / 2f);
        g.RotateTransform(washiLeft ? -6f : 6f);
        g.TranslateTransform(-washiW / 2f, -washiH / 2f);
        using (SolidBrush bWashi = new SolidBrush(Color.FromArgb(170, washiColor.R, washiColor.G, washiColor.B)))
        {
            g.FillRectangle(bWashi, 0, 0, washiW, washiH);
        }
        g.Restore(washiState);

        // 4. Marco de la foto (borde blanco limpio de recorte / sticker)
        int photoMargin = 14;
        int photoW = w - (photoMargin * 2);
        int photoH = 240;

        using (SolidBrush bPhotoBg = new SolidBrush(Color.White))
        using (Pen pPhotoBorder = new Pen(Color.FromArgb(20, 0, 0, 0), 1f))
        {
            g.FillRectangle(bPhotoBg, photoMargin, photoMargin, photoW, photoH);
            g.DrawRectangle(pPhotoBorder, photoMargin, photoMargin, photoW, photoH);
        }

        // Dibujar retrato real manteniendo proporción centrada
        DrawImageCentered(g, portrait, new Rectangle(photoMargin + 3, photoMargin + 3, photoW - 6, photoH - 6));

        // 5. Badge temático
        int badgeY = photoMargin + photoH + 12;
        using (Font fontBadge = new Font("Consolas", 8.5f, FontStyle.Bold))
        {
            SizeF badgeSize = g.MeasureString(badgeText, fontBadge);
            int bw = (int)badgeSize.Width + 14;
            int bh = (int)badgeSize.Height + 6;

            using (SolidBrush bBadge = new SolidBrush(Color.FromArgb(30, badgeColor.R, badgeColor.G, badgeColor.B)))
            using (Pen pBadge = new Pen(badgeColor, 1.2f))
            using (Brush textBadge = new SolidBrush(badgeColor))
            {
                FillRoundedRect(g, bBadge, new Rectangle(photoMargin, badgeY, bw, bh), 3);
                DrawRoundedRect(g, pBadge, new Rectangle(photoMargin, badgeY, bw, bh), 3);

                StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center };
                g.DrawString(badgeText, fontBadge, textBadge, photoMargin + 7, badgeY + (bh / 2f), sf);
            }
        }

        // 6. Nombre del científico
        int textY = badgeY + 28;
        using (Font fontName = new Font("Trebuchet MS", 15.5f, FontStyle.Bold))
        using (Brush bName = new SolidBrush(Charcoal))
        {
            g.DrawString(name, fontName, bName, photoMargin, textY);
        }

        // 7. Institución
        using (Font fontInst = new Font("Segoe UI", 9.5f, FontStyle.Bold))
        using (Brush bInst = new SolidBrush(CharcoalMuted))
        {
            g.DrawString(institution, fontInst, bInst, photoMargin, textY + 24);
        }

        // Línea divisoria suave
        using (Pen pDiv = new Pen(Color.FromArgb(35, 29, 30, 44), 1f))
        {
            pDiv.DashStyle = DashStyle.Dash;
            g.DrawLine(pDiv, photoMargin, textY + 46, w - photoMargin, textY + 46);
        }

        // 8. Resumen del Aporte
        using (Font fontDesc = new Font("Segoe UI", 8.5f, FontStyle.Regular))
        using (Brush bDesc = new SolidBrush(Color.FromArgb(255, 46, 48, 71)))
        {
            RectangleF rDesc = new RectangleF(photoMargin, textY + 52, w - (photoMargin * 2), 48);
            g.DrawString(contribution, fontDesc, bDesc, rDesc);
        }

        g.Restore(state);
    }

    static void DrawImageCentered(Graphics g, Image img, Rectangle destRect)
    {
        float imgAspect = (float)img.Width / img.Height;
        float destAspect = (float)destRect.Width / destRect.Height;

        int drawW = destRect.Width;
        int drawH = destRect.Height;
        int drawX = destRect.X;
        int drawY = destRect.Y;

        // Recorte tipo cover centrado en la cabeza
        if (imgAspect > destAspect)
        {
            // Imagen más ancha: escalar por alto y recortar lados
            drawW = (int)(destRect.Height * imgAspect);
            drawX = destRect.X + (destRect.Width - drawW) / 2;
        }
        else
        {
            // Imagen más alta: escalar por ancho y alinear hacia arriba (foco en cabeza)
            drawH = (int)(destRect.Width / imgAspect);
            drawY = destRect.Y;
        }

        Region oldClip = g.Clip;
        g.SetClip(destRect);
        g.DrawImage(img, drawX, drawY, drawW, drawH);
        g.Clip = oldClip;
    }

    static void FillRoundedRect(Graphics g, Brush b, Rectangle r, int radius)
    {
        using (GraphicsPath path = GetRoundedRectPath(r, radius))
        {
            g.FillPath(b, path);
        }
    }

    static void DrawRoundedRect(Graphics g, Pen p, Rectangle r, int radius)
    {
        using (GraphicsPath path = GetRoundedRectPath(r, radius))
        {
            g.DrawPath(p, path);
        }
    }

    static GraphicsPath GetRoundedRectPath(Rectangle r, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int d = radius * 2;
        path.AddArc(r.X, r.Y, d, d, 180, 90);
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }

    static ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;
    }
}
