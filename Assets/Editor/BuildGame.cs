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
        
        string[] scenes = { "Assets/Scenes/Open_Scene.unity", "Assets/Scenes/SampleScene.unity" };
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = exePath,
            target = BuildTarget.StandaloneWindows64,
            options = BuildOptions.None
        };
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        
        if (report.summary.result == BuildResult.Succeeded)
            UnityEngine.Debug.Log("Build succeeded: " + exePath);
        else
            UnityEngine.Debug.LogError("Build failed! Result: " + report.summary.result);
    }
}