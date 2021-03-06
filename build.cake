//Addins
#addin Cake.VersionReader
#addin Cake.FileHelpers
#tool "nuget:?package=NUnit.ConsoleRunner"
#tool "nuget:?package=OpenCover"

var tools = "./tools";
var sln = "./src/SemanticUx.sln";
var releaseFolder = "./src/SemanticUx/bin/Release";
var releaseDll = "/SemanticUx.dll";
var unitTestPaths = "./src/SemanticUx.Tests/bin/Debug/SemanticUx.Tests.dll";
var nuspecFile = "SemanticUx.nuspec";
var testResultFile = "./TestResult.xml";
var testErrorFile = "./Errors.xml";
var coverPath = "./CoverageResults.xml";

var target = Argument ("target", "Build");
var buildType = Argument<string>("buildType", "develop");
var buildCounter = Argument<int>("buildCounter", 0);

var version = "0.0.0";
var ciVersion = "0.0.0-CI00000";
var runningOnTeamCity = false;
var runningOnAppVeyor = false;
var testSucceeded = true;

//Paket folders
var paketBootstrapper = "./.paket/paket.bootstrapper.exe";
var paketExecutable = "./.paket/paket.exe";
var paketBootstrapperUrl = "https://github.com/fsprojects/Paket/releases/download/3.1.9/paket.bootstrapper.exe";

//SonarQube
var sonarUrl = "https://github.com/SonarSource-VisualStudio/sonar-scanner-msbuild/releases/download/2.1/MSBuild.SonarQube.Runner-2.1.zip";
var sonarZipPath = tools + "/SonarQube.zip";
var sonarQubeServerUrl = "";
var sonarQubeProject = "";
var sonarQubeKey = "";

// Find out if we are running on a Build Server
Task("DiscoverBuildDetails")
	.Does(() =>
	{
		runningOnTeamCity = TeamCity.IsRunningOnTeamCity;
		Information("Running on TeamCity: " + runningOnTeamCity);
		runningOnAppVeyor = AppVeyor.IsRunningOnAppVeyor;
		Information("Running on AppVeyor: " + runningOnAppVeyor);
	});

Task("OutputVariables")
	.Does(() =>
	{
		Information("BuildType: " + buildType);
		Information("BuildCounter: " + buildCounter);
	});

Task ("Build")
.IsDependentOn("OutputVariables")
.IsDependentOn("DiscoverBuildDetails")
.IsDependentOn("ToolSetup")
.IsDependentOn("PaketRestore")
.IsDependentOn("SonarQubeStartup")
	.Does (() => {
		DotNetBuild (sln, c => c.Configuration = "Release");
		var file = MakeAbsolute(Directory(releaseFolder)) + releaseDll;
		version = GetVersionNumber(file);
		ciVersion = GetVersionNumberWithContinuesIntegrationNumberAppended(file, buildCounter);
		Information("Version: " + version);
		Information("CI Version: " + ciVersion);
		PushVersion(ciVersion);
	});

//Execute Unit tests
Task("UnitTest")
	.IsDependentOn("Build")
	.Does(() =>
	{
		StartBlock("Unit Testing");

		var testAssemblies = GetFiles(unitTestPaths);
		OpenCover(tool => {
				tool.NUnit3(testAssemblies, new NUnit3Settings {
    				ErrorOutputFile = testErrorFile
    			});
			},
			new FilePath(coverPath),
			new OpenCoverSettings()
                .WithFilter("+:SemanticUx")
    			.WithFilter("-:SemanticUx.Tests")
		);

		if(FileExists(testErrorFile) && FileReadLines(testErrorFile).Count() > 0)
		{
			Information("Unit tests failed");
			testSucceeded = false;
		}
		
		EndBlock("Unit Testing");
	});
	
Task ("Nuget")
	.WithCriteria(buildType == "master")
	.IsDependentOn ("SonarQubeShutdown")
	.Does (() => {
		if(!testSucceeded)
		{
			Error("Unit tests failed - Cannot push to Nuget");
			throw new Exception("Unit tests failed");
		}

		CreateDirectory ("./nupkg/");
		ReplaceRegexInFiles(nuspecFile, "0.0.0", version);
		
		NuGetPack (nuspecFile, new NuGetPackSettings { 
			Verbosity = NuGetVerbosity.Detailed,
			OutputDirectory = "./nupkg/"
		});	
	});

//Restore Paket
Task("PaketRestore")
	.Does(() => {
		StartBlock("Restoring Paket");
		var paketBootstrapperFullPath = MakeAbsolute(File(paketBootstrapper));
		if(!FileExists(paketBootstrapperFullPath))
		{
			DownloadFile(paketBootstrapperUrl, paketBootstrapperFullPath);
		}
		StartProcess(paketBootstrapper);
		StartProcess(paketExecutable, new ProcessSettings{ Arguments = "restore" });
		EndBlock("Restoring Paket");
	});

Task ("Push")
	.WithCriteria(buildType == "master")
	.IsDependentOn ("Nuget")
	.Does (() => {
		// Get the newest (by last write time) to publish
		var newestNupkg = GetFiles ("nupkg/*.nupkg")
			.OrderBy (f => new System.IO.FileInfo (f.FullPath).LastWriteTimeUtc)
			.LastOrDefault();

		var apiKey = EnvironmentVariable("NugetKey");

		NuGetPush (newestNupkg, new NuGetPushSettings { 
			Verbosity = NuGetVerbosity.Detailed,
			Source = "https://www.nuget.org/api/v2/package/",
			ApiKey = apiKey
		});
	});

Task("ToolSetup")
	.Does(() =>{
		StartBlock("Tool Setup");
		if(!FileExists(sonarZipPath))
		{
			Information("Downloading SonarQube");
			DownloadFile(sonarUrl, sonarZipPath);
		}
		if(!FileExists(tools + "/MSBuild.SonarQube.Runner.exe"))
		{
			Information("Extraction SonarQube");
			Unzip(tools + "/SonarQube.zip", tools + "/");
		}
		
		EndBlock("Tool Setup");
	});

Task("SonarQubeStartup")
	.Does(() =>{
		StartBlock("SonarQube Startup");

		sonarQubeKey = EnvironmentVariable("SonarQubeKey");
		var testResult = MakeAbsolute(File(testResultFile));
		var coveragePath = MakeAbsolute(File(coverPath));
		var arguments = "begin /k:\"" + sonarQubeKey + "\" /n:\"" + sonarQubeProject + "\" /d:sonar.host.url=" + sonarQubeServerUrl + " /d:sonar.cs.dotcover.reportsPaths=\"" + coveragePath + "\" /v:\"" + buildCounter + "\"";
		StartProcess(tools + "/MSBuild.SonarQube.Runner.exe", new ProcessSettings{ Arguments = arguments });
	});

Task("SonarQubeShutdown")
	.IsDependentOn("UnitTest")
	.Does(() => {
		StartBlock("SonarQube Shutdown");
		StartProcess(tools + "/MSBuild.SonarQube.Runner.exe", new ProcessSettings{ Arguments = "end" });
		EndBlock("SonarQube Shutdown");
	});

Task("Default")
	.IsDependentOn("SonarQubeShutdown");
Task("Release")
    .IsDependentOn("Push");

RunTarget (target);

public void StartBlock(string blockName)
{
		if(runningOnTeamCity)
		{
			TeamCity.WriteStartBlock(blockName);
		}
}

public void StartBuildBlock(string blockName)
{
	if(runningOnTeamCity)
	{
		TeamCity.WriteStartBuildBlock(blockName);
	}
}

public void EndBlock(string blockName)
{
	if(runningOnTeamCity)
	{
		TeamCity.WriteEndBlock(blockName);
	}
}

public void EndBuildBlock(string blockName)
{
	if(runningOnTeamCity)
	{
		TeamCity.WriteEndBuildBlock(blockName);
	}
}

public void PushVersion(string version)
{
	if(runningOnTeamCity)
	{
		TeamCity.SetBuildNumber(version);
	}
	if(runningOnAppVeyor)
	{
		Information("Pushing version to AppVeyor: " + version);
		AppVeyor.UpdateBuildVersion(version);
	}
}

public void PushTestResults(string filePath)
{
	var file = MakeAbsolute(File(filePath));
	if(runningOnAppVeyor)
	{
		AppVeyor.UploadTestResults(file, AppVeyorTestResultsType.NUnit3);
	}
}