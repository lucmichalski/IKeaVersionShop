using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LoadAssets : MonoBehaviour
{
    public string assetName = "chair1";
    public string bundleName = "chair";
    public GameObject asset;
    // Start is called before the first frame update
    void Start()
    {
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
        if (localAssetBundle == null)
        {
            Debug.LogError("Failed to load AssetBundle!");
            return;
        }
        asset = localAssetBundle.LoadAsset<GameObject>(assetName);
        Instantiate(asset);
        localAssetBundle.Unload(false);
        //string url = "http://filmbuzzer.com/AssetBundles/Chair";
     //   WWW www = new WWW(url);
      //  StartCoroutine(WaitForReq(www));

    }

    IEnumerator WaitForReq(WWW www)
    {
        yield return www;
        AssetBundle bunlde = www.assetBundle;
        if (www.error == null)
        {
            //GameObject asset = localAssetBundle.LoadAsset<GameObject>("chair1");
            //    (GameObject)AssetBundle.LoadAsset("Chair");
           // Instantiate(asset);
        }
        else
        {
            Debug.Log(www.error);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
