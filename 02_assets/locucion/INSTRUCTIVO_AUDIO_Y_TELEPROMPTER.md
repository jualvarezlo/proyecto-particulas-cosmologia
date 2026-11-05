# Instructivo Técnico: Grabación de Audio y Uso de Teleprompter

**Proyecto:** Video de divulgación "El 95% Invisible: Cuatro Colombianos en la Frontera del Universo"  
**Objetivo:** Conseguir un audio de voz nítido, con presencia profesional y al ritmo exacto de 149 palabras por minuto, utilizando exclusivamente software gratuito y de código abierto (**QPrompt** y **Audacity**).

**Voces del proyecto:**
- **Autor 1:** Juan Alvarez
- **Autor 2:** Geffrey

---

## PARTE 1: TELEPROMPTER (QPROMPT / WEB)

El teleprompter evita la memorización forzada, elimina las muletillas y garantiza que el video cumpla los 15 minutos exactos sin atropellar las analogías científicas.

### 1.1 Preparación de Herramientas
- **Opción Software (Recomendada):** Descarga e instala **[QPrompt](https://qprompt.app/)** (gratuito y de código abierto para Windows, macOS y Linux).
- **Opción Navegador (Sin instalación):** Utiliza **[Teleprompter Online](https://teleprompteronline.com/)** en cualquier tablet o pantalla secundaria.

### 1.2 Carga de Archivos
En la carpeta [`01_guion/teleprompter/`](../01_guion/teleprompter/) dispones de un archivo limpio por cada bloque temático:
- `B0_cold_open.txt` (00:00 - 01:00)
- `B1_tablero_juego.txt` (01:00 - 02:30)
- `B2_diego_restrepo.txt` (02:30 - 05:30)
- `B3_andres_plazas.txt` (05:30 - 08:30)
- `B4_juan_carlos_sanabria.txt` (08:30 - 11:30)
- `B5_leonardo_castaneda.txt` (11:30 - 14:00)
- `B6_cierre_outro.txt` (14:00 - 15:00)

> **Regla de oro:** Carga y graba **un bloque a la vez**. No cargues los 15 minutos juntos.

### 1.3 Configuración de Lectura en QPrompt
1. **Velocidad de desplazamiento:** Ajústala entre **145 y 150 palabras por minuto (ppm)**.
2. **Tipografía y contraste:** Fuente sans-serif grande (ej. Arial o Inter en negrita), color blanco o amarillo suave sobre fondo negro absoluto.
3. **Márgenes laterales amplios (Crucial):** Configura los márgenes laterales al **30% o 40%**. Si el texto ocupa todo el ancho de la pantalla, tus ojos se moverán visiblemente de izquierda a derecha ("efecto espectador de tenis"). Con texto centrado y estrecho, la mirada permanece fija en el lente.

### 1.4 Posicionamiento Físico de la Pantalla
- **Sin cristal teleprompter:** Coloca el teléfono o tablet **inmediatamente debajo o encima del lente de la cámara**, lo más pegado posible al borde del objetivo.
- **Distancia:** Separa la cámara del presentador entre **1.5 y 2.0 metros** y haz un ligero zoom. A mayor distancia entre el presentador y la cámara, menor es el ángulo de desviación visual y parecerá que miras directo a los ojos del espectador.
- **Con cristal teleprompter:** Activa la opción **Modo Espejo (Flip Horizontal)** en QPrompt.

---

## PARTE 2: CONFIGURACIÓN Y GRABACIÓN EN AUDACITY

### 2.1 Parámetros del Proyecto (Estándar de Video)
Abre **[Audacity](https://www.audacityteam.org/)** y verifica en la barra inferior (o en *Editar → Preferencias → Audio*):
- **Frecuencia del proyecto (Project Sample Rate):** `48.000 Hz` (48 kHz). *(Estándar oficial de video para YouTube; evita desfases de sincronización de labios).*
- **Formato de muestra predeterminado:** `24-bit PCM` o `32-bit float`.
- **Canales de grabación:** `1 (Mono)`. *(La voz hablada siempre se graba en mono).*

### 2.2 Estructura de Pistas en la Sesión
1. Ve a *Pistas → Agregar nueva → Pista mono*.
2. Renómbrala como `Juan_Alvarez`.
3. Crea una segunda pista mono y renómbrala como `Geffrey`.
4. Silencia (*Mute*) la pista que no esté grabando en ese momento.

### 2.3 Calibración de Ganancia (*Gain Staging*)
1. Colócate a la distancia de grabación (entre 15 y 20 cm del micrófono con filtro antipop o a 45 grados de la boca).
2. Haz una prueba leyendo con la máxima energía que usarás en el video.
3. Observa el vúmetro de grabación en Audacity:
   - **Nivel óptimo de picos:** Entre **-18 dB y -12 dB** (zona verde alta / inicio de amarillo).
   - **Peligro:** Si la barra toca **0 dB** o la zona roja, el audio se distorsiona digitalmente (*clipping*) de forma irrecuperable. Baja la ganancia de entrada.

---

## PARTE 3: PROTOCOLO DURANTE LA SESIÓN DE GRABACIÓN

### 3.1 Los 5 Segundos de Silencio Inicial (Obligatorio)
Antes de pronunciar la primera palabra de cada bloque, quédate completamente quieto en silencio frente al micrófono durante **5 segundos**. Este fragmento es indispensable para capturar el perfil de ruido ambiental en Audacity.

### 3.2 Manejo de Errores con la Técnica del Chasquido
Si te trabas o te equivocas en una frase:
1. **No pares la grabación en Audacity.**
2. Haz una pausa de **2 segundos en silencio**.
3. **Chasquea los dedos fuertemente o da una palmada cerca del micrófono.** Esto genera un pico vertical angosto y evidente en la forma de onda de Audacity.
4. Respira y repite el beat completo desde el inicio.
5. Al editar, ubica los picos visuales de las palmadas para cortar el error en segundos.

---

## PARTE 4: CADENA DE PROCESAMIENTO Y MASTERIZACIÓN (AUDACITY)

Aplica esta cadena de efectos nativos en este orden exacto a cada pista:

```
[Audio Crudo] 
      ↓ 
1. Reducción de Ruido (Noise Reduction) 
      ↓ 
2. Filtro Paso Alto (High-Pass Filter a 80 Hz) 
      ↓ 
3. Compresor Suave (Compressor) 
      ↓ 
4. Normalización de Sonoridad (-14 LUFS para YouTube)
```

1. **Reducción de Ruido:** Selecciona los 5 segundos de silencio inicial → *Efecto → Reducción de ruido → Obtener perfil de ruido*. Luego selecciona toda la pista y aplica: Reducción: `8 dB`, Sensibilidad: `6.00`, Suavizado de frecuencia: `3`.
2. **Filtro Paso Alto (*High-Pass*):** Frecuencia de corte: `80 Hz`, Pendiente: `12 dB/octava` (elimina golpes en la mesa y vibraciones subgraves).
3. **Compresor Suave:** Umbral: `-16 dB` a `-18 dB`, Ratio: `2.5:1` a `3:1`, Ataque: `20 ms`, Decaimiento: `100 ms`.
4. **Normalización de Sonoridad:** *Efecto → Normalización de sonoridad* ajustada a **`-14 LUFS`** (estándar de YouTube) con pico máximo de `-1.0 dB True Peak`.

---

## PARTE 5: CHECKLIST DE ARCHIVOS DE AUDIO REQUERIDOS

Todos los archivos deben exportarse en formato **WAV (48 kHz / 24 bits mono)** dentro de la carpeta:  
📁 `02_assets/locucion/`

### 👤 ARCHIVOS DE JUAN ALVAREZ (AUTOR 1)

| Estado | Archivo a Exportar | Bloque | Modo | Beats | Duración Aprox. |
| :---: | :--- | :--- | :---: | :---: | :---: |
| [ ] | `B0_cold_open_JuanAlvarez.wav` | Bloque 0: Cold Open | VO / A Cámara | 01, 02, 03, 06 | ~38 s |
| [ ] | `B1_tablero_juego_JuanAlvarez.wav` | Bloque 1: Tablero de Juego | A Cámara / VO | 07, 08, 09, 14 | ~45 s |
| [ ] | `B2_diego_restrepo_JuanAlvarez.wav` | Bloque 2: Acto I (Diego Restrepo) | VO / A Cámara | 15 a 29 (completo) | ~170 s |
| [ ] | `B3_andres_plazas_JuanAlvarez.wav` | Bloque 3: Acto II (Transición) | A Cámara | 46 | ~7 s |
| [ ] | `B4_juan_carlos_sanabria_JuanAlvarez.wav` | Bloque 4: Acto III (J. C. Sanabria) | VO / A Cámara | 47 a 60 (completo) | ~165 s |
| [ ] | `B6_cierre_JuanAlvarez.wav` | Bloque 6: Cierre y Outro | VO / A Cámara | 76, 78 (frase 1), 79 (frase 2), 80 | ~35 s |

---

### 👤 ARCHIVOS DE GEFFREY (AUTOR 2)

| Estado | Archivo a Exportar | Bloque | Modo | Beats | Duración Aprox. |
| :---: | :--- | :--- | :---: | :---: | :---: |
| [ ] | `B0_cold_open_Geffrey.wav` | Bloque 0: Cold Open | A Cámara / VO | 04, 05 | ~20 s |
| [ ] | `B1_tablero_juego_Geffrey.wav` | Bloque 1: Tablero de Juego | A Cámara / VO | 10, 11, 12, 13 | ~45 s |
| [ ] | `B2_diego_restrepo_Geffrey.wav` | Bloque 2: Acto I (Transición) | A Cámara | 30 | ~8 s |
| [ ] | `B3_andres_plazas_Geffrey.wav` | Bloque 3: Acto II (Andrés Plazas) | VO / A Cámara | 31 a 45 (completo) | ~173 s |
| [ ] | `B4_juan_carlos_sanabria_Geffrey.wav` | Bloque 4: Acto III (Transición) | A Cámara | 61, 62 | ~15 s |
| [ ] | `B5_leonardo_castaneda_Geffrey.wav` | Bloque 5: Acto IV (L. Castañeda) | VO / A Cámara | 63 a 75 (completo) | ~150 s |
| [ ] | `B6_cierre_Geffrey.wav` | Bloque 6: Cierre y Outro | VO / A Cámara | 77, 78 (frase 2), 79 (frase 1) | ~25 s |

---

### 👥 ARCHIVOS A DÚO / TOMA CONJUNTA EN SET (OPCIONAL EN SESIÓN FINAL)

| Estado | Archivo a Exportar | Bloque | Modo | Participantes | Notas |
| :---: | :--- | :--- | :---: | :---: | :--- |
| [ ] | `B6_cierre_conjunto_Juan_y_Geffrey.wav` | Bloque 6: Outro | A Cámara (Plano conjunto) | Juan Alvarez & Geffrey | Grabación simultánea en set para máxima naturalidad en los Beats 78 y 79. |

---

## PARTE 6: ALTERNATIVA CON IA (ADOBE PODCAST ENHANCE)

Si grabaron en una habitación con eco o usaron micrófono de celular:
1. Exporta el archivo WAV crudo desde Audacity.
2. Súbelo a **[Adobe Podcast Enhance Voice](https://podcast.adobe.com/enhance)** (gratuito).
3. Ajusta el deslizador de intensidad entre **65% y 75%** para conservar naturalidad en las consonantes.
4. Descarga el audio procesado y reemplaza el archivo en `02_assets/locucion/`.
