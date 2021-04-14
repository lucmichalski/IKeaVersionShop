using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BundlerLoaderAsync : MonoBehaviour
{
    public GameObject obj;
    public GameObject parentObj;
    // Start is called before the first frame update
    void Start()
    {
        obj.transform.position = parentObj.transform.position;
        string url = "https://bundle-asset.s3.amazonaws.com/BundledAssets/sofa.fbx";
        WWW www = new WWW(url);
        StartCoroutine(WaitForReq(www));
    }


    IEnumerator WaitForReq(WWW www)
    {
        yield return www;
        AssetBundle bundle = www.assetBundle;
        if (www.error == "")
        {
            GameObject sofa = bundle.LoadAsset<GameObject>("sofa");
            obj = Instantiate(sofa) as GameObject;
            obj.transform.SetParent(parentObj.transform, false);
        } else
        {
            Debug.Log(www.error);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
