# El 95% Invisible: Cuatro Colombianos en la Frontera del Universo

> **Video documental de divulgación científica (15 minutos / 80 beats secuenciales)**  
> Estilo: *Quantum Fracture* (animaciones vectoriales rigurosas y analogías) + *Date un Vlog* (ritmo, cercanía a cámara y humor ligero).  
> Autores y Presentadores: **Juan Alvarez** y **Geffrey**.

---

## 📌 ¿Dónde leer las instrucciones del proyecto?

Para entender cómo está estructurado el proyecto y cómo ejecutar cada fase de trabajo, consulta estos documentos clave:

1. 📖 **Plan Maestro y Guía de Roles:** [`INSTRUCCIONES.md`](INSTRUCCIONES.md)
   * Contiene la visión general, división de trabajo entre **Agentes de IA** y **Autores Humanos**, flujo de producción de 9 semanas y criterios de calidad.
2. 🎙️ **Instructivo de Grabación y Teleprompter:** [`03_produccion/INSTRUCTIVO_AUDIO_Y_TELEPROMPTER.md`](03_produccion/INSTRUCTIVO_AUDIO_Y_TELEPROMPTER.md)
   * Configuración paso a paso de **QPrompt** (teleprompter a 149 ppm) y **Audacity** (48 kHz / 24 bits, cadena de compresión, ecualización y normalización a -14 LUFS).
   * **Checklist completo de archivos `.wav`** diferenciado para Juan Alvarez y Geffrey.
3. 🎬 **Guion Definitivo de Producción (80 Beats):** [`01_guion/guion_definitivo.md`](01_guion/guion_definitivo.md)
   * Formato técnico dos columnas (Visual / Motion Graphics vs. Locución y Cámara).
   * Versión machine-readable para animación y subtítulos: [`01_guion/script.json`](01_guion/script.json).
4. 🛠️ **Registro de Skills y Tecnologías Abiertas:** [`INF-SKILLS.md`](INF-SKILLS.md)
   * Explicación de las herramientas 100% de código abierto usadas (Motion Canvas, Remotion, SVG Animation, Fact-Checking y Vox-Explainer).

---

## 🗺️ Mapa de Estructura del Repositorio

```text
proyecto-particulas-cosmologia/
├── README.md                              # Documento principal y estado del proyecto
├── INSTRUCCIONES.md                       # Plan maestro para agentes y autores
├── INF-SKILLS.md                          # Registro de skills y herramientas open source
├── 00_investigacion/
│   ├── candidatos.md                      # Evaluación inicial de candidatos
│   ├── fact_check_report.md               # Auditoría formal de fact-checking y fuentes primarias
│   ├── conceptos/                         # Fichas de conceptos físicos y límites de analogías
│   └── personajes/                        # Fichas verificadas con DOIs, citas y contactos
│       ├── diego_restrepo.md              # Dr. Diego Restrepo (UdeA)
│       ├── andres_plazas_malagon.md       # Dr. Andrés Plazas Malagón (SLAC / Stanford)
│       ├── juan_carlos_sanabria.md        # Dr. Juan Carlos Sanabria (Uniandes / ACCEFYN)
│       └── leonardo_castaneda.md          # Dr. Leonardo Castañeda (OAN / UNAL)
├── 01_guion/
│   ├── escaleta.md                        # Estructura minuto a minuto (00:00 - 15:00)
│   ├── guion_v1.md                        # Borrador inicial de guion
│   ├── guion_definitivo.md                # Guion maestro definitivo de 80 beats
│   ├── script.json                        # Guion estructurado para TTS, subtítulos y animación
│   ├── preguntas_entrevista.md            # Cuestionarios y cartas de contacto institucional
│   └── teleprompter/                      # Archivos de texto limpios para QPrompt / Audacity
│       ├── B0_cold_open.txt               # Bloque 0: Cold open & gancho
│       ├── B1_tablero_juego.txt           # Bloque 1: El tablero del 95% invisible
│       ├── B2_diego_restrepo.txt          # Bloque 2: Acto I (Diego Restrepo)
│       ├── B3_andres_plazas.txt           # Bloque 3: Acto II (Andrés Plazas)
│       ├── B4_juan_carlos_sanabria.txt    # Bloque 4: Acto III (J. C. Sanabria)
│       ├── B5_leonardo_castaneda.txt      # Bloque 5: Acto IV (Leonardo Castañeda)
│       └── B6_cierre_outro.txt            # Bloque 6: Cierre y llamada a la acción
├── 02_assets/
│   ├── licencias.csv                      # Registro de derechos de autor y atribuciones
│   ├── archivo_publico/                   # B-roll y fotos de archivo (CERN, Rubin, UNAL, UdeA)
│   ├── animaciones/                       # Renders de Motion Canvas y SVG
│   ├── graficos/                          # Elementos visuales y diagramas
│   ├── musica/                            # Bandas sonoras instrumentales libres
│   ├── sfx/                               # Efectos de sonido (whooshes, pops, clics)
│   └── locucion/                          # Tomas de audio grabadas por Juan Alvarez y Geffrey
├── 03_produccion/
│   ├── INSTRUCTIVO_AUDIO_Y_TELEPROMPTER.md # Guía técnica de grabación y checklist de tomas
│   ├── plan_rodaje.md                     # Cronograma de rodaje, utilería y setup de luces
│   └── autorizaciones/                    # Cartas de cesión de imagen y permisos
├── 04_edicion/
│   ├── proyectos/                         # Archivos de proyecto (DaVinci Resolve / Premiere)
│   ├── proxies/                           # Archivos ligeros de edición
│   └── exports/                           # Cortes preliminares y exportaciones
└── 05_publicacion/
    ├── metadatos_youtube.md               # Títulos, descripción con capítulos y tags
    ├── miniaturas/                        # Diseños de portada (CTR optimizado)
    └── subtitulos/                        # Archivos de subtítulos (.srt / .ass)
```

---

## ✅ Checklist General del Proyecto

### Fase 1: Investigación y Rigor Científico
- [x] Selección y filtrado de candidatos (descarte de falsos positivos como Camila Correa).
- [x] Verificación de papers en INSPIRE-HEP con DOIs y citas reales.
- [x] Creación de fichas biográficas y científicas en `00_investigacion/personajes/`.
- [x] Fichas de investigación conceptual exhaustiva en `00_investigacion/conceptos/` (5 conceptos clave).
- [x] Auditoría formal con la skill `fact-check-workflow` en `00_investigacion/fact_check_report.md`.
- [x] Auditoría de alineación conceptual vs guion en `00_investigacion/auditoria_alineacion_guion.md`.
- [x] Identificación de material audiovisual público y canales oficiales en YouTube.

### Fase 2: Guionización y Narrativa Audiovisual
- [x] Diseño de la escaleta maestra cronometrada a 15:00 exactos (`01_guion/escaleta.md`).
- [x] Redacción del primer borrador en dos columnas (`01_guion/guion_v1.md`).
- [x] Refinamiento con la skill `vox-explainer` en 80 beats secuenciales (`01_guion/guion_definitivo.md`).
- [x] Generación del esquema estructurado `01_guion/script.json`.
- [x] Adaptación de archivos limpios para teleprompter diferenciados para **Juan Alvarez** y **Geffrey** (`01_guion/teleprompter/`).
- [x] Creación de cuestionarios y plantillas de correo formal para los científicos (`01_guion/preguntas_entrevista.md`).

### Fase 3: Preproducción y Setup Técnico
- [x] Estructuración completa de carpetas del repositorio con archivos de control `.gitkeep`.
- [x] Creación de la matriz de licencias y atribuciones (`02_assets/licencias.csv`).
- [x] Elaboración del plan de rodaje, lista de utilería y esquema de iluminación (`03_produccion/plan_rodaje.md`).
- [x] Creación de la guía técnica de grabación en Audacity y teleprompter con QPrompt (`03_produccion/INSTRUCTIVO_AUDIO_Y_TELEPROMPTER.md`).
- [x] Definición del subagente especializado de animación: `motion-graphics-animator`.
- [ ] Enviar correos de contacto a los cuatro científicos (o sus departamentos) para solicitar entrevistas o visto bueno.
- [ ] Descargar los clips de metraje público libre catalogados en `licencias.csv` a `02_assets/archivo_publico/`.
- [ ] Desarrollar los códigos procedurales de animación en Motion Canvas / HTML5 Canvas / SVG (MG-01 a MG-07).

### Fase 4: Producción y Rodaje
- [ ] Grabar las pistas de voz de **Juan Alvarez** (`B0` a `B6`) siguiendo el checklist de audio en Audacity.
- [ ] Grabar las pistas de voz de **Geffrey** (`B0` a `B6`) siguiendo el checklist de audio en Audacity.
- [ ] Grabar las escenas a cámara de ambos presentadores en el set según `03_produccion/plan_rodaje.md`.
- [ ] Procesar y limpiar los audios a -14 LUFS (o pasarlos por Adobe Podcast Enhance) y guardarlos en `02_assets/locucion/`.

### Fase 5: Postproducción y Montaje
- [ ] Sincronizar audio de locución con clips de video y B-roll en el software de edición (DaVinci Resolve / Premiere).
- [ ] Integrar las animaciones de Motion Canvas y gráficos vectoriales sobre el guion de 80 beats.
- [ ] Mezcla sonora: música de fondo a -15 dB bajo voz, efectos sonoros (SFX) y transiciones.
- [ ] Control de calidad y revisión de continuidad contra el guion y el reporte de fact-check.
- [ ] Exportar corte final en resolución 1080p o 4K a 30 fps.

### Fase 6: Publicación y Difusión
- [x] Redacción de metadatos de YouTube (opciones de títulos, descripción con timestamps y tags) en `05_publicacion/metadatos_youtube.md`.
- [ ] Diseño de 3 conceptos de miniatura de alto contraste en `05_publicacion/miniaturas/`.
- [ ] Generación y sincronización de subtítulos `.srt` en español neutro.
- [ ] Publicación del video en YouTube y difusión en facultades de física, colegios y redes científicas.
