using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking; //for assetbundle online

using System.IO;//for listening
using UnityEngine.EventSystems;//for touc

public class BundlerLoaderAsync : MonoBehaviour
{


    private Touch touch;

    public GameObject obj;
    public GameObject parentObj;
    public int pickNumber = 1;
    private int countOrder;
    
    private String[] urls = { "https://bundle-asset.s3.amazonaws.com/StreamingAssets/chair",
                                           "https://bundle-asset.s3.amazonaws.com/StreamingAssets/furniture",
                                           "https://bundle-asset.s3.amazonaws.com/StreamingAssets/plant",
                                           "https://bundle-asset.s3.amazonaws.com/StreamingAssets/sofa",
                                           "https://bundle-asset.s3.amazonaws.com/StreamingAssets/cabinet",
                                           "https://bundle-asset.s3.amazonaws.com/StreamingAssets/tablemorning",
                                           "https://bundle-asset.s3.amazonaws.com/StreamingAssets/doublesofa",
                                           "https://bundle-asset.s3.amazonaws.com/StreamingAssets/victoriansofa" };
    private String[] assetNames = {"chair1","furniture1",
              "plant1","sofa","ShoesCabinet","tableMorning", "Toska_LowPoly", "victorianSofa"};
    // Start is called before the first frame update
    void Start()
    {
        //5325631691
        obj.transform.position = parentObj.transform.position;
        countOrder = 0;
       
        //string url = "https://drive.google.com/uc?export=download&id=1CrzXJj76H0uGGMUl-r7cOjynORem1QF9";
       // WWW www = new WWW(url);
        StartCoroutine(WaitForReq(urls[pickNumber], assetNames[pickNumber]));
    }


    IEnumerator WaitForReq(String url, String assetName)
    {

        //yield return www;

        //   AssetBundle bundle = www.assetBundle;
        //   if (www.error == "")
        //   {
        //      GameObject sofa = (GameObject)bundle.LoadAsset("ShoesCabinet");
        //      Instantiate(sofa);
        //obj = Instantiate(sofa); //as GameObject;
        //obj.transform.SetParent(parentObj.transform, false);
        //    } else
        //     {
        //        Debug.Log(www.error);
        //   }
        //   bundle.Unload(false);
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url, 0);
    
        yield return request.SendWebRequest();

        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        
        GameObject asset = bundle.LoadAsset<GameObject>(assetName);
        obj = Instantiate(asset) as GameObject;
        obj.transform.SetParent(parentObj.transform, false);
        bundle.Unload(false);

        
    }
    // Update is called once per frame
    void Update()
    {
     /*   if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (obj != null)
            {
                Destroy(obj);
                StartCoroutine(WaitForReq(urls[0], assetNames[0]));
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (obj != null)
            {
                Destroy(obj);
                StartCoroutine(WaitForReq(urls[1], assetNames[1]));
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (obj != null)
            {
                Destroy(obj);
                StartCoroutine(WaitForReq(urls[2], assetNames[2]));
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (obj != null)
            {
                Destroy(obj);
                StartCoroutine(WaitForReq(urls[3], assetNames[3]));
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (obj != null)
            {
                Destroy(obj);
                StartCoroutine(WaitForReq(urls[4], assetNames[4]));
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (obj != null)
            {
                Destroy(obj);
                StartCoroutine(WaitForReq(urls[5], assetNames[5]));
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (obj != null)
            {
                Destroy(obj);
                StartCoroutine(WaitForReq(urls[6], assetNames[6]));
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (obj != null)
            {
                Destroy(obj);
                StartCoroutine(WaitForReq(urls[7], assetNames[7]));
            }
        }*/
        //---------------------------------------

        touch = Input.GetTouch(0);
        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began)
        {
            return;
        }

        if (IsPointerOverUI(touch)) return;
        if (countOrder != 7)
        {
            countOrder = countOrder + 1;
        } else
        {
            countOrder = 0;
        }

        if (obj != null)
        {
            Destroy(obj);
            StartCoroutine(WaitForReq(urls[countOrder], assetNames[countOrder]));
        }


    }




    bool IsPointerOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
