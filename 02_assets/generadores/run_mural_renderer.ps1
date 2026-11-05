$ErrorActionPreference = "Stop"

$csPath = "c:\Proyectos\proyecto-particulas-cosmologia\MuralBeat77Renderer.cs"
$outJpg = "c:\Proyectos\proyecto-particulas-cosmologia\02_assets\graficos\mural_cuatro_cientificos_beat77.jpg"
$outArtifact = "C:\Users\juanj\.gemini\antigravity\brain\40b72386-eda6-459b-83e3-8a289d6331a4\mural_cuatro_cientificos_beat77.jpg"

$pRestrepo = "c:\Proyectos\proyecto-particulas-cosmologia\02_assets\graficos\retrato_diego_restrepo.jpg"
$pPlazas = "c:\Proyectos\proyecto-particulas-cosmologia\02_assets\graficos\retrato_andres_plazas.jpg"
$pSanabria = "c:\Proyectos\proyecto-particulas-cosmologia\02_assets\graficos\retrato_juan_carlos_sanabria.jpg"
$pCastaneda = "c:\Proyectos\proyecto-particulas-cosmologia\02_assets\graficos\retrato_leonardo_castaneda.jpg"

Write-Output "Compilando motor gráfico C# (System.Drawing)..."
Add-Type -ReferencedAssemblies "System.Drawing" -Path $csPath

Write-Output "Renderizando mural 1920x1080 con los 4 retratos confirmados..."
[MuralBeat77Renderer]::Render($pRestrepo, $pPlazas, $pSanabria, $pCastaneda, $outJpg)

Copy-Item $outJpg $outArtifact -Force

Write-Output "Mural renderizado exitosamente:"
Get-Item $outJpg | Select-Object Name, Length, LastWriteTime
