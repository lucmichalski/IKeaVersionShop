﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class CreateAssetBundles : MonoBehaviour
{
   [MenuItem("Assets/Build AssetBundles")]
   static void BuildAllAssetBundles()
    {
        if (!Directory.Exists(Application.streamingAssetsPath)){
        	Directory.CreateDirectory("Assets/StreamingAssets");
        }

        BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);

    }
}
