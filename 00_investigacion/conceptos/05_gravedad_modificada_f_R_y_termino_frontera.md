# Concepto Físico: Gravedad Modificada $f(R)$, Principio Variacional y el Término de Frontera

**Área:** Gravitación Teórica / Relatividad General y Cosmología Matemática  
**Científico vinculado en el guion:** Dr. Leonardo Castañeda Colorado (Observatorio Astronómico Nacional - UNAL)  
**Beats del guion relacionados:** Beats 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75

---

## 1. De la Relatividad General a las Teorías $f(R)$

### La Acción de Einstein-Hilbert
En la Relatividad General estándar (1915), la dinámica del espacio-tiempo en una variedad pseudoriemanniana cuadridimensional $(\mathcal{M}, g_{\mu\nu})$ se obtiene a partir de la acción de Einstein-Hilbert:
$$S_{\text{EH}} = \frac{1}{2\kappa} \int_{\mathcal{M}} d^4x \sqrt{-g} \, R + S_m[g_{\mu\nu}, \psi_m]$$

Donde $\kappa = \frac{8\pi G}{c^4}$, $g = \det(g_{\mu\nu})$, $R = g^{\mu\nu} R_{\mu\nu}$ es el escalar de curvatura de Ricci y $S_m$ es la acción de la materia.

Al variar esta acción respecto a la métrica inversa $g^{\mu\nu}$ y exigir que la acción sea estacionaria ($\delta S = 0$), se obtienen las célebres ecuaciones de campo de Einstein:
$$G_{\mu\nu} \equiv R_{\mu\nu} - \frac{1}{2}g_{\mu\nu}R = \kappa T_{\mu\nu}$$

### La Motivación Cosmológica: La Alternativa a la Energía Oscura
Para explicar la aceleración de la expansión cósmica observada ($q < 0$), el modelo $\Lambda\text{CDM}$ agrega a mano una constante cosmológica $\Lambda$:
$$G_{\mu\nu} + \Lambda g_{\mu\nu} = \kappa T_{\mu\nu}$$

Sin embargo, $\Lambda$ sufre del **problema de la constante cosmológica** (su valor medido es $10^{120}$ órdenes de magnitud menor que la densidad de energía del vacío predicha por la teoría cuántica de campos).

**La hipótesis geométrica de las teorías $f(R)$:**  
¿Y si la aceleración cósmica no proviene de una sustancia material exótica en el lado derecho ($T_{\mu\nu}$), sino de una modificación de la ley geométrica de la gravedad en el lado izquierdo ($G_{\mu\nu}$)?  
Se generaliza la acción sustituyendo el escalar lineal $R$ por una función no lineal $f(R)$:
$$S_{f(R)} = \frac{1}{2\kappa} \int_{\mathcal{M}} d^4x \sqrt{-g} \, f(R) + S_m$$

---

## 2. El Formalismo Métrico y las Ecuaciones de Cuarto Orden

En el **formalismo métrico**, la conexión afín $\Gamma^\alpha_{\mu\nu}$ es exclusivamente la conexión de Levi-Civita determinada por la métrica $g_{\mu\nu}$.

Al variar la acción $S_{f(R)}$ respecto a $g^{\mu\nu}$:
1. Aparecen términos proporcionales a las derivadas segundas del escalar de Ricci: $\nabla_\mu \nabla_\nu f'(R)$ y $\Box f'(R)$, donde $f'(R) \equiv \frac{df}{dR}$.
2. Como $R$ contiene derivadas segundas de la métrica ($\partial^2 g$), las ecuaciones de campo resultantes son **ecuaciones diferenciales en derivadas parciales no lineales de cuarto orden** en las componentes de la métrica $g_{\mu\nu}$:
$$f'(R) R_{\mu\nu} - \frac{1}{2} f(R) g_{\mu\nu} - \left( \nabla_\mu \nabla_\nu - g_{\mu\nu} \Box \right) f'(R) = \kappa T_{\mu\nu}$$

*(Nótese que si $f(R) = R$, entonces $f'(R) = 1$, las derivadas de $f'(R)$ se anulan y se recuperan idénticamente las ecuaciones de segundo orden de Einstein).*

---

## 3. El Problema del Principio Variacional y el Término de Frontera

### El Problema en la Relatividad General Clásica
Al calcular la variación $\delta S_{\text{EH}}$, la integración por partes genera una integral sobre la frontera tridimensional $\partial \mathcal{M}$:
$$\delta S_{\text{EH}} = \frac{1}{2\kappa} \int_{\mathcal{M}} d^4x \sqrt{-g} G_{\mu\nu} \delta g^{\mu\nu} + \frac{1}{2\kappa} \oint_{\partial \mathcal{M}} d^3y \, \epsilon \sqrt{|h|} \, n^\sigma \left( g^{\mu\nu} \nabla_\sigma \delta g_{\mu\nu} - \nabla^\mu \delta g_{\mu\sigma} \right)$$

- Aunque fijemos que la variación de la métrica sea nula en la frontera ($\left.\delta g_{\mu\nu}\right|_{\partial \mathcal{M}} = 0$), las **derivadas normales** de la variación $\left.n^\sigma \nabla_\sigma \delta g_{\mu\nu}\right|_{\partial \mathcal{M}}$ **no tienen por qué anularse**.
- Para que el principio variacional esté bien definido matemáticamente y no aparezcan restricciones espurias sobre las derivadas normales, Gibbons, York y Hawking (1977) demostraron que se debe añadir a la acción un término de superficie:
$$S_{\text{GHY}} = \frac{1}{\kappa} \oint_{\partial \mathcal{M}} d^3y \, \epsilon \sqrt{|h|} \, K$$
donde $h_{ab}$ es la métrica inducida en la frontera y $K = h^{ab} K_{ab}$ es la traza de la curvatura extrínseca.

### El Aporte de Castañeda, Guarnizo y Tejeiro (2010)
En gravedad $f(R)$, al ser una teoría de cuarto orden, la variación en la frontera es mucho más intrincada porque involucra derivadas normales de segundo orden.

Tradicionalmente, muchos autores eludían el problema transformando conformalmente la métrica ($g_{\mu\nu} \to \tilde{g}_{\mu\nu} = f'(R) g_{\mu\nu}$) para pasar del "marco de Jordan" a un "marco de Einstein" equivalente con un campo escalar acoplado.

En su artículo fundamental de 2010 en *General Relativity and Gravitation* (+105 citas):
1. **Deducción directa en el formalismo métrico:** Alejandro Guarnizo, Leonardo Castañeda y Juan Manuel Tejeiro dedujeron rigurosamente las ecuaciones de campo completas trabajando directamente en la teoría métrica original, sin necesidad de redefiniciones de campos ni marcos conformes.
2. **El Término de Frontera Generalizado:** Determinaron la forma matemática exacta del término de superficie que debe añadirse a la acción $f(R)$ para cancelar las derivadas normales de $\delta g_{\mu\nu}$ y de $\delta R$ en la hipersuperficie frontera $\partial \mathcal{M}$:
$$S_{\text{frontera}}^{f(R)} = \frac{1}{\kappa} \oint_{\partial \mathcal{M}} d^3y \, \epsilon \sqrt{|h|} \, f'(R) K + S_{\text{adicional}}$$
3. **Consistencia:** Probaron que este término garantiza la conservación covariante del tensor de energía-momento ($\nabla^\mu T_{\mu\nu} = 0$) y permite formular adecuadamente problemas de frontera, termodinámica de agujeros negros y la **ecuación de desviación geodésica** (Guarnizo, Castañeda, Tejeiro 2011) para el estudio de ondas gravitacionales y lentes en gravedad modificada.

---

## 4. Las Analogías del Guion y sus Límites Físicos

### Analogía 1: La Tela Elástica No Lineal (Beats 68-69)
> *"Piensa en el espacio-tiempo como una tela elástica. En la teoría de Einstein, la tela tiene una sola ley de elasticidad fija. En la gravedad $f(R)$, la rigidez de la tela cambia cuando la estiras a escalas cosmológicas."*
- **SÍ es:** Una metáfora intuitiva de la transición entre una respuesta lineal de la curvatura frente a la densidad ($f(R) = R$) y una respuesta no lineal a curvaturas extremadamente bajas ($R \to 0$ en el vacío cósmico) donde términos tipo $R - \mu^4 / R$ o $R + \alpha R^2$ dominan.
- **Límite Explícito (Beat 69):**
  - La tela real es un objeto bidimensional inmerso en un espacio euclidiano tridimensional que necesita la gravedad terrestre hacia abajo para deformarse con el peso de una bola.
  - El espacio-tiempo **tiene cuatro dimensiones intrínsecas** ($3+1$), no está inmerso en ningún espacio exterior y su curvatura es una propiedad geométrica intrínseca codificada en el tensor de Riemann.

### Analogía 2: La Auditoría del Banco (Beat 72)
> *"Si auditas solo el dinero que se mueve entre los escritorios del banco, pero ignoras los billetes que entran y salen por las puertas y ventanas, las cuentas jamás van a cuadrar. El término de frontera cuadra el balance de la acción en los bordes del universo."*
- **SÍ es:** El teorema de la divergencia / Stokes aplicado a un principio variacional: una integral de volumen de una divergencia total ($\int_{\mathcal{M}} \nabla_\mu V^\mu d^4x$) se convierte en un flujo neto a través de la superficie frontera ($\oint_{\partial \mathcal{M}} V^\mu d\Sigma_\mu$). Si ignoras ese flujo de frontera, la variación no se anula y el principio de mínima acción falla.
- **Límite Riguroso:** No se trata de un balance de conservación de materia, sino de una consistencia matemática sobre el espacio de configuraciones admisibles de la métrica.

---

## 5. Fuentes Primarias y Literatura Científica
- A. Guarnizo, L. Castañeda, J. M. Tejeiro, *"Boundary Term in Metric $f(R)$ Gravity: Field Equations in the Metric Formalism"*, *Gen. Relativ. Gravit.* 42 (2010) 2713–2728, [arXiv:1002.0617 [gr-qc]](https://arxiv.org/abs/1002.0617).
- A. Guarnizo, L. Castañeda, J. M. Tejeiro, *"Geodesic Deviation Equation in $f(R)$ Gravity"*, *Gen. Relativ. Gravit.* 43 (2011) 2713, [arXiv:1010.5279 [gr-qc]](https://arxiv.org/abs/1010.5279).
- T. P. Sotiriou, V. Faraoni, *"$f(R)$ Theories of Gravity"*, *Rev. Mod. Phys.* 82 (2010) 451, [arXiv:0805.1726 [gr-qc]](https://arxiv.org/abs/0805.1726).
- A. De Felice, S. Tsujikawa, *"$f(R)$ Theories"*, *Living Rev. Relativ.* 13 (2010) 3, [arXiv:1002.4928 [gr-qc]](https://arxiv.org/abs/1002.4928).
