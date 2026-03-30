using UnityEditor;
using System.IO;

public static class BuildScript
{
    public static void BuildWindows()
    {
        string buildPath = Path.Combine("build", "StandaloneWindows64");
        if (!Directory.Exists(buildPath))
            Directory.CreateDirectory(buildPath);
        string[] scenes = {
            "Assets/Scenes/SampleScene.unity"
        };
        string exePath = Path.Combine(buildPath, "Lenfilm.exe");
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = exePath,
            target = BuildTarget.StandaloneWindows64,
            options = BuildOptions.None
        };
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        if (File.Exists(exePath))
            UnityEngine.Debug.Log("Build succeeded: " + exePath);
        else
            UnityEngine.Debug.LogError("Build failed! Check the log for errors.");
    }
}