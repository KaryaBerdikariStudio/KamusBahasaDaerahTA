using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    public DisplayCaller displayCaller;
    public Transform parentTransform;

    [HideInInspector]
    public GameObject prefab;
    [HideInInspector]
    public string prefabName;

    // Start is called before the first frame update
    void Awake()
    {
        parentTransform = GetComponent<Transform>();
        displayCaller = GameObject.Find("Aset").GetComponent<DisplayCaller>(); 
        prefabName = displayCaller.assetName;
        DisplayAsset();
    }


    public void DisplayAsset()
    {   
        if (GameObject.Find(prefabName) == null)
        {
            prefab = (GameObject)AssetDatabase.LoadAssetAtPath(displayCaller.truePath, typeof(GameObject));
            Instantiate(prefab, parentTransform);
            prefab.name = prefabName;
        }
        if (prefab.name == "x")
        {
            prefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/3D Model/x/x.blend", typeof(GameObject));
            Instantiate(prefab, parentTransform);
            prefab.name = prefabName;
        }
    }

}
