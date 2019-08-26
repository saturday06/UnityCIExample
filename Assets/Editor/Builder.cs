using System;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;

namespace UnityCIExample
{
    public class Builder
    {
        public static void BuildPlayer()
        {
            var buildPlayerOptions = new BuildPlayerOptions
            {
                locationPathName = "Build",
                scenes = new [] { "Assets/Scenes/SampleScene.unity" },
                target = EditorUserBuildSettings.activeBuildTarget,
                targetGroup = BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget),
            };
            if (buildPlayerOptions.target == BuildTarget.Android)
            {
                buildPlayerOptions.locationPathName += ".apk";
            }
            var report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            if (report.summary.result != BuildResult.Succeeded)
            {
                throw new Exception("Build failed: " + report.summary.result);
            }
        }
    }
}
