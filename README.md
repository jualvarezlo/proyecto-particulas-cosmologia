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
- [x] Descargar los clips de metraje público libre catalogados en `licencias.csv` a `02_assets/archivo_publico/` (14 de 16 assets adquiridos con NASA, Wikimedia y yt-dlp).
- [ ] Desarrollar los códigos procedurales de animación en Motion Canvas / HTML5 Canvas / SVG (MG-01 a MG-07).


#### 📦 Inventario y Checklist de Assets Públicos Descargados (14/16)

| Estado | ID | Archivo en Disco (`02_assets/archivo_publico/`) | Beats | Fuente / Repositorio | Licencia |
| :---: | :---: | :--- | :---: | :--- | :---: |
| [x] | **ASSET-01** | `01_sol_sdo_flares.mp4` (49.2 MB) | Beat 01 | NASA SDO SVS | Dominio Público |
| [ ] | **ASSET-02** | `02_rubin_camera_arrival.mp4` | Beats 02, 44 | NOIRLab / Rubin Observatory | CC BY 4.0 |
| [x] | **ASSET-03** | `03_cern_cms_cavern_broll.jpg` (1.0 MB) | Beats 03, 50, 53 | CERN / Wikimedia Commons | CC BY 4.0 |
| [x] | **ASSET-04** | `04_hubble_jwst_gravitational_lensing.jpg` (141 KB) | Beats 09, 34, 36 | NASA JWST SMACS 0723 | Dominio Público |
| [x] | **ASSET-05** | `05_udea_campus_facultad.jpg` (404 KB) | Beat 15 | UdeA / Wikimedia Commons | CC BY-SA |
| [x] | **ASSET-06** | `06_particulas_valle_restrepo.mp4` (2.8 MB) | Beats 15, 29 | UdeA Ciencias (`yt-dlp`) | Cita Educativa |
| [x] | **ASSET-07** | `07_fermilab_wilson_hall.jpg` (320 KB) | Beat 33 | Fermilab Visual Media / Wikimedia | Dominio Público |
| [x] | **ASSET-08** | `08_decam_focal_plane.jpg` (7.4 MB) | Beat 39 | DECam / NOIRLab / Wikimedia | CC BY 4.0 |
| [ ] | **ASSET-09** | `09_premio_faae_plazas_2016.jpg` | Beat 43 | Fundación Alejandro Ángel Escobar | Cita Divulgativa |
| [x] | **ASSET-10** | `10_big_astronomy_andres_plazas.mp4` (1.8 MB) | Beats 31, 33, 44 | Big Astronomy NSF (`yt-dlp`) | CC BY Educativa |
| [x] | **ASSET-11** | `11_cern_lhc_tunnel.jpg` (6.0 MB) | Beat 51 | CERN LHC Tunnel / Wikimedia | CC BY 4.0 |
| [x] | **ASSET-12** | `12_cms_higgs_event_display.jpg` (801 KB) | Beat 55 | CERN CMS Experiment / Wikimedia | CC BY 4.0 |
| [x] | **ASSET-13** | `13_uniandes_presentacion_sanabria.mp4` (13.5 MB) | Beats 58, 59 | Uniandes Ciencias (`yt-dlp`) | Cita Educativa |
| [x] | **ASSET-14** | `14_oan_cupula_historica_1803.jpg` (393 KB) | Beat 63 | OAN UNAL / Wikimedia Commons | Extensión UNAL |
| [x] | **ASSET-15** | `15_oan_jueves_estrellas_castaneda.mp4` (921 KB) | Beats 74, 75 | OAN Colombia (`yt-dlp`) | Cita Educativa |
| [x] | **ASSET-16** | `16_voyager_pale_blue_dot.jpg` (633 KB) | Beat 80 | NASA JPL-Caltech | Dominio Público |

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

---

## 🎬 Checklist de Producción Beat por Beat (80 Beats)

> **Regla de Agentes:** Siempre que un agente finalice la animación, edición o renderizado de un beat (o bloque de beats), **DEBE actualizar inmediatamente esta checklist** marcando la casilla correspondiente (`[x]`) y detallando el archivo generado.


### Bloque 0: Cold Open & Hook (00:00 - 01:00 | Beats 01 a 06)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 01** | `00:00-00:11` | `COLLAGE` | En este preciso segundo, cien mil millones de partículas invisibles nacidas en el ... | Human hand as paper cutout on aged-cream blueprint paper; a diagonal bea... 📥 [Asset listo: `01_sol_sdo_flares.mp4`] |
| [ ] | **Beat 02** | `00:11-00:22` | `CAM_1` | Al mismo tiempo, en la cima de un cerro en los Andes chilenos, una cámara digital ... | Presenter 1 on camera medium shot; paper cutout overlay of the Vera C. R... |
| [ ] | **Beat 03** | `00:22-00:32` | `COLLAGE` | Y a cien metros bajo tierra, en la frontera entre Francia y Suiza, un detector de ... | Cross-section editorial collage of the CERN underground cavern; archival... 📥 [Asset listo: `03_cern_cms_cavern_broll.jpg`] |
| [ ] | **Beat 04** | `00:32-00:42` | `CAM_2` | Parecen postales de otro planeta. Pero detrás de esos tres experimentos, y de las ... | Presenter 2 on camera; background collage map connecting Geneva, Stanfor... |
| [ ] | **Beat 05** | `00:42-00:52` | `COLLAGE` | Para entender cómo la física moderna intenta descifrar el noventa y cinco por cien... | Four portrait paper cutouts pinned with washi tape on astronomical grid ... |
| [ ] | **Beat 06** | `00:52-01:00` | `MG_INTRO` | Esta es la historia de cuatro científicos colombianos que decidieron mirar donde n... | Full-screen editorial title card on cream paper with bold condensed typo... |

### Bloque 1: El Tablero de Juego — El 95% Invisible (01:00 - 02:30 | Beats 07 a 14)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 07** | `01:00-01:12` | `CAM_1` | Antes de conocerlos, necesitamos entender el tamaño del problema al que se enfrent... | Presenter 1 in dimly lit set striking a real wooden match in front of th... |
| [ ] | **Beat 08** | `01:12-01:23` | `COLLAGE` | Suena ridículo, pero esa es la situación exacta de la física actual. Todo lo que c... | Torn-paper pie chart on cream board: a tiny 5% slice in solar amber next... |
| [ ] | **Beat 09** | `01:23-01:35` | `COLLAGE` | Del resto, cerca del veintisiete por ciento es materia oscura: un pegamento gravit... | The 95% disk splits into two textured paper layers: 27% with cyan gravit... 📥 [Asset listo: `04_hubble_jwst_gravitational_lensing.jpg`] |
| [ ] | **Beat 10** | `01:35-01:46` | `CAM_2` | Para atacar este misterio, la humanidad solo tiene dos caminos. El primero es mira... | Presenter 2 on camera with floating collage card of the Standard Model o... |
| [ ] | **Beat 11** | `01:46-01:58` | `COLLAGE` | El Modelo Estándar es la teoría más exitosa jamás escrita. Describe diecisiete par... | Grid of 17 Standard Model particle tiles on cream paper; to the right, a... |
| [ ] | **Beat 12** | `01:58-02:10` | `CAM_2` | El segundo camino es mirar lo infinitamente grande: la cosmología y la Relatividad... | Presenter 2 on camera; archival 1919 cutout of Albert Einstein layered o... |
| [ ] | **Beat 13** | `02:10-02:20` | `COLLAGE` | Durante décadas, partículas y cosmología parecían dos mundos separados. Hoy sabemo... | Two torn paper halves joined by a strip of washi tape: left side shows C... |
| [ ] | **Beat 14** | `02:20-02:30` | `CAM_1` | Y nuestro primer protagonista descubrió que dos de las piezas más esquivas de ese ... | Presenter 1 gesturing toward camera with chapter title overlay |

### Bloque 2: Acto I — Diego Restrepo y el Fantasma que Pesa (02:30 - 05:30 | Beats 15 a 30)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 15** | `02:30-02:41` | `COLLAGE` | Ciudad Universitaria de Medellín, bloque seis, oficina cuatrocientos quince. Aquí,... | Paper cutout of Universidad de Antioquia Physics Institute building and ... 📥 [Assets listos: `05_udea_campus_facultad.jpg` + `06_particulas_valle_restrepo.mp4`] |
| [ ] | **Beat 16** | `02:41-02:52` | `COLLAGE` | Formado en esta misma universidad pública y doctorado en el Instituto de Física Co... | Charcoal ink map showing a dotted flight path between Medellin and Valen... |
| [ ] | **Beat 17** | `02:52-03:03` | `CAM_1` | Consolida en Medellín el Grupo de Fenomenología de Interacciones Fundamentales, un... | Presenter 1 on camera with GFIF UdeA and MinCiencias A1 stamp overlay |
| [ ] | **Beat 18** | `03:03-03:15` | `COLLAGE` | Cuando los arquitectos del Modelo Estándar escribieron sus ecuaciones en el siglo ... | Engraved-style illustration of a precision laboratory scale on cream pap... |
| [ ] | **Beat 19** | `03:15-03:27` | `COLLAGE` | Pero la naturaleza tenía guardada una sorpresa. En mil novecientos noventa y ocho,... | Three paper circles labeled electron, muon, and tau neutrino connected b... |
| [ ] | **Beat 20** | `03:27-03:38` | `CAM_1` | Y según las leyes de la mecánica cuántica, si una partícula cambia con el paso del... | Presenter 1 holding a ticking mechanical metronome on desk |
| [ ] | **Beat 21** | `03:38-03:50` | `COLLAGE` | Es la primera grieta real en el Modelo Estándar. Una masa millones de veces más li... | Monolith paper cutout labeled MODELO ESTÁNDAR with a glowing solar amber... |
| [ ] | **Beat 22** | `03:50-04:02` | `COLLAGE` | En agosto de dos mil trece, Diego Restrepo, junto a sus colegas colombianos Óscar ... | Cutout of the actual JHEP 11 (2013) 011 paper header (arXiv:1308.3655) w... |
| [ ] | **Beat 23** | `04:02-04:14` | `CAM_1` | Su pregunta de partida es de una elegancia brutal. Tenemos dos misterios sin resol... | Presenter 1 bringing two paper cards ('Masa del Neutrino' and 'Materia O... |
| [ ] | **Beat 24** | `04:14-04:26` | `COLLAGE` | En física teórica, esto se conoce como mecanismo escotogénico, una palabra que vie... | Clean Feynman diagram on cream blueprint paper: neutrino line enters lef... |
| [ ] | **Beat 25** | `04:26-04:38` | `COLLAGE` | En este escenario, el neutrino no adquiere masa de forma directa. La adquiere a tr... | Close-up of the Feynman loop interior showing scalar and fermion lines s... |
| [ ] | **Beat 26** | `04:38-04:50` | `CAM_1` | Imagínalo así: el neutrino es como un corredor que por sí solo no siente resistenc... | Presenter 1 on camera with side animation of a runner exchanging a glowi... |
| [ ] | **Beat 27** | `04:50-05:01` | `CAM_1` | Ahora, cuidado con el límite de la analogía. No es un roce físico ni hay fricción ... | Presenter 1 with an amber stamp overlay in upper corner reading LÍMITE D... |
| [ ] | **Beat 28** | `05:01-05:12` | `COLLAGE` | Restrepo y su equipo clasificaron sistemáticamente treinta y cinco modelos distint... | Grid of 35 small numbered Feynman diagram cards on cream paper; several ... |
| [ ] | **Beat 29** | `05:12-05:22` | `COLLAGE` | Además de su trabajo teórico, Restrepo hoy lidera el proyecto Colav y la plataform... | Cutout from 'Particulas en el Valle' UdeA documentary paired with an edi... 📥 [Asset listo: `06_particulas_valle_restrepo.mp4`] |
| [ ] | **Beat 30** | `05:22-05:30` | `CAM_2` | Pero proponer de qué está hecha la materia oscura en el papel es solo la mitad de ... | Presenter 2 on camera transitioning to Act II |

### Bloque 3: Acto II — Andrés Plazas Malagón y los Ojos del Gigante (05:30 - 08:30 | Beats 31 a 46)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 31** | `05:30-05:41` | `COLLAGE` | Bogotá, año dos mil. Un joven recién graduado del Colegio Salesiano de León Trece ... | Collage of Bogota skyline, Colegio Salesiano Leon XIII badge, and a univ... 📥 [Asset listo: `10_big_astronomy_andres_plazas.mp4`] |
| [ ] | **Beat 32** | `05:41-05:52` | `CAM_2` | Su nombre es Andrés Alejandro Plazas Malagón. En su primer semestre inscribe una c... | Presenter 2 on camera with newspaper cutout quote from DES Scientist of ... |
| [ ] | **Beat 33** | `05:52-06:03` | `COLLAGE` | Lector devoto de Gabriel García Márquez y Jorge Luis Borges, fanático del fútbol, ... | Portrait cutout of Andres Plazas Malagon surrounded by sticker cutouts o... 📥 [Assets listos: `07_fermilab_wilson_hall.jpg` + `10_big_astronomy_andres_plazas.mp4`] |
| [ ] | **Beat 34** | `06:03-06:15` | `COLLAGE` | Allí entra en contacto con el proyecto que definirá su carrera doctoral en la Univ... | Starfield panel inside cream frame; cyan light rays from distant galaxie... 📥 [Asset listo: `04_hubble_jwst_gravitational_lensing.jpg`] |
| [ ] | **Beat 35** | `06:15-06:27` | `CAM_2` | La idea física es fascinante. Como la materia oscura tiene gravedad, dobla la luz ... | Presenter 2 holding an optical lens in front of a grid of dots, demonstr... |
| [ ] | **Beat 36** | `06:27-06:39` | `COLLAGE` | Si miras una sola galaxia, no notas nada porque sabe Dios qué forma tenía original... | Field of dozens of small galaxy ellipses on cream paper; a cyan concentr... 📥 [Asset listo: `04_hubble_jwst_gravitational_lensing.jpg`] |
| [ ] | **Beat 37** | `06:39-06:50` | `COLLAGE` | Con ese uno por ciento, los cosmólogos pueden reconstruir el mapa tridimensional d... | 3D cosmic web map cutout with a bright solar amber warning triangle poin... |
| [ ] | **Beat 38** | `06:50-07:02` | `CAM_2` | Cuando buscas una señal de apenas el uno por ciento, el enemigo ya no está en el c... | Presenter 2 tight medium close-up looking directly into the lens |
| [ ] | **Beat 39** | `07:02-07:14` | `COLLAGE` | Plazas se convierte en un detective de detectores. En sus artículos de dos mil cat... | Archival photo cutout of the 62 golden CCD array of DECam paired with th... 📥 [Asset listo: `08_decam_focal_plane.jpg`] |
| [ ] | **Beat 40** | `07:14-07:26` | `COLLAGE` | Uno de los villanos principales que ayuda a domar se llama efecto Brighter-Fatter:... | Side-by-side comparison on cream grid paper: left shows a sharp star pro... |
| [ ] | **Beat 41** | `07:26-07:38` | `COLLAGE` | Para entender por qué ocurre, piensa que cada píxel del sensor es un balde recogie... | Cross-section diagram of three adjacent CCD pixel buckets: the center bu... |
| [ ] | **Beat 42** | `07:38-07:49` | `CAM_2` | Límite de la analogía: el agua se desborda solo cuando llega al borde físico del b... | Presenter 2 on camera with technical diagram overlay of transverse elect... |
| [ ] | **Beat 43** | `07:49-08:01` | `COLLAGE` | Por este trabajo pionero corrigiendo errores sistemáticos para usar lentes débiles... | Official award record cutout from Fundacion Alejandro Angel Escobar (201... 📥 [Asset pendiente: `09_premio_faae_plazas_2016.jpg`] |
| [ ] | **Beat 44** | `08:01-08:13` | `COLLAGE` | Hoy, desde el laboratorio SLAC de la Universidad de Stanford y el instituto KIPAC,... | Cutout of the giant LSST Camera at SLAC/Cerro Pachon with a human silhou... 📥 [Asset listo: `10_big_astronomy_andres_plazas.mp4`] |
| [ ] | **Beat 45** | `08:13-08:23` | `COLLAGE` | Y en su tiempo libre, junto a la astrofísica colombiana Clara Inés Barbosa, conduc... | Cover art cutout of 'Vision Cosmica' podcast with cyan soundwaves and a ... |
| [ ] | **Beat 46** | `08:23-08:30` | `CAM_1` | Pero si mirar el cielo desde los Andes requiere ojos perfectos, recrear el Big Ban... | Presenter 1 on camera introducing Act III |

### Bloque 4: Acto III — Juan Carlos Sanabria y la Máquina de Dios (08:30 - 11:30 | Beats 47 a 62)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 47** | `08:30-08:41` | `COLLAGE` | Nuestra tercera historia nace en Chiquinquirá, en las montañas de Boyacá. Allí cre... | Collage map of Boyaca, architectural cutout of Chiquinquira, and portrai... |
| [ ] | **Beat 48** | `08:41-08:52` | `COLLAGE` | En la Universidad de los Andes toma una decisión poco común: cursa simultáneamente... | Two intersecting paper badges (Physics + Electrical Engineering) connect... |
| [ ] | **Beat 49** | `08:52-09:04` | `CAM_1` | Esa doble formación como ingeniero y físico experimental resulta ser el pasaporte ... | Presenter 1 on camera as three vintage passport stamps land in sequence:... |
| [ ] | **Beat 50** | `09:04-09:16` | `COLLAGE` | A mediados de los años dos mil, el grupo de altas energías de la Universidad de lo... | Archival CERN photo cutout of the open CMS detector cavern with Uniandes... 📥 [Asset listo: `03_cern_cms_cavern_broll.jpg`] |
| [ ] | **Beat 51** | `09:16-09:28` | `COLLAGE` | En este anillo de veintisiete kilómetros, dos haces de protones chocan de frente c... | Diagram of the 27 km LHC ring on blueprint grid; two counter-rotating cy... 📥 [Asset listo: `11_cern_lhc_tunnel.jpg`] |
| [ ] | **Beat 52** | `09:28-09:40` | `CAM_1` | Ahora, piensa en el desafío de ingeniería. Cuarenta millones de colisiones por seg... | Presenter 1 gesturing wide as stacks of archival hard-drive cutouts pile... |
| [ ] | **Beat 53** | `09:40-09:52` | `COLLAGE` | El detector necesita un filtro ultrarrápido llamado sistema de Trigger, y cámaras ... | Cross-section wedge of the CMS detector highlighting the outer RPC muon ... 📥 [Asset listo: `03_cern_cms_cavern_broll.jpg`] |
| [ ] | **Beat 54** | `09:52-10:03` | `CAM_1` | Es como tener un portero de seguridad con reflejos sobrehumanos que, en millonésim... | Presenter 1 snaps fingers; corner stamp notes: 'Límite: Selección automá... |
| [ ] | **Beat 55** | `10:03-10:15` | `COLLAGE` | Gracias a esa cacería colectiva de miles de científicos, en julio de dos mil doce ... | CMS mass plot showing the 125 GeV Higgs boson peak in cyan, paired with ... 📥 [Asset listo: `12_cms_higgs_event_display.jpg`] |
| [ ] | **Beat 56** | `10:15-10:27` | `COLLAGE` | Dos años después, al posesionarse en la Academia Colombiana de Ciencias Exactas, F... | ACCEFYN emblem cutout and title card of his April 23, 2014 inaugural lec... |
| [ ] | **Beat 57** | `10:27-10:39` | `CAM_1` | En una entrevista con el diario El Tiempo, Sanabria lo resumía con total honestida... | Presenter 1 on camera with verified quote cutout from El Tiempo newspaper |
| [ ] | **Beat 58** | `10:39-10:51` | `COLLAGE` | Esa urgencia por compartir las grandes preguntas lo llevó a escribir una trilogía ... | Three book cover cutouts fanned out on cream paper: 'El enigma de los ci... 📥 [Asset listo: `13_uniandes_presentacion_sanabria.mp4`] |
| [ ] | **Beat 59** | `10:51-11:03` | `COLLAGE` | En Espías nucleares, presentado en la Academia de Ciencias, reconstruye cómo el es... | Editorial collage of declassified Los Alamos files, uranium-235 fission ... 📥 [Asset listo: `13_uniandes_presentacion_sanabria.mp4`] |
| [ ] | **Beat 60** | `11:03-11:15` | `CAM_1` | Sanabria suele decir que la ciencia, si no se comunica, carece de sentido. Y que u... | Presenter 1 on camera; ink illustration of pruning shears trimming dense... |
| [ ] | **Beat 61** | `11:15-11:23` | `CAM_2` | Ahora, quédate con la frase que dijo hace un momento: donde todo el mundo está más... | Presenter 2 medium shot |
| [ ] | **Beat 62** | `11:23-11:30` | `CAM_2` | Porque nuestro cuarto científico se hizo la pregunta más atrevida de todas: ¿y si ... | Presenter 2 looking straight into lens with chapter transition graphic |

### Bloque 5: Acto IV — Leonardo Castañeda y el Tablero Roto de Einstein (11:30 - 14:00 | Beats 63 a 75)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 63** | `11:30-11:42` | `COLLAGE` | Fundado en mil ochocientos tres por José Celestino Mutis, el Observatorio Astronóm... | Collage blending the historic 1803 Bogota Observatory dome with the mode... 📥 [Asset listo: `14_oan_cupula_historica_1803.jpg`] |
| [ ] | **Beat 64** | `11:42-11:53` | `COLLAGE` | Físico y magíster de la Universidad Nacional, con un doctorado en ciencias natural... | Seals of Universidad Nacional de Colombia and Johannes Gutenberg-Univers... |
| [ ] | **Beat 65** | `11:53-12:05` | `CAM_2` | Para entender su trabajo, recordemos la joya de la corona de Einstein: las ecuacio... | Presenter 2 on camera with the Einstein-Hilbert action integral floating... |
| [ ] | **Beat 66** | `12:05-12:17` | `COLLAGE` | Pero cuando aplicamos esa misma ecuación al universo entero, aparece el problema: ... | Two mathematical balance scales on cream paper: top scale adds a dark bl... |
| [ ] | **Beat 67** | `12:17-12:29` | `COLLAGE` | Castañeda explora ese segundo camino, conocido como gravedad modificada efe de err... | The Ricci scalar R inside the gravitational action expands into the gene... |
| [ ] | **Beat 68** | `12:29-12:41` | `CAM_2` | Piensa en el espacio-tiempo como una tela elástica. En la teoría de Einstein, la t... | Presenter 2 holding a stretched fabric swatch; overlay graph compares li... |
| [ ] | **Beat 69** | `12:41-12:52` | `CAM_2` | Límite importante de la analogía: el espacio-tiempo tiene cuatro dimensiones y no ... | Presenter 2 with solar amber stamp overlay reading: 'Límite: Curvatura 4... |
| [ ] | **Beat 70** | `12:52-13:05` | `COLLAGE` | Pero modificar las ecuaciones de Einstein tiene un precio matemático altísimo. En ... | Cutout of the paper 'Boundary Term in Metric f(R) Gravity: Field Equatio... |
| [ ] | **Beat 71** | `13:05-13:18` | `COLLAGE` | En ese trabajo deducen las ecuaciones de campo directamente en el formalismo métri... | Isometric 3D spacetime manifold block on cream blueprint paper; the inte... |
| [ ] | **Beat 72** | `13:18-13:30` | `CAM_2` | Imagina la contabilidad de un banco. Si auditas solo el dinero que se mueve entre ... | Presenter 2 framing an imaginary building with his hands; diagram shows ... |
| [ ] | **Beat 73** | `13:30-13:42` | `COLLAGE` | Ese término de frontera garantiza que el principio variacional de la física sea ma... | Two parallel geodesic lines on graph paper diverging as a gravitational ... |
| [ ] | **Beat 74** | `13:42-13:52` | `COLLAGE` | Y cuando cae la noche en Bogotá, Castañeda baja de las ecuaciones a los jardines d... | Cutout from his OAN lecture 'Ondas Gravitacionales: fábricas del espacio... 📥 [Asset listo: `15_oan_jueves_estrellas_castaneda.mp4`] |
| [ ] | **Beat 75** | `13:52-14:00` | `CAM_2` | Como él mismo explica con humor: la gente a veces espera que le mostremos cien gra... | Presenter 2 smiling and holding an empty glass jar labeled '100 g de Mat... 📥 [Asset listo: `15_oan_jueves_estrellas_castaneda.mp4`] |

### Bloque 6: Cierre, Conclusiones y Créditos (14:00 - 15:00 | Beats 76 a 80)
| Estado | Beat | Tiempo | Modo | Locución / Idea Central | Asset / Composición Visual |
| :---: | :---: | :---: | :---: | :--- | :--- |
| [ ] | **Beat 76** | `14:00-14:12` | `COLLAGE` | Vuelve a mirar ese noventa y cinco por ciento invisible del universo con el que em... | Return to the 95% dark pie chart from Beat 08, now illuminated by four b... |
| [ ] | **Beat 77** | `14:12-14:25` | `COLLAGE` | En Medellín, Diego Restrepo conecta la masa de los neutrinos con la materia oscura... | Full mural collage uniting all four portrait cutouts with cyan and solar... |
| [ ] | **Beat 78** | `14:25-14:37` | `CAM_BOTH` | Cuatro trayectorias distintas que derriban un prejuicio antiguo: la física de fron... | Both presenters on camera in two-shot, energetic and warm lighting |
| [ ] | **Beat 79** | `14:37-14:49` | `CAM_BOTH` | Si esta historia te inspiró, suscríbete al canal, compártela y cuéntanos en los co... | Presenters gesture downward; editorial collage end-cards slide in showin... |
| [ ] | **Beat 80** | `14:49-15:00` | `COLLAGE_OUTRO` | Porque la próxima vez que cien mil millones de neutrinos atraviesen tu mano sin ha... | Callback to Beat 01 hand cutout with cyan neutrino dots, pulling back to... 📥 [Asset listo: `16_voyager_pale_blue_dot.jpg`] |