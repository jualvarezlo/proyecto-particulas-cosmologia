# INSTRUCCIONES – Video de divulgación: "4 colombianos que miran el universo"

> Título de trabajo. Duración objetivo: **15 min (±1 min)**. Idioma: español neutro/colombiano. Estilo: divulgación con humor, ritmo rápido y rigor científico, al estilo de *Quantum Fracture* (analogías visuales, animación explicativa) y *Date un Vlog* (presentador cercano, narrativa personal, humor, edición dinámica).

---

## 0. Resumen del proyecto

| Elemento | Definición |
|---|---|
| Tema | Aportes de 4 científicos colombianos a la física de partículas y/o cosmología |
| Formato | Documental-divulgación: presentadores a cámara + motion graphics + material público (archivo) |
| Duración | ~15 min (ver escaleta, sección 4) |
| Público | Jóvenes y adultos curiosos, sin formación en física (estudiantes de bachillerato/universidad) |
| Entregables | Video final 1080p/4K, subtítulos .srt, miniatura, guion, lista de créditos y licencias, cortes verticales (30–60 s) |

### Personajes candidatos (⚠️ PRELIMINAR – deben verificarse)

Los nombres siguientes son **propuestas de partida** basadas en conocimiento general y **no están verificadas**. El primer paso del plan es confirmar trayectoria, aportes concretos y disponibilidad. Seleccionar 4 buscando diversidad (generación, género, experimental/teórico, residentes/diáspora).

| # | Candidato | Área sugerida | Por verificar |
|---|---|---|---|
| 1 | Carlos Ávila (U. de los Andes) | Física experimental de altas energías (Fermilab/DØ, LHC/CMS) | Aportes concretos, participación en resultados clave |
| 2 | Diego Restrepo (U. de Antioquia) | Fenomenología: neutrinos, materia oscura | Publicaciones y líneas principales |
| 3 | Camila Correa (diáspora) | Cosmología: simulaciones de materia oscura | Afiliación actual y aportes |
| 4 | Leonardo Castañeda (U. Nacional) | Gravitación y cosmología | Aportes y proyectos |
| Reserva | Yuber Pérez-González, Juan Carlos Sanabria, Jorge Zuluaga (astrofísica), otros | — | — |

> Criterio de selección: (a) aporte demostrable y citable (papers, colaboraciones, premios), (b) historia humana contable, (c) disponibilidad para entrevista o material propio con licencia, (d) poder explicarse con una analogía visual.

---

# PARTE A – EXPLICACIÓN PARA AGENTES (IA / asistentes)

## A.1 Rol y reglas generales

Los agentes asisten en investigación, guion, preproducción y organización. **No sustituyen la validación científica ni la voz de los autores.**

1. **Rigor ante todo.** Toda afirmación científica y biográfica debe tener **fuente citada** (paper en arXiv/INSPIRE-HEP/ADS, sitio institucional, entrevista, prensa fiable). Si no se puede verificar: marcar `[NO VERIFICADO]`. **Prohibido inventar** datos, citas textuales, fechas o premios.
2. **Distinguir hechos de simplificaciones.** Las analogías deben anotarse con su límite ("analogía: …; no es exacto porque …").
3. **Derechos de autor.** Solo proponer material con licencia clara (dominio público, Creative Commons, NASA/ESA/CERN con sus términos de uso, Wikimedia Commons, Pexels/Pixabay, archivos propios). Registrar licencia y atribución exacta de cada recurso. Ante duda: no usar y avisar. No descargar ni proponer material pirata o de YouTube sin permiso.
4. **Respeto a las personas.** No publicar datos privados de los científicos. Contacto solo por canales institucionales/públicos y con autorización de los autores.
5. **Idioma y tono:** español, frases cortas, hablado (no escrito), humor ligero, sin condescendencia. Evitar jerga sin definir.
6. **Trazabilidad:** cada entregable se guarda en la estructura de carpetas de la sección A.2 y se registra en `fuentes.md` / `licencias.csv`.
7. Ante ambigüedad o decisiones creativas/éticas importantes: **preguntar a los autores**, no asumir.
8. **Actualización Obligatoria de la Checklist de Beats en README:** Siempre que un agente finalice la animación, edición o renderizado de un beat (o bloque de beats), **DEBE actualizar inmediatamente la checklist en el archivo principal `README.md`** marcando la casilla correspondiente (`- [x]`) y detallando el archivo generado para mantener la visibilidad del avance de producción en tiempo real.

## A.2 Estructura de carpetas esperada

```
proyecto-particulas-cosmologia/
├─ INSTRUCCIONES.md
├─ 00_investigacion/
│  ├─ personajes/<nombre>.md      # biografía, aportes, fuentes, estado de verificación
│  ├─ conceptos/<tema>.md         # explicación + analogías + límites
│  └─ fuentes.md
├─ 01_guion/
│  ├─ escaleta.md
│  ├─ guion_v1.md ... guion_vN.md  # tabla: tiempo | visual | audio | notas
│  └─ preguntas_entrevista.md
├─ 02_assets/
│  ├─ archivo_publico/            # clips/imágenes con licencia
│  ├─ animaciones/ ; graficos/ ; musica/ ; sfx/
│  └─ licencias.csv               # archivo, fuente, URL, licencia, atribución
├─ 03_produccion/                 # plan de rodaje, call sheets, permisos
├─ 04_edicion/                    # proyectos, exportaciones, versiones
└─ 05_publicacion/                # título, descripción, miniaturas, capítulos, subtítulos
```

## A.3 Tareas de los agentes por fase

### Fase 1 – Investigación y selección (semana 1–2)
- Elaborar fichas por candidato (`personajes/*.md`) con: formación, trayectoria, **3 aportes concretos** con fuentes, anécdota humana, material audiovisual disponible, contacto institucional público, nivel de verificación.
- Proponer ranking y 4 finalistas con justificación; los autores deciden.
- Fichas de conceptos clave (p. ej. modelo estándar, colisionadores/detectores, neutrinos, materia oscura, expansión del universo), cada una con **una analogía principal** y su límite.
- Referentes de estilo: analizar estructura de *Quantum Fracture* y *Date un Vlog* (gancho, ritmo, uso de humor, duración de segmentos, cortes, recursos gráficos). **Describir técnicas, no copiar contenido, guiones, gráficos ni música.**

### Fase 2 – Guion (semana 2–4)
- Producir escaleta y guion siguiendo la sección 4 (tabla tiempo/visual/audio).
- Palabras habladas: ~140–160 palabras/min ⇒ ~2.100–2.400 palabras para 15 min contando pausas, entrevistas y música.
- Cada versión: lista de afirmaciones a verificar y lista de visuales necesarios.
- Preparar guion de preguntas de entrevista (abiertas, anecdóticas, sin tecnicismos).
- Redactar el texto de a cámara en la voz de cada autor (los autores reescriben a su modo).

### Fase 3 – Preproducción (semana 3–5)
- Lista de planos y de assets (shot list), storyboard textual por escena.
- Buscar material público: bancos (NASA Image and Video Library, ESA/Hubble, CERN Document Server, Wikimedia Commons, Internet Archive, Pexels, Pixabay), anotar licencia.
- Guiones técnicos de animación (qué se mueve, cómo, duración, estilo) para el motion designer.
- Borradores de correos de contacto (los autores revisan y envían) y de formularios de autorización/uso de imagen.
- Cronograma y presupuesto estimado.

### Fase 4 – Postproducción (semana 5–8)
- Apoyo con: lista de clips por escena, subtítulos (.srt) a partir del guion final, revisión de continuidad contra guion, comprobación de licencias, créditos finales.
- Chequeo científico final: contrastar cada cifra y afirmación del corte con `fuentes.md`.

### Fase 5 – Publicación (semana 8–9)
- 5 títulos y 3 miniaturas (conceptos), descripción con capítulos y fuentes, etiquetas, cortes verticales sugeridos, plan de difusión (universidades, colegios, redes de físicos).

## A.4 Formato de salidas de los agentes

- Markdown, tablas claras, fuentes con URL. Cada archivo inicia con: `Estado: borrador | revisado | aprobado` y fecha.
- Marcadores obligatorios: `[NO VERIFICADO]`, `[PENDIENTE AUTORIZACIÓN]`, `[LICENCIA?]`.
- Tabla de guion:

| Tiempo | Escena | Visual | Audio / texto | Fuente / licencia |
|---|---|---|---|---|

## A.5 Lista de verificación antes de entregar algo
- [ ] ¿Todas las afirmaciones tienen fuente?
- [ ] ¿Cada asset tiene licencia registrada?
- [ ] ¿Cumple la duración asignada?
- [ ] ¿Usa lenguaje comprensible y analogías con límites explicados?
- [ ] ¿Se respeta la privacidad y se pide autorización cuando corresponde?

---

# PARTE B – EXPLICACIÓN PARA LOS AUTORES (humanos)

## B.1 Qué hará cada quien
Definan los roles (una persona puede tener varios). Sugerencia:

| Rol | Responsabilidad |
|---|---|
| Director/a y presentador/a 1 | Visión general, entrevistas, cámara |
| Presentador/a 2 | Narración, segmentos a cámara |
| Responsable científico | Valida datos, aprueba analogías, contacta a los científicos |
| Edición / motion graphics | Montaje, animaciones, color y sonido |

Los agentes **apoyan**, pero ustedes deciden: selección de personajes, tono, guion final y publicación.

## B.2 Qué necesitan decidir primero (semana 1)
1. Los **4 científicos** (a partir de la lista preliminar; verifiquen quiénes siguen activos y aceptan participar).
2. Si habrá **entrevistas** con ellos (recomendado; da frescura y exclusividad) o solo material público.
3. Software y equipo disponible (ver B.5).
4. Fechas de entrega y presupuesto.
5. Canal y licencia del video (por ejemplo, YouTube y CC-BY si lo desean).

## B.3 Flujo de trabajo (≈ 9 semanas)

| Semana | Hito | Responsable |
|---|---|---|
| 1–2 | Fichas de candidatos, selección de 4, primer contacto | Agentes + científico del equipo |
| 2–4 | Escaleta y guion v1 → v3, validación científica | Todos |
| 3–5 | Entrevistas, rodaje a cámara, solicitud de material/permisos | Dirección |
| 4–7 | Animaciones, búsqueda de archivo, locución | Edición |
| 6–8 | Montaje, música, color, subtítulos | Edición |
| 8 | Revisión científica final y de licencias, **visto bueno de los científicos** | Responsable científico |
| 9 | Publicación y difusión | Todos |

## B.4 Cómo contar bien la historia (guía creativa)

- **Gancho en los primeros 20–30 s:** una pregunta o dato sorprendente ("¿Sabías que parte de lo que sabemos del universo salió de un laboratorio en Bogotá o Medellín?" – solo si es cierto).
- **Una idea, una analogía, una imagen** por concepto. Mostrar antes que decir.
- **Humanizar:** de dónde vienen, qué obstáculos, por qué eligieron la física desde Colombia.
- **Ritmo:** cambio visual cada 3–6 s; ningún segmento a cámara de más de ~40 s sin insertar B-roll o gráficos.
- **Humor** ligero y recurrente (un personaje, un gag visual); nunca a costa de los científicos.
- **Honestidad:** distinguir "descubrió", "contribuyó a" y "formó parte de la colaboración". Evitar exageraciones nacionalistas; el valor está en el aporte real.
- Cierre: qué sigue, mensaje de inspiración y llamada a la acción (suscribirse, apoyar la ciencia local).

## B.5 Equipo y software sugeridos
- Cámara/teléfono con 4K, micrófono de solapa o shotgun, 2 luces suaves, trípode, fondo cuidado (laboratorio, universidad, lugares icónicos).
- Edición: DaVinci Resolve (gratis) o Premiere; animación: After Effects, Blender o Motion Canvas/Manim (código abierto, ideal para física); audio: Audacity/Reaper.
- Música: YouTube Audio Library, Free Music Archive, o licencias propias. Registrar todo.

## B.6 Escaleta de 15 minutos

| Min | Bloque | Contenido |
|---|---|---|
| 0:00–0:45 | Gancho + título | Pregunta sorprendente, adelanto de los 4 y animación de apertura |
| 0:45–2:00 | Contexto | ¿Qué estudia la física de partículas y la cosmología? Mapa visual y analogía simple. Ciencia en Colombia |
| 2:00–5:00 | **Científico 1** | Historia + aporte + concepto + analogía |
| 5:00–8:00 | **Científico 2** | Ídem |
| 8:00–11:00 | **Científico 3** | Ídem |
| 11:00–14:00 | **Científico 4** | Ídem |
| 14:00–15:00 | Cierre | Conexión entre los 4, mensaje, créditos y llamada a la acción |

Estructura repetible para cada científico (3 min): 20 s gancho personal → 40 s trayectoria → 80 s aporte con animación → 20 s impacto/por qué importa → 20 s transición con humor.

## B.7 Contacto y permisos con los científicos
- Contacten por correo institucional con una presentación breve del proyecto, fecha tentativa y duración de la entrevista (30–45 min).
- Pidan **autorización escrita** de uso de imagen y de entrevista, y ofrezcan revisar el guion de su segmento antes de publicar.
- Para fotos o videos de universidades, CERN, Fermilab, etc.: revisen sus términos de uso y pidan permiso si hace falta.
- Usen **fair use/cita** con prudencia: fragmentos breves, con crédito y fines claramente divulgativos; en caso de duda, pedir permiso.

## B.8 Criterios de calidad (checklist final)
- [ ] Duración 14–16 min.
- [ ] Cada dato científico verificado y con fuente en la descripción.
- [ ] Autorizaciones firmadas de los 4 científicos.
- [ ] Todos los clips, imágenes y música con licencia registrada y créditos al final.
- [ ] Audio claro (voz −12 a −6 dB, música por debajo), subtítulos revisados.
- [ ] Miniatura y título atractivos, honestos (sin clickbait falso).
- [ ] Revisión por una persona ajena al proyecto (¿se entiende sin saber física?).

## B.9 Riesgos y mitigación

| Riesgo | Mitigación |
|---|---|
| Un científico no está disponible | Tener 2–3 reservas y plan de segmento solo con material público |
| Problemas de licencias | Registrar licencias desde el día 1; sustituir material dudoso |
| Error científico | Revisión del científico del equipo + visto bueno de los entrevistados |
| Video demasiado largo | Escaleta con tiempos y recorte de segmentos al final de guion |
| Contenido demasiado técnico | Prueba con público no experto y reescritura |

---

## Anexo – Referencias de estilo (para analizar, no copiar)
- Quantum Fracture: https://www.youtube.com/user/QuantumFracture
- Date un Vlog: https://www.youtube.com/@dateunvlog

Observar: estructura del gancho, uso de analogías, ritmo de edición, humor, tipo de gráficos, cierre y llamadas a la acción. Crear una identidad visual y de voz **propia**.
