import {
  makeScene2D,
  Camera,
  Circle,
  Grid,
  Line,
  Node,
  Path,
  Rect,
  Txt,
} from '@motion-canvas/2d';
import {
  all,
  createRef,
  createSignal,
  easeInOutCubic,
  easeOutBack,
  easeOutCubic,
  easeOutExpo,
  spawn,
  tween,
  waitFor,
} from '@motion-canvas/core';

/**
 * BLOQUE 0 (COLD OPEN) · BEAT 01 [00:00 - 00:11]
 * Escena declarativa en Motion Canvas (@motion-canvas/2d)
 * Dirección de arte: Vox Explainer + Quantum Fracture Mixed-Media Collage
 */
export default makeScene2D(function* (view) {
  const PALETTE = {
    cream: '#F4EFE6',
    creamCard: '#FAF6EE',
    charcoal: '#1D1E2C',
    cyan: '#00B4D8',
    amber: '#F77F00',
    stickerWhite: '#FDFBF7',
  };

  view.fill(PALETTE.cream);

  const camera = createRef<Camera>();
  const blueprintGrid = createRef<Grid>();
  const solarStamp = createRef<Rect>();
  const thumbGroup = createRef<Node>();
  const mainBanner = createRef<Rect>();
  const contrastStamp = createRef<Rect>();
  const trajectoryLine = createRef<Line>();

  // Señales reactivas (Motion Canvas Signals System)
  const neutrinoCounter = createSignal(0);
  const beamProgress = createSignal(0);

  view.add(
    <Camera ref={camera}>
      {/* Capa 0: Cuadrícula técnica con trazado progresivo start/end */}
      <Grid
        ref={blueprintGrid}
        width={1920}
        height={1080}
        spacing={120}
        stroke={'rgba(0, 180, 216, 0.22)'}
        lineWidth={1.5}
        start={0}
        end={0}
      />

      {/* Capa 1: Sello Solar en esquina superior izquierda */}
      <Rect
        ref={solarStamp}
        x={-670}
        y={-285}
        width={410}
        height={310}
        fill={PALETTE.creamCard}
        stroke={PALETTE.stickerWhite}
        lineWidth={12}
        rotation={-2.4}
        scale={0}
        shadowColor={'rgba(29, 30, 44, 0.24)'}
        shadowBlur={22}
        shadowOffset={[6, 10]}
      >
        <Circle x={-92} y={-12} width={96} height={96} fill={PALETTE.amber} stroke={PALETTE.charcoal} lineWidth={3} />
        <Txt
          x={50}
          y={-95}
          text={'SOLAR CORE | 1.5 × 10⁷ K'}
          fontFamily={'JetBrains Mono'}
          fontSize={14}
          fontWeight={800}
          fill={PALETTE.charcoal}
        />
        <Txt
          x={50}
          y={-15}
          text={'p + p → ²H + e⁺ + νₑ'}
          fontFamily={'JetBrains Mono'}
          fontSize={16}
          fontWeight={800}
          fill={PALETTE.cyan}
        />
      </Rect>

      {/* Capa 2: Haz diagonal de neutrinos con draw-on progresivo */}
      <Line
        ref={trajectoryLine}
        points={[
          [-755, -295],
          [195, -55],
          [1090, 162],
        ]}
        stroke={PALETTE.cyan}
        lineWidth={4}
        lineDash={[16, 10]}
        end={() => beamProgress()}
        endArrow
      />

      {/* Capa 3: Recorte de Mano y Pulgar con retícula sobre la uña */}
      <Node ref={thumbGroup} x={195} y={-55} opacity={0}>
        <Path
          data={'M 385 475 C 255 425 140 360 60 260 C 10 195 -40 135 -70 70 C -87 30 -83 -23 -53 -51 C -20 -80 37 -73 60 -33 Z'}
          fill={'#EFE3D0'}
          stroke={PALETTE.stickerWhite}
          lineWidth={14}
        />
        <Rect
          width={116}
          height={116}
          stroke={PALETTE.amber}
          lineWidth={3}
          lineDash={[8, 6]}
        />
      </Node>
    </Camera>,
  );

  // Capa UI fija: Banners Editoriales
  view.add(
    <>
      <Rect
        ref={mainBanner}
        x={-488}
        y={138}
        width={760}
        height={146}
        fill={PALETTE.charcoal}
        stroke={PALETTE.stickerWhite}
        lineWidth={10}
        opacity={0}
      >
        <Txt
          y={-42}
          text={() =>
            `FLUJO SOLAR: ~6.5 × 10¹⁰ νₑ / cm²·s [${Math.round(neutrinoCounter()).toLocaleString('es-CO')}.000.000 νₑ/s]`
          }
          fontFamily={'JetBrains Mono'}
          fontSize={14}
          fontWeight={800}
          fill={PALETTE.cyan}
        />
        <Txt
          y={15}
          text={'100.000 MILLONES POR SEGUNDO'}
          fontFamily={'Archivo Black'}
          fontSize={38}
          fill={PALETTE.stickerWhite}
        />
      </Rect>

      <Rect
        ref={contrastStamp}
        x={-450}
        y={305}
        width={835}
        height={128}
        fill={PALETTE.amber}
        stroke={PALETTE.stickerWhite}
        lineWidth={10}
        rotation={-1.1}
        scale={0}
      >
        <Txt
          y={-28}
          text={'MATERIA TRANSPARENTE — 0 COLISIONES // σ ≈ 10⁻⁴⁴ cm²'}
          fontFamily={'JetBrains Mono'}
          fontSize={14}
          fontWeight={800}
          fill={PALETTE.stickerWhite}
        />
        <Txt
          y={22}
          text={'Y TÚ NO SIENTES ABSOLUTAMENTE NADA'}
          fontFamily={'Archivo Black'}
          fontSize={34}
          fill={PALETTE.charcoal}
        />
      </Rect>
    </>,
  );

  // Push-in continuo 2D de cámara durante los 11.0s (1.00x -> 1.045x)
  spawn(function* () {
    yield* all(
      camera().zoom(1.045, 11.0, easeInOutCubic),
      camera().position([24, 10], 11.0, easeInOutCubic),
    );
  });

  // 0.0s - 1.65s: Trazado de cuadrícula, entrada de sello solar, pulgar y haz de neutrinos
  yield* all(
    blueprintGrid().end(1, 0.9, easeOutCubic),
    solarStamp().scale(1, 0.8, easeOutBack),
    thumbGroup().opacity(1, 0.9, easeOutCubic),
    beamProgress(1, 1.35, easeOutCubic),
  );

  yield* waitFor(0.3);

  // 1.65s - 3.6s: Entrada del banner "100.000 MILLONES POR SEGUNDO" y contador
  yield* all(
    mainBanner().opacity(1, 0.35, easeOutCubic),
    neutrinoCounter(100000, 1.8, easeOutExpo),
  );

  // Esperar hasta el segundo 7.2s ("Y tú no sientes absolutamente nada")
  yield* waitFor(3.75);

  // 7.2s - 11.0s: Estampado del sello de contraste y respiración final
  yield* contrastStamp().scale(1, 0.45, easeOutBack);
  yield* waitFor(3.35);
});
