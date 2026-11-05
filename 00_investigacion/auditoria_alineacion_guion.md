# Informe de Auditoría: Alineación del Guion con la Investigación Científica

**Fecha:** 2026-11-04  
**Documentos auditados:**
- Guion Maestro: [`01_guion/guion_definitivo.md`](../01_guion/guion_definitivo.md) (80 beats)
- Guion Estructurado: [`01_guion/script.json`](../01_guion/script.json)
- Fichas de Personajes: [`00_investigacion/personajes/`](personajes/)
- Fichas de Conceptos Físicos: [`00_investigacion/conceptos/`](conceptos/)
- Reporte de Fact-Checking: [`00_investigacion/fact_check_report.md`](fact_check_report.md)

---

## 1. Resumen de la Auditoría de Alineación

El guion definitivo de 15 minutos fue contrastado exhaustivamente contra las bases de datos científicas primarias (INSPIRE-HEP, arXiv, revistas con revisión por pares, portales universitarios y fundaciones).

| Bloque / Personaje | Grado de Alineación | Citas / Papers Clave Verificados | Manejo de Analogías y Límites | Observaciones para Confirmación |
| :--- | :---: | :--- | :--- | :--- |
| **Bloque 0 & 1: Contexto Cósmico** | **100% Alineado** | Planck 2018 ($\Omega_b \approx 5\%$, $\Omega_{\text{cdm}} \approx 27\%$, $\Omega_\Lambda \approx 68\%$) | Distinción clara entre partículas y cosmología. | Cifras redondeadas a enteros para teleprompter. |
| **Bloque 2: Dr. Diego Restrepo** | **100% Alineado** | *JHEP 11 (2013) 011* (arXiv:1308.3655), 35 modelos escotogénicos. | Analogía del corredor con advertencia explícita de "no fricción mecánica". | Coautores (Óscar Zapata y Carlos Yaguna) correctamente nombrados. |
| **Bloque 3: Dr. Andrés Plazas** | **100% Alineado** | *JINST* (2014, 2015), Premio FAAE 2016, DECam y Rubin 3200 MP. | Analogía de los baldes y repulsión de campo eléctrico transversal. | Se respeta la distinción entre lentes débiles (1%) y aberración instrumental. |
| **Bloque 4: Dr. Juan Carlos Sanabria** | **100% Alineado** | CMS / CERN, Higgs a 125 GeV, Trilogía de libros (Debate / Uniandes / ACCEFYN). | Fiesta de cóctel de Higgs con límite explícito de "no resistencia/fricción". | Exclusión deliberada de papers dudosos de los años 90; cita textual de *El Tiempo* exacta. |
| **Bloque 5: Dr. Leonardo Castañeda** | **100% Alineado** | *Gen. Rel. Grav. 42 (2010)* (arXiv:1002.0617), término de frontera, OAN 1803. | Analogía de la tela elástica no lineal y auditoría del banco. | Coautores (Alejandro Guarnizo y Juan M. Tejeiro) y frase del frasco de materia oscura exactos. |
| **Bloque 6: Resolución y Cierre** | **100% Alineado** | Síntesis de los 4 frentes, fuentes primarias en descripción. | Reframe circular cerrando con el Punto Azul Pálido de Sagan. | Transición natural a créditos y atribuciones de `licencias.csv`. |

---

## 2. Puntos Clave de Control y Validación Científica

### A. Rigor en la Masa de Neutrinos y el Modelo Escotogénico (Diego Restrepo)
- **En la investigación:** El Modelo Estándar predice $m_\nu = 0$. Las oscilaciones prueban que $\Delta m^2 \neq 0$. El mecanismo escotogénico (JHEP 2013) genera masa radiativa a un lazo donde las partículas del lazo son materia oscura protegida por $\mathbb{Z}_2$.
- **En el guion (Beats 18–28):** El guion narra con precisión la oscilación como "reloj interno", presenta el bucle cuántico a un lazo e incluye explícitamente el Beat 27: *"No es un roce físico ni hay fricción mecánica: son fluctuaciones cuánticas virtuales gobernadas por simetrías matemáticas exactas"*. **Alineación total.**

### B. Rigor en el Efecto Brighter-Fatter y Lentes Débiles (Andrés Plazas Malagón)
- **En la investigación:** La señal cosmológica de lentes débiles (*shear*) es de apenas el 1%. El efecto *Brighter-Fatter* es una interacción electrostática en el volumen del silicio donde la carga acumulada en el pozo del píxel desvía los electrones entrantes, ensanchando la PSF de estrellas brillantes.
- **En el guion (Beats 36–42):** Se explica la analogía de los baldes de lluvia, pero inmediatamente en el Beat 42 se aclara el límite técnico: el desborde en un balde es por llegar al borde, mientras que en el CCD el campo eléctrico transversal desvía las cargas mucho antes de la saturación física. **Alineación total.**

### C. Rigor en el Experimento CMS y el Bosón de Higgs (Juan Carlos Sanabria)
- **En la investigación:** Sanabria es cofirmante de CMS en el LHC (frecuencia de cruce de paquetes de 40 MHz). El sistema de Trigger filtra en microsegundos para salvar 1 kHz de 40 MHz. Su conferencia en ACCEFYN (2014) trató sobre materia oscura supersimétrica. Sus tres libros son *El enigma de los cielos* (2019), *El poder del fuego* (2023) y *Espías nucleares* (2025).
- **En el guion (Beats 51–60):** Todos los datos numéricos (27 km, 40 millones de choques/segundo, 99.99% de descarte por Trigger, 125 GeV, títulos y años de los 3 libros) coinciden con exactitud matemática y cronológica con las fuentes primarias. La metáfora del jardinero proviene literalmente de su entrevista en *El Tiempo*. **Alineación total.**

### D. Rigor en la Gravedad $f(R)$ y el Término de Frontera (Leonardo Castañeda)
- **En la investigación:** En el formalismo métrico de $f(R)$, las ecuaciones de campo son de cuarto orden. La variación de la acción produce derivadas normales de la métrica en la frontera que no se anulan por fijar $\delta g = 0$. El paper de 2010 (Guarnizo, Castañeda, Tejeiro en *Gen. Rel. Grav.* con +105 citas) introduce el término de frontera que hace matemáticamente consistente el principio variacional.
- **En el guion (Beats 67–73):** Se explica que $f(R)$ es una alternativa geométrica a la energía oscura, se aclara que el espacio-tiempo es 4D sin gravedad externa (límite de la tela elástica), y la metáfora de la auditoría del banco ilustra con elegancia el teorema de Stokes aplicado a la acción en la frontera. **Alineación total.**

---

## 3. Observaciones y Sugerencias Menores para Decisión de los Autores

*(Ningún cambio ha sido aplicado al guion; se presentan únicamente para consideración de Juan Alvarez y Geffrey):*

1. **Pronunciación de la escala de energía en locución (Beat 55):**
   - *Texto actual:* `"bosón de Higgs a ciento veinticinco gigaelectronvoltios"` (o `125 GeV`).
   - *Sugerencia:* Asegurar que Juan Alvarez lo pronuncie en español fluido: *"ciento veinticinco gigaelectronvoltios"* o *"ciento veinticinco ge-e-ve"*.
2. **Mención de la simetría $\mathbb{Z}_2$ (Beat 25):**
   - *Texto actual:* En el texto hablado se menciona *"un bucle cuántico en el que participan partículas pesadas que son candidatas a materia oscura"*, mientras que en la columna visual aparece rotulada la simetría discreta $\mathbb{Z}_2$.
   - *Evaluación:* Es la decisión correcta para no sobrecargar el audio con jerga matemática abstracta y dejar el tecnicismo para el gráfico de apoyo.
3. **Redondeo de densidades cósmicas (Beat 09):**
   - *Texto actual:* `"cinco por ciento"`, `"veintisiete por ciento"` y `"sesenta y ocho por ciento"`.
   - *Evaluación:* Valores de Planck 2018 son 4.9%, 26.8% y 68.3%. Redondearlos al entero más cercano es el estándar unánime en divulgación de alto ritmo (Quantum Fracture / Date un Vlog / Vox) para facilitar la memorabilidad.

---

## 4. Veredicto Final de Alineación

El guion definitivo [`01_guion/guion_definitivo.md`](../01_guion/guion_definitivo.md) se encuentra **100% ALINEADO Y CONSISTENTE** con el corpus de investigación científica, las citas primarias, las instituciones y los límites epistemológicos de cada modelo. 

**No se requiere ninguna modificación de fondo.** El guion está blindado contra errores científicos y listo para la fase de grabación de voz.
