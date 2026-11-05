import { spawn, spawnSync } from 'node:child_process';
import fs from 'node:fs';
import path from 'node:path';
import os from 'node:os';
import { fileURLToPath } from 'node:url';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);
const PROJECT_ROOT = path.resolve(__dirname, '..', '..');

const AUDIO_PATH = path.join(PROJECT_ROOT, '02_assets', 'locucion', 'B0_cold_open_JuanAlvarez.wav');
const OUTPUT_MP4 = path.join(PROJECT_ROOT, '04_edicion', 'exports', 'B0_beat01_prueba_JuanAlvarez.mp4');
const PREVIEW_START = path.join(__dirname, 'preview_beat01_start.png');
const PREVIEW_MID = path.join(__dirname, 'preview_beat01_mid.png');
const PREVIEW_END = path.join(__dirname, 'preview_beat01_end.png');

const FFMPEG_BIN =
  'C:\\Users\\juanj\\AppData\\Local\\Microsoft\\WinGet\\Packages\\Gyan.FFmpeg_Microsoft.Winget.Source_8wekyb3d8bbwe\\ffmpeg-9.0.2-full_build\\bin\\ffmpeg.exe';

const FPS = 30;
const DURATION = 11.0;
const TOTAL_FRAMES = Math.round(DURATION * FPS); // 330 fotogramas exactos
const WIDTH = 1920;
const HEIGHT = 1080;

// ============================================================================
// MOTOR VECTORIAL C# GDI+ DETERMINISTA (MOTION-CANVAS + REMOTION + SVG DRAW-ON)
// ============================================================================
const CSHARP_RENDERER_SOURCE = `
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.InteropServices;

public class Beat01Renderer {
    const int W = 1920;
    const int H = 1080;
    const double DURATION = 11.0;
    const int FPS = 30;
    const int TOTAL_FRAMES = 330;

    // Paleta Editorial Vox Explainer + Quantum Fracture
    static readonly Color CreamBg = Color.FromArgb(255, 244, 239, 230);       // #F4EFE6
    static readonly Color CreamCard = Color.FromArgb(255, 250, 246, 238);     // #FAF6EE
    static readonly Color Charcoal = Color.FromArgb(255, 29, 30, 44);         // #1D1E2C
    static readonly Color CyanElectric = Color.FromArgb(255, 0, 180, 216);    // #00B4D8
    static readonly Color CyanBright = Color.FromArgb(255, 72, 202, 228);     // #48CAE4
    static readonly Color CyanDeep = Color.FromArgb(255, 0, 119, 182);       // #0077B6
    static readonly Color AmberSolar = Color.FromArgb(255, 247, 127, 0);      // #F77F00
    static readonly Color AmberBright = Color.FromArgb(255, 252, 191, 73);    // #FCBF49
    static readonly Color StickerWhite = Color.FromArgb(255, 253, 251, 247);  // #FDFBF7
    static readonly Color SkinPaper = Color.FromArgb(255, 239, 227, 208);     // #EFE3D0
    static readonly Color SkinShadow = Color.FromArgb(255, 223, 203, 176);    // #DFCBB0
    static readonly Color NailBed = Color.FromArgb(255, 247, 237, 226);       // #F7EDE2

    struct Particle {
        public double OffsetPhase;
        public double Speed;
        public double LateralSpread;
        public float Radius;
        public int Type; // 0: dot, 1: large halftone, 2: wavepacket
        public bool AmberAccent;
    }

    static Particle[] particles;
    static Bitmap paperCache;

    // --- Utilidades Matemáticas y Easings (Motion Canvas + Remotion) ---
    static double Clamp(double min, double max, double v) {
        return Math.Max(min, Math.Min(max, v));
    }
    static double Map(double from, double to, double t) {
        return from + (to - from) * t;
    }
    static double EaseOutCubic(double t) {
        double x = Clamp(0.0, 1.0, t);
        return 1.0 - Math.Pow(1.0 - x, 3.0);
    }
    static double EaseInOutCubic(double t) {
        double x = Clamp(0.0, 1.0, t);
        return x < 0.5 ? 4.0 * x * x * x : 1.0 - Math.Pow(-2.0 * x + 2.0, 3.0) / 2.0;
    }
    static double EaseOutExpo(double t) {
        double x = Clamp(0.0, 1.0, t);
        return x >= 1.0 ? 1.0 : 1.0 - Math.Pow(2.0, -10.0 * x);
    }
    static double EaseOutBack(double t) {
        double x = Clamp(0.0, 1.0, t);
        double c1 = 1.70158;
        double c3 = c1 + 1.0;
        return 1.0 + c3 * Math.Pow(x - 1.0, 3.0) + c1 * Math.Pow(x - 1.0, 2.0);
    }
    static double Interpolate(double input, double inMin, double inMax, double outMin, double outMax, int easeType) {
        double raw = Clamp(0.0, 1.0, (input - inMin) / (inMax - inMin));
        double eased = raw;
        if (easeType == 1) eased = EaseOutCubic(raw);
        else if (easeType == 2) eased = EaseInOutCubic(raw);
        else if (easeType == 3) eased = EaseOutExpo(raw);
        else if (easeType == 4) eased = EaseOutBack(raw);
        return Map(outMin, outMax, eased);
    }
    static double SeededRandom(double seed) {
        double s = Math.Sin(seed * 12.9898 + 78.233) * 43758.5453;
        return s - Math.Floor(s);
    }

    static void InitAssets() {
        // 1. Generar textura de papel crema envejecido (#F4EFE6) con grano de imprenta y viñeteado
        paperCache = new Bitmap(W, H, PixelFormat.Format32bppArgb);
        BitmapData bd = paperCache.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
        int bytes = Math.Abs(bd.Stride) * H;
        byte[] buf = new byte[bytes];
        uint seed = 1337;
        double cx = W * 0.5;
        double cy = H * 0.5;
        double maxR = H * 0.68;
        double minR = H * 0.35;

        for (int y = 0; y < H; y++) {
            int row = y * bd.Stride;
            for (int x = 0; x < W; x++) {
                seed = seed * 1664525u + 1013904223u;
                int n = (int)((seed >> 24) & 0xFF) - 128;
                double grain = n * 0.055;

                double dist = Math.Sqrt((x - cx) * (x - cx) + (y - cy) * (y - cy));
                double vig = Clamp(0.0, 1.0, (dist - minR) / (maxR - minR)) * 0.14;

                int r = (int)Clamp(0, 255, 244 + grain - vig * 45);
                int g = (int)Clamp(0, 255, 239 + grain - vig * 50);
                int b = (int)Clamp(0, 255, 230 + grain * 1.1 - vig * 60);

                int idx = row + x * 4;
                buf[idx + 0] = (byte)b;
                buf[idx + 1] = (byte)g;
                buf[idx + 2] = (byte)r;
                buf[idx + 3] = 255;
            }
        }
        Marshal.Copy(buf, 0, bd.Scan0, bytes);
        paperCache.UnlockBits(bd);

        using (Graphics pg = Graphics.FromImage(paperCache)) {
            pg.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pDark = new Pen(Color.FromArgb(8, 29, 30, 44), 1.0f))
            using (Pen pWarm = new Pen(Color.FromArgb(12, 180, 155, 115), 1.0f)) {
                for (int i = 0; i < 420; i++) {
                    float fx = (float)(SeededRandom(i * 3.1) * W);
                    float fy = (float)(SeededRandom(i * 7.3) * H);
                    float len = (float)(8.0 + SeededRandom(i * 11.7) * 26.0);
                    double ang = SeededRandom(i * 19.3) * Math.PI * 2.0;
                    pg.DrawLine(i % 2 == 0 ? pDark : pWarm, fx, fy, fx + (float)Math.Cos(ang) * len, fy + (float)Math.Sin(ang) * len);
                }
            }
        }

        // 2. Inicializar las 280 partículas deterministas del haz de neutrinos
        particles = new Particle[280];
        for (int i = 0; i < 280; i++) {
            int tType = (i % 5 == 0) ? 2 : ((i % 3 == 0) ? 1 : 0);
            particles[i] = new Particle {
                OffsetPhase = SeededRandom(i * 1.13),
                Speed = 0.24 + SeededRandom(i * 2.71) * 0.22,
                LateralSpread = (SeededRandom(i * 4.09) - 0.5) * 2.0,
                Radius = tType == 1
                    ? (float)(3.8 + SeededRandom(i * 5.3) * 3.4)
                    : (float)(2.0 + SeededRandom(i * 6.7) * 2.4),
                Type = tType,
                AmberAccent = SeededRandom(i * 13.7) > 0.86
            };
        }
    }

    static GraphicsPath CreateRoundedRect(float x, float y, float w, float h, float r) {
        GraphicsPath path = new GraphicsPath();
        float d = r * 2f;
        if (d <= 0.1f) {
            path.AddRectangle(new RectangleF(x, y, w, h));
            return path;
        }
        path.AddArc(x, y, d, d, 180, 90);
        path.AddArc(x + w - d, y, d, d, 270, 90);
        path.AddArc(x + w - d, y + h - d, d, d, 0, 90);
        path.AddArc(x, y + h - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }

    static void DrawWashiTape(Graphics g, float cx, float cy, float width, float height, float angleDeg, Color tint) {
        GraphicsState st = g.Save();
        g.TranslateTransform(cx, cy);
        g.RotateTransform(angleDeg);

        float hw = width * 0.5f;
        float hh = height * 0.5f;

        using (SolidBrush sh = new SolidBrush(Color.FromArgb(28, 29, 30, 44))) {
            g.FillRectangle(sh, -hw + 2, -hh + 3, width, height);
        }
        using (SolidBrush br = new SolidBrush(tint)) {
            g.FillRectangle(br, -hw, -hh, width, height);
        }
        using (Pen hatch = new Pen(Color.FromArgb(24, 29, 30, 44), 1.0f)) {
            for (float x = -hw + 8; x < hw - 4; x += 9) {
                g.DrawLine(hatch, x, -hh + 2, x - 6, hh - 2);
            }
        }
        using (Pen border = new Pen(Color.FromArgb(95, 255, 255, 255), 1.2f)) {
            g.DrawRectangle(border, -hw + 1.5f, -hh + 1.5f, width - 3f, height - 3f);
        }
        g.Restore(st);
    }

    static void DrawHalftoneCircle(Graphics g, float cx, float cy, float maxR, float spacing, Color col, float maxDotR) {
        using (SolidBrush br = new SolidBrush(col)) {
            for (float x = cx - maxR; x <= cx + maxR; x += spacing) {
                for (float y = cy - maxR; y <= cy + maxR; y += spacing) {
                    double dist = Math.Sqrt((x - cx) * (x - cx) + (y - cy) * (y - cy));
                    if (dist < maxR) {
                        double factor = 1.0 - dist / maxR;
                        float r = (float)(maxDotR * Math.Pow(factor, 0.75));
                        if (r > 0.4f) {
                            g.FillEllipse(br, x - r, y - r, r * 2f, r * 2f);
                        }
                    }
                }
            }
        }
    }

    static GraphicsPath GetHandSilhouette() {
        GraphicsPath p = new GraphicsPath();
        p.StartFigure();
        p.AddBezier(1540f, 960f, 1410f, 910f, 1295f, 845f, 1215f, 745f);
        p.AddBezier(1215f, 745f, 1165f, 680f, 1115f, 620f, 1085f, 555f);
        p.AddBezier(1085f, 555f, 1068f, 515f, 1072f, 462f, 1102f, 434f);
        p.AddBezier(1102f, 434f, 1135f, 405f, 1192f, 412f, 1215f, 452f);
        p.AddBezier(1215f, 452f, 1235f, 490f, 1230f, 548f, 1248f, 588f);
        p.AddBezier(1248f, 588f, 1265f, 622f, 1308f, 615f, 1332f, 585f);
        p.AddBezier(1332f, 585f, 1312f, 530f, 1335f, 472f, 1388f, 468f);
        p.AddBezier(1388f, 468f, 1435f, 465f, 1468f, 498f, 1485f, 535f);
        p.AddBezier(1485f, 535f, 1525f, 520f, 1568f, 548f, 1588f, 590f);
        p.AddBezier(1588f, 590f, 1622f, 595f, 1650f, 632f, 1658f, 680f);
        p.AddBezier(1658f, 680f, 1675f, 765f, 1665f, 865f, 1685f, 960f);
        p.CloseFigure();
        return p;
    }

    static GraphicsPath GetNailPath() {
        GraphicsPath np = new GraphicsPath();
        np.StartFigure();
        np.AddBezier(1112f, 495f, 1108f, 458f, 1126f, 430f, 1156f, 428f);
        np.AddBezier(1156f, 428f, 1186f, 426f, 1204f, 454f, 1200f, 495f);
        np.AddBezier(1200f, 495f, 1196f, 520f, 1178f, 530f, 1155f, 530f);
        np.AddBezier(1155f, 530f, 1132f, 530f, 1116f, 518f, 1112f, 495f);
        np.CloseFigure();
        return np;
    }

    public static void RenderFrame(Graphics g, double t) {
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        // 1. Papel crema base (#F4EFE6)
        g.DrawImageUnscaled(paperCache, 0, 0);

        // 2. Push-in 2D lento de cámara (1.000x -> 1.045x) hacia la uña del pulgar (1155, 485)
        double camProg = EaseInOutCubic(t / DURATION);
        float camZoom = (float)Map(1.0, 1.045, camProg);
        float focusX = 1155f;
        float focusY = 485f;
        float panX = (float)Map(0.0, -24.0, camProg);
        float panY = (float)Map(0.0, -10.0, camProg);

        GraphicsState camState = g.Save();
        g.TranslateTransform(focusX, focusY);
        g.ScaleTransform(camZoom, camZoom);
        g.TranslateTransform(-focusX, -focusY);

        // ====================================================================
        // CAPA 0: CUADRÍCULA TÉCNICA Y COTAS DE INGENIERÍA (PARALAJE 0.35)
        // ====================================================================
        GraphicsState s0 = g.Save();
        g.TranslateTransform(panX * 0.35f, panY * 0.35f);

        double gridAlpha = Interpolate(t, 0.0, 0.6, 0.0, 1.0, 1);
        double majorDraw = Interpolate(t, 0.0, 0.9, 0.0, 1.0, 3);

        using (Pen minorPen = new Pen(Color.FromArgb((int)(28 * gridAlpha), 0, 180, 216), 1.0f)) {
            for (int x = -48; x <= W + 48; x += 24) g.DrawLine(minorPen, x, -48, x, H + 48);
            for (int y = -48; y <= H + 48; y += 24) g.DrawLine(minorPen, -48, y, W + 48, y);
        }
        using (Pen majorPen = new Pen(Color.FromArgb((int)(56 * gridAlpha), 0, 180, 216), 1.4f)) {
            float maxY = (float)Map(-48, H + 48, majorDraw);
            float maxX = (float)Map(-48, W + 48, majorDraw);
            for (int x = 0; x <= W; x += 120) g.DrawLine(majorPen, x, -48, x, maxY);
            for (int y = 0; y <= H; y += 120) g.DrawLine(majorPen, -48, y, maxX, y);
        }
        using (Pen crossPen = new Pen(Color.FromArgb((int)(72 * gridAlpha), 29, 30, 44), 1.3f)) {
            for (int x = 120; x < W; x += 240) {
                for (int y = 120; y < H; y += 240) {
                    g.DrawLine(crossPen, x - 6, y, x + 6, y);
                    g.DrawLine(crossPen, x, y - 6, x, y + 6);
                }
            }
        }
        g.Restore(s0);

        // ====================================================================
        // CAPA 2: HAZ DIAGONAL DE NEUTRINOS — FONDO Y ONDAS (PARALAJE 0.90)
        // ====================================================================
        float beamStartX = 245f, beamStartY = 255f;
        float nailCenterX = 1155f, nailCenterY = 485f;
        float beamEndX = 2050f, beamEndY = 711f;
        float dx = beamEndX - beamStartX;
        float dy = beamEndY - beamStartY;
        float beamAngleDeg = (float)(Math.Atan2(dy, dx) * 180.0 / Math.PI);
        float beamLength = (float)Math.Sqrt(dx * dx + dy * dy);
        float nailDist = (float)Math.Sqrt((nailCenterX - beamStartX) * (nailCenterX - beamStartX) + (nailCenterY - beamStartY) * (nailCenterY - beamStartY));

        double beamAppear = Interpolate(t, 0.25, 1.4, 0.0, 1.0, 1);
        if (beamAppear > 0.0) {
            GraphicsState s2 = g.Save();
            g.TranslateTransform(panX * 0.9f, panY * 0.9f);
            g.TranslateTransform(beamStartX, beamStartY);
            g.RotateTransform(beamAngleDeg);

            float curLen = (float)(beamLength * beamAppear);
            using (SolidBrush bOuter = new SolidBrush(Color.FromArgb((int)(22 * beamAppear), 0, 180, 216)))
            using (SolidBrush bInner = new SolidBrush(Color.FromArgb((int)(34 * beamAppear), 0, 180, 216))) {
                g.FillRectangle(bOuter, 0f, -68f, curLen, 136f);
                g.FillRectangle(bInner, 0f, -35f, curLen, 70f);
            }

            using (Pen trackPen = new Pen(Color.FromArgb((int)(122 * beamAppear), 0, 180, 216), 1.6f)) {
                trackPen.DashPattern = new float[] { 12f, 8f };
                trackPen.DashOffset = (float)(-t * 18.0);
                float[] offs = new float[] { -64f, -36f, -12f, 12f, 36f, 64f };
                foreach (float off in offs) {
                    g.DrawLine(trackPen, 0f, off, curLen, off);
                }
            }

            // Ondas sinusoidales cuánticas continuas
            using (Pen wavePen = new Pen(Color.FromArgb((int)(105 * beamAppear), 0, 180, 216), 2.0f)) {
                for (int wIdx = -1; wIdx <= 1; wIdx += 2) {
                    int steps = (int)(curLen / 8f);
                    if (steps > 2) {
                        PointF[] pts = new PointF[steps];
                        float baseOff = wIdx * 24f;
                        for (int s = 0; s < steps; s++) {
                            float sx = s * 8f;
                            double env = Math.Sin((sx / 180.0) * Math.PI - t * 6.0) * 10.0;
                            float wy = (float)(Math.Sin(sx * 0.085 - t * 22.0 + wIdx) * env);
                            pts[s] = new PointF(sx, baseOff + wy);
                        }
                        g.DrawLines(wavePen, pts);
                    }
                }
            }
            g.Restore(s2);

            // Cota dimensional superior del haz con trazado progresivo
            double dimDraw = Interpolate(t, 0.6, 2.0, 0.0, 1.0, 2);
            if (dimDraw > 0.05) {
                GraphicsState sDim = g.Save();
                g.TranslateTransform(panX * 0.9f, panY * 0.9f);
                using (Pen dimPen = new Pen(Color.FromArgb(165, 29, 30, 44), 1.6f)) {
                    dimPen.DashPattern = new float[] { 6f, 6f };
                    float x2 = (float)Map(515.0, 1065.0, dimDraw);
                    float y2 = (float)Map(222.0, 362.0, dimDraw);
                    g.DrawLine(dimPen, 515f, 222f, x2, y2);
                }
                if (dimDraw > 0.45) {
                    g.TranslateTransform(785f, 282f);
                    g.RotateTransform((float)(Math.Atan2(362.0 - 222.0, 1065.0 - 515.0) * 180.0 / Math.PI));
                    using (SolidBrush bCard = new SolidBrush(CreamCard))
                    using (Pen pCard = new Pen(Charcoal, 1.2f))
                    using (SolidBrush bChar = new SolidBrush(Charcoal))
                    using (Font fDim = new Font("Consolas", 8.8f, FontStyle.Bold)) {
                        g.FillRectangle(bCard, -135f, -18f, 270f, 22f);
                        g.DrawRectangle(pCard, -135f, -18f, 270f, 22f);
                        StringFormat sfC = new StringFormat { Alignment = StringAlignment.Center };
                        g.DrawString("TRAYECTORIA RECTILÍNEA (v ≈ c)", fDim, bChar, 0f, -14f, sfC);
                    }
                }
                g.Restore(sDim);
            }
        }

        // ====================================================================
        // CAPA 1: SELLO SOLAR EN COLLAGE (ESQUINA SUPERIOR IZQUIERDA, PARALAJE 0.65)
        // ====================================================================
        GraphicsState s1 = g.Save();
        double solarEnter = Interpolate(t, 0.05, 0.85, 0.0, 1.0, 4);
        float solarSlideX = (float)((1.0 - solarEnter) * -80.0);
        float solarSlideY = (float)((1.0 - solarEnter) * -40.0);
        g.TranslateTransform(290f + panX * 0.65f + solarSlideX, 255f + panY * 0.65f + solarSlideY);
        g.RotateTransform(-2.4f);

        float cardW = 415f;
        float cardH = 310f;
        float hw = cardW * 0.5f;
        float hh = cardH * 0.5f;

        using (GraphicsPath shadowPath = CreateRoundedRect(-hw - 1f, -hh + 3f, cardW + 14f, cardH + 14f, 8f))
        using (SolidBrush shBrush = new SolidBrush(Color.FromArgb(55, 29, 30, 44))) {
            g.FillPath(shBrush, shadowPath);
        }
        using (GraphicsPath stickerPath = CreateRoundedRect(-hw - 7f, -hh - 7f, cardW + 14f, cardH + 14f, 8f))
        using (SolidBrush stBrush = new SolidBrush(StickerWhite)) {
            g.FillPath(stBrush, stickerPath);
        }
        using (GraphicsPath cardPath = CreateRoundedRect(-hw, -hh, cardW, cardH, 4f))
        using (SolidBrush cardBrush = new SolidBrush(CreamCard))
        using (Pen cardPen = new Pen(Charcoal, 2.5f)) {
            g.FillPath(cardBrush, cardPath);
            g.DrawPath(cardPen, cardPath);
        }
        using (Pen dashPen = new Pen(Color.FromArgb(90, 29, 30, 44), 1.2f)) {
            dashPen.DashPattern = new float[] { 6f, 4f };
            g.DrawRectangle(dashPen, -hw + 10f, -hh + 10f, cardW - 20f, cardH - 20f);
        }

        float sunCx = -96f;
        float sunCy = -12f;
        float sunPulse = (float)(1.0 + 0.025 * Math.Sin(t * 4.2));

        DrawHalftoneCircle(g, sunCx, sunCy, 86f * sunPulse, 9f, Color.FromArgb(85, 247, 127, 0), 3.1f);

        GraphicsState sunRot = g.Save();
        g.TranslateTransform(sunCx, sunCy);
        g.RotateTransform((float)(t * 10.5));
        using (Pen ringPen = new Pen(AmberSolar, 2.0f)) {
            ringPen.DashPattern = new float[] { 8f, 5f };
            g.DrawEllipse(ringPen, -68f, -68f, 136f, 136f);
        }
        using (Pen rayAmber = new Pen(AmberSolar, 2.2f))
        using (Pen rayChar = new Pen(Charcoal, 1.5f)) {
            for (int i = 0; i < 12; i++) {
                double a = i * Math.PI / 6.0;
                g.DrawLine(i % 2 == 0 ? rayAmber : rayChar,
                    (float)Math.Cos(a) * 52f, (float)Math.Sin(a) * 52f,
                    (float)Math.Cos(a) * 63f, (float)Math.Sin(a) * 63f);
            }
        }
        g.Restore(sunRot);

        using (SolidBrush bAmber = new SolidBrush(AmberSolar))
        using (SolidBrush bWhite = new SolidBrush(StickerWhite))
        using (Pen pChar = new Pen(Charcoal, 2.5f)) {
            g.FillEllipse(bAmber, sunCx - 48f, sunCy - 48f, 96f, 96f);
            g.DrawEllipse(pChar, sunCx - 48f, sunCy - 48f, 96f, 96f);

            float coreR = 23f * sunPulse;
            g.FillEllipse(bWhite, sunCx - coreR, sunCy - coreR, coreR * 2f, coreR * 2f);
            g.DrawEllipse(pChar, sunCx - coreR, sunCy - coreR, coreR * 2f, coreR * 2f);
        }

        using (Font fNu = new Font("Consolas", 13f, FontStyle.Bold))
        using (SolidBrush bChar = new SolidBrush(Charcoal)) {
            StringFormat sfC = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString("νe", fNu, bChar, sunCx, sunCy + 1f, sfC);
        }

        float infoX = -10f;
        using (SolidBrush bChar = new SolidBrush(Charcoal))
        using (SolidBrush bWhite = new SolidBrush(StickerWhite))
        using (SolidBrush bCyan = new SolidBrush(CyanDeep))
        using (SolidBrush bAmber = new SolidBrush(AmberSolar))
        using (Font fBadge = new Font("Consolas", 9.5f, FontStyle.Bold))
        using (Font fSub = new Font("Segoe UI", 10f, FontStyle.Bold))
        using (Font fEq = new Font("Consolas", 10.5f, FontStyle.Bold))
        using (Font fBullets = new Font("Consolas", 8.8f, FontStyle.Bold)) {
            g.FillRectangle(bChar, infoX, -hh + 22f, 202f, 24f);
            g.DrawString("SOLAR CORE | 1.5 × 10⁷ K", fBadge, bWhite, infoX + 6f, -hh + 26f);

            g.DrawString("CADENA PROTÓN-PROTÓN", fSub, bChar, infoX, -46f);

            double eqDraw = Interpolate(t, 0.4, 1.3, 0.0, 1.0, 1);
            using (SolidBrush eqFill = new SolidBrush(Color.FromArgb(32, 0, 180, 216)))
            using (Pen eqPen = new Pen(CyanElectric, 1.8f)) {
                g.FillRectangle(eqFill, infoX, -26f, (float)(202.0 * eqDraw), 32f);
                g.DrawRectangle(eqPen, infoX, -26f, 202f, 32f);
            }
            g.DrawString("p + p → ²H + e⁺ + νe", fEq, bChar, infoX + 6f, -18f);

            g.DrawString("• DENSIDAD: 150 g/cm³", fBullets, bChar, infoX, 16f);
            g.DrawString("• ESCAPE SOLAR: ~2 s", fBullets, bChar, infoX, 34f);
            g.DrawString("• EMISIÓN: 1.8 × 10³⁸ νe/s", fBullets, bAmber, infoX, 52f);

            using (Pen linePen = new Pen(Charcoal, 1.5f)) {
                g.DrawLine(linePen, -hw + 18f, hh - 40f, hw - 18f, hh - 40f);
            }
            g.DrawString("ORIGEN: CORAZÓN DEL SOL (R < 0.25 R☉)", fBullets, bChar, -hw + 18f, hh - 30f);
        }

        DrawWashiTape(g, -hw + 18f, -hh + 6f, 115f, 28f, -32f, Color.FromArgb(200, 238, 224, 192));
        DrawWashiTape(g, hw - 28f, -hh + 10f, 105f, 26f, 26f, Color.FromArgb(95, 247, 127, 0));
        g.Restore(s1);

        // ====================================================================
        // CAPA 3: MANO HUMANA Y PULGAR EN RECORTE DE PAPEL (PARALAJE 1.05)
        // ====================================================================
        GraphicsState s3 = g.Save();
        double handEnter = Interpolate(t, 0.15, 1.05, 0.0, 1.0, 1);
        float handSlideX = (float)((1.0 - handEnter) * 120.0);
        float handSlideY = (float)((1.0 - handEnter) * 60.0);
        g.TranslateTransform(panX * 1.05f + handSlideX, panY * 1.05f + handSlideY);

        using (GraphicsPath handPath = GetHandSilhouette()) {
            // Sombra paralela suave del recorte
            GraphicsState shState = g.Save();
            g.TranslateTransform(-6f, 14f);
            using (SolidBrush shBrush = new SolidBrush(Color.FromArgb(62, 29, 30, 44)))
            using (Pen shPen = new Pen(Color.FromArgb(62, 29, 30, 44), 18f) { LineJoin = LineJoin.Round }) {
                g.FillPath(shBrush, handPath);
                g.DrawPath(shPen, handPath);
            }
            g.Restore(shState);

            // Borde tipo sticker blanco (6px+ visibles)
            using (Pen stickerPen = new Pen(StickerWhite, 18f) { LineJoin = LineJoin.Round })
            using (SolidBrush stickerFill = new SolidBrush(StickerWhite)) {
                g.FillPath(stickerFill, handPath);
                g.DrawPath(stickerPen, handPath);
            }

            // Relleno de papel cálido y sombreado en semitono dentro de la silueta de la mano
            using (SolidBrush skinBrush = new SolidBrush(SkinPaper)) {
                g.FillPath(skinBrush, handPath);
            }

            GraphicsState clipState = g.Save();
            g.SetClip(handPath);

            using (GraphicsPath shadowZone = new GraphicsPath()) {
                shadowZone.AddBezier(1070f, 520f, 1120f, 610f, 1185f, 690f, 1310f, 770f);
                shadowZone.AddLine(1310f, 770f, 1680f, 960f);
                shadowZone.AddLine(1680f, 960f, 1200f, 960f);
                shadowZone.AddLine(1200f, 960f, 1050f, 600f);
                shadowZone.CloseFigure();
                using (SolidBrush sb = new SolidBrush(SkinShadow)) {
                    g.FillPath(sb, shadowZone);
                }
            }

            DrawHalftoneCircle(g, 1365f, 760f, 190f, 12f, Color.FromArgb(42, 29, 30, 44), 2.8f);
            DrawHalftoneCircle(g, 1175f, 645f, 95f, 10f, Color.FromArgb(38, 29, 30, 44), 2.4f);

            // Trama de grabado anatómico en el pulgar
            using (Pen hatchPen = new Pen(Color.FromArgb(82, 29, 30, 44), 1.4f)) {
                for (int i = 0; i < 22; i++) {
                    float y = 545f + i * 9f;
                    g.DrawBezier(hatchPen,
                        1092f + i * 3.2f, y,
                        1120f + i * 3.0f, y + 5f,
                        1145f + i * 2.7f, y + 4f,
                        1168f + i * 2.5f, y - 2f);
                }
            }
            g.Restore(clipState);

            // Contorno en tinta carbón y pliegues anatómicos
            using (Pen charOutline = new Pen(Charcoal, 3.6f) { LineJoin = LineJoin.Round }) {
                g.DrawPath(charOutline, handPath);
            }
            using (Pen creasePen = new Pen(Charcoal, 2.5f) { StartCap = LineCap.Round, EndCap = LineCap.Round }) {
                g.DrawBezier(creasePen, 1332f, 585f, 1365f, 625f, 1425f, 635f, 1468f, 610f);
                g.DrawBezier(creasePen, 1485f, 535f, 1495f, 585f, 1525f, 632f, 1560f, 645f);
                g.DrawBezier(creasePen, 1588f, 590f, 1595f, 635f, 1612f, 668f, 1635f, 685f);
                g.DrawBezier(creasePen, 1108f, 548f, 1135f, 560f, 1175f, 560f, 1204f, 542f);
                g.DrawBezier(creasePen, 1118f, 562f, 1140f, 572f, 1172f, 572f, 1195f, 558f);
                g.DrawBezier(creasePen, 1248f, 588f, 1265f, 665f, 1320f, 735f, 1410f, 785f);
            }
        }

        // Uña del pulgar en (1155, 485)
        using (GraphicsPath nailPath = GetNailPath()) {
            double nailGlow = 0.25 + 0.15 * Math.Sin(t * 8.0);
            using (SolidBrush nb = new SolidBrush(NailBed))
            using (SolidBrush glowB = new SolidBrush(Color.FromArgb((int)(255 * nailGlow), 0, 180, 216)))
            using (Pen nailPen = new Pen(Charcoal, 2.8f)) {
                g.FillPath(nb, nailPath);
                g.FillPath(glowB, nailPath);

                // Lúnula
                using (GraphicsPath lunula = new GraphicsPath()) {
                    lunula.AddBezier(1122f, 512f, 1140f, 496f, 1170f, 496f, 1188f, 512f);
                    lunula.AddBezier(1188f, 512f, 1175f, 528f, 1135f, 528f, 1122f, 512f);
                    using (SolidBrush wb = new SolidBrush(StickerWhite)) {
                        g.FillPath(wb, lunula);
                    }
                }
                g.DrawPath(nailPen, nailPath);
            }
        }

        // Retícula técnica sobre la uña del pulgar (~1.5 cm²)
        double reticleAlpha = Interpolate(t, 0.8, 1.8, 0.0, 1.0, 1);
        if (reticleAlpha > 0.01) {
            GraphicsState sRet = g.Save();
            g.TranslateTransform(nailCenterX, nailCenterY);
            int a255 = (int)(255 * reticleAlpha);

            float hRw = 58f, hRh = 58f;
            using (Pen boxPen = new Pen(Color.FromArgb((int)(180 * reticleAlpha), 0, 180, 216), 1.6f)) {
                boxPen.DashPattern = new float[] { 5f, 5f };
                g.DrawRectangle(boxPen, -hRw, -hRh, hRw * 2f, hRh * 2f);
            }
            using (Pen brkPen = new Pen(Color.FromArgb(a255, AmberSolar), 3.2f)) {
                float cL = 16f;
                g.DrawLines(brkPen, new PointF[] { new PointF(-hRw, -hRh + cL), new PointF(-hRw, -hRh), new PointF(-hRw + cL, -hRh) });
                g.DrawLines(brkPen, new PointF[] { new PointF(hRw, -hRh + cL), new PointF(hRw, -hRh), new PointF(hRw - cL, -hRh) });
                g.DrawLines(brkPen, new PointF[] { new PointF(-hRw, hRh - cL), new PointF(-hRw, hRh), new PointF(-hRw + cL, hRh) });
                g.DrawLines(brkPen, new PointF[] { new PointF(hRw, hRh - cL), new PointF(hRw, hRh), new PointF(hRw - cL, hRh) });
            }

            GraphicsState ringRot = g.Save();
            g.RotateTransform((float)(-t * 25.0));
            using (Pen scanPen = new Pen(Color.FromArgb(a255, CyanElectric), 2.0f)) {
                scanPen.DashPattern = new float[] { 10f, 7f };
                g.DrawEllipse(scanPen, -74f, -74f, 148f, 148f);
            }
            g.Restore(ringRot);

            // Callout con trazado progresivo
            double calloutDraw = Interpolate(t, 1.0, 1.9, 0.0, 1.0, 3);
            using (Pen callPen = new Pen(Color.FromArgb(a255, Charcoal), 2.0f)) {
                if (calloutDraw < 0.35) {
                    float p1 = (float)(calloutDraw / 0.35);
                    g.DrawLine(callPen, hRw - 4f, -hRh + 4f, MapF(hRw - 4f, 88f, p1), MapF(-hRh + 4f, -118f, p1));
                } else {
                    float p2 = (float)((calloutDraw - 0.35) / 0.65);
                    g.DrawLine(callPen, hRw - 4f, -hRh + 4f, 88f, -118f);
                    g.DrawLine(callPen, 88f, -118f, MapF(88f, 360f, p2), -118f);
                }
            }
            using (SolidBrush bAmb = new SolidBrush(Color.FromArgb(a255, AmberSolar))) {
                g.FillEllipse(bAmb, hRw - 8.5f, -hRh - 0.5f, 9f, 9f);
            }

            if (calloutDraw > 0.35) {
                int cAlpha = (int)(255 * reticleAlpha * Clamp(0.0, 1.0, (calloutDraw - 0.35) / 0.55));
                using (SolidBrush bChar = new SolidBrush(Color.FromArgb(cAlpha, Charcoal)))
                using (SolidBrush bWhite = new SolidBrush(Color.FromArgb(cAlpha, StickerWhite)))
                using (SolidBrush bCream = new SolidBrush(Color.FromArgb(cAlpha, CreamCard)))
                using (SolidBrush bCyan = new SolidBrush(Color.FromArgb(cAlpha, CyanDeep)))
                using (Pen pChar = new Pen(Color.FromArgb(cAlpha, Charcoal), 1.5f))
                using (Font fCall1 = new Font("Consolas", 9.5f, FontStyle.Bold))
                using (Font fCall2 = new Font("Consolas", 9.0f, FontStyle.Bold)) {
                    g.FillRectangle(bChar, 88f, -154f, 276f, 30f);
                    g.DrawString("ÁREA UÑA ≈ 1.5 cm² (BLANCO)", fCall1, bWhite, 96f, -147f);

                    g.FillRectangle(bCream, 88f, -116f, 276f, 26f);
                    g.DrawRectangle(pChar, 88f, -116f, 276f, 26f);
                    g.DrawString("ESPESOR: ~0.5 mm · QUERATINA α", fCall2, bCyan, 96f, -111f);
                }
            }
            g.Restore(sRet);
        }

        // Lupa Atómica en Collage (t >= 3.2s)
        double loupeProg = Interpolate(t, 3.2, 4.1, 0.0, 1.0, 4);
        if (loupeProg > 0.01) {
            GraphicsState sLoupe = g.Save();
            float lx = 1695f, ly = 210f, lr = 90f;
            using (Pen connPen = new Pen(Color.FromArgb(140, 29, 30, 44), 1.8f)) {
                connPen.DashPattern = new float[] { 6f, 6f };
                g.DrawLine(connPen, nailCenterX + 58f, nailCenterY - 10f, lx - lr * 0.7f, ly + lr * 0.65f);
            }
            g.TranslateTransform(lx, ly);
            float sc = (float)Math.Max(0.05, loupeProg);
            g.ScaleTransform(sc, sc);

            using (SolidBrush shB = new SolidBrush(Color.FromArgb(60, 29, 30, 44)))
            using (SolidBrush stB = new SolidBrush(StickerWhite))
            using (SolidBrush chB = new SolidBrush(Charcoal)) {
                g.FillEllipse(shB, -lr - 5f, -lr + 2f, (lr + 7f) * 2f, (lr + 7f) * 2f);
                g.FillEllipse(stB, -lr - 7f, -lr - 7f, (lr + 7f) * 2f, (lr + 7f) * 2f);
                g.FillEllipse(chB, -lr, -lr, lr * 2f, lr * 2f);
            }

            using (GraphicsPath lClip = new GraphicsPath()) {
                lClip.AddEllipse(-lr, -lr, lr * 2f, lr * 2f);
                GraphicsState gsClip = g.Save();
                g.SetClip(lClip);

                using (Pen orbPen = new Pen(Color.FromArgb(38, 244, 239, 230), 1.0f))
                using (SolidBrush nucBrush = new SolidBrush(AmberSolar)) {
                    for (int gx = -60; gx <= 60; gx += 40) {
                        for (int gy = -60; gy <= 60; gy += 40) {
                            g.DrawEllipse(orbPen, gx - 15f, gy - 15f, 30f, 30f);
                            g.FillEllipse(nucBrush, gx - 2.5f, gy - 2.5f, 5f, 5f);
                        }
                    }
                }
                g.RotateTransform(14f);
                using (Pen trPen = new Pen(Color.FromArgb(145, 0, 180, 216), 1.6f))
                using (SolidBrush wDot = new SolidBrush(StickerWhite)) {
                    for (int tr = -65; tr <= 65; tr += 22) {
                        g.DrawLine(trPen, -lr, tr, lr, tr);
                        float px = (float)(((t * 220.0 + tr * 7.0) % (lr * 2.0)) - lr);
                        g.FillEllipse(wDot, px - 3.2f, tr - 3.2f, 6.4f, 6.4f);
                    }
                }
                g.Restore(gsClip);
            }

            using (Pen rimPen = new Pen(CyanElectric, 3.0f)) {
                g.DrawEllipse(rimPen, -lr, -lr, lr * 2f, lr * 2f);
            }
            using (SolidBrush stB = new SolidBrush(StickerWhite))
            using (Pen chP = new Pen(Charcoal, 2.0f))
            using (SolidBrush chB = new SolidBrush(Charcoal))
            using (Font fLoupe = new Font("Consolas", 8.2f, FontStyle.Bold)) {
                g.FillRectangle(stB, -114f, lr - 12f, 228f, 26f);
                g.DrawRectangle(chP, -114f, lr - 12f, 228f, 26f);
                StringFormat sfC = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString("ESCALA ATÓMICA: 99.9999999% VACÍO", fLoupe, chB, 0f, lr - 5f, sfC);
            }
            g.Restore(sLoupe);
        }

        DrawWashiTape(g, 1585f, 885f, 165f, 36f, -24f, Color.FromArgb(200, 238, 224, 192));
        DrawWashiTape(g, 1345f, 875f, 140f, 32f, 18f, Color.FromArgb(95, 247, 127, 0));
        g.Restore(s3);

        // ====================================================================
        // CAPA 4: PARTÍCULAS EN SEMITONO CIAN Y PAQUETES DE ONDA (PARALAJE 1.22)
        // ====================================================================
        double fgBeam = Interpolate(t, 0.3, 1.5, 0.0, 1.0, 1);
        if (fgBeam > 0.01) {
            GraphicsState s4 = g.Save();
            g.TranslateTransform(panX * 1.22f, panY * 1.22f);
            g.TranslateTransform(beamStartX, beamStartY);
            g.RotateTransform(beamAngleDeg);

            float maxS = (float)(beamLength * fgBeam);
            float bandHalfW = 62f;

            using (SolidBrush bCyan = new SolidBrush(CyanElectric))
            using (SolidBrush bAmber = new SolidBrush(AmberSolar))
            using (SolidBrush bWhite = new SolidBrush(StickerWhite))
            using (Pen pChar = new Pen(Charcoal, 1.3f))
            using (Pen pCyan = new Pen(CyanElectric, 1.6f)) {
                for (int i = 0; i < particles.Length; i++) {
                    Particle p = particles[i];
                    double prog = (p.OffsetPhase + t * p.Speed) % 1.0;
                    float s = (float)(prog * beamLength);
                    if (s > maxS) continue;

                    float yOff = (float)(p.LateralSpread * bandHalfW);
                    float distToNail = Math.Abs(s - nailDist);
                    bool crossing = distToNail < 58f && Math.Abs(yOff) < 48f;
                    float boost = crossing ? (1f - distToNail / 58f) : 0f;

                    if (p.Type == 2) {
                        // Paquete de onda cuántico
                        GraphicsState ws = g.Save();
                        g.TranslateTransform(s, yOff);
                        Color wc = crossing ? StickerWhite : (p.AmberAccent ? AmberSolar : CyanElectric);
                        using (Pen wp = new Pen(wc, crossing ? 2.6f : 1.9f)) {
                            PointF[] wpts = new PointF[23];
                            for (int k = 0; k < 23; k++) {
                                float wx = -22f + k * 2f;
                                double gauss = Math.Exp(-(wx * wx) / 140.0);
                                float wy = (float)(Math.Sin(wx * 0.55 - t * 25.0) * 7.5 * gauss);
                                wpts[k] = new PointF(wx, wy);
                            }
                            g.DrawLines(wp, wpts);
                        }
                        float r = p.Radius + boost * 2.5f;
                        g.FillEllipse(crossing ? bWhite : bCyan, -r, -r, r * 2f, r * 2f);
                        g.Restore(ws);
                    } else {
                        float r = p.Radius * (1f + boost * 0.65f);
                        Color trailCol = crossing
                            ? Color.FromArgb(215, StickerWhite)
                            : (p.AmberAccent ? Color.FromArgb(115, AmberSolar) : Color.FromArgb(122, CyanElectric));
                        using (Pen tp = new Pen(trailCol, r * 0.9f)) {
                            g.DrawLine(tp, s - 18f - r * 2f, yOff, s, yOff);
                        }
                        SolidBrush fillB = crossing ? bWhite : (p.AmberAccent ? bAmber : bCyan);
                        g.FillEllipse(fillB, s - r, yOff - r, r * 2f, r * 2f);
                        if (p.Type == 1 || crossing) {
                            g.DrawEllipse(crossing ? pCyan : pChar, s - r, yOff - r, r * 2f, r * 2f);
                        }
                    }
                }

                // Anillos concéntricos de transmisión en la uña (0 desviación)
                for (int k = 0; k < 3; k++) {
                    double pulseProg = (t * 1.6 + k * 0.333) % 1.0;
                    float ringR = (float)(14.0 + pulseProg * 54.0);
                    int alpha = (int)((1.0 - pulseProg) * 190.0 * fgBeam);
                    Color rc = (k % 2 == 0)
                        ? Color.FromArgb(alpha, CyanElectric)
                        : Color.FromArgb(alpha, StickerWhite);
                    using (Pen rp = new Pen(rc, 2.2f)) {
                        g.DrawEllipse(rp, nailDist - ringR, -ringR, ringR * 2f, ringR * 2f);
                    }
                }
            }
            g.Restore(s4);
        }

        // Restaurar transformación de cámara para el marco técnico exterior y los banners editoriales
        g.Restore(camState);

        // Marco técnico exterior fijo (1:1 sin recorte por zoom)
        float fm = 42f;
        using (Pen borderPen = new Pen(Color.FromArgb(140, 29, 30, 44), 1.8f)) {
            g.DrawRectangle(borderPen, fm, fm, W - fm * 2, H - fm * 2);
        }
        using (Pen cornerPen = new Pen(Charcoal, 3.5f)) {
            float cl = 22f;
            g.DrawLines(cornerPen, new PointF[] { new PointF(fm, fm + cl), new PointF(fm, fm), new PointF(fm + cl, fm) });
            g.DrawLines(cornerPen, new PointF[] { new PointF(W - fm, fm + cl), new PointF(W - fm, fm), new PointF(W - fm - cl, fm) });
            g.DrawLines(cornerPen, new PointF[] { new PointF(fm, H - fm - cl), new PointF(fm, H - fm), new PointF(fm + cl, H - fm) });
            g.DrawLines(cornerPen, new PointF[] { new PointF(W - fm, H - fm - cl), new PointF(W - fm, H - fm), new PointF(W - fm - cl, H - fm) });
        }
        using (Pen tickPen = new Pen(Color.FromArgb(115, 29, 30, 44), 1.2f)) {
            for (int x = (int)fm + 40; x < W - (int)fm - 40; x += 20) {
                bool isMaj = ((x - (int)fm) % 100) == 0;
                g.DrawLine(tickPen, x, H - fm, x, H - fm - (isMaj ? 9f : 4.5f));
            }
        }
        using (Font fHeader = new Font("Consolas", 10.2f, FontStyle.Bold))
        using (SolidBrush bChar = new SolidBrush(Charcoal))
        using (SolidBrush bCyan = new SolidBrush(CyanDeep)) {
            g.DrawString("ARCHIVO CIENTÍFICO // BLOQUE 0: COLD OPEN · BEAT 01 [00:00 - 00:11]", fHeader, bChar, fm + 14, fm - 22);
            StringFormat sfRight = new StringFormat { Alignment = StringAlignment.Far };
            g.DrawString("FIG. 01 — FLUJO SOLAR DE NEUTRINOS ELECTRÓNICOS (νe) · ESCALA 1:1", fHeader, bCyan, W - fm - 14, fm - 22, sfRight);
            g.DrawString("COORD. SOL -> TIERRA (1 UA = 1.496 × 10⁸ km) // TIEMPO DE VUELO: ~8 min 20 s", fHeader, bChar, fm + 14, H - fm + 7);
            g.DrawString("MODO: COLLAGE MIXED-MEDIA // MOTION-CANVAS + REMOTION + SVG", fHeader, bChar, W - fm - 14, H - fm + 7, sfRight);
        }

        // ====================================================================
        // CAPA 5: BANNERS EDITORIALES Y SELLOS TIPOGRÁFICOS (REMOTION SEQUENCES)
        // ====================================================================
        // Sequence 1 (t >= 1.65s): "100.000 MILLONES POR SEGUNDO"
        if (t >= 1.65) {
            double bannerProg = Interpolate(t, 1.65, 2.35, 0.0, 1.0, 4);
            float offsetX = (float)((1.0 - bannerProg) * -90.0);
            GraphicsState sBan = g.Save();
            g.TranslateTransform(92f + offsetX, 605f);

            using (SolidBrush bChar = new SolidBrush(Charcoal))
            using (SolidBrush bWhite = new SolidBrush(StickerWhite))
            using (SolidBrush bCyan = new SolidBrush(CyanElectric))
            using (SolidBrush bCyanBr = new SolidBrush(CyanBright))
            using (SolidBrush bAmberBr = new SolidBrush(AmberBright)) {
                g.FillRectangle(bChar, 8f, 8f, 760f, 146f);
                g.FillRectangle(bWhite, -5f, -5f, 770f, 156f);
                g.FillRectangle(bChar, 0f, 0f, 760f, 146f);
                g.FillRectangle(bCyan, 0f, 0f, 16f, 146f);

                double countVal = Interpolate(t, 1.8, 3.6, 0.0, 100000.0, 3);
                long countInt = (long)Math.Round(countVal);
                string countStr = countInt.ToString("N0").Replace(",", ".");

                using (Font fTop = new Font("Consolas", 10.5f, FontStyle.Bold))
                using (Font fBig = new Font("Arial Black", 30f, FontStyle.Bold))
                using (Font fSide1 = new Font("Consolas", 9.5f, FontStyle.Bold))
                using (Font fSide2 = new Font("Consolas", 11f, FontStyle.Bold)) {
                    g.DrawString(
                        String.Format("FLUJO SOLAR: ~6.5 × 10¹⁰ νe / cm²·s  [CONTADOR: {0}.000.000 νe/s]", countStr),
                        fTop, bCyanBr, 28f, 12f
                    );
                    g.DrawString("100.000 MILLONES", fBig, bWhite, 26f, 36f);
                    g.DrawString("POR SEGUNDO", fBig, bCyan, 26f, 84f);

                    using (SolidBrush boxFill = new SolidBrush(Color.FromArgb(38, 0, 180, 216)))
                    using (Pen boxPen = new Pen(CyanElectric, 2.0f)) {
                        g.FillRectangle(boxFill, 545f, 44f, 194f, 84f);
                        g.DrawRectangle(boxPen, 545f, 44f, 194f, 84f);
                    }
                    g.DrawString("PARTÍCULA:", fSide1, bWhite, 558f, 52f);
                    g.DrawString("NEUTRINO (νe)", fSide2, bCyanBr, 558f, 74f);
                    g.DrawString("CARGA ELÉCTRICA: 0", fSide1, bAmberBr, 558f, 100f);
                }
            }
            g.Restore(sBan);
        }

        // Sequence 2 (t >= 7.20s): "Y TÚ NO SIENTES ABSOLUTAMENTE NADA"
        if (t >= 7.20) {
            double stampScale = Interpolate(t, 7.20, 7.60, 1.22, 1.0, 4);
            GraphicsState sSt = g.Save();
            float sx = 92f, sy = 782f, sw = 835f, sh = 128f;
            g.TranslateTransform(sx + 410f, sy + 64f);
            g.ScaleTransform((float)stampScale, (float)stampScale);
            g.RotateTransform(-1.1f);
            g.TranslateTransform(-410f, -64f);

            using (SolidBrush bChar = new SolidBrush(Charcoal))
            using (SolidBrush bWhite = new SolidBrush(StickerWhite))
            using (SolidBrush bAmber = new SolidBrush(AmberSolar))
            using (Pen pChar = new Pen(Charcoal, 3.0f))
            using (Font fSub = new Font("Consolas", 10.5f, FontStyle.Bold))
            using (Font fMain = new Font("Arial Black", 24.5f, FontStyle.Bold)) {
                g.FillRectangle(bChar, 10f, 10f, sw, sh);
                g.FillRectangle(bWhite, -5f, -5f, sw + 10f, sh + 10f);
                g.FillRectangle(bAmber, 0f, 0f, sw, sh);
                g.DrawRectangle(pChar, 6f, 6f, sw - 12f, sh - 12f);

                g.FillRectangle(bChar, 18f, 16f, sw - 36f, 32f);
                g.DrawString("MATERIA TRANSPARENTE — 0 COLISIONES  //  SECCIÓN EFICAZ: σ ≈ 10⁻⁴⁴ cm²", fSub, bWhite, 28f, 23f);
                g.DrawString("Y TÚ NO SIENTES ABSOLUTAMENTE NADA", fMain, bChar, 20f, 60f);
            }
            DrawWashiTape(g, sw - 25f, 10f, 95f, 24f, 22f, Color.FromArgb(200, 238, 224, 192));
            g.Restore(sSt);
        }
    }

    static float MapF(float a, float b, float t) {
        return a + (b - a) * Math.Max(0f, Math.Min(1f, t));
    }

    public static void RenderAll(string outRawPath, string pStart, string pMid, string pEnd) {
        InitAssets();
        using (Bitmap frameBmp = new Bitmap(W, H, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(frameBmp))
        using (FileStream fs = new FileStream(outRawPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024)) {
            int frameBytes = W * H * 4;
            byte[] rawBuf = new byte[frameBytes];

            for (int f = 0; f < TOTAL_FRAMES; f++) {
                double t = (double)f / FPS;
                RenderFrame(g, t);

                if (f == 15) frameBmp.Save(pStart, ImageFormat.Png);
                else if (f == 135) frameBmp.Save(pMid, ImageFormat.Png);
                else if (f == 255) frameBmp.Save(pEnd, ImageFormat.Png);

                BitmapData bd = frameBmp.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                Marshal.Copy(bd.Scan0, rawBuf, 0, frameBytes);
                frameBmp.UnlockBits(bd);

                fs.Write(rawBuf, 0, frameBytes);
            }
        }
    }
}
`;

async function main() {
  fs.mkdirSync(path.dirname(OUTPUT_MP4), { recursive: true });

  const tmpDir = fs.mkdtempSync(path.join(os.tmpdir(), 'beat01-render-'));
  const rawVideoPath = path.join(tmpDir, 'frames.bgra');
  const csFilePath = path.join(tmpDir, 'Beat01Renderer.cs');
  const psScriptPath = path.join(tmpDir, 'run_render.ps1');

  try {
    console.log('[1/3] Compilando y ejecutando motor vectorial determinista (330 fotogramas @ 1920x1080, 30 FPS)...');
    fs.writeFileSync(csFilePath, CSHARP_RENDERER_SOURCE, 'utf-8');

    const psContent = `
$ErrorActionPreference = "Stop"
Add-Type -ReferencedAssemblies "System.Drawing" -Path "${csFilePath.replace(/\\/g, '\\\\')}"
[Beat01Renderer]::RenderAll(
  "${rawVideoPath.replace(/\\/g, '\\\\')}",
  "${PREVIEW_START.replace(/\\/g, '\\\\')}",
  "${PREVIEW_MID.replace(/\\/g, '\\\\')}",
  "${PREVIEW_END.replace(/\\/g, '\\\\')}"
)
`;
    fs.writeFileSync(psScriptPath, psContent, 'utf-8');

    const t0 = Date.now();
    const psRes = spawnSync('powershell.exe', ['-NoProfile', '-ExecutionPolicy', 'Bypass', '-File', psScriptPath], {
      encoding: 'utf-8',
      maxBuffer: 20 * 1024 * 1024,
    });

    if (psRes.status !== 0) {
      console.error(psRes.stdout);
      console.error(psRes.stderr);
      throw new Error(`Error en motor vectorial C#: código ${psRes.status}`);
    }
    console.log(`      330 fotogramas renderizados en ${((Date.now() - t0) / 1000).toFixed(2)}s.`);
    console.log(`      Capturas de verificación guardadas: preview_beat01_start.png, preview_beat01_mid.png, preview_beat01_end.png`);

    console.log('[2/3] Codificando MP4 final con FFmpeg (H.264 CRF 18 + Locución Juan Alvarez + SFX Zumbido Subatómico 55/110Hz a -26dB)...');

    const filterComplex = [
      `[1:a]atrim=0:${DURATION},asetpts=PTS-STARTPTS[vo]`,
      `sine=frequency=55:duration=${DURATION}:sample_rate=48000[s55]`,
      `sine=frequency=110:duration=${DURATION}:sample_rate=48000[s110]`,
      `[s55][s110]amix=inputs=2:duration=first,lowpass=f=140,volume=-26dB,afade=t=in:st=0:d=0.5,afade=t=out:st=${(DURATION - 0.6).toFixed(2)}:d=0.6[hum]`,
      `[vo][hum]amix=inputs=2:duration=first:dropout_transition=0:normalize=0[aout]`,
    ].join(';');

    const ffmpegArgs = [
      '-y',
      '-f', 'rawvideo',
      '-pix_fmt', 'bgra',
      '-s', `${WIDTH}x${HEIGHT}`,
      '-r', String(FPS),
      '-i', rawVideoPath,
      '-i', AUDIO_PATH,
      '-filter_complex', filterComplex,
      '-map', '0:v:0',
      '-map', '[aout]',
      '-c:v', 'libx264',
      '-preset', 'medium',
      '-crf', '18',
      '-pix_fmt', 'yuv420p',
      '-r', String(FPS),
      '-c:a', 'aac',
      '-ar', '48000',
      '-b:a', '192k',
      '-t', String(DURATION),
      '-movflags', '+faststart',
      OUTPUT_MP4,
    ];

    const ffRes = spawnSync(FFMPEG_BIN, ffmpegArgs, {
      encoding: 'utf-8',
      maxBuffer: 20 * 1024 * 1024,
    });

    if (ffRes.status !== 0) {
      console.error(ffRes.stderr);
      throw new Error(`FFmpeg falló con código ${ffRes.status}`);
    }

    console.log(`[3/3] ¡Video MP4 generado exitosamente en: ${OUTPUT_MP4}!`);
  } finally {
    try {
      fs.rmSync(tmpDir, { recursive: true, force: true });
    } catch (_) {}
  }
}

main().catch((err) => {
  console.error(err);
  process.exit(1);
});
