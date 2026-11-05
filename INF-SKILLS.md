# Registro de Skills y Agentes del Proyecto (`INF-SKILLS.md`)

Este documento registra todas las habilidades (*skills*), herramientas de código abierto y agentes utilizados en el proyecto, detallando el propósito de cada uno y su contribución técnica.

> **Regla de repositorio:** Las carpetas operativas de las skills (`.agents/skills/`) están ignoradas en el control de versiones (`.gitignore`) para mantener el repositorio ligero y enfocado en el código y guion de producción.

---

## 1. Skills de Animación y Motion Graphics (100% Código Abierto / Web)

### A. `videozero/skills@motion-canvas`
- **Repositorio:** `https://skills.sh/videozero/skills/motion-canvas`
- **Tecnología:** TypeScript + HTML5 Canvas API + Vite (Open Source).
- **Para qué se usa en el proyecto:**
  - Es el estándar abierto más potente para gráficos y animaciones científicas procedurales estilo **3Blue1Brown** y **Quantum Fracture**.
  - Permite programar con precisión matemática los diagramas de física:
    - **Diagrama de Feynman escotogénico:** bucle cuántico a un lazo de materia oscura que otorga masa al neutrino (Dr. Diego Restrepo).
    - **Simulación del efecto Brighter-Fatter:** repulsión electrostática entre cargas en píxeles CCD (Dr. Andrés Plazas Malagón).
    - **Geometría de curvatura $f(R)$ y término de frontera:** mallas tensoriales deformándose (Dr. Leonardo Castañeda).
  - Genera render directo a video (MP4/WebM) o previsualización fluida en navegador a 60 FPS sin herramientas de pago.

### B. `remotion-dev/skills@remotion-best-practices`
- **Repositorio:** `https://skills.sh/remotion-dev/skills/remotion-best-practices`
- **Tecnología:** React + JavaScript / TypeScript + WebCodecs / FFmpeg.
- **Para qué se usa en el proyecto:**
  - Creación de composiciones de video programáticas usando HTML/CSS/React.
  - Sincronización milimétrica entre audio (locución) y elementos gráficos en pantalla.
  - Animación de tipografía cinética, tarjetas editoriales de datos, gráficos del Modelo Estándar y layouts a pantalla dividida (presentador a cámara + infografía).

### C. `iart-ai/web-animation-skills@svg-animation`
- **Repositorio:** `https://skills.sh/iart-ai/web-animation-skills/svg-animation`
- **Tecnología:** SVG nativo + CSS Animations + JavaScript (SMIL / Web Animations API).
- **Para qué se usa en el proyecto:**
  - Ilustraciones vectoriales de resolución infinita (escalables de 1080p a 4K).
  - Trazado dinámico de líneas de campo eléctrico, trayectorias geodésicas y ondas sinusoidales de oscilación de neutrinos sin coste computacional y con peso mínimo.

---

## 2. Skills de Investigación y Guionización Utilizadas

### D. `jamditis/claude-skills-journalism@fact-check-workflow`
- **Propósito:** Verificación periodística y científica sistemática.
- **Para qué se usó:** Extracción de afirmaciones, clasificación de fuentes primarias (INSPIRE-HEP, Universidad de los Andes, Universidad Nacional, Universidad de Antioquia, SLAC Stanford, Fundación Alejandro Ángel Escobar) y descarte de candidatos incorrectos (como la nacionalidad de Camila Correa).
- **Entregable generado:** [`00_investigacion/fact_check_report.md`](00_investigacion/fact_check_report.md).

### E. `ck42bb/vox-explainer-skill@vox-explainer`
- **Propósito:** Arquitectura de guiones explicativos estilo *Vox / Veritasium*.
- **Para qué se usó:** Estructurar el guion definitivo de 15 minutos en 80 beats secuenciales (~11 s cada uno, ~2.233 palabras a 149 ppm) en formato dos columnas sincronizadas y generar el archivo automatizable [`01_guion/script.json`](01_guion/script.json).
- **Entregable generado:** [`01_guion/guion_definitivo.md`](01_guion/guion_definitivo.md).

---

## 3. Subagentes Especializados Definidos

### Subagente: `motion-graphics-animator`
- **Tipo:** Agente de desarrollo frontend y animación científica en código abierto.
- **Rol:** Implementar los scripts en Motion Canvas / HTML5 Canvas / SVG interactivo / Remotion para cada una de las animaciones del guion definitivo sin depender de software privativo (After Effects de pago o generadores de video comerciales).
- **Matriz de Selección de Skills Configurada en el Subagente:**
  1. **`motion-canvas` (`videozero/skills@motion-canvas`):** Para física procedural estilo *Quantum Fracture* (diagramas de Feynman, oscilación de neutrinos, efecto *Brighter-Fatter* en CCD, curvatura $f(R)$), curvas de *easing* (`easeInOutCubic`, `easeOutExpo`, `spring`), señales reactivas y cámara 2D con paralaje.
  2. **`remotion-best-practices` (`remotion-dev/skills@remotion-best-practices`):** Para arquitectura determinista basada en `frame`/`fps`, funciones `interpolate` con *clamping*, secuenciación sincronizada con las pistas `.wav` de locución y pipeline de exportación a MP4 con FFmpeg.
  3. **`svg-animation` (`iart-ai/web-animation-skills@svg-animation`):** Para trazado vectorial progresivo (*stroke draw-on* con `stroke-dasharray` / `stroke-dashoffset` y `pathLength="1"`), cotas de ingeniería, movimiento sobre trayectorias curvas y arnés de verificación por fotograma (`?t=N`).
  4. **`vox-explainer` (`ck42bb/vox-explainer-skill@vox-explainer`):** Como guía de dirección de arte para mantener la estética *Mixed-Media Editorial Collage* (papel crema `#F4EFE6`, bordes *sticker*, cintas *washi*, *halftone* y paleta `#1D1E2C` / `#00B4D8` / `#F77F00`).
- **Invocación:** Disponible mediante `invoke_subagent(TypeName="motion-graphics-animator", ...)` para producir las escenas web y renderizar los clips de video MP4.
