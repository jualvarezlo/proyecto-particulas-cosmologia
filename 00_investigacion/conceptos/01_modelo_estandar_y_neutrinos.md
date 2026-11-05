# Concepto Físico: El Modelo Estándar, Oscilación de Neutrinos y el Mecanismo Escotogénico

**Área:** Física de Partículas Teórica / Fenomenología Más Allá del Modelo Estándar (BSM)  
**Científico vinculado en el guion:** Dr. Diego Alejandro Restrepo Quintero (UdeA)  
**Beats del guion relacionados:** Beats 10, 11, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28

---

## 1. Definición Física y Marco Teórico

### El Modelo Estándar (SM)
El Modelo Estándar de la física de partículas es una teoría cuántica de campos basada en el grupo de simetría gauge local:
$$SU(3)_C \times SU(2)_L \times U(1)_Y$$

Describe las interacciones fuerte, débil y electromagnética entre fermiones fundamentales (6 quarks y 6 leptones) mediados por bosones gauge ($g, W^\pm, Z^0, \gamma$) y el mecanismo de Brout-Englert-Higgs para la generación de masa mediante un doblete escalar $H$.

### El Problema de la Masa de los Neutrinos
En la formulación mínima del Modelo Estándar:
1. No existen neutrinos con quiralidad derecha ($\nu_R$ singletes de gauge).
2. Como consecuencia, no se puede escribir un término de masa de Dirac gauge-invariante y renormalizable del tipo $-y_\nu \bar{L} \tilde{H} \nu_R$.
3. El número leptónico total $L$ se conserva como una simetría global accidental a nivel clásico y perturbativo, impidiendo un término de masa de Majorana para los neutrinos izquierdos $\nu_L$.
4. **Predicción teórica del Modelo Estándar mínimo:** $m_\nu \equiv 0$.

### La Evidencia Experimental: Oscilaciones de Sabor
En 1998 (Super-Kamiokande, neutrinos atmosféricos) y 2001-2002 (SNO, neutrinos solares):
- Se comprobó que los autoestados de sabor de los neutrinos $(\nu_e, \nu_\mu, \nu_\tau)$ son combinaciones lineales de autoestados de masa $(\nu_1, \nu_2, \nu_3)$ gobernados por la matriz unitaria PMNS (*Pontecorvo-Maki-Nakagawa-Sakata*):
$$\left|\nu_\alpha\right\rangle = \sum_{i=1}^3 U_{\alpha i}^* \left|\nu_i\right\rangle$$
- La probabilidad de transición entre sabores tras viajar una distancia $L$ con energía $E$ es proporcional a:
$$P(\nu_\alpha \to \nu_\beta) \propto \sin^2\left(\frac{\Delta m_{ij}^2 L}{4E}\right)$$
- Para que $\Delta m_{ij}^2 = m_i^2 - m_j^2 \neq 0$, al menos dos de los tres neutrinos **deben poseer masa no nula**.
- Las cotas cosmológicas (Planck) exigen que la suma de masas sea extremadamente diminuta: $\sum m_\nu \lesssim 0.12 \text{ eV}$ (más de un millón de veces más ligeros que el electrón, $m_e \approx 511.000 \text{ eV}$).

---

## 2. El Mecanismo Escotogénico (Restrepo, Zapata, Yaguna 2013)

### La Idea Central
En lugar del tradicional mecanismo *seesaw* Tipo I a escala de Gran Unificación ($10^{14}$ GeV, inalcanzable experimentalmente), el modelo escotogénico (propuesto originalmente por Ernest Ma en 2006 y ampliado sistemáticamente por Diego Restrepo y colaboradores en 2013) genera masas de neutrinos a **un lazo cuántico (radiativo)** a escala de TeV ($10^3$ GeV), testeable en el LHC.

### Conexión Directa con Materia Oscura
1. Se extiende el Modelo Estándar con nuevos campos fermiónicos y escalares que están protegidos por una simetría discreta exacta $\mathbb{Z}_2$ (impar para las partículas del sector oscuro, par para las del Modelo Estándar).
2. Como consecuencia de la simetría $\mathbb{Z}_2$, los neutrinos **no pueden acoplarse a nivel árbol (*tree-level*)** con el vacío del Higgs estándar.
3. La masa del neutrino emerge de un diagrama de Feynman a un lazo donde las partículas que circulan en el bucle interior pertenecen al sector $\mathbb{Z}_2$-impar (partículas oscuras):
$$(\mathcal{M}_\nu)_{\alpha\beta} \sim \sum_k \frac{h_{\alpha k} h_{\beta k} M_k}{16\pi^2} \left[ \frac{m_{\eta_R}^2}{m_{\eta_R}^2 - M_k^2} \ln\left(\frac{m_{\eta_R}^2}{M_k^2}\right) - \frac{m_{\eta_I}^2}{m_{\eta_I}^2 - M_k^2} \ln\left(\frac{m_{\eta_I}^2}{M_k^2}\right) \right]$$
4. **Doble resultado:**
   - La pequeñez de la masa del neutrino se explica de forma natural por dos supresiones: el factor de bucle cuántico $\frac{1}{16\pi^2}$ y la pequeña separación de masa entre los escalares neutros $(m_{\eta_R}^2 - m_{\eta_I}^2) \propto \lambda_5 v^2$.
   - La partícula más ligera del sector $\mathbb{Z}_2$-impar es absolutamente estable, no decae en partículas ordinarias y constituye un **candidato viable a materia oscura** (WIMP/FIMP).

---

## 3. La Analogía Pedagógica del Guion y su Límite Riguroso

### La Analogía (Beats 26-27 del Guion)
> *"El neutrino es como un corredor que por sí solo no siente resistencia alguna en la pista. Pero al cruzar el vacío cuántico, intercambia un pase fugaz con jugadores invisibles de materia oscura. Ese intercambio breve lo frena un poquito y le da su diminuta masa."*

### El Límite Riguroso (Qué es físicamente y qué NO es)
1. **Qué NO es:**
   - **No hay fricción ni disipación mecánica:** La partícula no pierde energía cinética ni se "desgasta" al viajar por el espacio. No existe ningún medio viscoso material tipo "éter".
   - **No es una colisión real con materia oscura circundante:** El neutrino no necesita chocar con partículas de materia oscura que estén flotando en el espacio interestelar.
2. **Qué SÍ es:**
   - **Fluctuaciones del vacío cuántico:** El neutrino interactúa consigo mismo a través del vacío. En teoría cuántica de campos, el vacío no está vacío: contiene fluctuaciones cuánticas donde partículas virtuales del sector oscuro se crean y aniquilan en intervalos de tiempo permitidos por el principio de incertidumbre de Heisenberg ($\Delta E \Delta t \sim \hbar$).
   - La masa es un término en el lagrangiano cuántico resultante de la autoenergía del propagador del neutrino a un lazo.

---

## 4. Fuentes Primarias y Literatura Científica
- D. Restrepo, O. Zapata, C. E. Yaguna, *"Models with radiative neutrino masses and viable dark matter candidates"*, *JHEP* 11 (2013) 011, [arXiv:1308.3655 [hep-ph]](https://arxiv.org/abs/1308.3655).
- E. Ma, *"Verifiable radiative seesaw mechanism of neutrino mass and dark matter"*, *Phys. Rev. D* 73 (2006) 077301, [arXiv:hep-ph/0601225](https://arxiv.org/abs/hep-ph/0601225).
- Particle Data Group (PDG), *"Neutrino Masses, Mixing, and Oscillations"* (Review of Particle Physics).
