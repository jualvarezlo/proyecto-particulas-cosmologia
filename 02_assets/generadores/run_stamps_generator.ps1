Add-Type -ReferencedAssemblies "System.Drawing" -TypeDefinition (Get-Content "c:\Proyectos\proyecto-particulas-cosmologia\GenerateStampsAndLabels.cs" -Raw -Encoding UTF8)
[GenerateStampsAndLabels]::Main()
