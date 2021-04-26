using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AssetLoader : MonoBehaviour
{
    public AssetReference objectToLoad;
    private GameObject goObject;
    Text txtTrace;

    private void Start()
    {

                txtTrace = GameObject.Find("txtTrace").GetComponent<Text>();

    }
    public void LoadAssets()
    {
        txtTrace.text=("Button click");
        Debug.Log(objectToLoad.RuntimeKey);
        Addressables.LoadAssetAsync<GameObject>(objectToLoad).Completed += ObjectLoadDone;
    }

    private void ObjectLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        txtTrace.text += "\nLoadObjDone";
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject loadedObject = obj.Result;
            txtTrace.text += ("\nOperation success");
            goObject = Instantiate(loadedObject);
            goObject.name = "NewObj";
            goObject.transform.position = Vector3.forward * -6.4f;
        }
        if (obj.Status == AsyncOperationStatus.Failed)
            txtTrace.text += ("\nOperation failed");
    }
}
