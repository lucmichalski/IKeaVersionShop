using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LoadAssets : MonoBehaviour
{
    public string assetName = "chair1";
    public string bundleName = "chair";
    public GameObject obj;
    public GameObject parentObj;
    // Start is called before the first frame update
    void Start()
    {
        obj.transform.position = parentObj.transform.position;
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
        if (localAssetBundle == null)
        {
            Debug.LogError("Failed to load AssetBundle!");
            return;
        }
        GameObject asset = localAssetBundle.LoadAsset<GameObject>(assetName);
      // obj = Instantiate(asset) as GameObject;
        // obj.transform.localScale += new Vector3(10F, 10F, 10F);
      //asset.transform.SetParent(obj.transform.parent, false);
        obj = Instantiate(asset) as GameObject;
        obj.transform.SetParent(parentObj.transform, false);
        localAssetBundle.Unload(false);
        ////////////////
        ///


        //string url = "http://filmbuzzer.com/AssetBundles/Chair";
        //   WWW www = new WWW(url);
        //  StartCoroutine(WaitForReq(www));

    }



    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.F))
        {
            if (obj != null)
            {
                Destroy(obj);
                AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "furniture"));
                GameObject asset = localAssetBundle.LoadAsset<GameObject>("furniture1");
                obj = Instantiate(asset) as GameObject;
                obj.transform.SetParent(parentObj.transform, false);
                localAssetBundle.Unload(false);
            }
        }

        else if (Input.GetKeyDown(KeyCode.T))
        {
            if (obj != null)
            {
                Destroy(obj);
                AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "bedsidetable"));
                GameObject asset = localAssetBundle.LoadAsset<GameObject>("bedsidetable");
                obj = Instantiate(asset) as GameObject;
                obj.transform.SetParent(parentObj.transform, false);
                localAssetBundle.Unload(false);
            }
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (obj != null)
            {
                Destroy(obj);
                AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "chair"));
                GameObject asset = localAssetBundle.LoadAsset<GameObject>("chair1");
                obj = Instantiate(asset) as GameObject;
                obj.transform.SetParent(parentObj.transform, false);
                localAssetBundle.Unload(false);
            }
        }

        else if (Input.GetKeyDown(KeyCode.P))
        {
            if (obj != null)
            {
                Destroy(obj);
                AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "plant"));
                GameObject asset = localAssetBundle.LoadAsset<GameObject>("plant1");
                obj = Instantiate(asset) as GameObject;
                obj.transform.SetParent(parentObj.transform, false);
                localAssetBundle.Unload(false);
            }
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (obj != null)
            {
                Destroy(obj);
                AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "sofa"));
                GameObject asset = localAssetBundle.LoadAsset<GameObject>("sofa");
                obj = Instantiate(asset) as GameObject;
                obj.transform.SetParent(parentObj.transform, false);
                localAssetBundle.Unload(false);
            }
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (obj != null)
            {
                Destroy(obj);
                AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "tablewood"));
                GameObject asset = localAssetBundle.LoadAsset<GameObject>("bedsidetablewood");
                obj = Instantiate(asset) as GameObject;
                obj.transform.SetParent(parentObj.transform, false);
                localAssetBundle.Unload(false);
            }
        }
    }
}
