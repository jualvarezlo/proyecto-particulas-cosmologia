# El 95% Invisible: Cuatro Colombianos en la Frontera del Universo

> **Video documental de divulgación científica (15 minutos / 80 beats secuenciales)**  
> Estilo: *Quantum Fracture* (animaciones vectoriales rigurosas y analogías) + *Date un Vlog* (ritmo, cercanía a cámara y humor ligero).  
> Autores y Presentadores: **Juan Alvarez** y **Geffrey**.

---

## 📌 ¿Dónde leer las instrucciones del proyecto?

Para entender cómo está estructurado el proyecto y cómo ejecutar cada fase de trabajo, consulta estos documentos clave:

1. 📖 **Plan Maestro y Guía de Roles:** [`INSTRUCCIONES.md`](INSTRUCCIONES.md)
   * Contiene la visión general, división de trabajo entre **Agentes de IA** y **Autores Humanos**, flujo de producción de 9 semanas, criterios de calidad y las **Reglas 1 a 10** de producción.
2. 🗂️ **Índice Maestro de Assets (57 Assets Registrados):** [`02_assets/INDICE_DE_ASSETS.md`](02_assets/INDICE_DE_ASSETS.md) / [`02_assets/indice_assets.json`](02_assets/indice_assets.json)
   * Catálogo unificado y matriz beat por beat (Beats 01 a 80) para el subagente de animación y editores.
3. 🎙️ **Instructivo de Grabación y Teleprompter:** [`02_assets/locucion/INSTRUCTIVO_AUDIO_Y_TELEPROMPTER.md`](02_assets/locucion/INSTRUCTIVO_AUDIO_Y_TELEPROMPTER.md)
   * Configuración paso a paso de **QPrompt** (teleprompter a 149 ppm) y **Audacity** (48 kHz / 24 bits, cadena de compresión, ecualización y normalización a -14 LUFS).
   * **Checklist completo de archivos `.wav`** diferenciado para Juan Alvarez y Geffrey.
4. 🎬 **Guion Definitivo de Producción (80 Beats):** [`01_guion/guion_definitivo.md`](01_guion/guion_definitivo.md)
   * Formato técnico dos columnas (Visual / Motion Graphics vs. Locución y Cámara).
   * Versión machine-readable para animación y subtítulos: [`01_guion/script.json`](01_guion/script.json).
5. 🛠️ **Registro de Skills y Tecnologías Abiertas:** [`INF-SKILLS.md`](INF-SKILLS.md)
   * Explicación de las herramientas 100% de código abierto usadas (Motion Canvas, Remotion, SVG Animation, Fact-Checking y Vox-Explainer).

---

## 🗺️ Mapa de Estructura del Repositorio

```text
proyecto-particulas-cosmologia/
├── README.md                              # Documento principal y estado del proyecto
├── INSTRUCCIONES.md                       # Plan maestro para agentes y autores (Reglas 1 a 10)
├── INF-SKILLS.md                          # Registro de skills y herramientas open source
├── 00_investigacion/
│   ├── candidatos.md                      # Evaluación inicial de candidatos
│   ├── fact_check_report.md               # Auditoría formal de fact-checking y fuentes primarias
│   ├── auditoria_alineacion_guion.md      # Alineación conceptual vs guion de 80 beats
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
│   ├── INDICE_DE_ASSETS.md                # Índice maestro y matriz beat a beat (57 assets)
│   ├── indice_assets.json                 # Catálogo estructurado para subagentes y pipeline
│   ├── licencias.csv                      # Registro completo de derechos de autor y atribuciones
│   ├── archivo_publico/                   # 16 clips y fotos de archivo (CERN, NASA, Rubin, UNAL, UdeA)
│   ├── animaciones/                       # Renders de Motion Canvas y SVG
│   ├── graficos/                          # 27 assets: retratos oficiales, mapas geodésicos, sellos y props
│   ├── musica/                            # Bandas sonoras calibradas a -15 dB bajo voz (WAV master y MP3)
│   ├── sfx/                               # 11 efectos de sonido diseñados (impactos, pops, sonar)
│   ├── referencias_reales/                # Fotografías de referencia de los cuatro científicos
│   └── locucion/                          # Instructivo y tomas de audio grabadas
├── 03_produccion/
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

### Fase 3: Preproducción y Setup Técnico (100% Completada)
- [x] Estructuración completa de carpetas del repositorio con archivos de control `.gitkeep`.
- [x] Creación y actualización integral de la matriz de licencias y atribuciones (`02_assets/licencias.csv` - 57 assets).
- [x] Elaboración del plan de rodaje, lista de utilería y esquema de iluminación (`03_produccion/plan_rodaje.md`).
- [x] Creación de la guía técnica de grabación en Audacity y teleprompter con QPrompt (`02_assets/locucion/INSTRUCTIVO_AUDIO_Y_TELEPROMPTER.md`).
- [x] Definición formal del subagente especializado `animador-motion-graphics` con la **Regla 10** (consulta obligatoria del índice de assets antes de animar cada beat).
- [x] Adquisición y verificación del 100% de clips y fotografías de archivo público (`02_assets/archivo_publico/` - 16/16 assets: NASA, Wikimedia, SLAC, FAAE, CERN y yt-dlp).
- [x] Generación de 12 gráficos editoriales, portadas de tesis, papers históricos y retratos oficiales recortados (`02_assets/graficos/` - `GRAF-01` a `GRAF-12`).
- [x] Renderizado de 3 mapas infográficos geodésicos en triple formato JPG 1080p, PNG y SVG vectorial (`02_assets/graficos/` - `MAPA-01` a `MAPA-03`).
- [x] Diseño y renderizado de 10 sellos de advertencia en ámbar solar, sellos de pasaporte vintage y sellos institucionales (`02_assets/graficos/` - `SELLO-01` a `SELLO-10`).
- [x] Elaboración de utilería y etiquetas a cámara (`02_assets/graficos/` - `PROP-01` frasco de Materia Oscura y `PROP-02` pasaporte científico).
- [x] Selección, descarga y calibración sonora de la banda sonora instrumental libre a -15 dB bajo voz en 48 kHz / 24-bit PCM WAV y MP3 320 kbps (`02_assets/musica/` - `MUS-01` a `MUS-03`, incluyendo versión extended loop de 11 min).
- [x] Diseño y calibración de 11 efectos sonoros (`02_assets/sfx/` - `SFX-01` a `SFX-11`).
- [x] Creación del Índice Maestro de Assets Audiovisuales y matriz beat a beat (`02_assets/INDICE_DE_ASSETS.md` y `02_assets/indice_assets.json`).
- [ ] Enviar correos de contacto a los cuatro científicos (o sus departamentos) para solicitar entrevistas o visto bueno.
- [ ] Desarrollar los códigos procedurales de animación en Motion Canvas / HTML5 Canvas / SVG (MG-01 a MG-07).

#### 📦 Resumen de los 57 Assets Audiovisuales Registrados

| Categoría | Total | Directorio | Formatos | Estado |
| :--- | :---: | :--- | :--- | :---: |
| **A. Archivo Público y B-Roll** | 16 | `02_assets/archivo_publico/` | MP4 (1080p), JPG (4K) | [x] 100% Listo |
| **B. Retratos y Editorial** | 12 | `02_assets/graficos/` | JPG (1080p) | [x] 100% Listo |
| **C. Mapas Infográficos Geodésicos** | 3 | `02_assets/graficos/` | JPG, PNG, SVG | [x] 100% Listo |
| **D. Sellos de Advertencia y Pasaportes** | 10 | `02_assets/graficos/` | PNG transparente, SVG | [x] 100% Listo |
| **E. Utilería a Cámara (Props)** | 2 | `02_assets/graficos/` | JPG, PNG | [x] 100% Listo |
| **F. Efectos de Sonido (SFX)** | 11 | `02_assets/sfx/` | WAV (48 kHz / 24-bit) | [x] 100% Listo |
| **G. Música Instrumental Calibrada** | 3 | `02_assets/musica/` | WAV Master & Calibrada -15dB, MP3 | [x] 100% Listo |
| **Total General** | **57** | `02_assets/` | Multi-formato profesional | **100% Operativo** |

### Fase 4: Producción y Rodaje
- [ ] Grabar las pistas de voz de **Juan Alvarez** (`B0` a `B6`) siguiendo el instructivo de audio en Audacity.
- [ ] Grabar las pistas de voz de **Geffrey** (`B0` a `B6`) siguiendo el instructivo de audio en Audacity.
- [ ] Grabar las escenas a cámara de ambos presentadores en el set según `03_produccion/plan_rodaje.md`.
- [ ] Procesar y limpiar los audios a -14 LUFS (o pasarlos por Adobe Podcast Enhance) y guardarlos en `02_assets/locucion/`.

### Fase 5: Postproducción y Montaje
- [ ] Sincronizar audio de locución con clips de video y B-roll en el software de edición (DaVinci Resolve / Premiere).
- [ ] Integrar las animaciones de Motion Canvas y gráficos vectoriales sobre el guion de 80 beats utilizando [`02_assets/INDICE_DE_ASSETS.md`](02_assets/INDICE_DE_ASSETS.md).
- [ ] Cargar pistas musicales pre-calibradas (`_calibrada_-15dB.wav`) manteniendo ganancia a 1.0 (sin necesidad de atenuación manual).
- [ ] Montaje de capas de efectos de sonido (`02_assets/sfx/`).
- [ ] Control de calidad y revisión de continuidad contra el guion y el reporte de fact-check (Regla 9: cero metadatos en pantalla).
- [ ] Exportar corte final en resolución 1080p o 4K a 30 fps.

### Fase 6: Publicación y Difusión
- [x] Redacción de metadatos de YouTube (opciones de títulos, descripción con timestamps y tags) en `05_publicacion/metadatos_youtube.md`.
- [ ] Diseño de 3 conceptos de miniatura de alto contraste en `05_publicacion/miniaturas/`.
- [ ] Generación y sincronización de subtítulos `.srt` en español neutro.
- [ ] Publicación del video en YouTube y difusión en facultades de física, colegios y redes científicas.

---

## 🎬 Checklist de Producción Beat por Beat (80 Beats)

> **Regla de Agentes:** Siempre que un agente finalice la animación, edición o renderizado de un beat (o bloque de beats), **DEBE actualizar inmediatamente esta checklist** marcando la casilla correspondiente (`[x]`) y detallando el archivo generado.
> **Consulta previa obligatoria:** Todo beat con assets asignados debe consumirlos desde `02_assets/` según [`02_assets/INDICE_DE_ASSETS.md`](02_assets/INDICE_DE_ASSETS.md).

### Bloque 0: Cold Open & Hook (00:00 - 01:00 | Beats 01 a 06)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 01** | `00:00-00:11` | `COLLAGE` | En este preciso segundo, cien mil millones de partículas invisibles nacidas en el ... | Human hand as paper cutout; diagonal beam 📥 [Assets: `01_sol_sdo_flares.mp4` + `hum_subatomico.wav`] |
| [ ] | **Beat 02** | `00:11-00:22` | `CAM_1` | Al mismo tiempo, en la cima de un cerro en los Andes chilenos, una cámara digital ... | Presenter 1 on camera; paper cutout overlay 📥 [Asset: `02_rubin_lsst_camera_slac.jpg`] |
| [ ] | **Beat 03** | `00:22-00:32` | `COLLAGE` | Y a cien metros bajo tierra, en la frontera entre Francia y Suiza, un detector de ... | Cross-section editorial collage cavern 📥 [Assets: `03_cern_cms_cavern_broll.jpg` + `pulso_cern.wav`] |
| [ ] | **Beat 04** | `00:32-00:42` | `CAM_2` | Parecen postales de otro planeta. Pero detrás de esos tres experimentos, y de las ... | Presenter 2 on camera; background collage map 📥 [Asset: `mapa_convergencia_global_colombia.jpg`] |
| [ ] | **Beat 05** | `00:42-00:52` | `COLLAGE` | Para entender cómo la física moderna intenta descifrar el noventa y cinco por cien... | Four portrait paper cutouts pinned with washi tape 📥 [Assets: `retrato_*.jpg` (4) + `sello_golpe.wav`] |
| [ ] | **Beat 06** | `00:52-01:00` | `MG_INTRO` | Esta es la historia de cuatro científicos colombianos que decidieron mirar donde n... | Full-screen editorial title card 📥 [Música: `01_intro_the_dread_calibrada_-15dB.wav`] |

### Bloque 1: El Tablero de Juego — El 95% Invisible (01:00 - 02:30 | Beats 07 a 14)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 07** | `01:00-01:12` | `CAM_1` | Antes de conocerlos, necesitamos entender el tamaño del problema al que se enfrent... | Presenter 1 in dimly lit set striking a match 📥 [SFX: `fosforo_strike.wav`] |
| [ ] | **Beat 08** | `01:12-01:23` | `COLLAGE` | Suena ridículo, pero esa es la situación exacta de la física actual. Todo lo que c... | Torn-paper pie chart on cream board: 5% vs 95% 📥 [SFX: `papel_rasgado.wav`] |
| [ ] | **Beat 09** | `01:23-01:35` | `COLLAGE` | Del resto, cerca del veintisiete por ciento es materia oscura: un pegamento gravit... | The 95% disk splits into textured paper layers 📥 [Asset: `04_hubble_jwst_gravitational_lensing.jpg`] |
| [ ] | **Beat 10** | `01:35-01:46` | `CAM_2` | Para atacar este misterio, la humanidad solo tiene dos caminos. El primero es mira... | Presenter 2 on camera with floating collage card 📥 [SFX: `pop_acordeon.wav`] |
| [ ] | **Beat 11** | `01:46-01:58` | `COLLAGE` | El Modelo Estándar es la teoría más exitosa jamás escrita. Describe diecisiete par... | Grid of 17 Standard Model particle tiles on cream paper |
| [ ] | **Beat 12** | `01:58-02:10` | `CAM_2` | El segundo camino es mirar lo infinitamente grande: la cosmología y la Relatividad... | Presenter 2 on camera; archival 1919 Einstein cutout 📥 [Asset: `einstein_curvatura.jpg`] |
| [ ] | **Beat 13** | `02:10-02:20` | `COLLAGE` | Durante décadas, partículas y cosmología parecían dos mundos separados. Hoy sabemo... | Two torn paper halves joined by a strip of washi tape |
| [ ] | **Beat 14** | `02:20-02:30` | `CAM_1` | Y nuestro primer protagonista descubrió que dos de las piezas más esquivas de ese ... | Presenter 1 gesturing toward camera with chapter title overlay |

### Bloque 2: Acto I — Diego Restrepo y el Fantasma que Pesa (02:30 - 05:30 | Beats 15 a 30)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 15** | `02:30-02:41` | `COLLAGE` | Ciudad Universitaria de Medellín, bloque seis, oficina cuatrocientos quince. Aquí,... | Paper cutout of UdeA Physics Institute building 📥 [Assets: `retrato_diego_restrepo.jpg`, `05_udea_campus_facultad.jpg`, `06_particulas_valle_restrepo.mp4`] |
| [ ] | **Beat 16** | `02:41-02:52` | `COLLAGE` | Formado en esta misma universidad pública y doctorado en el Instituto de Física Co... | Dotted flight path Medellin - Valencia 📥 [Assets: `mapa_vuelo_medellin_valencia.jpg`, `portada_tesis_restrepo_2001.jpg`] |
| [ ] | **Beat 17** | `02:52-03:03` | `CAM_1` | Consolida en Medellín el Grupo de Fenomenología de Interacciones Fundamentales, un... | Presenter 1 on camera with GFIF UdeA 📥 [Assets: `sello_institucional_udea.png`, `sello_minciencias_a1.png`] |
| [ ] | **Beat 18** | `03:03-03:15` | `COLLAGE` | Cuando los arquitectos del Modelo Estándar escribieron sus ecuaciones en el siglo ... | Engraved-style illustration of a precision laboratory scale on cream paper |
| [ ] | **Beat 19** | `03:15-03:27` | `COLLAGE` | Pero la naturaleza tenía guardada una sorpresa. En mil novecientos noventa y ocho,... | Three paper circles labeled electron, muon, and tau neutrino |
| [ ] | **Beat 20** | `03:27-03:38` | `CAM_1` | Y según las leyes de la mecánica cuántica, si una partícula cambia con el paso del... | Presenter 1 holding a ticking mechanical metronome on desk |
| [ ] | **Beat 21** | `03:38-03:50` | `COLLAGE` | Es la primera grieta real en el Modelo Estándar. Una masa millones de veces más li... | Monolith paper cutout MODELO ESTÁNDAR 📥 [SFX: `grieta_monolito.wav`] |
| [ ] | **Beat 22** | `03:50-04:02` | `COLLAGE` | En agosto de dos mil trece, Diego Restrepo, junto a sus colegas colombianos Óscar ... | Cutout of JHEP 11 (2013) 011 paper 📥 [Asset: `paper_escotogenico_restrepo.jpg`] |
| [ ] | **Beat 23** | `04:02-04:14` | `CAM_1` | Su pregunta de partida es de una elegancia brutal. Tenemos dos misterios sin resol... | Presenter 1 bringing two paper cards ('Masa del Neutrino' and 'Materia Oscura') |
| [ ] | **Beat 24** | `04:14-04:26` | `COLLAGE` | En física teórica, esto se conoce como mecanismo escotogénico, una palabra que vie... | Clean Feynman diagram on cream blueprint paper |
| [ ] | **Beat 25** | `04:26-04:38` | `COLLAGE` | En este escenario, el neutrino no adquiere masa de forma directa. La adquiere a tr... | Close-up of Feynman loop showing scalar and fermion lines |
| [ ] | **Beat 26** | `04:38-04:50` | `CAM_1` | Imagínalo así: el neutrino es como un corredor que por sí solo no siente resistenc... | Presenter 1 on camera with side animation of runner and glowing baton |
| [ ] | **Beat 27** | `04:50-05:01` | `CAM_1` | Ahora, cuidado con el límite de la analogía. No es un roce físico ni hay fricción ... | Presenter 1 with amber stamp overlay 📥 [Asset: `sello_limite_analogia.png`] |
| [ ] | **Beat 28** | `05:01-05:12` | `COLLAGE` | Restrepo y su equipo clasificaron sistemáticamente treinta y cinco modelos distint... | Grid of 35 small numbered Feynman diagram cards 📥 [SFX: `clics_cascada.wav`] |
| [ ] | **Beat 29** | `05:12-05:22` | `COLLAGE` | Además de su trabajo teórico, Restrepo hoy lidera el proyecto Colav y la plataform... | Cutout from 'Particulas en el Valle' 📥 [Assets: `06_particulas_valle_restrepo.mp4`, `sello_institucional_udea.png`] |
| [ ] | **Beat 30** | `05:22-05:30` | `CAM_2` | Pero proponer de qué está hecha la materia oscura en el papel es solo la mitad de ... | Presenter 2 on camera transitioning to Act II |

### Bloque 3: Acto II — Andrés Plazas Malagón y los Ojos del Gigante (05:30 - 08:30 | Beats 31 a 46)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 31** | `05:30-05:41` | `COLLAGE` | Bogotá, año dos mil. Un joven recién graduado del Colegio Salesiano de León Trece ... | Collage of Bogota skyline, Colegio Salesiano badge 📥 [Assets: `formulario_matricula_plazas.jpg`, `10_big_astronomy_andres_plazas.mp4` + `pluma_tinta.wav`] |
| [ ] | **Beat 32** | `05:41-05:52` | `CAM_2` | Su nombre es Andrés Alejandro Plazas Malagón. En su primer semestre inscribe una c... | Presenter 2 on camera with newspaper cutout quote from DES Scientist |
| [ ] | **Beat 33** | `05:52-06:03` | `COLLAGE` | Lector devoto de Gabriel García Márquez y Jorge Luis Borges, fanático del fútbol, ... | Portrait cutout Andres Plazas, Fermi map 📥 [Assets: `mapa_vuelo_bogota_fermilab.jpg`, `07_fermilab_wilson_hall.jpg`, `retrato_andres_plazas.jpg`] |
| [ ] | **Beat 34** | `06:03-06:15` | `COLLAGE` | Allí entra en contacto con el proyecto que definirá su carrera doctoral en la Univ... | Starfield panel inside cream frame; cyan light rays 📥 [Assets: `04_hubble_jwst_gravitational_lensing.jpg` + `refraccion_lente.wav`] |
| [ ] | **Beat 35** | `06:15-06:27` | `CAM_2` | La idea física es fascinante. Como la materia oscura tiene gravedad, dobla la luz ... | Presenter 2 holding an optical lens in front of a grid of dots |
| [ ] | **Beat 36** | `06:27-06:39` | `COLLAGE` | Si miras una sola galaxia, no notas nada porque sabe Dios qué forma tenía original... | Field of galaxy ellipses 📥 [Asset: `04_hubble_jwst_gravitational_lensing.jpg`] |
| [ ] | **Beat 37** | `06:39-06:50` | `COLLAGE` | Con ese uno por ciento, los cosmólogos pueden reconstruir el mapa tridimensional d... | 3D cosmic web map cutout 📥 [SFX: `sonar_alerta.wav`] |
| [ ] | **Beat 38** | `06:50-07:02` | `CAM_2` | Cuando buscas una señal de apenas el uno por ciento, el enemigo ya no está en el c... | Presenter 2 tight medium close-up looking directly into the lens |
| [ ] | **Beat 39** | `07:02-07:14` | `COLLAGE` | Plazas se convierte en un detective de detectores. En sus artículos de dos mil cat... | Archival photo cutout of 62 golden CCD array 📥 [Asset: `08_decam_focal_plane.jpg`] |
| [ ] | **Beat 40** | `07:14-07:26` | `COLLAGE` | Uno de los villanos principales que ayuda a domar se llama efecto Brighter-Fatter:... | Side-by-side comparison on cream grid paper: sharp star vs swollen spot |
| [ ] | **Beat 41** | `07:26-07:38` | `COLLAGE` | Para entender por qué ocurre, piensa que cada píxel del sensor es un balde recogie... | Cross-section diagram of CCD pixel buckets |
| [ ] | **Beat 42** | `07:38-07:49` | `CAM_2` | Límite de la analogía: el agua se desborda solo cuando llega al borde físico del b... | Presenter 2 on camera with stamp overlay 📥 [Asset: `sello_limite_analogia.png`] |
| [ ] | **Beat 43** | `07:49-08:01` | `COLLAGE` | Por este trabajo pionero corrigiendo errores sistemáticos para usar lentes débiles... | Official award record FAAE 2016 📥 [Asset: `09_premio_faae_plazas_2016.svg`] |
| [ ] | **Beat 44** | `08:01-08:13` | `COLLAGE` | Hoy, desde el laboratorio SLAC de la Universidad de Stanford y el instituto KIPAC,... | Cutout giant LSST Camera 📥 [Assets: `02_rubin_lsst_camera_slac.jpg`, `10_big_astronomy_andres_plazas.mp4`] |
| [ ] | **Beat 45** | `08:13-08:23` | `COLLAGE` | Y en su tiempo libre, junto a la astrofísica colombiana Clara Inés Barbosa, conduc... | Official logo 'Visión Cósmica' 📥 [Asset: `podcast_vision_cosmica.jpg`] |
| [ ] | **Beat 46** | `08:23-08:30` | `CAM_1` | Pero si mirar el cielo desde los Andes requiere ojos perfectos, recrear el Big Ban... | Presenter 1 on camera introducing Act III |

### Bloque 4: Acto III — Juan Carlos Sanabria y la Máquina de Dios (08:30 - 11:30 | Beats 47 a 62)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 47** | `08:30-08:41` | `COLLAGE` | Nuestra tercera historia nace en Chiquinquirá, en las montañas de Boyacá. Allí cre... | Collage map of Boyaca, portrait Sanabria 📥 [Assets: `retrato_juan_carlos_sanabria.jpg`, `sello_institucional_accefyn.png`] |
| [ ] | **Beat 48** | `08:41-08:52` | `COLLAGE` | En la Universidad de los Andes toma una decisión poco común: cursa simultáneamente... | Two intersecting paper badges (Physics + Electrical Engineering) |
| [ ] | **Beat 49** | `08:52-09:04` | `CAM_1` | Esa doble formación como ingeniero y físico experimental resulta ser el pasaporte ... | Three vintage passport stamps land in sequence 📥 [Assets: `pasaporte_cientifico_sanabria.jpg`, `sello_pasaporte_*.png` (3) + `sello_golpe.wav`] |
| [ ] | **Beat 50** | `09:04-09:16` | `COLLAGE` | A mediados de los años dos mil, el grupo de altas energías de la Universidad de lo... | Archival CERN photo cutout open CMS cavern 📥 [Assets: `03_cern_cms_cavern_broll.jpg`, `sello_universidad_mainz.png`] |
| [ ] | **Beat 51** | `09:16-09:28` | `COLLAGE` | En este anillo de veintisiete kilómetros, dos haces de protones chocan de frente c... | Diagram of 27 km LHC ring on blueprint grid 📥 [Asset: `11_cern_lhc_tunnel.jpg`] |
| [ ] | **Beat 52** | `09:28-09:40` | `CAM_1` | Ahora, piensa en el desafío de ingeniería. Cuarenta millones de colisiones por seg... | Presenter 1 gesturing wide as stacks of archival hard-drive cutouts pile up |
| [ ] | **Beat 53** | `09:40-09:52` | `COLLAGE` | El detector necesita un filtro ultrarrápido llamado sistema de Trigger, y cámaras ... | Cross-section wedge of CMS detector highlighting RPC muon chambers 📥 [Asset: `03_cern_cms_cavern_broll.jpg`] |
| [ ] | **Beat 54** | `09:52-10:03` | `CAM_1` | Es como tener un portero de seguridad con reflejos sobrehumanos que, en millonésim... | Presenter 1 snaps fingers; corner stamp 📥 [Asset: `sello_limite_analogia.png`] |
| [ ] | **Beat 55** | `10:03-10:15` | `COLLAGE` | Gracias a esa cacería colectiva de miles de científicos, en julio de dos mil doce ... | CMS mass plot showing 125 GeV Higgs peak 📥 [Assets: `12_cms_higgs_event_display.jpg` + `pulso_cern.wav`] |
| [ ] | **Beat 56** | `10:15-10:27` | `COLLAGE` | Dos años después, al posesionarse en la Academia Colombiana de Ciencias Exactas, F... | ACCEFYN emblem cutout 📥 [Asset: `sello_institucional_accefyn.png`] |
| [ ] | **Beat 57** | `10:27-10:39` | `CAM_1` | En una entrevista con el diario El Tiempo, Sanabria lo resumía con total honestida... | Presenter 1 on camera with verified quote cutout from El Tiempo newspaper |
| [ ] | **Beat 58** | `10:39-10:51` | `COLLAGE` | Esa urgencia por compartir las grandes preguntas lo llevó a escribir una trilogía ... | Three book cover cutouts 📥 [Assets: `trilogia_libros_sanabria.jpg`, `13_uniandes_presentacion_sanabria.mp4`] |
| [ ] | **Beat 59** | `10:51-11:03` | `COLLAGE` | En Espías nucleares, presentado en la Academia de Ciencias, reconstruye cómo el es... | Editorial collage Los Alamos files 📥 [Assets: `13_uniandes_presentacion_sanabria.mp4`, `sello_institucional_accefyn.png`] |
| [ ] | **Beat 60** | `11:03-11:15` | `CAM_1` | Sanabria suele decir que la ciencia, si no se comunica, carece de sentido. Y que u... | Presenter 1 on camera 📥 [Asset: `sello_minciencias_a1.png`] |
| [ ] | **Beat 61** | `11:15-11:23` | `CAM_2` | Ahora, quédate con la frase que dijo hace un momento: donde todo el mundo está más... | Presenter 2 medium shot |
| [ ] | **Beat 62** | `11:23-11:30` | `CAM_2` | Porque nuestro cuarto científico se hizo la pregunta más atrevida de todas: ¿y si ... | Presenter 2 looking straight into lens with chapter transition graphic |

### Bloque 5: Acto IV — Leonardo Castañeda y el Tablero Roto de Einstein (11:30 - 14:00 | Beats 63 a 75)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 63** | `11:30-11:42` | `COLLAGE` | Fundado en mil ochocientos tres por José Celestino Mutis, el Observatorio Astronóm... | Collage historic 1803 dome 📥 [Assets: `14_oan_cupula_historica_1803.jpg`, `retrato_leonardo_castaneda.jpg`, `sello_institucional_unal.png`] |
| [ ] | **Beat 64** | `11:42-11:53` | `COLLAGE` | Físico y magíster de la Universidad Nacional, con un doctorado en ciencias natural... | Seals of UNAL and Johannes Gutenberg Mainz 📥 [Assets: `sello_institucional_unal.png`, `sello_universidad_mainz.png`] |
| [ ] | **Beat 65** | `11:53-12:05` | `CAM_2` | Para entender su trabajo, recordemos la joya de la corona de Einstein: las ecuacio... | Presenter 2 on camera with Einstein-Hilbert action integral |
| [ ] | **Beat 66** | `12:05-12:17` | `COLLAGE` | Pero cuando aplicamos esa misma ecuación al universo entero, aparece el problema: ... | Two mathematical balance scales on cream paper |
| [ ] | **Beat 67** | `12:17-12:29` | `COLLAGE` | Castañeda explora ese segundo camino, conocido como gravedad modificada efe de err... | The Ricci scalar R expands into generic f(R) function |
| [ ] | **Beat 68** | `12:29-12:41` | `CAM_2` | Piensa en el espacio-tiempo como una tela elástica. En la teoría de Einstein, la t... | Presenter 2 holding a stretched fabric swatch |
| [ ] | **Beat 69** | `12:41-12:52` | `CAM_2` | Límite importante de la analogía: el espacio-tiempo tiene cuatro dimensiones y no ... | Presenter 2 with solar amber stamp overlay 📥 [Asset: `sello_limite_analogia.png`] |
| [ ] | **Beat 70** | `12:52-13:05` | `COLLAGE` | Pero modificar las ecuaciones de Einstein tiene un precio matemático altísimo. En ... | Cutout of paper 'Boundary Term in Metric f(R) Gravity' 📥 [Asset: `paper_castaneda_termino_frontera.jpg`] |
| [ ] | **Beat 71** | `13:05-13:18` | `COLLAGE` | En ese trabajo deducen las ecuaciones de campo directamente en el formalismo métri... | Isometric 3D spacetime manifold block on blueprint paper |
| [ ] | **Beat 72** | `13:18-13:30` | `CAM_2` | Imagina la contabilidad de un banco. Si auditas solo el dinero que se mueve entre ... | Presenter 2 framing an imaginary building with his hands |
| [ ] | **Beat 73** | `13:30-13:42` | `COLLAGE` | Ese término de frontera garantiza que el principio variacional de la física sea ma... | Two parallel geodesic lines diverging as gravitational wave passes |
| [ ] | **Beat 74** | `13:42-13:52` | `COLLAGE` | Y cuando cae la noche en Bogotá, Castañeda baja de las ecuaciones a los jardines d... | Cutout from OAN lecture 'Ondas Gravitacionales' 📥 [Assets: `15_oan_jueves_estrellas_castaneda.mp4`, `sello_institucional_unal.png`] |
| [ ] | **Beat 75** | `13:52-14:00` | `CAM_2` | Como él mismo explica con humor: la gente a veces espera que le mostremos cien gra... | Presenter 2 holding glass jar '100 g de Materia Oscura' 📥 [Assets: `prop_frasco_materia_oscura.jpg`, `etiqueta_frasco_materia_oscura.png`, `15_oan_jueves_estrellas_castaneda.mp4`] |

### Bloque 6: Cierre, Conclusiones y Créditos (14:00 - 15:00 | Beats 76 a 80)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 76** | `14:00-14:12` | `COLLAGE` | Vuelve a mirar ese noventa y cinco por ciento invisible del universo con el que em... | Return to 95% dark pie chart illuminated by 4 cyan beams 📥 [Música: `03_outro_at_launch_calibrada_-15dB.wav`] |
| [ ] | **Beat 77** | `14:12-14:25` | `COLLAGE` | En Medellín, Diego Restrepo conecta la masa de los neutrinos con la materia oscura... | Full mural collage uniting all four portrait cutouts 📥 [Assets: `mural_cuatro_cientificos_beat77.jpg` + `retrato_*.jpg` (4)] |
| [ ] | **Beat 78** | `14:25-14:37` | `CAM_BOTH` | Cuatro trayectorias distintas que derriban un prejuicio antiguo: la física de fron... | Both presenters on camera in two-shot, warm lighting |
| [ ] | **Beat 79** | `14:37-14:49` | `CAM_BOTH` | Si esta historia te inspiró, suscríbete al canal, compártela y cuéntanos en los co... | Presenters gesture downward; editorial collage end-cards slide in |
| [ ] | **Beat 80** | `14:49-15:00` | `COLLAGE_OUTRO` | Porque la próxima vez que cien mil millones de neutrinos atraviesen tu mano sin ha... | Callback to hand cutout with cyan neutrino dots 📥 [Asset: `16_voyager_pale_blue_dot.jpg` + Outro fade] |
