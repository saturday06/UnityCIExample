﻿using System;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;

namespace UnityCIExample
{
    public static class Builder
    {
        public static void BuildPlayer()
        {
            var buildPlayerOptions = new BuildPlayerOptions
            {
                locationPathName = "Build",
                scenes = EditorBuildSettings.scenes.Where(scene => scene.enabled).Select(scene => scene.path).ToArray(),
            };
            var report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            if (report.summary.result != BuildResult.Succeeded)
            {
                throw new Exception("Build failed: " + report.summary);
            }
        }
    }
}