# Instructivo Técnico: Búsqueda, Descarga y Licenciamiento de Assets Públicos

**Proyecto:** Video de divulgación "El 95% Invisible: Cuatro Colombianos en la Frontera del Universo"  
**Objetivo:** Guiar al equipo humano y a los agentes en la localización, descarga, organización y acreditación legal de todo el material audiovisual público (B-roll, fotografías históricas y gráficos científicos) necesario para el montaje del guion de 15 minutos.

---

## 1. MARCO LEGAL Y LICENCIAS PERMITIDAS

Para garantizar que el video se pueda monetizar o distribuir libremente en YouTube sin reclamos de *Content ID* ni infracciones de copyright, solo se utiliza material con las siguientes categorías de licencia:

1. **Dominio Público (Agencias Federales de EE. UU. - NASA, DOE, NSF):**
   - El material generado por el gobierno federal de EE. UU. (NASA, Fermilab/DOE, NSF) no está sujeto a derechos de autor y es de libre uso público. Requiere únicamente mención de cortesía (*Credit: NASA / JPL-Caltech*).
2. **Creative Commons Atribución (CC BY 4.0 - CERN, NOIRLab, ESO):**
   - Permite compartir, adaptar y usar comercialmente el metraje en documentales y videos de YouTube, siempre que se dé crédito explícito a la institución y se enlace a la licencia.
3. **Derecho de Cita y Uso Educativo / Institucional (Fair Use / Ley 23 de 1982 Colombia, Art. 31 y 32):**
   - Para fragmentos breves (de 5 a 15 segundos) de conferencias académicas, lanzamientos de libros o documentales universitarios (UdeA, UNAL, Uniandes, FAAE), la ley ampara el uso de pasajes con fines didácticos, de crítica, divulgación e ilustración, siempre citando el nombre del autor y la fuente.

---

## 2. DÓNDE ENCONTRAR Y CÓMO DESCARGAR CADA REPOSITORIO

### A. CERN Document Server (CDS) — Ginebra, Suiza
- **Portal oficial:** [cds.cern.ch](https://cds.cern.ch/)
- **Búsqueda:** Selecciona la categoría **"Videos"** o **"Photos"**.
- **Cómo descargar:** En la ficha del registro (ej. `record/2718428`), baja a la sección *"Files"* y descarga la versión `1080p.mp4` o `4k.mp4`.
- **Condiciones de uso:** CC BY 4.0 con crédito obligatorio: `CERN / CMS Collaboration`.

### B. NOIRLab / Vera C. Rubin Observatory — Cerro Pachón, Chile
- **Portal oficial:** [noirlab.edu/public/videos/](https://www.noirlab.edu/public/videos/) y [gallery.lsst.org](https://gallery.lsst.org/)
- **Búsqueda:** Palabras clave: `Vera C. Rubin Observatory`, `LSST Camera`, `Cerro Pachon timelapse`.
- **Cómo descargar:** En la columna derecha de cada video/foto, elige la resolución deseada (**Full HD 1080p** o **Ultra HD 4K** en formato `.mp4` o `.mov` H.264).
- **Condiciones de uso:** Libre para documentales y noticias con crédito: `Vera C. Rubin Observatory / NSF / DOE / NOIRLab`.

### C. NASA Images and Video Library / Scientific Visualization Studio (SVS)
- **Portal oficial:** [images.nasa.gov](https://images.nasa.gov/) y [svs.gsfc.nasa.gov](https://svs.gsfc.nasa.gov/)
- **Búsqueda:** `Solar Dynamics Observatory flare`, `Pale Blue Dot Voyager`, `SMACS 0723 gravitational lensing`.
- **Cómo descargar:** Clic en el botón azul de descarga en la parte superior derecha y selecciona la resolución `Large` u `Original (4K)`.
- **Condiciones de uso:** Dominio público con atribución: `NASA / SDO / Goddard Space Flight Center`.

### D. Descarga de Fragmentos Académicos de YouTube (UdeA, UNAL, Big Astronomy)
Para descargar fragmentos breves de uso educativo en máxima resolución sin pérdida de calidad:
- **Herramienta recomendada (Open Source):** `yt-dlp` en terminal:
  ```bash
  yt-dlp -f "bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]" --download-sections "*01:30-01:50" -o "02_assets/archivo_publico/NOMBRE_ARCHIVO.mp4" "URL_DEL_VIDEO"
  ```
- **Alternativa gráfica gratuita:** [4K Video Downloader+ (versión gratuita)](https://www.4kdownload.com/) o descargar el video completo y recortar solo los 10 segundos necesarios en el software de edición (DaVinci Resolve / Premiere).

---

## 3. CHECKLIST MAESTRO DE ASSETS PÚBLICOS NECESARIOS

Todos los archivos descargados deben guardarse en la carpeta:  
📁 `02_assets/archivo_publico/` con el nombre exacto indicado a continuación:

### 🔭 GRUPO 1: TELESCOPIOS, DETECTORES Y COSMOS (CERN, RUBIN, NASA)

| Check | ID | Nombre de Archivo Destino | Beats | Fuente / Enlace Directo | Licencia | Atribución Obligatoria |
| :---: | :---: | :--- | :---: | :--- | :---: | :--- |
| [ ] | **ASSET-01** | `01_sol_sdo_flares.mp4` | Beat 01 | [NASA SDO Video](https://images.nasa.gov/details/GSFC_20150618_m11818_Solardynamics) | Dominio Público | NASA / SDO / GSFC |
| [ ] | **ASSET-02** | `02_rubin_camera_arrival.mp4` | Beats 02, 44 | [NOIRLab LSST Camera](https://noirlab.edu/public/videos/ann24011a/) | CC BY 4.0 | Vera C. Rubin Observatory / NSF / DOE / NOIRLab |
| [ ] | **ASSET-03** | `03_cern_cms_cavern_broll.mp4` | Beats 03, 50, 53 | [CERN CDS CMS Cavern](https://cds.cern.ch/record/2718428) | CC BY 4.0 | CERN / CMS Collaboration |
| [ ] | **ASSET-04** | `04_hubble_jwst_gravitational_lensing.jpg` | Beats 09, 34, 36 | [NASA JWST SMACS 0723](https://images.nasa.gov/details/PIA25327) | Dominio Público | NASA, ESA, CSA, STScI |
| [ ] | **ASSET-07** | `07_fermilab_wilson_hall.jpg` | Beat 33 | [Fermilab Visual Media](https://vms.fnal.gov/) | Dominio Público | Fermilab / US DOE |
| [ ] | **ASSET-08** | `08_decam_focal_plane.jpg` | Beat 39 | [NOIRLab DECam CCDs](https://noirlab.edu/public/images/noao-decamfocalplane/) | CC BY 4.0 | Dark Energy Survey / DOE / FNAL / AURA |
| [ ] | **ASSET-11** | `11_cern_lhc_tunnel.mp4` | Beat 51 | [CERN CDS LHC Tunnel](https://cds.cern.ch/record/2676722) | CC BY 4.0 | CERN |
| [ ] | **ASSET-12** | `12_cms_higgs_event_display.png` | Beat 55 | [CERN CDS Higgs Event](https://cds.cern.ch/record/1459497) | CC BY 4.0 | CERN / CMS Collaboration |
| [ ] | **ASSET-16** | `16_voyager_pale_blue_dot.jpg` | Beat 80 | [NASA JPL Pale Blue Dot](https://images.nasa.gov/details/PIA23645) | Dominio Público | NASA / JPL-Caltech |

---

### 🏛️ GRUPO 2: ARCHIVO HISTÓRICO, UNIVERSIDADES Y ENTREVISTAS (COLOMBIA)

| Check | ID | Nombre de Archivo Destino | Beats | Fuente / Enlace Directo | Licencia | Atribución Obligatoria |
| :---: | :---: | :--- | :---: | :--- | :---: | :--- |
| [ ] | **ASSET-05** | `05_udea_campus_facultad.jpg` | Beat 15 | [Portal UdeA Medellín](https://www.udea.edu.co/) | Uso Institucional | Universidad de Antioquia |
| [ ] | **ASSET-06** | `06_particulas_valle_restrepo.mp4` | Beats 15, 29 | [YouTube Ciencias UdeA](https://www.youtube.com/watch?v=Brfj8ziHxV8) | Cita Educativa | Facultad de Ciencias Exactas - UdeA |
| [ ] | **ASSET-09** | `09_premio_faae_plazas_2016.jpg` | Beat 43 | [Archivo Histórico FAAE](https://www.faae.org.co/) | Cita Divulgativa | Fundación Alejandro Ángel Escobar (FAAE) |
| [ ] | **ASSET-10** | `10_big_astronomy_andres_plazas.mp4` | Beats 31, 33, 44 | [YouTube Big Astronomy](https://www.youtube.com/watch?v=-U34UhMZBuI) | CC BY Educativa | Big Astronomy / NSF |
| [ ] | **ASSET-13** | `13_uniandes_presentacion_sanabria.mp4` | Beats 58, 59 | [YouTube Ciencias Uniandes](https://www.youtube.com/watch?v=CPLiI4GPgRg) | Cita Educativa | Facultad de Ciencias - Uniandes |
| [ ] | **ASSET-14** | `14_oan_cupula_historica_1803.jpg` | Beat 63 | [Portal OAN UNAL Bogotá](https://ciencias.bogota.unal.edu.co/) | Extensión UNAL | Observatorio Astronómico Nacional - UNAL |
| [ ] | **ASSET-15** | `15_oan_jueves_estrellas_castaneda.mp4` | Beats 74, 75 | [YouTube OAN Colombia](https://www.youtube.com/watch?v=dzJ-RQFijrk) | Cita Educativa | Observatorio Astronómico Nacional de Colombia |

---

## 4. INTEGRACIÓN DE CRÉDITOS EN EL VIDEO FINAL

En los créditos finales del video (Beat 80) y en la caja de descripción de YouTube, debe incluirse el bloque de agradecimientos y licencias:

```text
MATERIAL AUDIOVISUAL Y FOTOGRÁFICO DE ARCHIVO:
- CERN / Colaboración CMS (CERN Document Server - CC BY 4.0)
- Vera C. Rubin Observatory / NSF / DOE / NOIRLab / AURA (CC BY 4.0)
- NASA / Goddard Space Flight Center / JPL-Caltech / STScI (Dominio Público)
- Big Astronomy Project / National Science Foundation (CC BY Educativa)
- Dark Energy Survey Collaboration / Fermilab Visual Media (CC BY / Public Domain)
- Facultad de Ciencias Exactas y Naturales - Universidad de Antioquia (UdeA)
- Observatorio Astronómico Nacional - Universidad Nacional de Colombia (UNAL Sede Bogotá)
- Facultad de Ciencias - Universidad de los Andes (Uniandes)
- Fundación Alejandro Ángel Escobar (FAAE - Premios Nacionales de Ciencia)
```

Toda la matriz de control estructurada se encuentra disponible en formato de hoja de cálculo en [`02_assets/licencias.csv`](licencias.csv).
