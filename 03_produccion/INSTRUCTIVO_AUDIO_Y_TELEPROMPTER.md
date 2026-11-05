# Instructivo Técnico: Grabación de Audio y Uso de Teleprompter

**Proyecto:** Video de divulgación "El 95% Invisible: Cuatro Colombianos en la Frontera del Universo"  
**Objetivo:** Conseguir un audio de voz nítido, con presencia profesional y al ritmo exacto de 149 palabras por minuto, utilizando exclusivamente software gratuito y de código abierto (**QPrompt** y **Audacity**).

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
Abre **[Audacity](https://www.audacityteam.org/)** y verifica en la esquina inferior izquierda (o en *Editar → Preferencias → Audio*):
- **Frecuencia del proyecto (Project Sample Rate):** `48.000 Hz` (48 kHz). *(Nota: 44.1 kHz es estándar de CD musical; el video profesional de YouTube exige 48 kHz para evitar desincronizaciones de labios).*
- **Formato de muestra predeterminado:** `24-bit PCM` o `32-bit float`.
- **Canales de grabación:** `1 (Mono)`. *(La voz humana hablada siempre se graba en mono; el estéreo solo duplica espacio o genera problemas de fase).*

### 2.2 Estructura de Pistas
1. Ve a *Pistas → Agregar nueva → Pista mono*.
2. Renómbrala como `Autor_1`.
3. Crea una segunda pista mono y renómbrala como `Autor_2`.
4. Silencia (*Mute*) la pista que no esté grabando en ese momento.

### 2.3 Calibración de Ganancia (*Gain Staging*)
1. Colócate a la distancia de grabación (entre 15 y 20 cm del micrófono con filtro antipop o a 45 grados de la boca).
2. Haz una prueba de voz leyendo con la máxima energía que usarás en el video.
3. Observa el vúmetro verde de grabación en Audacity:
   - **Nivel óptimo de picos:** Entre **-18 dB y -12 dB** (zona verde alta / inicio de amarillo).
   - **Peligro:** Si la barra toca **0 dB** o la zona roja, el audio se distorsiona digitalmente (*clipping*) y queda inservible. Baja la ganancia de entrada de tu interfaz o micrófono.

---

## PARTE 3: PROTOCOLO DURANTE LA SESIÓN DE GRABACIÓN

### 3.1 Los 5 Segundos de Silencio Inicial (Obligatorio)
Antes de pronunciar la primera palabra de cada bloque, quédate completamente quieto en silencio frente al micrófono durante **5 segundos**. Este fragmento de "silencio ambiental" es indispensable para que el algoritmo de reducción de ruido aprenda el perfil acústico de tu habitación.

### 3.2 Manejo de Errores con la Técnica del Chasquido
Si te trabas o te equivocas en una frase:
1. **No pares la grabación en Audacity.**
2. Haz una pausa de **2 segundos en silencio**.
3. **Chasquea los dedos fuertemente o da una palmada cerca del micrófono.** Esto genera un pico vertical angosto y evidente en la forma de onda de Audacity.
4. Respira y repite el beat completo desde el inicio.
5. Al momento de editar, bastará con buscar visualmente los picos de las palmadas para cortar el error en 3 segundos.

---

## PARTE 4: CADENA DE PROCESAMIENTO Y MASTERIZACIÓN (EN AUDACITY)

Una vez grabado el bloque, aplica esta cadena de efectos nativos en este orden exacto:

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

### Paso 1: Reducción de Ruido
1. Selecciona con el ratón los 5 segundos de silencio que grabaste al inicio.
2. Ve a *Efecto → Eliminación de ruido y reparación → Reducción de ruido*.
3. Haz clic en **Obtener perfil de ruido**.
4. Selecciona toda la pista (*Ctrl + A*).
5. Vuelve a abrir *Reducción de ruido* y aplica estos valores sutiles:
   - **Reducción de ruido:** `8 dB` *(valores mayores a 12 dB vuelven la voz metálica/robótica)*.
   - **Sensibilidad:** `6.00`.
   - **Suavizado de frecuencia (bandas):** `3`.
6. Clic en *Aceptar*.

### Paso 2: Filtro Paso Alto (*High-Pass Filter*)
1. Selecciona toda la pista (*Ctrl + A*).
2. Ve a *Efecto → Ecualización y filtros → Filtro paso alto*.
3. **Frecuencia de corte:** `80 Hz`.
4. **Pendiente:** `12 dB por octava`.
5. *Propósito:* Elimina ruidos sordos de tráfico lejano, golpes involuntarios a la mesa y frecuencias subgraves inaudibles que ensucian la mezcla.

### Paso 3: Compresor Suave
1. Ve a *Efecto → Volumen y compresión → Compresor*.
2. Configura:
   - **Umbral (Threshold):** `-16 dB` a `-18 dB`.
   - **Límite inferior de ruido:** `-40 dB`.
   - **Proporción (Ratio):** `2.5:1` o `3:1`.
   - **Tiempo de ataque:** `20 ms`.
   - **Tiempo de decaimiento (Release):** `100 ms`.
3. *Propósito:* Empareja las partes donde hablas más bajo con los momentos de mayor entusiasmo, dando presencia uniforme a la voz.

### Paso 4: Normalización de Sonoridad para YouTube
1. Ve a *Efecto → Volumen y compresión → Normalización de sonoridad (Loudness Normalization)*.
2. Configura:
   - **Ajustar sonoridad percibida a:** `-14 LUFS` *(estándar oficial de YouTube)*.
   - **Normalizar canales estéreo independientemente:** Desmarcado.
3. Clic en *Aceptar*.
4. *Resultado:* Tu voz sonará exactamente con el mismo volumen profesional que los canales de divulgación de referencia, sin que YouTube la baje ni la distorsione.

---

## PARTE 5: ALTERNATIVA ULTRA-RÁPIDA CON IA (ADOBE PODCAST ENHANCE)

Si tu habitación tiene mucho eco o grabaste con el micrófono del celular:
1. Exporta tu pista cruda desde Audacity (*Archivo → Exportar audio → Formato WAV 48 kHz*).
2. Entra a **[Adobe Podcast Enhance Voice](https://podcast.adobe.com/enhance)** (servicio web 100% gratuito con cuenta de Adobe).
3. Sube el archivo `.wav`.
4. Ajusta el deslizador de intensidad al **60% - 75%** *(al 100% puede eliminar un poco de naturalidad en consonantes rápidas)*.
5. Descarga el audio procesado: el eco y el ruido habrán desaparecido por completo, simulando un micrófono de estudio profesional.

---

## PARTE 6: CONVENCIÓN DE EXPORTACIÓN Y GUARDADO

Guarda los audios terminados en la carpeta del repositorio:  
📁 `02_assets/locucion/`

Usa esta nomenclatura estándar:
- `B0_cold_open_A1.wav` / `B0_cold_open_A2.wav`
- `B1_tablero_juego_A1.wav` / `B1_tablero_juego_A2.wav`
- `B2_restrepo_A1.wav` / `B2_restrepo_A2.wav`
- `B3_plazas_A1.wav` / `B3_plazas_A2.wav`
- `B4_sanabria_A1.wav` / `B4_sanabria_A2.wav`
- `B5_castaneda_A1.wav` / `B5_castaneda_A2.wav`
- `B6_cierre_A1.wav` / `B6_cierre_A2.wav`

¡Con este flujo, el material de voz quedará listo para sincronizarse de inmediato en la línea de tiempo de edición o con las animaciones de Motion Canvas!
