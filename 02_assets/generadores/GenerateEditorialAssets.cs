using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

public class GenerateEditorialAssets
{
    static readonly Color CreamBg = Color.FromArgb(255, 244, 239, 230);        // #F4EFE6
    static readonly Color CardBg = Color.FromArgb(255, 252, 249, 244);         // #FCF9F4
    static readonly Color Charcoal = Color.FromArgb(255, 29, 30, 44);          // #1D1E2C
    static readonly Color CharcoalMuted = Color.FromArgb(255, 75, 77, 98);     // #4B4D62
    static readonly Color CyanElectric = Color.FromArgb(255, 0, 180, 216);     // #00B4D8
    static readonly Color CyanDeep = Color.FromArgb(255, 0, 119, 182);         // #0077B6
    static readonly Color AmberSolar = Color.FromArgb(255, 247, 127, 0);       // #F77F00
    static readonly Color InkRed = Color.FromArgb(255, 190, 30, 45);           // Tinta roja
    static readonly Color InkBlue = Color.FromArgb(255, 20, 50, 140);          // Tinta azul pluma

    // 1. Einstein 1919 sobre cuadrícula curva
    public static void RenderEinsteinCurvatura(string refImgPath, string outPath)
    {
        using (Bitmap bmp = new Bitmap(1920, 1080))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            g.Clear(CreamBg);
            DrawBlueprintGrid(g, 1920, 1080);

            // Malla de espacio-tiempo curvándose hacia el centro
            using (Pen pGrid = new Pen(Color.FromArgb(50, 0, 180, 216), 1.5f))
            using (Pen pGravity = new Pen(Color.FromArgb(120, 247, 127, 0), 2f))
            {
                pGravity.DashStyle = DashStyle.Dash;
                int cx = 1350;
                int cy = 540;

                for (int r = 80; r <= 500; r += 50)
                {
                    g.DrawEllipse(pGravity, cx - r, cy - r, r * 2, r * 2);
                }
                for (int a = 0; a < 360; a += 30)
                {
                    double rad = a * Math.PI / 180.0;
                    g.DrawLine(pGrid, cx + (float)(Math.Cos(rad) * 60), cy + (float)(Math.Sin(rad) * 60),
                                      cx + (float)(Math.Cos(rad) * 550), cy + (float)(Math.Sin(rad) * 550));
                }
            }

            // Foto de Einstein en marco polaroid a la izquierda
            using (Image einstein = Image.FromFile(refImgPath))
            {
                GraphicsState state = g.Save();
                g.TranslateTransform(520, 540);
                g.RotateTransform(-2.5f);
                g.TranslateTransform(-260, -320);

                // Sombra
                using (SolidBrush bShadow = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                    FillRoundedRect(g, bShadow, new Rectangle(12, 16, 520, 640), 10);

                // Marco
                using (SolidBrush bCard = new SolidBrush(CardBg))
                using (Pen pCard = new Pen(Color.FromArgb(40, 0, 0, 0), 1f))
                {
                    FillRoundedRect(g, bCard, new Rectangle(0, 0, 520, 640), 8);
                    DrawRoundedRect(g, pCard, new Rectangle(0, 0, 520, 640), 8);
                }

                // Washi tape
                DrawWashi(g, 30, -14, 130, 32, -6f, AmberSolar);

                // Foto
                int pMargin = 20;
                int pW = 520 - (pMargin * 2);
                int pH = 450;
                DrawImageCover(g, einstein, new Rectangle(pMargin, pMargin, pW, pH));

                // Texto Polaroid
                using (Font fontName = new Font("Trebuchet MS", 26f, FontStyle.Bold))
                using (Font fontSub = new Font("Segoe UI", 13f, FontStyle.Regular))
                using (Brush bChar = new SolidBrush(Charcoal))
                using (Brush bMuted = new SolidBrush(CharcoalMuted))
                {
                    g.DrawString("ALBERT EINSTEIN", fontName, bChar, pMargin, pMargin + pH + 20);
                    g.DrawString("Relatividad General · La curvatura del espacio-tiempo", fontSub, bMuted, pMargin, pMargin + pH + 64);
                }

                g.Restore(state);
            }

            // Textos y Fórmulas a la derecha
            using (Font fontH1 = new Font("Trebuchet MS", 44f, FontStyle.Bold))
            using (Font fontEq = new Font("Georgia", 28f, FontStyle.Italic))
            using (Font fontExpl = new Font("Segoe UI", 16f, FontStyle.Regular))
            using (Font fontStamp = new Font("Consolas", 14f, FontStyle.Bold))
            using (Brush bChar = new SolidBrush(Charcoal))
            using (Brush bCyan = new SolidBrush(CyanElectric))
            using (Brush bAmber = new SolidBrush(AmberSolar))
            {
                g.DrawString("EL UNIVERSO TIENE FORMA", fontH1, bChar, 980, 240);
                g.DrawString("La materia le dice al espacio cómo curvarse;", fontExpl, bChar, 980, 320);
                g.DrawString("el espacio le dice a la materia cómo moverse.", fontExpl, bCyan, 980, 350);

                // Ecuación de Einstein
                g.DrawString("G_μν + Λ g_μν = (8πG / c⁴) T_μν", fontEq, bChar, 980, 420);

                // Sello de eclipse
                DrawStamp(g, 1080, 580, 340, 80, "ECLIPSE SOLAR DE 1919\nCONFIRMACIÓN EXPERIMENTAL", AmberSolar, 4f);
            }

            SaveJpeg(bmp, outPath);
        }
    }

    // 2. Portada Tesis Doctoral Restrepo 2001
    public static void RenderTesisRestrepo(string outPath)
    {
        using (Bitmap bmp = new Bitmap(1920, 1080))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            g.Clear(CreamBg);
            DrawBlueprintGrid(g, 1920, 1080);

            // Documento de tesis centrado en perspectiva / tarjeta editorial
            int docW = 680;
            int docH = 920;
            int docX = (1920 - docW) / 2;
            int docY = 80;

            // Sombra
            using (SolidBrush bShadow = new SolidBrush(Color.FromArgb(45, 0, 0, 0)))
                FillRoundedRect(g, bShadow, new Rectangle(docX + 15, docY + 20, docW, docH), 12);

            // Hoja de Tesis
            using (SolidBrush bDoc = new SolidBrush(Color.FromArgb(255, 255, 253, 248)))
            using (Pen pBorder = new Pen(Color.FromArgb(60, 29, 30, 44), 1.5f))
            {
                FillRoundedRect(g, bDoc, new Rectangle(docX, docY, docW, docH), 8);
                DrawRoundedRect(g, pBorder, new Rectangle(docX, docY, docW, docH), 8);
            }

            // Cinta washi en la esquina superior
            DrawWashi(g, docX + 60, docY - 14, 140, 32, -4f, CyanElectric);

            // Contenido formal de la tesis
            using (Font fUniv = new Font("Times New Roman", 19f, FontStyle.Bold))
            using (Font fDep = new Font("Times New Roman", 13f, FontStyle.Regular))
            using (Font fTitle = new Font("Times New Roman", 24f, FontStyle.Bold))
            using (Font fAuthor = new Font("Times New Roman", 20f, FontStyle.Bold))
            using (Font fDir = new Font("Times New Roman", 14f, FontStyle.Italic))
            using (Font fDate = new Font("Times New Roman", 13f, FontStyle.Regular))
            using (Brush bChar = new SolidBrush(Charcoal))
            {
                StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center };

                int cy = docY + 70;
                g.DrawString("UNIVERSITAT DE VALÈNCIA", fUniv, bChar, docX + docW / 2f, cy, sfCenter);
                cy += 32;
                g.DrawString("FACULTAT DE FÍSICA · DEPARTAMENT DE FÍSICA TEÒRICA", fDep, bChar, docX + docW / 2f, cy, sfCenter);
                cy += 24;
                g.DrawString("INSTITUT DE FÍSICA CORPUSCULAR (IFIC - CSIC)", fDep, bChar, docX + docW / 2f, cy, sfCenter);

                // Línea ornamental
                cy += 40;
                using (Pen pLine = new Pen(Charcoal, 1f))
                    g.DrawLine(pLine, docX + 100, cy, docX + docW - 100, cy);

                cy += 80;
                RectangleF rTitle = new RectangleF(docX + 60, cy, docW - 120, 160);
                g.DrawString("FENOMENOLOGÍA DE MODELOS SUPERSIMÉTRICOS Y FÍSICA DE NEUTRINOS", fTitle, bChar, rTitle, sfCenter);

                cy += 180;
                g.DrawString("Memoria de Tesis Doctoral presentada por:", fDep, bChar, docX + docW / 2f, cy, sfCenter);
                cy += 32;
                using (Brush bCyan = new SolidBrush(CyanDeep))
                    g.DrawString("Diego Alejandro Restrepo Quintero", fAuthor, bCyan, docX + docW / 2f, cy, sfCenter);

                cy += 60;
                g.DrawString("Dirigida por el:", fDep, bChar, docX + docW / 2f, cy, sfCenter);
                cy += 26;
                g.DrawString("Prof. Dr. José W. F. Valle", fAuthor, bChar, docX + docW / 2f, cy, sfCenter);

                cy += 80;
                g.DrawString("València, Octubre de 2001", fDate, bChar, docX + docW / 2f, cy, sfCenter);
            }

            // Sello de calificación oficial
            DrawStamp(g, docX + docW - 260, docY + docH - 140, 220, 75, "QUALIFICACIÓ:\nEXCEL·LENT CUM LAUDE", AmberSolar, -8f);

            SaveJpeg(bmp, outPath);
        }
    }

    // 3. Paper Escotogénico JHEP 11 (2013) 011 con Sello +148 Citas
    public static void RenderPaperRestrepoJHEP(string outPath)
    {
        using (Bitmap bmp = new Bitmap(1920, 1080))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            g.Clear(CreamBg);
            DrawBlueprintGrid(g, 1920, 1080);

            int pW = 1200;
            int pH = 820;
            int pX = (1920 - pW) / 2;
            int pY = (1080 - pH) / 2;

            // Sombra
            using (SolidBrush bShadow = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                FillRoundedRect(g, bShadow, new Rectangle(pX + 12, pY + 16, pW, pH), 12);

            // Hoja del paper
            using (SolidBrush bCard = new SolidBrush(Color.White))
            using (Pen pBorder = new Pen(Color.FromArgb(40, 0, 0, 0), 1f))
            {
                FillRoundedRect(g, bCard, new Rectangle(pX, pY, pW, pH), 6);
                DrawRoundedRect(g, pBorder, new Rectangle(pX, pY, pW, pH), 6);
            }

            // Cinta washi
            DrawWashi(g, pX + 80, pY - 14, 150, 32, -3f, CyanElectric);

            // Banner superior de JHEP
            using (Font fJhep = new Font("Arial", 16f, FontStyle.Bold))
            using (Font fMeta = new Font("Consolas", 12f, FontStyle.Regular))
            using (Brush bChar = new SolidBrush(Charcoal))
            {
                g.DrawString("JHEP 11 (2013) 011", fJhep, bChar, pX + 50, pY + 45);
                g.DrawString("Published for SISSA by Springer · Open Access · arXiv:1308.3655 [hep-ph]", fMeta, new SolidBrush(CharcoalMuted), pX + 50, pY + 75);
            }

            using (Pen pLine = new Pen(Color.FromArgb(200, 0, 180, 216), 2f))
                g.DrawLine(pLine, pX + 50, pY + 110, pX + pW - 50, pY + 110);

            // Título del Paper
            using (Font fTitle = new Font("Georgia", 30f, FontStyle.Bold))
            using (Brush bChar = new SolidBrush(Charcoal))
            {
                RectangleF rTitle = new RectangleF(pX + 50, pY + 145, pW - 100, 90);
                g.DrawString("Models with radiative neutrino masses and viable dark matter candidates", fTitle, bChar, rTitle);
            }

            // Autores con resaltador cian
            int aY = pY + 260;
            using (SolidBrush bHigh = new SolidBrush(Color.FromArgb(70, 0, 180, 216)))
            {
                g.FillRectangle(bHigh, pX + 48, aY - 4, 620, 36);
            }

            using (Font fAuth = new Font("Arial", 18f, FontStyle.Bold))
            using (Font fAff = new Font("Arial", 13f, FontStyle.Italic))
            using (Brush bChar = new SolidBrush(Charcoal))
            {
                g.DrawString("Diego Restrepo,  Oscar Zapata,  Carlos E. Yaguna", fAuth, bChar, pX + 55, aY);
                g.DrawString("Instituto de Física, Universidad de Antioquia, Calle 70 No. 52-21, Medellín, Colombia", fAff, new SolidBrush(CharcoalMuted), pX + 55, aY + 46);
            }

            // Abstract
            int absY = aY + 105;
            using (SolidBrush bAbsBox = new SolidBrush(Color.FromArgb(248, 248, 252)))
            using (Pen pAbsBorder = new Pen(Color.FromArgb(220, 220, 230), 1f))
            {
                FillRoundedRect(g, bAbsBox, new Rectangle(pX + 50, absY, pW - 100, 280), 6);
                DrawRoundedRect(g, pAbsBorder, new Rectangle(pX + 50, absY, pW - 100, 280), 6);
            }

            using (Font fAbsH = new Font("Arial", 13f, FontStyle.Bold))
            using (Font fAbsT = new Font("Georgia", 14.5f, FontStyle.Regular))
            using (Brush bChar = new SolidBrush(Charcoal))
            {
                g.DrawString("ABSTRACT", fAbsH, new SolidBrush(CyanDeep), pX + 80, absY + 25);
                string abstractText = "We systematically analyze extensions of the Standard Model where active neutrino masses are generated radiatively at the one-loop level and a viable dark matter candidate is naturally stabilized by an unbroken symmetry. We classify all realizations requiring new scalar and fermion multiplets and identify 35 distinct topologies with promising collider signatures at the LHC.";
                RectangleF rAbs = new RectangleF(pX + 80, absY + 60, pW - 160, 200);
                g.DrawString(abstractText, fAbsT, bChar, rAbs);
            }

            // Sello Amber: +148 CITAS CIENTÍFICAS
            DrawStamp(g, pX + pW - 320, pY + 210, 260, 85, "+148 CITAS\nCIENTÍFICAS", AmberSolar, 7f);

            SaveJpeg(bmp, outPath);
        }
    }

    // 4. Formulario de Matrícula Plazas (Tachado y Corregido)
    public static void RenderMatriculaPlazas(string outPath)
    {
        using (Bitmap bmp = new Bitmap(1920, 1080))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            g.Clear(CreamBg);
            DrawBlueprintGrid(g, 1920, 1080);

            int fW = 1100;
            int fH = 800;
            int fX = (1920 - fW) / 2;
            int fY = (1080 - fH) / 2;

            // Sombra
            using (SolidBrush bShadow = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                FillRoundedRect(g, bShadow, new Rectangle(fX + 12, fY + 16, fW, fH), 10);

            // Hoja oficial de matrícula
            using (SolidBrush bDoc = new SolidBrush(Color.FromArgb(255, 255, 254, 250)))
            using (Pen pBorder = new Pen(Color.FromArgb(50, 29, 30, 44), 1.5f))
            {
                FillRoundedRect(g, bDoc, new Rectangle(fX, fY, fW, fH), 6);
                DrawRoundedRect(g, pBorder, new Rectangle(fX, fY, fW, fH), 6);
            }

            // Cinta washi
            DrawWashi(g, fX + 60, fY - 14, 140, 30, -5f, AmberSolar);

            // Encabezado institucional Uniandes
            using (Font fHead = new Font("Arial", 16f, FontStyle.Bold))
            using (Font fSub = new Font("Arial", 12f, FontStyle.Regular))
            using (Brush bChar = new SolidBrush(Charcoal))
            {
                g.DrawString("UNIVERSIDAD DE LOS ANDES · BOGOTÁ, COLOMBIA", fHead, bChar, fX + 60, fY + 45);
                g.DrawString("OFICINA DE ADMISIONES Y REGISTRO ACADÉMICO · PERÍODO 2000-1", fSub, new SolidBrush(CharcoalMuted), fX + 60, fY + 75);
            }

            using (Pen pLine = new Pen(Charcoal, 2f))
                g.DrawLine(pLine, fX + 60, fY + 110, fX + fW - 60, fY + 110);

            // Datos del Estudiante
            using (Font fLabel = new Font("Consolas", 12f, FontStyle.Bold))
            using (Font fVal = new Font("Arial", 16f, FontStyle.Bold))
            using (Brush bChar = new SolidBrush(Charcoal))
            using (Brush bMuted = new SolidBrush(CharcoalMuted))
            {
                int ly = fY + 140;
                g.DrawString("NOMBRE DEL ASPIRANTE:", fLabel, bMuted, fX + 60, ly);
                g.DrawString("PLAZAS MALAGÓN, ANDRÉS ALEJANDRO", fVal, bChar, fX + 60, ly + 25);

                ly += 75;
                g.DrawString("COLEGIO DE PROCEDENCIA:", fLabel, bMuted, fX + 60, ly);
                g.DrawString("Colegio Salesiano de León XIII (Bogotá) · Mejor ICFES Promoción 2000", fVal, bChar, fX + 60, ly + 25);

                ly += 90;
                g.DrawString("PROGRAMA ACADÉMICO SELECCIONADO:", fLabel, bMuted, fX + 60, ly);

                // Texto tachado: INGENIERÍA INDUSTRIAL
                int tX = fX + 60;
                int tY = ly + 35;
                using (Font fStriked = new Font("Arial", 22f, FontStyle.Regular))
                using (Brush bGray = new SolidBrush(Color.FromArgb(140, 140, 140)))
                {
                    g.DrawString("INGENIERÍA INDUSTRIAL", fStriked, bGray, tX, tY);
                    // Trazo de tachado en tinta roja
                    using (Pen pRed = new Pen(InkRed, 4.5f))
                    {
                        g.DrawLine(pRed, tX - 10, tY + 16, tX + 370, tY + 16);
                        g.DrawLine(pRed, tX, tY + 22, tX + 360, tY + 10);
                    }
                }

                // Corrección manuscrita en tinta azul: FÍSICA Y MATEMÁTICAS
                using (Font fHand = new Font("Segoe Script", 25f, FontStyle.Bold))
                using (Brush bBlue = new SolidBrush(InkBlue))
                {
                    GraphicsState hState = g.Save();
                    g.TranslateTransform(tX + 410, tY - 15);
                    g.RotateTransform(-3f);
                    g.DrawString("FÍSICA Y MATEMÁTICAS (Doble)", fHand, bBlue, 0, 0);
                    g.Restore(hState);
                }
            }

            // Nota marginal
            using (Font fNote = new Font("Segoe UI", 12f, FontStyle.Italic))
            using (Brush bMuted = new SolidBrush(CharcoalMuted))
            {
                g.DrawString("* Cambio de vocación inspirado tras cursar la asignatura 'Grandes Ideas de la Física'.", fNote, bMuted, fX + 60, fY + 540);
            }

            // Sello de aprobación en tinta púrpura
            Color stampPurp = Color.FromArgb(255, 110, 40, 140);
            DrawStamp(g, fX + fW - 350, fY + fH - 180, 280, 95, "FACULTAD DE CIENCIAS\nMATRÍCULA APROBADA", stampPurp, -6f);

            SaveJpeg(bmp, outPath);
        }
    }

    // 5. Portada Podcast Visión Cósmica (1400x1400)
    public static void RenderPodcastVisionCosmica(string outPath)
    {
        int S = 1400;
        using (Bitmap bmp = new Bitmap(S, S))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            // Fondo azul cósmico oscuro
            Color deepNavy = Color.FromArgb(255, 13, 19, 33);
            g.Clear(deepNavy);

            // Campo estelar procedural
            Random rnd = new Random(42);
            for (int i = 0; i < 350; i++)
            {
                int sx = rnd.Next(S);
                int sy = rnd.Next(S);
                int sr = rnd.Next(1, 4);
                int alpha = rnd.Next(60, 240);
                using (SolidBrush bStar = new SolidBrush(Color.FromArgb(alpha, 240, 245, 255)))
                    g.FillEllipse(bStar, sx, sy, sr, sr);
            }

            // Anillos y ondas cósmicas de radio / podcast
            using (Pen pCyan = new Pen(Color.FromArgb(140, 0, 180, 216), 2.5f))
            using (Pen pAmber = new Pen(Color.FromArgb(160, 247, 127, 0), 2.5f))
            {
                int cx = S / 2;
                int cy = 520;
                for (int r = 120; r <= 380; r += 50)
                {
                    Pen p = (r % 100 == 0) ? pAmber : pCyan;
                    p.DashStyle = DashStyle.Dash;
                    g.DrawEllipse(p, cx - r, cy - r, r * 2, r * 2);
                }

                // Ondas sonoras centrales
                for (int x = -180; x <= 180; x += 18)
                {
                    float waveH = (float)(Math.Cos(x * 0.02) * 110.0 * Math.Exp(-Math.Abs(x) * 0.008));
                    using (Pen pWave = new Pen(CyanElectric, 5f))
                    {
                        pWave.StartCap = LineCap.Round;
                        pWave.EndCap = LineCap.Round;
                        g.DrawLine(pWave, cx + x, cy - waveH, cx + x, cy + waveH);
                    }
                }
            }

            // Títulos del Podcast
            using (Font fBadge = new Font("Consolas", 18f, FontStyle.Bold))
            using (Font fMain = new Font("Trebuchet MS", 74f, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 26f, FontStyle.Bold))
            using (Font fHosts = new Font("Segoe UI", 21f, FontStyle.Regular))
            using (Brush bWhite = new SolidBrush(Color.White))
            using (Brush bCyan = new SolidBrush(CyanElectric))
            using (Brush bAmber = new SolidBrush(AmberSolar))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };

                g.DrawString("PODCAST OFICIAL · DIVULGACIÓN CIENTÍFICA", fBadge, bAmber, S / 2f, 210, sf);
                g.DrawString("VISIÓN CÓSMICA", fMain, bWhite, S / 2f, 820, sf);
                g.DrawString("Astronomía, Ciencia y Sociedad", fSub, bCyan, S / 2f, 920, sf);

                using (Pen pDiv = new Pen(Color.FromArgb(80, 255, 255, 255), 2f))
                    g.DrawLine(pDiv, 350, 990, S - 350, 990);

                g.DrawString("Con Andrés Plazas Malagón & Clara Inés Barbosa", fHosts, new SolidBrush(Color.FromArgb(220, 230, 245)), S / 2f, 1025, sf);
                g.DrawString("SLAC · Stanford University · CosmoQuest", fBadge, bAmber, S / 2f, 1080, sf);
            }

            SaveJpeg(bmp, outPath);
        }
    }

    // 6. Trilogía de Libros de Juan Carlos Sanabria (Fanned Out)
    public static void RenderTrilogiaSanabria(string book1, string book2, string book3, string outPath)
    {
        using (Bitmap bmp = new Bitmap(1920, 1080))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            g.Clear(CreamBg);
            DrawBlueprintGrid(g, 1920, 1080);

            // Cabecera superior
            using (Font fH1 = new Font("Trebuchet MS", 38f, FontStyle.Bold))
            using (Font fSub = new Font("Segoe UI", 16f, FontStyle.Bold))
            using (Brush bChar = new SolidBrush(Charcoal))
            using (Brush bMuted = new SolidBrush(CharcoalMuted))
            {
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString("TRILOGÍA DE DIVULGACIÓN CIENTÍFICA", fH1, bChar, 1920 / 2f, 50, sf);
                g.DrawString("Dr. Juan Carlos Sanabria · Editorial Debate & Ediciones Uniandes", fSub, bMuted, 1920 / 2f, 110, sf);
            }

            using (Image img1 = Image.FromFile(book1))
            using (Image img2 = Image.FromFile(book2))
            using (Image img3 = Image.FromFile(book3))
            {
                // Disposición en abanico de los 3 libros
                // Libro 1 (Izquierda): El Enigma de los Cielos (Debate)
                DrawBookCover(g, 360, 580, 360, 520, -10f, img1, "EL ENIGMA DE LOS CIELOS", "Historia de la Cosmología (2019)");

                // Libro 3 (Derecha): El Poder del Fuego (Uniandes)
                DrawBookCover(g, 1560, 580, 360, 520, 10f, img3, "EL PODER DEL FUEGO", "La Historia de la Energía (2023)");

                // Libro 2 (Centro): Espías Nucleares (Uniandes) - Destacado al frente
                DrawBookCover(g, 960, 560, 380, 550, 0f, img2, "ESPÍAS NUCLEARES", "Los Secretos de la Bomba Atómica (2025)");
            }

            SaveJpeg(bmp, outPath);
        }
    }

    // 7. Paper Castañeda Término de Frontera (arXiv:1002.0617) con Sello +105 Citas
    public static void RenderPaperCastaneda(string outPath)
    {
        using (Bitmap bmp = new Bitmap(1920, 1080))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            SetupGraphics(g);
            g.Clear(CreamBg);
            DrawBlueprintGrid(g, 1920, 1080);

            int pW = 1200;
            int pH = 820;
            int pX = (1920 - pW) / 2;
            int pY = (1080 - pH) / 2;

            // Sombra
            using (SolidBrush bShadow = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                FillRoundedRect(g, bShadow, new Rectangle(pX + 12, pY + 16, pW, pH), 12);

            // Hoja
            using (SolidBrush bCard = new SolidBrush(Color.White))
            using (Pen pBorder = new Pen(Color.FromArgb(40, 0, 0, 0), 1f))
            {
                FillRoundedRect(g, bCard, new Rectangle(pX, pY, pW, pH), 6);
                DrawRoundedRect(g, pBorder, new Rectangle(pX, pY, pW, pH), 6);
            }

            // Washi tape
            DrawWashi(g, pX + 80, pY - 14, 150, 32, -3f, AmberSolar);

            // Encabezado Springer
            using (Font fJour = new Font("Arial", 16f, FontStyle.Bold))
            using (Font fMeta = new Font("Consolas", 12f, FontStyle.Regular))
            using (Brush bChar = new SolidBrush(Charcoal))
            {
                g.DrawString("GENERAL RELATIVITY AND GRAVITATION", fJour, bChar, pX + 50, pY + 45);
                g.DrawString("Gen. Relativ. Gravit. 42 (2010) 2713–2728 · Springer · arXiv:1002.0617 [gr-qc]", fMeta, new SolidBrush(CharcoalMuted), pX + 50, pY + 75);
            }

            using (Pen pLine = new Pen(Color.FromArgb(247, 127, 0), 2f))
                g.DrawLine(pLine, pX + 50, pY + 110, pX + pW - 50, pY + 110);

            // Título del Paper
            using (Font fTitle = new Font("Georgia", 28f, FontStyle.Bold))
            using (Brush bChar = new SolidBrush(Charcoal))
            {
                RectangleF rTitle = new RectangleF(pX + 50, pY + 145, pW - 100, 90);
                g.DrawString("Boundary Term in Metric f(R) Gravity: Field Equations in the Metric Formalism", fTitle, bChar, rTitle);
            }

            // Autores
            int aY = pY + 260;
            using (SolidBrush bHigh = new SolidBrush(Color.FromArgb(70, 247, 127, 0)))
            {
                g.FillRectangle(bHigh, pX + 48, aY - 4, 760, 36);
            }

            using (Font fAuth = new Font("Arial", 18f, FontStyle.Bold))
            using (Font fAff = new Font("Arial", 13f, FontStyle.Italic))
            using (Brush bChar = new SolidBrush(Charcoal))
            {
                g.DrawString("Alejandro Guarnizo,  Leonardo Castañeda,  Juan Manuel Tejeiro", fAuth, bChar, pX + 55, aY);
                g.DrawString("Grupo de Gravitación y Cosmología, Observatorio Astronómico Nacional, Universidad Nacional de Colombia", fAff, new SolidBrush(CharcoalMuted), pX + 55, aY + 46);
            }

            // Abstract
            int absY = aY + 105;
            using (SolidBrush bAbsBox = new SolidBrush(Color.FromArgb(254, 250, 245)))
            using (Pen pAbsBorder = new Pen(Color.FromArgb(240, 230, 220), 1f))
            {
                FillRoundedRect(g, bAbsBox, new Rectangle(pX + 50, absY, pW - 100, 280), 6);
                DrawRoundedRect(g, pAbsBorder, new Rectangle(pX + 50, absY, pW - 100, 280), 6);
            }

            using (Font fAbsH = new Font("Arial", 13f, FontStyle.Bold))
            using (Font fAbsT = new Font("Georgia", 14.5f, FontStyle.Regular))
            using (Font fEq = new Font("Georgia", 15f, FontStyle.Italic))
            using (Brush bChar = new SolidBrush(Charcoal))
            {
                g.DrawString("ABSTRACT", fAbsH, new SolidBrush(AmberSolar), pX + 80, absY + 25);
                string abstractText = "We derive the complete gravitational field equations in metric f(R) gravity by applying a well-posed variational principle that explicitly includes the required boundary term. We show that the surface term generalizes the Gibbons-Hawking-York boundary term of General Relativity and prevents spurious higher-order variations on the hypersurface.";
                RectangleF rAbs = new RectangleF(pX + 80, absY + 55, pW - 160, 130);
                g.DrawString(abstractText, fAbsT, bChar, rAbs);

                g.DrawString("Acción:  S = (1 / 2κ) ∫_M d⁴x √(-g) f(R)  +  S_boundary", fEq, new SolidBrush(Charcoal), pX + 80, absY + 215);
            }

            // Sello Amber: +105 CITAS CIENTÍFICAS
            DrawStamp(g, pX + pW - 320, pY + 210, 260, 85, "+105 CITAS\nCIENTÍFICAS", AmberSolar, 7f);

            SaveJpeg(bmp, outPath);
        }
    }

    // --- MÉTODOS AUXILIARES ---
    static void SetupGraphics(Graphics g)
    {
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    }

    static void DrawBlueprintGrid(Graphics g, int w, int h)
    {
        using (Pen pMinor = new Pen(Color.FromArgb(12, 29, 30, 44), 1f))
        using (Pen pMajor = new Pen(Color.FromArgb(24, 0, 180, 216), 1.5f))
        {
            for (int x = 0; x <= w; x += 40)
            {
                Pen p = (x % 200 == 0) ? pMajor : pMinor;
                g.DrawLine(p, x, 0, x, h);
            }
            for (int y = 0; y <= h; y += 40)
            {
                Pen p = (y % 200 == 0) ? pMajor : pMinor;
                g.DrawLine(p, 0, y, w, y);
            }
        }
    }

    static void DrawWashi(Graphics g, int x, int y, int w, int h, float angle, Color c)
    {
        GraphicsState state = g.Save();
        g.TranslateTransform(x + w / 2f, y + h / 2f);
        g.RotateTransform(angle);
        g.TranslateTransform(-w / 2f, -h / 2f);
        using (SolidBrush bWashi = new SolidBrush(Color.FromArgb(170, c.R, c.G, c.B)))
            g.FillRectangle(bWashi, 0, 0, w, h);
        g.Restore(state);
    }

    static void DrawStamp(Graphics g, int x, int y, int w, int h, string text, Color c, float angle)
    {
        GraphicsState state = g.Save();
        g.TranslateTransform(x + w / 2f, y + h / 2f);
        g.RotateTransform(angle);
        g.TranslateTransform(-w / 2f, -h / 2f);

        using (Pen pDouble = new Pen(Color.FromArgb(220, c.R, c.G, c.B), 3.5f))
        using (Pen pInner = new Pen(Color.FromArgb(180, c.R, c.G, c.B), 1.5f))
        using (SolidBrush bBg = new SolidBrush(Color.FromArgb(30, c.R, c.G, c.B)))
        using (Font fStamp = new Font("Consolas", 15f, FontStyle.Bold))
        using (Brush bText = new SolidBrush(Color.FromArgb(230, c.R, c.G, c.B)))
        {
            FillRoundedRect(g, bBg, new Rectangle(0, 0, w, h), 8);
            DrawRoundedRect(g, pDouble, new Rectangle(0, 0, w, h), 8);
            DrawRoundedRect(g, pInner, new Rectangle(4, 4, w - 8, h - 8), 6);

            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(text, fStamp, bText, new RectangleF(0, 0, w, h), sf);
        }

        g.Restore(state);
    }

    static void DrawBookCover(Graphics g, int cx, int cy, int w, int h, float angle, Image img, string title, string sub)
    {
        GraphicsState state = g.Save();
        g.TranslateTransform(cx, cy);
        g.RotateTransform(angle);
        g.TranslateTransform(-w / 2f, -h / 2f);

        // Sombra
        using (SolidBrush bShadow = new SolidBrush(Color.FromArgb(45, 0, 0, 0)))
            FillRoundedRect(g, bShadow, new Rectangle(10, 16, w, h), 8);

        // Marco
        using (SolidBrush bCard = new SolidBrush(Color.White))
        using (Pen pBorder = new Pen(Color.FromArgb(40, 0, 0, 0), 1f))
        {
            FillRoundedRect(g, bCard, new Rectangle(0, 0, w, h), 6);
            DrawRoundedRect(g, pBorder, new Rectangle(0, 0, w, h), 6);
        }

        // Imagen de portada
        int pad = 12;
        int imgW = w - (pad * 2);
        int imgH = h - 100;
        DrawImageCover(g, img, new Rectangle(pad, pad, imgW, imgH));

        // Título al pie
        using (Font fT = new Font("Trebuchet MS", 13f, FontStyle.Bold))
        using (Font fS = new Font("Segoe UI", 10.5f, FontStyle.Regular))
        using (Brush bChar = new SolidBrush(Charcoal))
        using (Brush bMuted = new SolidBrush(CharcoalMuted))
        {
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
            g.DrawString(title, fT, bChar, w / 2f, h - 75, sf);
            g.DrawString(sub, fS, bMuted, w / 2f, h - 45, sf);
        }

        g.Restore(state);
    }

    static void DrawImageCover(Graphics g, Image img, Rectangle destRect)
    {
        float imgAspect = (float)img.Width / img.Height;
        float destAspect = (float)destRect.Width / destRect.Height;

        int drawW = destRect.Width;
        int drawH = destRect.Height;
        int drawX = destRect.X;
        int drawY = destRect.Y;

        if (imgAspect > destAspect)
        {
            drawW = (int)(destRect.Height * imgAspect);
            drawX = destRect.X + (destRect.Width - drawW) / 2;
        }
        else
        {
            drawH = (int)(destRect.Width / imgAspect);
            drawY = destRect.Y + (destRect.Height - drawH) / 2;
        }

        Region oldClip = g.Clip;
        g.SetClip(destRect);
        g.DrawImage(img, drawX, drawY, drawW, drawH);
        g.Clip = oldClip;
    }

    static void FillRoundedRect(Graphics g, Brush b, Rectangle r, int radius)
    {
        using (GraphicsPath path = GetRoundedRectPath(r, radius))
            g.FillPath(b, path);
    }

    static void DrawRoundedRect(Graphics g, Pen p, Rectangle r, int radius)
    {
        using (GraphicsPath path = GetRoundedRectPath(r, radius))
            g.DrawPath(p, path);
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

    static void SaveJpeg(Bitmap bmp, string path)
    {
        ImageCodecInfo jpgEncoder = null;
        foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageDecoders())
        {
            if (codec.FormatID == ImageFormat.Jpeg.Guid)
            {
                jpgEncoder = codec;
                break;
            }
        }
        EncoderParameters p = new EncoderParameters(1);
        p.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 96L);
        bmp.Save(path, jpgEncoder, p);
    }
}
