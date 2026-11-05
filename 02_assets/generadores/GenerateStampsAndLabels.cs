using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Text;

public class GenerateStampsAndLabels
{
    // Color Palette
    static readonly Color AmberSolar = Color.FromArgb(247, 127, 0);
    static readonly Color AmberDark = Color.FromArgb(215, 105, 0);
    static readonly Color CyanElectric = Color.FromArgb(0, 180, 216);
    static readonly Color Charcoal = Color.FromArgb(29, 30, 44);
    static readonly Color PaperCream = Color.FromArgb(244, 239, 230);
    static readonly Color InkNavy = Color.FromArgb(20, 35, 65);
    static readonly Color InkWine = Color.FromArgb(139, 30, 45);
    static readonly Color InkTeal = Color.FromArgb(26, 75, 117);

    public static void Main()
    {
        string outDir = @"c:\Proyectos\proyecto-particulas-cosmologia\02_assets\graficos";
        string artifactDir = @"C:\Users\juanj\.gemini\antigravity\brain\40b72386-eda6-459b-83e3-8a289d6331a4";

        Directory.CreateDirectory(outDir);

        Console.WriteLine("=== GENERATING STAMPS AND PROP LABELS ===");

        // 1. Sello de Advertencia: LÍMITE DE LA ANALOGÍA
        GenerateSelloLimiteAnalogia(outDir, artifactDir);

        // 2. Sellos Institucionales de Fondo
        GenerateSelloUdeA(outDir, artifactDir);
        GenerateSelloMinCiencias(outDir, artifactDir);
        GenerateSelloACCEFYN(outDir, artifactDir);
        GenerateSelloUNAL(outDir, artifactDir);
        GenerateSelloMainz(outDir, artifactDir);

        // 3. Sellos de Pasaporte Vintage (Jefferson Lab, Fermilab, CERN) + Página Compuesta
        GenerateSelloJeffersonLab(outDir, artifactDir);
        GenerateSelloFermilab(outDir, artifactDir);
        GenerateSelloCERN(outDir, artifactDir);
        GeneratePasaporteSanabria(outDir, artifactDir);

        // 4. Etiqueta para Utilería a Cámara: 100 g de Materia Oscura
        GenerateEtiquetaMateriaOscura(outDir, artifactDir);

        Console.WriteLine("=== ALL STAMPS AND LABELS GENERATED SUCCESSFULLY ===");
    }

    // ==========================================
    // 1. SELLO: LÍMITE DE LA ANALOGÍA
    // ==========================================
    static void GenerateSelloLimiteAnalogia(string outDir, string artifactDir)
    {
        int W = 1000, H = 340;
        using (Bitmap bmp = new Bitmap(W, H, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);

            // Borde exterior rectangular de caucho con esquinas redondeadas
            using (Pen pThick = new Pen(AmberSolar, 12f))
            using (Pen pThin = new Pen(AmberSolar, 3.5f))
            {
                Rectangle rOuter = new Rectangle(20, 20, W - 40, H - 40);
                DrawRoundedRect(g, pThick, rOuter, 28);

                Rectangle rInner = new Rectangle(36, 36, W - 72, H - 72);
                DrawRoundedRect(g, pThin, rInner, 20);
            }

            // Franjas de advertencia en los costados
            using (Brush bAmber = new SolidBrush(AmberSolar))
            {
                for (int y = 50; y <= H - 80; y += 35)
                {
                    g.FillPolygon(bAmber, new Point[] {
                        new Point(45, y), new Point(70, y), new Point(55, y + 25), new Point(30, y + 25)
                    });
                    g.FillPolygon(bAmber, new Point[] {
                        new Point(W - 45, y), new Point(W - 70, y), new Point(W - 55, y + 25), new Point(W - 30, y + 25)
                    });
                }
            }

            // Tipografía de advertencia
            using (Font fTop = new Font("Segoe UI", 18f, FontStyle.Bold))
            using (Font fMain = new Font("Trebuchet MS", 46f, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 17f, FontStyle.Bold))
            using (Brush bAmber = new SolidBrush(AmberSolar))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };

                g.DrawString("▲  PRECAUCIÓN TEÓRICA  ▲", fTop, bAmber, W / 2f, 50, sf);
                g.DrawString("LÍMITE DE LA ANALOGÍA", fMain, bAmber, W / 2f, 108, sf);

                using (Pen pDiv = new Pen(AmberSolar, 3f))
                {
                    g.DrawLine(pDiv, 160, 215, W - 160, 215);
                }

                g.DrawString("MODELO SIMPLIFICADO · LA FÍSICA REAL CONTINÚA AQUÍ", fSub, bAmber, W / 2f, 235, sf);
            }

            // Micro-desgaste procedural de sello de caucho
            ApplyStampDistress(bmp, AmberSolar, 42);

            string pngPath = Path.Combine(outDir, "sello_limite_analogia.png");
            bmp.Save(pngPath, ImageFormat.Png);
            bmp.Save(Path.Combine(artifactDir, "sello_limite_analogia.png"), ImageFormat.Png);
        }

        // SVG Vectorial
        string svg = string.Format(
@"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 {0} {1}"" width=""{0}"" height=""{1}"">
  <defs>
    <style>
      .amber-text {{ fill: #F77F00; font-family: 'Trebuchet MS', 'Arial Black', sans-serif; font-weight: bold; }}
      .sub-text {{ fill: #F77F00; font-family: 'Segoe UI', Arial, sans-serif; font-weight: bold; }}
      .amber-stroke {{ stroke: #F77F00; fill: none; }}
    </style>
  </defs>
  <rect x=""20"" y=""20"" width=""{2}"" height=""{3}"" rx=""28"" class=""amber-stroke"" stroke-width=""12""/>
  <rect x=""36"" y=""36"" width=""{4}"" height=""{5}"" rx=""20"" class=""amber-stroke"" stroke-width=""3.5""/>
  <text x=""{6}"" y=""80"" text-anchor=""middle"" class=""sub-text"" font-size=""24"">▲  PRECAUCIÓN TEÓRICA  ▲</text>
  <text x=""{6}"" y=""180"" text-anchor=""middle"" class=""amber-text"" font-size=""66"">LÍMITE DE LA ANALOGÍA</text>
  <line x1=""140"" y1=""215"" x2=""{7}"" y2=""215"" class=""amber-stroke"" stroke-width=""3""/>
  <text x=""{6}"" y=""265"" text-anchor=""middle"" class=""sub-text"" font-size=""20"">MODELO SIMPLIFICADO · LA FÍSICA REAL CONTINÚA AQUÍ</text>
</svg>", W, H, W - 40, H - 40, W - 72, H - 72, W / 2, W - 140);

        File.WriteAllText(Path.Combine(outDir, "sello_limite_analogia.svg"), svg, Encoding.UTF8);
    }

    // ==========================================
    // 2. SELLOS INSTITUCIONALES DE FONDO
    // ==========================================

    static void GenerateSelloUdeA(string outDir, string artifactDir)
    {
        int S = 800;
        string topText = "UNIVERSIDAD DE ANTIOQUIA · MEDELLÍN";
        string botText = "★ CIENCIAS EXACTAS Y NATURALES ★";
        using (Bitmap bmp = new Bitmap(S, S, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            Color c = InkTeal;
            DrawCircularSeal(g, S, c, topText, botText, "UDEA", "GRUPO GFIF · 1803", "FÍSICA FUNDAMENTAL");
            ApplyStampDistress(bmp, c, 101);
            bmp.Save(Path.Combine(outDir, "sello_institucional_udea.png"), ImageFormat.Png);
            bmp.Save(Path.Combine(artifactDir, "sello_institucional_udea.png"), ImageFormat.Png);
        }

        string svg = GenerateCircularSealSVG(S, "#1A4B75", topText, botText, "UDEA", "GRUPO GFIF · 1803", "FÍSICA FUNDAMENTAL");
        File.WriteAllText(Path.Combine(outDir, "sello_institucional_udea.svg"), svg, Encoding.UTF8);
    }

    static void GenerateSelloMinCiencias(string outDir, string artifactDir)
    {
        int W = 850, H = 550;
        using (Bitmap bmp = new Bitmap(W, H, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            Color c = InkNavy;

            using (Pen pThick = new Pen(c, 8f))
            using (Pen pThin = new Pen(c, 2.5f))
            {
                DrawOctagon(g, pThick, 25, 25, W - 50, H - 50, 40);
                DrawOctagon(g, pThin, 40, 40, W - 80, H - 80, 30);
            }

            using (Font fTop = new Font("Segoe UI", 20f, FontStyle.Bold))
            using (Font fHuge = new Font("Trebuchet MS", 80f, FontStyle.Bold))
            using (Font fMid = new Font("Segoe UI", 24f, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 16f, FontStyle.Regular))
            using (Brush b = new SolidBrush(c))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString("REPÚBLICA DE COLOMBIA · MINCIENCIAS", fTop, b, W / 2f, 65, sf);
                g.DrawString("CATEGORÍA A1", fHuge, b, W / 2f, 130, sf);

                using (Pen p = new Pen(c, 3f))
                    g.DrawLine(p, 120, 275, W - 120, 275);

                g.DrawString("GRUPO DE INVESTIGACIÓN RECONOCIDO", fMid, b, W / 2f, 305, sf);
                g.DrawString("MÁXIMA CALIFICACIÓN NACIONAL DE EXCELENCIA", fSub, b, W / 2f, 365, sf);
                g.DrawString("SISTEMA NACIONAL DE CIENCIA Y TECNOLOGÍA", fSub, b, W / 2f, 410, sf);
            }

            ApplyStampDistress(bmp, c, 202);
            bmp.Save(Path.Combine(outDir, "sello_minciencias_a1.png"), ImageFormat.Png);
            bmp.Save(Path.Combine(artifactDir, "sello_minciencias_a1.png"), ImageFormat.Png);
        }

        string svg = string.Format(
@"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 {0} {1}"" width=""{0}"" height=""{1}"">
  <defs>
    <style>
      .navy-text {{ fill: #142341; font-family: 'Segoe UI', Arial, sans-serif; font-weight: bold; text-anchor: middle; }}
      .navy-huge {{ fill: #142341; font-family: 'Trebuchet MS', sans-serif; font-weight: bold; text-anchor: middle; font-size: 84px; }}
      .navy-stroke {{ stroke: #142341; fill: none; }}
    </style>
  </defs>
  <rect x=""30"" y=""30"" width=""{2}"" height=""{3}"" rx=""35"" class=""navy-stroke"" stroke-width=""8""/>
  <rect x=""45"" y=""45"" width=""{4}"" height=""{5}"" rx=""25"" class=""navy-stroke"" stroke-width=""2.5""/>
  <text x=""{6}"" y=""95"" class=""navy-text"" font-size=""22"">REPÚBLICA DE COLOMBIA · MINCIENCIAS</text>
  <text x=""{6}"" y=""225"" class=""navy-huge"">CATEGORÍA A1</text>
  <line x1=""120"" y1=""270"" x2=""{7}"" y2=""270"" class=""navy-stroke"" stroke-width=""3""/>
  <text x=""{6}"" y=""330"" class=""navy-text"" font-size=""26"">GRUPO DE INVESTIGACIÓN RECONOCIDO</text>
  <text x=""{6}"" y=""385"" class=""navy-text"" font-size=""18"" font-weight=""normal"">MÁXIMA CALIFICACIÓN NACIONAL DE EXCELENCIA</text>
</svg>", W, H, W - 60, H - 60, W - 90, H - 90, W / 2, W - 120);

        File.WriteAllText(Path.Combine(outDir, "sello_minciencias_a1.svg"), svg, Encoding.UTF8);
    }

    static void GenerateSelloACCEFYN(string outDir, string artifactDir)
    {
        int S = 800;
        string topText = "ACADEMIA COLOMBIANA DE CIENCIAS";
        string botText = "★ EXACTAS, FÍSICAS Y NATURALES ★";
        using (Bitmap bmp = new Bitmap(S, S, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            Color c = InkWine;
            DrawCircularSeal(g, S, c, topText, botText, "ACCEFYN", "FUNDADA EN 1936", "CIENCIA Y RIGOR");
            ApplyStampDistress(bmp, c, 303);
            bmp.Save(Path.Combine(outDir, "sello_institucional_accefyn.png"), ImageFormat.Png);
            bmp.Save(Path.Combine(artifactDir, "sello_institucional_accefyn.png"), ImageFormat.Png);
        }

        string svg = GenerateCircularSealSVG(S, "#8B1E2D", topText, botText, "ACCEFYN", "FUNDADA EN 1936", "CIENCIA Y RIGOR");
        File.WriteAllText(Path.Combine(outDir, "sello_institucional_accefyn.svg"), svg, Encoding.UTF8);
    }

    static void GenerateSelloUNAL(string outDir, string artifactDir)
    {
        int S = 800;
        string topText = "UNIVERSIDAD NACIONAL DE COLOMBIA";
        string botText = "★ OBSERVATORIO ASTRONÓMICO NACIONAL ★";
        using (Bitmap bmp = new Bitmap(S, S, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            Color c = Charcoal;
            DrawCircularSeal(g, S, c, topText, botText, "UNAL", "OAN · 1803", "COSMOLOGÍA Y GRAVITACIÓN");
            ApplyStampDistress(bmp, c, 404);
            bmp.Save(Path.Combine(outDir, "sello_institucional_unal.png"), ImageFormat.Png);
            bmp.Save(Path.Combine(artifactDir, "sello_institucional_unal.png"), ImageFormat.Png);
        }

        string svg = GenerateCircularSealSVG(S, "#1D1E2C", topText, botText, "UNAL", "OAN · 1803", "COSMOLOGÍA Y GRAVITACIÓN");
        File.WriteAllText(Path.Combine(outDir, "sello_institucional_unal.svg"), svg, Encoding.UTF8);
    }

    static void GenerateSelloMainz(string outDir, string artifactDir)
    {
        int S = 800;
        string topText = "JOHANNES GUTENBERG-UNIVERSITÄT";
        string botText = "★ FACHBEREICH PHYSIK · MAINZ ★";
        using (Bitmap bmp = new Bitmap(S, S, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            Color c = InkTeal;
            DrawCircularSeal(g, S, c, topText, botText, "JGU", "MAINZ · 1477", "INSTITUT FÜR PHYSIK");
            ApplyStampDistress(bmp, c, 505);
            bmp.Save(Path.Combine(outDir, "sello_universidad_mainz.png"), ImageFormat.Png);
            bmp.Save(Path.Combine(artifactDir, "sello_universidad_mainz.png"), ImageFormat.Png);
        }

        string svg = GenerateCircularSealSVG(S, "#1A4B75", topText, botText, "JGU", "MAINZ · 1477", "INSTITUT FÜR PHYSIK");
        File.WriteAllText(Path.Combine(outDir, "sello_universidad_mainz.svg"), svg, Encoding.UTF8);
    }

    // ==========================================
    // 3. SELLOS DE PASAPORTE VINTAGE [Beat 49]
    // ==========================================

    static void GenerateSelloJeffersonLab(string outDir, string artifactDir)
    {
        int W = 750, H = 450;
        using (Bitmap bmp = new Bitmap(W, H, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            Color c = InkTeal;

            using (Pen pOuter = new Pen(c, 7f))
            using (Pen pInner = new Pen(c, 2.5f))
            {
                Rectangle rO = new Rectangle(20, 20, W - 40, H - 40);
                DrawRoundedRect(g, pOuter, rO, 24);
                Rectangle rI = new Rectangle(32, 32, W - 64, H - 64);
                DrawRoundedRect(g, pInner, rI, 16);
            }

            using (Font fTop = new Font("Segoe UI", 18f, FontStyle.Bold))
            using (Font fMain = new Font("Trebuchet MS", 38f, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 20f, FontStyle.Bold))
            using (Font fDate = new Font("Consolas", 26f, FontStyle.Bold))
            using (Brush b = new SolidBrush(c))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString("★ U.S. DEPT OF ENERGY · SCIENTIFIC ENTRY ★", fTop, b, W / 2f, 55, sf);
                g.DrawString("JEFFERSON LAB", fMain, b, W / 2f, 105, sf);
                g.DrawString("CEBAF · NEWPORT NEWS, VA", fSub, b, W / 2f, 175, sf);

                using (Pen p = new Pen(c, 2.5f))
                {
                    g.DrawLine(p, 80, 235, W - 80, 235);
                    g.DrawLine(p, 80, 335, W - 80, 335);
                }

                g.DrawString("ENTRY: 14 OCT 1994", fDate, b, W / 2f, 260, sf);
                g.DrawString("NUCLEAR PHYSICS RESEARCH CLEARANCE", fTop, b, W / 2f, 355, sf);
            }

            ApplyStampDistress(bmp, c, 606);
            bmp.Save(Path.Combine(outDir, "sello_pasaporte_jefferson_lab.png"), ImageFormat.Png);
            bmp.Save(Path.Combine(artifactDir, "sello_pasaporte_jefferson_lab.png"), ImageFormat.Png);
        }

        string svg = string.Format(
@"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 {0} {1}"" width=""{0}"" height=""{1}"">
  <rect x=""20"" y=""20"" width=""{2}"" height=""{3}"" rx=""24"" stroke=""#1A4B75"" stroke-width=""7"" fill=""none""/>
  <rect x=""32"" y=""32"" width=""{4}"" height=""{5}"" rx=""16"" stroke=""#1A4B75"" stroke-width=""2.5"" fill=""none""/>
  <text x=""{6}"" y=""75"" text-anchor=""middle"" fill=""#1A4B75"" font-family=""'Segoe UI', Arial"" font-weight=""bold"" font-size=""20"">★ U.S. DEPT OF ENERGY · SCIENTIFIC ENTRY ★</text>
  <text x=""{6}"" y=""150"" text-anchor=""middle"" fill=""#1A4B75"" font-family=""'Trebuchet MS'"" font-weight=""bold"" font-size=""44"">JEFFERSON LAB</text>
  <text x=""{6}"" y=""205"" text-anchor=""middle"" fill=""#1A4B75"" font-family=""'Segoe UI', Arial"" font-weight=""bold"" font-size=""22"">CEBAF · NEWPORT NEWS, VA</text>
  <line x1=""80"" y1=""235"" x2=""{7}"" y2=""235"" stroke=""#1A4B75"" stroke-width=""2.5""/>
  <text x=""{6}"" y=""295"" text-anchor=""middle"" fill=""#1A4B75"" font-family=""Consolas, monospace"" font-weight=""bold"" font-size=""30"">ENTRY: 14 OCT 1994</text>
  <line x1=""80"" y1=""335"" x2=""{7}"" y2=""335"" stroke=""#1A4B75"" stroke-width=""2.5""/>
  <text x=""{6}"" y=""385"" text-anchor=""middle"" fill=""#1A4B75"" font-family=""'Segoe UI', Arial"" font-weight=""bold"" font-size=""18"">NUCLEAR PHYSICS RESEARCH CLEARANCE</text>
</svg>", W, H, W - 40, H - 40, W - 64, H - 64, W / 2, W - 80);

        File.WriteAllText(Path.Combine(outDir, "sello_pasaporte_jefferson_lab.svg"), svg, Encoding.UTF8);
    }

    static void GenerateSelloFermilab(string outDir, string artifactDir)
    {
        int W = 750, H = 480;
        using (Bitmap bmp = new Bitmap(W, H, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            Color c = InkNavy;

            using (Pen pOuter = new Pen(c, 7f))
            using (Pen pInner = new Pen(c, 2.5f))
            {
                g.DrawEllipse(pOuter, 25, 25, W - 50, H - 50);
                g.DrawEllipse(pInner, 40, 40, W - 80, H - 80);
            }

            using (Font fTop = new Font("Segoe UI", 18f, FontStyle.Bold))
            using (Font fMain = new Font("Trebuchet MS", 46f, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 20f, FontStyle.Bold))
            using (Font fDate = new Font("Consolas", 28f, FontStyle.Bold))
            using (Brush b = new SolidBrush(c))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString("FERMI NATIONAL ACCELERATOR LABORATORY", fTop, b, W / 2f, 75, sf);
                g.DrawString("FERMILAB", fMain, b, W / 2f, 135, sf);
                g.DrawString("BATAVIA, ILLINOIS · TEVATRON", fSub, b, W / 2f, 215, sf);

                using (Pen p = new Pen(c, 2.5f))
                {
                    g.DrawLine(p, 120, 260, W - 120, 260);
                    g.DrawLine(p, 120, 350, W - 120, 350);
                }

                g.DrawString("ADMITTED: 22 MAY 1997", fDate, b, W / 2f, 285, sf);
                g.DrawString("HIGH ENERGY COLLIDER EXPERIMENT", fTop, b, W / 2f, 380, sf);
            }

            ApplyStampDistress(bmp, c, 707);
            bmp.Save(Path.Combine(outDir, "sello_pasaporte_fermilab.png"), ImageFormat.Png);
            bmp.Save(Path.Combine(artifactDir, "sello_pasaporte_fermilab.png"), ImageFormat.Png);
        }

        string svg = string.Format(
@"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 {0} {1}"" width=""{0}"" height=""{1}"">
  <ellipse cx=""{2}"" cy=""{3}"" rx=""{4}"" ry=""{5}"" stroke=""#142341"" stroke-width=""7"" fill=""none""/>
  <ellipse cx=""{2}"" cy=""{3}"" rx=""{6}"" ry=""{7}"" stroke=""#142341"" stroke-width=""2.5"" fill=""none""/>
  <text x=""{2}"" y=""95"" text-anchor=""middle"" fill=""#142341"" font-family=""'Segoe UI', Arial"" font-weight=""bold"" font-size=""19"">FERMI NATIONAL ACCELERATOR LABORATORY</text>
  <text x=""{2}"" y=""185"" text-anchor=""middle"" fill=""#142341"" font-family=""'Trebuchet MS'"" font-weight=""bold"" font-size=""52"">FERMILAB</text>
  <text x=""{2}"" y=""240"" text-anchor=""middle"" fill=""#142341"" font-family=""'Segoe UI', Arial"" font-weight=""bold"" font-size=""22"">BATAVIA, ILLINOIS · TEVATRON</text>
  <line x1=""120"" y1=""265"" x2=""{8}"" y2=""265"" stroke=""#142341"" stroke-width=""2.5""/>
  <text x=""{2}"" y=""320"" text-anchor=""middle"" fill=""#142341"" font-family=""Consolas, monospace"" font-weight=""bold"" font-size=""30"">ADMITTED: 22 MAY 1997</text>
  <line x1=""120"" y1=""355"" x2=""{8}"" y2=""355"" stroke=""#142341"" stroke-width=""2.5""/>
  <text x=""{2}"" y=""405"" text-anchor=""middle"" fill=""#142341"" font-family=""'Segoe UI', Arial"" font-weight=""bold"" font-size=""18"">HIGH ENERGY COLLIDER EXPERIMENT</text>
</svg>", W, H, W / 2, H / 2, W / 2 - 25, H / 2 - 25, W / 2 - 40, H / 2 - 40, W - 120);

        File.WriteAllText(Path.Combine(outDir, "sello_pasaporte_fermilab.svg"), svg, Encoding.UTF8);
    }

    static void GenerateSelloCERN(string outDir, string artifactDir)
    {
        int W = 750, H = 460;
        using (Bitmap bmp = new Bitmap(W, H, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            Color c = InkWine;

            using (Pen pOuter = new Pen(c, 7f))
            using (Pen pInner = new Pen(c, 2.5f))
            {
                Rectangle rO = new Rectangle(25, 25, W - 50, H - 50);
                DrawRoundedRect(g, pOuter, rO, 32);
                Rectangle rI = new Rectangle(40, 40, W - 80, H - 80);
                DrawRoundedRect(g, pInner, rI, 22);
            }

            using (Font fTop = new Font("Segoe UI", 18f, FontStyle.Bold))
            using (Font fMain = new Font("Trebuchet MS", 52f, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 19f, FontStyle.Bold))
            using (Font fDate = new Font("Consolas", 28f, FontStyle.Bold))
            using (Brush b = new SolidBrush(c))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString("★ DOUANE SUISSE - FRANCE · CONTRÔLE SCIENTIFIQUE ★", fTop, b, W / 2f, 65, sf);
                g.DrawString("CERN · GENÈVE", fMain, b, W / 2f, 120, sf);
                g.DrawString("ORGANISATION EUROPÉENNE POUR LA RECHERCHE NUCLÉAIRE", fSub, b, W / 2f, 205, sf);

                using (Pen p = new Pen(c, 2.5f))
                {
                    g.DrawLine(p, 90, 250, W - 90, 250);
                    g.DrawLine(p, 90, 345, W - 90, 345);
                }

                g.DrawString("ENTRÉE: 08 SEP 2002", fDate, b, W / 2f, 275, sf);
                g.DrawString("ACCÈS MEYRIN & POINT 5 CMS COLLABORATION", fTop, b, W / 2f, 375, sf);
            }

            ApplyStampDistress(bmp, c, 808);
            bmp.Save(Path.Combine(outDir, "sello_pasaporte_cern.png"), ImageFormat.Png);
            bmp.Save(Path.Combine(artifactDir, "sello_pasaporte_cern.png"), ImageFormat.Png);
        }

        string svg = string.Format(
@"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 {0} {1}"" width=""{0}"" height=""{1}"">
  <rect x=""25"" y=""25"" width=""{2}"" height=""{3}"" rx=""32"" stroke=""#8B1E2D"" stroke-width=""7"" fill=""none""/>
  <rect x=""40"" y=""40"" width=""{4}"" height=""{5}"" rx=""22"" stroke=""#8B1E2D"" stroke-width=""2.5"" fill=""none""/>
  <text x=""{6}"" y=""85"" text-anchor=""middle"" fill=""#8B1E2D"" font-family=""'Segoe UI', Arial"" font-weight=""bold"" font-size=""18"">★ DOUANE SUISSE - FRANCE · CONTRÔLE SCIENTIFIQUE ★</text>
  <text x=""{6}"" y=""175"" text-anchor=""middle"" fill=""#8B1E2D"" font-family=""'Trebuchet MS'"" font-weight=""bold"" font-size=""56"">CERN · GENÈVE</text>
  <text x=""{6}"" y=""230"" text-anchor=""middle"" fill=""#8B1E2D"" font-family=""'Segoe UI', Arial"" font-weight=""bold"" font-size=""19"">ORGANISATION EUROPÉENNE POUR LA RECHERCHE NUCLÉAIRE</text>
  <line x1=""90"" y1=""255"" x2=""{7}"" y2=""255"" stroke=""#8B1E2D"" stroke-width=""2.5""/>
  <text x=""{6}"" y=""315"" text-anchor=""middle"" fill=""#8B1E2D"" font-family=""Consolas, monospace"" font-weight=""bold"" font-size=""30"">ENTRÉE: 08 SEP 2002</text>
  <line x1=""90"" y1=""350"" x2=""{7}"" y2=""350"" stroke=""#8B1E2D"" stroke-width=""2.5""/>
  <text x=""{6}"" y=""400"" text-anchor=""middle"" fill=""#8B1E2D"" font-family=""'Segoe UI', Arial"" font-weight=""bold"" font-size=""18"">ACCÈS MEYRIN &amp; POINT 5 CMS COLLABORATION</text>
</svg>", W, H, W - 50, H - 50, W - 80, H - 80, W / 2, W - 90);

        File.WriteAllText(Path.Combine(outDir, "sello_pasaporte_cern.svg"), svg, Encoding.UTF8);
    }

    // Composición de Página de Pasaporte Completa [Beat 49] (1920x1080)
    static void GeneratePasaporteSanabria(string outDir, string artifactDir)
    {
        int W = 1920, H = 1080;
        using (Bitmap bmp = new Bitmap(W, H))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            g.Clear(PaperCream);

            // Fondo de cuadrícula de seguridad y marcas de agua de pasaporte
            DrawSecurityGuilloche(g, W, H);

            // Libreta de pasaporte abierta (dos páginas centrales)
            int bookW = 1680, bookH = 920;
            int bx = (W - bookW) / 2;
            int by = (H - bookH) / 2;

            // Sombra del libro
            using (SolidBrush bShadow = new SolidBrush(Color.FromArgb(40, 20, 20, 30)))
            {
                g.FillRectangle(bShadow, bx + 16, by + 16, bookW, bookH);
            }

            // Páginas de papel de seguridad
            Color pageColor = Color.FromArgb(250, 246, 238);
            using (SolidBrush bPage = new SolidBrush(pageColor))
            using (Pen pPageBorder = new Pen(Color.FromArgb(200, 185, 170), 2f))
            {
                g.FillRectangle(bPage, bx, by, bookW, bookH);
                g.DrawRectangle(pPageBorder, bx, by, bookW, bookH);

                // Pliegue central del pasaporte
                using (LinearGradientBrush bSpine = new LinearGradientBrush(
                    new Rectangle(W / 2 - 35, by, 70, bookH),
                    Color.FromArgb(50, 0, 0, 0), Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Horizontal))
                {
                    g.FillRectangle(bSpine, W / 2 - 35, by, 35, bookH);
                }
                using (LinearGradientBrush bSpine2 = new LinearGradientBrush(
                    new Rectangle(W / 2, by, 35, bookH),
                    Color.FromArgb(0, 0, 0, 0), Color.FromArgb(50, 0, 0, 0), LinearGradientMode.Horizontal))
                {
                    g.FillRectangle(bSpine2, W / 2, by, 35, bookH);
                }
                using (Pen pStitch = new Pen(Color.FromArgb(140, 120, 100), 2f) { DashStyle = DashStyle.Dash })
                    g.DrawLine(pStitch, W / 2, by + 20, W / 2, by + bookH - 20);
            }

            // Encabezados de página de pasaporte
            using (Font fHead = new Font("Consolas", 14f, FontStyle.Bold))
            using (Font fTitle = new Font("Georgia", 22f, FontStyle.Bold))
            using (Brush bInk = new SolidBrush(Color.FromArgb(120, 50, 60, 80)))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString("REPÚBLICA DE COLOMBIA · VISAS & ENTRADAS DE INVESTIGACIÓN", fHead, bInk, bx + bookW / 4f, by + 35, sf);
                g.DrawString("INTERNATIONAL SCIENTIFIC ENDORSEMENTS", fHead, bInk, bx + 3 * bookW / 4f, by + 35, sf);

                g.DrawString("PASAPORTE CIENTÍFICO", fTitle, bInk, bx + bookW / 4f, by + 65, sf);
                g.DrawString("PARTICLE PHYSICS DIVISION", fTitle, bInk, bx + 3 * bookW / 4f, by + 65, sf);
            }

            // Estampado de los 3 sellos con rotaciones y tintas realistas
            string pathJLab = Path.Combine(outDir, "sello_pasaporte_jefferson_lab.png");
            string pathFermi = Path.Combine(outDir, "sello_pasaporte_fermilab.png");
            string pathCERN = Path.Combine(outDir, "sello_pasaporte_cern.png");

            if (File.Exists(pathJLab))
            {
                using (Image imgJLab = Image.FromFile(pathJLab))
                {
                    DrawStampTransformed(g, imgJLab, bx + 160, by + 220, 480, 288, -4.5f);
                }
            }

            if (File.Exists(pathFermi))
            {
                using (Image imgFermi = Image.FromFile(pathFermi))
                {
                    DrawStampTransformed(g, imgFermi, bx + 190, by + 540, 470, 300, 3.2f);
                }
            }

            if (File.Exists(pathCERN))
            {
                using (Image imgCERN = Image.FromFile(pathCERN))
                {
                    DrawStampTransformed(g, imgCERN, bx + bookW / 2 + 140, by + 320, 560, 345, -2.8f);
                }
            }

            // Washi tape decorativo en esquina
            DrawWashi(g, bx + 40, by - 15, 140, 36, -8f, Color.FromArgb(200, AmberSolar));

            string outJpg = Path.Combine(outDir, "pasaporte_cientifico_sanabria.jpg");
            SaveJpeg(bmp, outJpg);
            SaveJpeg(bmp, Path.Combine(artifactDir, "pasaporte_cientifico_sanabria.jpg"));
        }
    }

    // ==========================================
    // 4. ETIQUETA PARA UTILERÍA A CÁMARA [Beat 75]
    // ==========================================
    static void GenerateEtiquetaMateriaOscura(string outDir, string artifactDir)
    {
        int W = 1200, H = 800;
        using (Bitmap bmp = new Bitmap(W, H, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);

            // Fondo papel de laboratorio vintage
            Color labPaper = Color.FromArgb(252, 249, 242);
            using (SolidBrush bBg = new SolidBrush(labPaper))
                g.FillRectangle(bBg, 0, 0, W, H);

            // Borde ornamental de reactivo de alta pureza
            using (Pen pThick = new Pen(Charcoal, 6f))
            using (Pen pThin = new Pen(Charcoal, 2f))
            {
                g.DrawRectangle(pThick, 20, 20, W - 40, H - 40);
                g.DrawRectangle(pThin, 32, 32, W - 64, H - 64);
                // Esquinas ornamentales
                DrawCornerFlourish(g, 20, 20, 40, Charcoal);
                DrawCornerFlourish(g, W - 20, 20, 40, Charcoal);
                DrawCornerFlourish(g, 20, H - 20, 40, Charcoal);
                DrawCornerFlourish(g, W - 20, H - 20, 40, Charcoal);
            }

            using (Font fInst = new Font("Segoe UI", 16f, FontStyle.Bold))
            using (Font fLote = new Font("Consolas", 14f, FontStyle.Regular))
            using (Font fTitle = new Font("Trebuchet MS", 52f, FontStyle.Bold))
            using (Font fFormula = new Font("Georgia", 20f, FontStyle.Italic))
            using (Font fSpecsHead = new Font("Segoe UI", 15f, FontStyle.Bold))
            using (Font fSpecs = new Font("Segoe UI", 15f, FontStyle.Regular))
            using (Font fWarn = new Font("Segoe UI", 14f, FontStyle.Bold))
            using (Brush bDark = new SolidBrush(Charcoal))
            using (Brush bAmber = new SolidBrush(AmberSolar))
            {
                StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center };

                g.DrawString("LABORATORIO DE COSMOLOGÍA OBSERVACIONAL Y ALTAS ENERGÍAS", fInst, bDark, W / 2f, 48, sfCenter);
                g.DrawString("REACTIVO CIENTÍFICO CERTIFICADO · GRADO NO BARIÓNICO", new Font("Segoe UI", 13f, FontStyle.Bold), new SolidBrush(Color.FromArgb(120, 120, 130)), W / 2f, 78, sfCenter);

                using (Pen p = new Pen(Charcoal, 2f))
                    g.DrawLine(p, 60, 110, W - 60, 110);

                // TÍTULO CENTRAL DESTACADO
                g.DrawString("100 g DE MATERIA OSCURA", fTitle, bDark, W / 2f, 135, sfCenter);
                g.DrawString("Candidato Teórico: WIMP / Axión / Neutrino Estéril (M_χ ≈ 100 GeV)", fFormula, new SolidBrush(Color.FromArgb(0, 119, 182)), W / 2f, 218, sfCenter);

                using (Pen p = new Pen(AmberSolar, 3.5f))
                    g.DrawLine(p, 100, 265, W - 100, 265);

                // CUADRO DE ESPECIFICACIONES FÍSICAS
                int boxX = 65, boxY = 285, boxW = W - 130, boxH = 265;
                using (SolidBrush bBox = new SolidBrush(Color.FromArgb(242, 238, 228)))
                using (Pen pBox = new Pen(Color.FromArgb(200, 190, 175), 1.5f))
                {
                    g.FillRectangle(bBox, boxX, boxY, boxW, boxH);
                    g.DrawRectangle(pBox, boxX, boxY, boxW, boxH);
                }

                int lineY = boxY + 20;
                int leftCol = boxX + 30;
                int valCol = leftCol + 225;
                g.DrawString("• ESTADO FÍSICO:", fSpecsHead, bDark, leftCol, lineY);
                g.DrawString("Materia Oscura Fría (Cold Dark Matter - CDM)", fSpecs, bDark, valCol, lineY);

                lineY += 42;
                g.DrawString("• INTERACCIÓN:", fSpecsHead, bDark, leftCol, lineY);
                g.DrawString("Exclusivamente Gravitacional (Sección eficaz electromagnética = 0)", fSpecs, bDark, valCol, lineY);

                lineY += 42;
                g.DrawString("• DENSIDAD CÓSMICA:", fSpecsHead, bDark, leftCol, lineY);
                g.DrawString("~26.8% de la masa-energía del Universo observable", fSpecs, bDark, valCol, lineY);

                lineY += 42;
                g.DrawString("• COMPROBACIÓN:", fSpecsHead, bDark, leftCol, lineY);
                g.DrawString("Lentes gravitacionales débiles (Andrés Plazas) / Modelos escotogénicos (Diego Restrepo)", fSpecs, bDark, valCol, lineY);

                lineY += 42;
                g.DrawString("• LOTE REF:", fSpecsHead, bDark, leftCol, lineY);
                g.DrawString("COSMOS-13.8B-ACCEFYN / OAN-COLOMBIA", fLote, bAmber, valCol, lineY);

                // RECUADRO DE ADVERTENCIA / HUMOR CIENTÍFICO RIGUROSO
                int warnY = 575;
                using (SolidBrush bWarnBg = new SolidBrush(Color.FromArgb(30, AmberSolar)))
                using (Pen pWarn = new Pen(AmberSolar, 2.5f))
                {
                    g.FillRectangle(bWarnBg, boxX, warnY, boxW, 115);
                    g.DrawRectangle(pWarn, boxX, warnY, boxW, 115);
                }

                g.DrawString("▲  ADVERTENCIA DE SEGURIDAD Y MANIPULACIÓN A CÁMARA  ▲", fWarn, bAmber, W / 2f, warnY + 14, sfCenter);
                g.DrawString("CONTENIDO COMPLETAMENTE INVISIBLE AL OJO HUMANO Y A CÁMARAS DIGITALES.", fWarn, bDark, W / 2f, warnY + 45, sfCenter);
                g.DrawString("Los fotones de iluminación de estudio atravesarán este frasco sin ser dispersados, reflejados ni absorbidos.", fSpecs, bDark, W / 2f, warnY + 75, sfCenter);

                // Sello de pie
                g.DrawString("MUESTRA AUTÉNTICA PARA DEMOSTRACIÓN EDUCATIVA · EL 95% INVISIBLE", new Font("Segoe UI", 12f, FontStyle.Bold), new SolidBrush(Color.FromArgb(140, 140, 150)), W / 2f, 725, sfCenter);
            }

            string pngPath = Path.Combine(outDir, "etiqueta_frasco_materia_oscura.png");
            bmp.Save(pngPath, ImageFormat.Png);
            bmp.Save(Path.Combine(artifactDir, "etiqueta_frasco_materia_oscura.png"), ImageFormat.Png);
        }

        // SVG de la etiqueta
        string svg = string.Format(
@"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 {0} {1}"" width=""{0}"" height=""{1}"">
  <defs>
    <style>
      .label-bg {{ fill: #FCF9F2; }}
      .border-thick {{ stroke: #1D1E2C; stroke-width: 6; fill: none; }}
      .border-thin {{ stroke: #1D1E2C; stroke-width: 2; fill: none; }}
      .head-text {{ fill: #1D1E2C; font-family: 'Segoe UI', Arial, sans-serif; font-weight: bold; font-size: 20px; text-anchor: middle; }}
      .sub-head {{ fill: #787882; font-family: 'Segoe UI', Arial; font-weight: bold; font-size: 15px; text-anchor: middle; }}
      .title-text {{ fill: #1D1E2C; font-family: 'Trebuchet MS', Arial, sans-serif; font-weight: bold; font-size: 58px; text-anchor: middle; }}
      .formula-text {{ fill: #0077B6; font-family: Georgia, serif; font-style: italic; font-size: 26px; text-anchor: middle; }}
      .spec-head {{ fill: #1D1E2C; font-family: 'Segoe UI', Arial; font-weight: bold; font-size: 17px; }}
      .spec-val {{ fill: #1D1E2C; font-family: 'Segoe UI', Arial; font-size: 17px; }}
      .warn-title {{ fill: #F77F00; font-family: 'Segoe UI', Arial; font-weight: bold; font-size: 17px; text-anchor: middle; }}
      .warn-body {{ fill: #1D1E2C; font-family: 'Segoe UI', Arial; font-size: 15px; text-anchor: middle; }}
    </style>
  </defs>
  <rect width=""{0}"" height=""{1}"" class=""label-bg""/>
  <rect x=""20"" y=""20"" width=""{2}"" height=""{3}"" class=""border-thick""/>
  <rect x=""32"" y=""32"" width=""{4}"" height=""{5}"" class=""border-thin""/>
  <text x=""{6}"" y=""65"" class=""head-text"">LABORATORIO DE COSMOLOGÍA OBSERVACIONAL Y ALTAS ENERGÍAS</text>
  <text x=""{6}"" y=""95"" class=""sub-head"">REACTIVO CIENTÍFICO CERTIFICADO · GRADO NO BARIÓNICO</text>
  <line x1=""60"" y1=""115"" x2=""{7}"" y2=""115"" stroke=""#1D1E2C"" stroke-width=""2""/>
  <text x=""{6}"" y=""185"" class=""title-text"">100 g DE MATERIA OSCURA</text>
  <text x=""{6}"" y=""235"" class=""formula-text"">Fórmula Candidata: WIMP / Axión / Neutrino Estéril (M_χ ≈ 100 GeV)</text>
  <line x1=""100"" y1=""265"" x2=""{8}"" y2=""265"" stroke=""#F77F00"" stroke-width=""3.5""/>
  <rect x=""65"" y=""285"" width=""{9}"" height=""265"" fill=""#F2EEE4"" stroke=""#C8BEAF"" stroke-width=""1.5""/>
  <text x=""95"" y=""325"" class=""spec-head"">• ESTADO FÍSICO:</text>
  <text x=""285"" y=""325"" class=""spec-val"">Materia Oscura Fría (Cold Dark Matter - CDM)</text>
  <text x=""95"" y=""365"" class=""spec-head"">• INTERACCIÓN:</text>
  <text x=""285"" y=""365"" class=""spec-val"">Exclusivamente Gravitacional (Sección eficaz electromagnética = 0)</text>
  <text x=""95"" y=""405"" class=""spec-head"">• DENSIDAD CÓSMICA:</text>
  <text x=""285"" y=""405"" class=""spec-val"">~26.8% de la masa-energía del Universo observable</text>
  <text x=""95"" y=""445"" class=""spec-head"">• COMPROBACIÓN:</text>
  <text x=""285"" y=""445"" class=""spec-val"">Lentes gravitacionales débiles (Andrés Plazas) / Modelos escotogénicos (Diego Restrepo)</text>
  <text x=""95"" y=""485"" class=""spec-head"">• LOTE REF:</text>
  <text x=""285"" y=""485"" fill=""#F77F00"" font-family=""Consolas"" font-size=""16"">COSMOS-13.8B-ACCEFYN / OAN-COLOMBIA</text>
  <rect x=""65"" y=""575"" width=""{9}"" height=""115"" fill=""#FFF4E6"" stroke=""#F77F00"" stroke-width=""2.5""/>
  <text x=""{6}"" y=""605"" class=""warn-title"">▲  ADVERTENCIA DE SEGURIDAD Y MANIPULACIÓN A CÁMARA  ▲</text>
  <text x=""{6}"" y=""635"" class=""warn-body"" font-weight=""bold"">CONTENIDO COMPLETAMENTE INVISIBLE AL OJO HUMANO Y A CÁMARAS DIGITALES.</text>
  <text x=""{6}"" y=""665"" class=""warn-body"">Los fotones de iluminación de estudio atravesarán este frasco sin ser dispersados, reflejados ni absorbidos.</text>
</svg>", W, H, W - 40, H - 40, W - 64, H - 64, W / 2, W - 60, W - 100, W - 130);

        File.WriteAllText(Path.Combine(outDir, "etiqueta_frasco_materia_oscura.svg"), svg, Encoding.UTF8);

        // 2. Mockup editorial a cámara (1920x1080)
        GenerateMockupFrasco(outDir, artifactDir);
    }

    static void GenerateMockupFrasco(string outDir, string artifactDir)
    {
        int W = 1920, H = 1080;
        using (Bitmap bmp = new Bitmap(W, H))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);

            // Fondo estudio con cuadrícula suave
            g.Clear(PaperCream);
            DrawBlueprintGrid(g, W, H);

            // Tarjeta central de utilería (prop card)
            int cardW = 1400, cardH = 880;
            int cx = (W - cardW) / 2;
            int cy = (H - cardH) / 2;

            // Sombra
            using (SolidBrush bShadow = new SolidBrush(Color.FromArgb(35, 20, 20, 30)))
                g.FillRectangle(bShadow, cx + 18, cy + 18, cardW, cardH);

            // Fondo tarjeta
            using (SolidBrush bCard = new SolidBrush(Color.FromArgb(252, 249, 242)))
            using (Pen pCard = new Pen(Color.FromArgb(210, 200, 185), 2f))
            {
                g.FillRectangle(bCard, cx, cy, cardW, cardH);
                g.DrawRectangle(pCard, cx, cy, cardW, cardH);
            }

            // Título de la utilería en estilo editorial
            using (Font fHeader = new Font("Trebuchet MS", 28f, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 16f, FontStyle.Regular))
            using (Brush bDark = new SolidBrush(Charcoal))
            using (Brush bAmber = new SolidBrush(AmberSolar))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString("UTILERÍA A CÁMARA · FRASCO DE DEMOSTRACIÓN", fHeader, bDark, W / 2f, cy + 45, sf);
                g.DrawString("El presentador sostiene ante la cámara un frasco completamente transparente y aparentemente vacío", fSub, new SolidBrush(Color.FromArgb(100, 110, 125)), W / 2f, cy + 95, sf);
            }

            // Ilustración del Frasco de Vidrio y Etiqueta
            int jarX = cx + 180, jarY = cy + 160, jarW = 340, jarH = 620;

            // Sombra del frasco
            using (SolidBrush bJarShadow = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
                g.FillEllipse(bJarShadow, jarX + 20, jarY + jarH - 30, jarW - 40, 50);

            // Tapa de corcho/madera
            int corkW = 160, corkH = 70;
            int corkX = jarX + (jarW - corkW) / 2;
            int corkY = jarY;
            using (SolidBrush bCork = new SolidBrush(Color.FromArgb(205, 155, 105)))
            using (Pen pCork = new Pen(Color.FromArgb(160, 110, 70), 3f))
            {
                g.FillRectangle(bCork, corkX, corkY, corkW, corkH);
                g.DrawRectangle(pCork, corkX, corkY, corkW, corkH);
            }

            // Cuello del frasco
            int neckW = 190, neckH = 50;
            int neckX = jarX + (jarW - neckW) / 2;
            int neckY = corkY + corkH;
            using (SolidBrush bGlass = new SolidBrush(Color.FromArgb(80, 215, 235, 245)))
            using (Pen pGlass = new Pen(Color.FromArgb(160, 0, 180, 216), 3f))
            {
                g.FillRectangle(bGlass, neckX, neckY, neckW, neckH);
                g.DrawRectangle(pGlass, neckX, neckY, neckW, neckH);

                // Cuerpo del frasco
                int bodyY = neckY + neckH;
                int bodyH = jarH - (neckH + corkH);
                Rectangle rBody = new Rectangle(jarX, bodyY, jarW, bodyH);
                DrawRoundedRect(g, pGlass, rBody, 40);
                using (SolidBrush bBody = new SolidBrush(Color.FromArgb(50, 180, 225, 240)))
                    FillRoundedRect(g, bBody, rBody, 40);

                // Reflejos especulares de vidrio
                using (Pen pReflect = new Pen(Color.FromArgb(140, 255, 255, 255), 6f))
                {
                    g.DrawLine(pReflect, jarX + 25, bodyY + 40, jarX + 25, bodyY + bodyH - 60);
                    g.DrawLine(pReflect, jarX + 45, bodyY + 60, jarX + 45, bodyY + bodyH - 90);
                }

                // Etiqueta pegada al frasco (renderizada desde la etiqueta original)
                int lblW = jarW - 50;
                int lblH = (int)(lblW * 800.0 / 1200.0);
                int lblX = jarX + 25, lblY = bodyY + 110;
                string lblPath = Path.Combine(outDir, "etiqueta_frasco_materia_oscura.png");
                if (File.Exists(lblPath))
                {
                    using (Image imgLbl = Image.FromFile(lblPath))
                    {
                        // Sombra sutil de la etiqueta
                        using (SolidBrush bLblSh = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                            g.FillRectangle(bLblSh, lblX + 4, lblY + 4, lblW, lblH);
                        g.DrawImage(imgLbl, lblX, lblY, lblW, lblH);
                    }
                }
            }

            // Panel explicativo derecho (para el equipo de producción y espectadores)
            int panX = cx + 600, panY = cy + 180, panW = cardW - 660, panH = 580;
            using (SolidBrush bPan = new SolidBrush(Color.FromArgb(244, 240, 230)))
            using (Pen pPan = new Pen(Color.FromArgb(215, 205, 190), 1.5f))
            {
                g.FillRectangle(bPan, panX, panY, panW, panH);
                g.DrawRectangle(pPan, panX, panY, panW, panH);
            }

            using (Font fPanHead = new Font("Trebuchet MS", 22f, FontStyle.Bold))
            using (Font fPanBody = new Font("Segoe UI", 16f, FontStyle.Regular))
            using (Font fPanLead = new Font("Segoe UI", 16f, FontStyle.Bold))
            using (Brush bD = new SolidBrush(Charcoal))
            using (Brush bCyan = new SolidBrush(Color.FromArgb(0, 119, 182)))
            {
                int py = panY + 35;
                int px = panX + 40;

                g.DrawString("LA ANALOGÍA VISUAL DEL FRASCO", fPanHead, bCyan, px, py);
                py += 55;

                string text1 = "Al inicio del bloque de cosmología, el presentador toma este frasco etiquetado y lo muestra en primer plano: «Tengo aquí exactamente 100 gramos de materia oscura».";
                g.DrawString(text1, fPanBody, bD, new RectangleF(px, py, panW - 80, 95));
                py += 105;

                string text2 = "A primera vista parece un frasco vacío, pero esa es precisamente la lección física: la materia oscura no interactúa con el electromagnetismo. La luz del estudio atraviesa el frasco sin ser frenada ni absorbida.";
                g.DrawString(text2, fPanBody, bD, new RectangleF(px, py, panW - 80, 120));
                py += 135;

                string text3 = "La única forma de saber que está allí es por su peso gravitacional sobre las galaxias y la curvatura que produce sobre los rayos de luz que vienen detrás (efecto de lente gravitacional débil).";
                g.DrawString(text3, fPanBody, bD, new RectangleF(px, py, panW - 80, 120));
            }

            // Washi tape
            DrawWashi(g, cx + 60, cy - 15, 150, 36, -6f, Color.FromArgb(210, AmberSolar));
            DrawWashi(g, cx + cardW - 200, cy - 15, 150, 36, 5f, Color.FromArgb(190, CyanElectric));

            string outJpg = Path.Combine(outDir, "prop_frasco_materia_oscura.jpg");
            SaveJpeg(bmp, outJpg);
            SaveJpeg(bmp, Path.Combine(artifactDir, "prop_frasco_materia_oscura.jpg"));
        }
    }

    // ==========================================
    // UTILITY METHODS
    // ==========================================

    static void SetupGraphics(Graphics g)
    {
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    }

    static void DrawCircularSeal(Graphics g, int S, Color c, string outerTop, string outerBottom, string centerAcronym, string centerDate, string centerSub)
    {
        int cx = S / 2, cy = S / 2;

        // Doble anillo exterior
        using (Pen pThick = new Pen(c, 7f))
        using (Pen pThin = new Pen(c, 2.5f))
        {
            g.DrawEllipse(pThick, 30, 30, S - 60, S - 60);
            g.DrawEllipse(pThin, 52, 52, S - 104, S - 104);
            g.DrawEllipse(pThin, 175, 175, S - 350, S - 350);
            g.DrawEllipse(pThick, 195, 195, S - 390, S - 390);
        }

        // Anillos dentados / estrellas decorativas
        using (Brush b = new SolidBrush(c))
        {
            for (int angle = 0; angle < 360; angle += 15)
            {
                double rad = angle * Math.PI / 180.0;
                float dotR = 210f;
                float dx = cx + (float)(Math.Cos(rad) * dotR);
                float dy = cy + (float)(Math.Sin(rad) * dotR);
                g.FillEllipse(b, dx - 3f, dy - 3f, 6f, 6f);
            }
        }

        // Textos circulares superior e inferior con espaciado tipográfico proporcional
        using (Font fOuter = new Font("Segoe UI", 17f, FontStyle.Bold))
        using (Brush b = new SolidBrush(c))
        {
            DrawCurvedTextWidthAware(g, outerTop, cx, cy, 310f, fOuter, b, true);
            DrawCurvedTextWidthAware(g, outerBottom, cx, cy, 310f, fOuter, b, false);
        }

        // Centro del sello
        using (Font fHuge = new Font("Trebuchet MS", 64f, FontStyle.Bold))
        using (Font fMid = new Font("Segoe UI", 20f, FontStyle.Bold))
        using (Font fSub = new Font("Segoe UI", 13.5f, FontStyle.Bold))
        using (Brush b = new SolidBrush(c))
        {
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
            g.DrawString(centerAcronym, fHuge, b, cx, cy - 88, sf);

            using (Pen p = new Pen(c, 2.5f))
                g.DrawLine(p, cx - 120, cy + 8, cx + 120, cy + 8);

            g.DrawString(centerDate, fMid, b, cx, cy + 20, sf);
            g.DrawString(centerSub, fSub, b, cx, cy + 56, sf);
        }
    }

    static void DrawCurvedTextWidthAware(Graphics g, string text, float cx, float cy, float radius, Font font, Brush brush, bool isTop)
    {
        if (string.IsNullOrEmpty(text)) return;

        float[] widths = new float[text.Length];
        float totalWidth = 0f;
        for (int i = 0; i < text.Length; i++)
        {
            SizeF sz = g.MeasureString(text[i].ToString(), font, 1000, StringFormat.GenericTypographic);
            float w = Math.Max(font.Size * 0.45f, sz.Width * 1.08f);
            widths[i] = w;
            totalWidth += w;
        }

        float totalAngleDeg = (float)((totalWidth / radius) * (180.0 / Math.PI));

        if (isTop)
        {
            float currentAngle = -90f - (totalAngleDeg / 2f);
            for (int i = 0; i < text.Length; i++)
            {
                float charWidth = widths[i];
                float midAngle = currentAngle + (charWidth / 2f / radius) * (float)(180.0 / Math.PI);
                double rad = midAngle * Math.PI / 180.0;

                float x = cx + (float)(Math.Cos(rad) * radius);
                float y = cy + (float)(Math.Sin(rad) * radius);

                GraphicsState state = g.Save();
                g.TranslateTransform(x, y);
                g.RotateTransform(midAngle + 90f);

                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(text[i].ToString(), font, brush, 0f, 0f, sf);
                g.Restore(state);

                currentAngle += (charWidth / radius) * (float)(180.0 / Math.PI);
            }
        }
        else
        {
            float currentAngle = 90f + (totalAngleDeg / 2f);
            for (int i = 0; i < text.Length; i++)
            {
                float charWidth = widths[i];
                float midAngle = currentAngle - (charWidth / 2f / radius) * (float)(180.0 / Math.PI);
                double rad = midAngle * Math.PI / 180.0;

                float x = cx + (float)(Math.Cos(rad) * radius);
                float y = cy + (float)(Math.Sin(rad) * radius);

                GraphicsState state = g.Save();
                g.TranslateTransform(x, y);
                g.RotateTransform(midAngle - 90f);

                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(text[i].ToString(), font, brush, 0f, 0f, sf);
                g.Restore(state);

                currentAngle -= (charWidth / radius) * (float)(180.0 / Math.PI);
            }
        }
    }

    static string GenerateCircularSealSVG(int S, string colorHex, string outerTop, string outerBottom, string centerMain, string centerDate, string centerSub)
    {
        int cx = S / 2, cy = S / 2;
        int R = 310;
        return string.Format(
@"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 {0} {0}"" width=""{0}"" height=""{0}"">
  <defs>
    <path id=""topCircle"" d=""M {1} {2} A {3} {3} 0 0 1 {4} {2}""/>
    <path id=""bottomCircle"" d=""M {4} {2} A {3} {3} 0 0 1 {1} {2}""/>
    <style>
      .seal-stroke {{ stroke: {5}; fill: none; }}
      .seal-text {{ fill: {5}; font-family: 'Segoe UI', Arial, sans-serif; font-weight: bold; }}
    </style>
  </defs>
  <circle cx=""{2}"" cy=""{2}"" r=""{6}"" class=""seal-stroke"" stroke-width=""7""/>
  <circle cx=""{2}"" cy=""{2}"" r=""{7}"" class=""seal-stroke"" stroke-width=""2.5""/>
  <circle cx=""{2}"" cy=""{2}"" r=""220"" class=""seal-stroke"" stroke-width=""2.5""/>
  <circle cx=""{2}"" cy=""{2}"" r=""200"" class=""seal-stroke"" stroke-width=""7""/>
  <text class=""seal-text"" font-size=""21"">
    <textPath href=""#topCircle"" startOffset=""50%"" text-anchor=""middle"">{8}</textPath>
  </text>
  <text class=""seal-text"" font-size=""19"">
    <textPath href=""#bottomCircle"" startOffset=""50%"" text-anchor=""middle"">{9}</textPath>
  </text>
  <text x=""{2}"" y=""{10}"" text-anchor=""middle"" class=""seal-text"" font-size=""72"" font-family=""'Trebuchet MS'"">{11}</text>
  <line x1=""{12}"" y1=""{13}"" x2=""{14}"" y2=""{13}"" class=""seal-stroke"" stroke-width=""3""/>
  <text x=""{2}"" y=""{15}"" text-anchor=""middle"" class=""seal-text"" font-size=""24"">{16}</text>
  <text x=""{2}"" y=""{17}"" text-anchor=""middle"" class=""seal-text"" font-size=""17"">{18}</text>
</svg>", S, cx - R, cy, R, cx + R, colorHex, S / 2 - 30, S / 2 - 52, outerTop, outerBottom, cy - 10, centerMain, cx - 140, cy + 15, cx + 140, cy + 55, centerDate, cy + 95, centerSub);
    }

    static void DrawStampTransformed(Graphics g, Image stamp, int x, int y, int w, int h, float angle)
    {
        GraphicsState state = g.Save();
        g.TranslateTransform(x + w / 2f, y + h / 2f);
        g.RotateTransform(angle);
        g.DrawImage(stamp, -w / 2f, -h / 2f, w, h);
        g.Restore(state);
    }

    static void ApplyStampDistress(Bitmap bmp, Color baseColor, int seed)
    {
        Random rnd = new Random(seed);
        int W = bmp.Width;
        int H = bmp.Height;

        for (int i = 0; i < W * H / 45; i++)
        {
            int rx = rnd.Next(W);
            int ry = rnd.Next(H);
            Color p = bmp.GetPixel(rx, ry);
            if (p.A > 40)
            {
                int newA = Math.Max(0, p.A - rnd.Next(60, 180));
                bmp.SetPixel(rx, ry, Color.FromArgb(newA, p.R, p.G, p.B));
            }
        }
    }

    static void DrawCornerFlourish(Graphics g, int x, int y, int size, Color c)
    {
        using (Pen p = new Pen(c, 2.5f))
        {
            g.DrawLine(p, x, y, x + (x > 200 ? -size : size), y);
            g.DrawLine(p, x, y, x, y + (y > 200 ? -size : size));
        }
    }

    static void DrawBlueprintGrid(Graphics g, int w, int h)
    {
        using (Pen pFine = new Pen(Color.FromArgb(18, 0, 180, 216), 1f))
        using (Pen pMajor = new Pen(Color.FromArgb(32, 0, 180, 216), 1.5f))
        {
            for (int x = 0; x < w; x += 40)
                g.DrawLine((x % 200 == 0) ? pMajor : pFine, x, 0, x, h);
            for (int y = 0; y < h; y += 40)
                g.DrawLine((y % 200 == 0) ? pMajor : pFine, 0, y, w, y);
        }
    }

    static void DrawSecurityGuilloche(Graphics g, int w, int h)
    {
        using (Pen p1 = new Pen(Color.FromArgb(25, 0, 119, 182), 1f))
        using (Pen p2 = new Pen(Color.FromArgb(20, 247, 127, 0), 1f))
        {
            for (int i = 0; i < w; i += 25)
            {
                g.DrawLine(p1, i, 0, i, h);
            }
            for (int j = 0; j < h; j += 25)
            {
                g.DrawLine(p2, 0, j, w, j);
            }
        }
    }

    static void DrawWashi(Graphics g, int x, int y, int w, int h, float angle, Color c)
    {
        GraphicsState state = g.Save();
        g.TranslateTransform(x + w / 2f, y + h / 2f);
        g.RotateTransform(angle);
        using (SolidBrush b = new SolidBrush(Color.FromArgb(175, c)))
        using (Pen p = new Pen(Color.FromArgb(40, 255, 255, 255), 1.5f))
        {
            g.FillRectangle(b, -w / 2f, -h / 2f, w, h);
            g.DrawRectangle(p, -w / 2f, -h / 2f, w, h);
        }
        g.Restore(state);
    }

    static void DrawOctagon(Graphics g, Pen p, int x, int y, int w, int h, int cut)
    {
        Point[] pts = new Point[] {
            new Point(x + cut, y),
            new Point(x + w - cut, y),
            new Point(x + w, y + cut),
            new Point(x + w, y + h - cut),
            new Point(x + w - cut, y + h),
            new Point(x + cut, y + h),
            new Point(x, y + h - cut),
            new Point(x, y + cut)
        };
        g.DrawPolygon(p, pts);
    }

    static void DrawRoundedRect(Graphics g, Pen p, Rectangle r, int radius)
    {
        using (GraphicsPath path = GetRoundedPath(r, radius))
            g.DrawPath(p, path);
    }

    static void FillRoundedRect(Graphics g, Brush b, Rectangle r, int radius)
    {
        using (GraphicsPath path = GetRoundedPath(r, radius))
            g.FillPath(b, path);
    }

    static GraphicsPath GetRoundedPath(Rectangle r, int radius)
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

    static void SaveJpeg(Bitmap bmp, string path)
    {
        ImageCodecInfo jpgEncoder = null;
        foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
        {
            if (codec.MimeType == "image/jpeg") { jpgEncoder = codec; break; }
        }
        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 96L);
        bmp.Save(path, jpgEncoder, encoderParams);
    }
}
