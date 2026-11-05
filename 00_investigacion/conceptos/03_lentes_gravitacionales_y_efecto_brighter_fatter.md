# Concepto Físico: Lentes Gravitacionales Débiles y el Efecto Brighter-Fatter en Sensores CCD

**Área:** Cosmología Observacional / Instrumentación Astronómica de Alta Precisión  
**Científico vinculado en el guion:** Dr. Andrés Alejandro Plazas Malagón (SLAC / Stanford / KIPAC)  
**Beats del guion relacionados:** Beats 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44

---

## 1. Fundamento Físico de las Lentes Gravitacionales Débiles (*Weak Lensing*)

### La Ecuación de la Lente Gravitacional
En Relatividad General, la masa deforma la geometría del espacio-tiempo, curvando las trayectorias geodésicas de los fotones. La desviación angular $\hat{\boldsymbol{\alpha}}$ de un rayo de luz que pasa a un parámetro de impacto $\boldsymbol{\xi}$ de una distribución de masa superficial $\Sigma(\boldsymbol{\xi})$ es:
$$\hat{\boldsymbol{\alpha}}(\boldsymbol{\xi}) = \frac{4G}{c^2} \int \frac{\Sigma(\boldsymbol{\xi}') (\boldsymbol{\xi} - \boldsymbol{\xi}')}{|\boldsymbol{\xi} - \boldsymbol{\xi}'|^2} d^2\boldsymbol{\xi}'$$

La relación entre la posición no distorsionada en el plano fuente $\boldsymbol{\beta}$ y la posición observada en el plano lente $\boldsymbol{\theta}$ se describe mediante la matriz de deformación jacobiana $\mathcal{A}$:
$$\mathcal{A} = \frac{\partial \boldsymbol{\beta}}{\partial \boldsymbol{\theta}} = \begin{pmatrix} 1 - \kappa - \gamma_1 & -\gamma_2 \\ -\gamma_2 & 1 - \kappa + \gamma_1 \end{pmatrix} = (1 - \kappa) \begin{pmatrix} 1 - g_1 & -g_2 \\ -g_2 & 1 + g_1 \end{pmatrix}$$

Donde:
- $\kappa$ es la **convergencia** (magnificación y cambio de tamaño isotrópico), proporcional a la densidad de materia proyectada a lo largo de la línea de visión: $\kappa(\boldsymbol{\theta}) = \frac{\Sigma(\boldsymbol{\theta})}{\Sigma_{\text{crit}}}$.
- $\gamma = \gamma_1 + i\gamma_2$ es el **corte gravitacional o cizallamiento (*shear*)**, que estira tangencialmente las imágenes circulares transformándolas en elipses.
- $g = \frac{\gamma}{1 - \kappa} \approx \gamma$ es el corte reducido (*reduced shear*).

### El Régimen Débil (*Cosmic Shear*)
- En lentes fuertes (cerca del centro denso de un cúmulo), se observan arcos gigantes, anillos de Einstein e imágenes múltiples.
- En **lentes débiles (*weak lensing*)**, que ocurren en la inmensa mayoría del cielo, la deformación de una galaxia individual es minúscula: **$|g| \sim 0.01$ (apenas un 1%)**.
- Como las galaxias tienen una elipticidad intrínseca aleatoria mucho mayor ($\sigma_\epsilon \approx 0.3$), es imposible detectar la lente en una sola galaxia.
- **La solución estadística:** Promediar la forma y orientación de **cientos de millones de galaxias**. La orientación intrínseca se cancela por simetría aleatoria ($\langle \epsilon_{\text{int}} \rangle = 0$), dejando al descubierto el campo coherente de cizallamiento cósmico inducido por la materia oscura intermedia:
$$\langle \epsilon \rangle = g \approx \gamma$$

---

## 2. El Desafío Instrumental: Sensores CCD y el Efecto Brighter-Fatter

### Los Detectores CCD Astronómicos
Cámaras como la **DECam** (*Dark Energy Camera*, 570 MP en el Telescopio Blanco en Chile) y la **LSST Camera** (*Legacy Survey of Space and Time*, 3.200 MP en el Observatorio Vera C. Rubin) utilizan sensores CCD de silicio grueso y alto voltaje (*deep-depletion CCDs*, ~250 $\mu$m de espesor) diseñados para maximizar la eficiencia cuántica en el infrarrojo cercano.

### El Efecto *Brighter-Fatter* (BFE)
Cuando los fotones inciden sobre el silicio, generan pares electrón-hueco por efecto fotoeléctrico. Los electrones se desplazan a lo largo de las líneas de campo eléctrico vertical hacia los potenciales de pozo de cada píxel en la superficie.

1. **Acumulación de Carga:** A medida que una fuente brillante deposita cientos de miles de electrones en el pozo del píxel central, la carga negativa neta acumulada genera un **campo eléctrico transversal repulsivo** $\mathbf{E}_\perp$.
2. **Deflexión de Electrones Posteriores:** Los nuevos electrones foto-generados que viajan a través del silicio sienten esta fuerza de repulsión electrostática colombiana ($\mathbf{F} = -e \mathbf{E}_\perp$) y se desvían hacia los píxeles vecinos adyacentes.
3. **Consecuencia Sistemática:** El área efectiva de colección del píxel central disminuye en función de la carga ya almacenada, mientras que el área de los píxeles vecinos aumenta.
4. **Impacto Cosmológico:** La función de dispersión de punto (*Point Spread Function*, PSF) se ensancha artificialmente a mayor brillo de la estrella. Si este efecto no se modela píxel a píxel, induce una elipticidad espuria que imita de forma idéntica una señal de lentes débiles, sesgando los parámetros cosmológicos de materia y energía oscura ($\Omega_m, \sigma_8, w$).

### El Aporte de Andrés Plazas Malagón
Plazas y sus colaboradores en DES y Rubin demostraron experimentalmente en banco óptico y en datos de cielo de DECam:
- El efecto no es una saturación ordinaria de silicio, sino un corrimiento continuo de frontera de píxeles dependiente de la carga (*charge-induced pixel shifts*).
- Desarrollaron algoritmos de calibración basados en matrices de correlación espacial de planos planos (*flat fields*) y curvas de varianza de brillo para invertir matemáticamente la distorsión antes de medir la forma de las galaxias.
- Este trabajo le valió el **Premio Nacional de Ciencias Alejandro Ángel Escobar 2016**.

---

## 3. Las Analogías del Guion y sus Límites Físicos

### Analogía 1: El Fondo de la Piscina (Beat 35)
> *"La materia oscura dobla la luz de las galaxias lejanas igual que el agua ondulada de una piscina deforma los azulejos del fondo."*
- **SÍ es:** Un mapeo óptico donde las perturbaciones de un medio transparente intermedio alteran la geometría de una fuente de fondo.
- **NO es:** En la piscina hay refracción por índice de refracción variable del agua ($n > 1$); en lentes gravitacionales no hay medio material: la luz sigue geodésicas en un espacio-tiempo curvado por el tensor de energía-momento.

### Analogía 2: Los Baldes de Lluvia y el Efecto Brighter-Fatter (Beats 41-42)
> *"Cada píxel es un balde recogiendo gotas de luz. Cuando un balde se llena mucho, su propia carga eléctrica repele las nuevas gotas hacia los baldes vecinos, haciendo que la estrella parezca más gorda."*
- **Límite Explícito (Beat 42):**
  - En un balde ordinario con agua, el líquido rebosa solo cuando el agua alcanza físicamente el borde del recipiente (límite de capacidad geométrica).
  - En un píxel CCD de silicio, **la repulsión electrostática del campo transversal desvía las cargas mucho antes de que el pozo se sature** (ocurre de forma continua desde niveles medios de llenado).

---

## 4. Fuentes Primarias y Literatura Científica
- A. A. Plazas, E. S. Bernstein, G. M. Bernstein, *"Characterization and Correction of Charge-Induced Pixel Shifts in DECam"*, *JINST* 10 (2015) C05032, [arXiv:1501.02802 [astro-ph.IM]](https://arxiv.org/abs/1501.02802).
- A. A. Plazas, E. S. Bernstein, G. M. Bernstein, *"Transverse electric fields' effects in the Dark Energy Camera CCDs"*, *JINST* 9 (2014) C04001, [arXiv:1403.6127 [astro-ph.IM]](https://arxiv.org/abs/1403.6127).
- D. Gruen et al. (DES Collaboration), *"Dark Energy Survey Year 3 Results: Covariance modelling and its robustness to modeling uncertainty"*, *Mon. Not. Roy. Astron. Soc.* 503 (2021) 2686.
