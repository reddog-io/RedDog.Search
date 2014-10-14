// include Fake lib
#r @"tools/fake/FakeLib.dll"
open Fake
open Fake.AssemblyInfoFile

let productDescription = "A client SDK for Microsoft Azure Search."
let productName = "Red Dog"

let version = environVarOrDefault "version" "0.2.1.0"
let buildDir = "./build/output/"
let packagingDir = "./build/packages/"


Target "Clean" (fun _ ->
    CleanDir buildDir
)

Target "Build" (fun _ ->
    CreateCSharpAssemblyInfo "./src/RedDog.Search/Properties/AssemblyInfo.cs"
        [Attribute.Title "RedDog.Search"
         Attribute.Description productDescription
         Attribute.Product productName
         Attribute.Version version
         Attribute.FileVersion version]

    // Build all projects.
    !! "./src/**/*.csproj"
      |> MSBuildRelease buildDir "Build"
      |> Log "AppBuild-Output: "
)

Target "Package" (fun _ ->
    let author = 
            [
                "Sandrino Di Mattia"
                "Toon De Coninck"
            ]

    // Prepare RedDog.Search.
    let workingDir = packagingDir
    let net45Dir = workingDir @@ "lib/net45/"
    CleanDirs [workingDir; net45Dir]
    CopyFile net45Dir (buildDir @@ "RedDog.Search.dll")
        
    // Package RedDog.Search
    NuGet (fun p ->
        {p with
            Authors = author
            Project = "RedDog.Search"
            Description = productDescription
            OutputPath = packagingDir
            Summary = productDescription
            WorkingDir = workingDir
            Version = version }) "./packaging/RedDog.Search.nuspec"
)
    
// Default target
Target "Default" (fun _ ->
    let msg = "Building RedDog.Search version: " + version
    trace msg
)

// Dependencies
"Clean"
   ==> "Build"
   ==> "Package"
   ==> "Default"
  
// Start Build
RunTargetOrDefault "Default"