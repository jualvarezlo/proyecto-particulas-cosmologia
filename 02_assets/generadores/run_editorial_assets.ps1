$ErrorActionPreference = "Stop"

$csPath = "c:\Proyectos\proyecto-particulas-cosmologia\GenerateEditorialAssets.cs"
$outDir = "c:\Proyectos\proyecto-particulas-cosmologia\02_assets\graficos"
$artDir = "C:\Users\juanj\.gemini\antigravity\brain\40b72386-eda6-459b-83e3-8a289d6331a4"

$refEinstein = "c:\Proyectos\proyecto-particulas-cosmologia\02_assets\referencias_reales\ref_einstein.jpg"
$refBook1 = "c:\Proyectos\proyecto-particulas-cosmologia\02_assets\referencias_reales\ref_libro_enigma_cielos.jpg"
$refBook2 = "c:\Proyectos\proyecto-particulas-cosmologia\02_assets\referencias_reales\ref_libro_espias_nucleares.jpg"
$refBook3 = "c:\Proyectos\proyecto-particulas-cosmologia\02_assets\referencias_reales\ref_libro_poder_fuego.jpg"

Write-Output "Compilando GenerateEditorialAssets.cs..."
Add-Type -ReferencedAssemblies "System.Drawing" -Path $csPath

Write-Output "1. Renderizando einstein_curvatura.jpg..."
$out1 = "$outDir\einstein_curvatura.jpg"
[GenerateEditorialAssets]::RenderEinsteinCurvatura($refEinstein, $out1)
Copy-Item $out1 "$artDir\einstein_curvatura.jpg" -Force

Write-Output "2. Renderizando portada_tesis_restrepo_2001.jpg..."
$out2 = "$outDir\portada_tesis_restrepo_2001.jpg"
[GenerateEditorialAssets]::RenderTesisRestrepo($out2)
Copy-Item $out2 "$artDir\portada_tesis_restrepo_2001.jpg" -Force

Write-Output "3. Renderizando paper_escotogenico_restrepo.jpg..."
$out3 = "$outDir\paper_escotogenico_restrepo.jpg"
[GenerateEditorialAssets]::RenderPaperRestrepoJHEP($out3)
Copy-Item $out3 "$artDir\paper_escotogenico_restrepo.jpg" -Force

Write-Output "4. Renderizando formulario_matricula_plazas.jpg..."
$out4 = "$outDir\formulario_matricula_plazas.jpg"
[GenerateEditorialAssets]::RenderMatriculaPlazas($out4)
Copy-Item $out4 "$artDir\formulario_matricula_plazas.jpg" -Force

Write-Output "5. Renderizando podcast_vision_cosmica.jpg..."
$out5 = "$outDir\podcast_vision_cosmica.jpg"
[GenerateEditorialAssets]::RenderPodcastVisionCosmica($out5)
Copy-Item $out5 "$artDir\podcast_vision_cosmica.jpg" -Force

Write-Output "6. Renderizando trilogia_libros_sanabria.jpg..."
$out6 = "$outDir\trilogia_libros_sanabria.jpg"
[GenerateEditorialAssets]::RenderTrilogiaSanabria($refBook1, $refBook2, $refBook3, $out6)
Copy-Item $out6 "$artDir\trilogia_libros_sanabria.jpg" -Force

Write-Output "7. Renderizando paper_castaneda_termino_frontera.jpg..."
$out7 = "$outDir\paper_castaneda_termino_frontera.jpg"
[GenerateEditorialAssets]::RenderPaperCastaneda($out7)
Copy-Item $out7 "$artDir\paper_castaneda_termino_frontera.jpg" -Force

Write-Output "=== Todos los 7 assets editoriales han sido generados exitosamente ==="
Get-ChildItem -Path $outDir -Filter "*.jpg" | Select-Object Name, Length, LastWriteTime
