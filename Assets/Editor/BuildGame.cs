using UnityEditor;
using UnityEditor.Build.Reporting;
using System.IO;

public static class BuildGame
{
    [MenuItem("Build/Build Windows")]
    public static void BuildWindows()
    {
        string buildPath = Path.Combine("build", "StandaloneWindows64");
        if (!Directory.Exists(buildPath))
            Directory.CreateDirectory(buildPath);
        
        string exePath = Path.Combine(buildPath, "Lenfilm.exe");
        
        BuildReport report = BuildPipeline.BuildPlayer(
            EditorBuildSettings.scenes,
            exePath,
            BuildTarget.StandaloneWindows64,
            BuildOptions.None
        );
        
        if (report.summary.result == BuildResult.Succeeded)
            UnityEngine.Debug.Log("Build succeeded: " + exePath);
        else
            UnityEngine.Debug.LogError("Build failed! Result: " + report.summary.result);
    }
}