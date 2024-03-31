using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DisplayCaller : MonoBehaviour
{
    public Transform parentTransform;
    public GameObject prefab;
    [HideInInspector]
    public string assetName, truePath, prefabPath;

    // Start is called before the first frame update
    void Start()
    {
        prefabPath = "Assets/Prefab/AsetDisplay.prefab";

        //Memanggil Prefab Aset Display
        Main.instance.wordSearch.cariKata.onClick.AddListener(() => {
            if (GameObject.Find("AsetDisplay(Clone)") != null) Destroy(GameObject.Find("AsetDisplay(Clone)"));
            StartCoroutine(CallingAsset());
        });
    }

    
    public IEnumerator CallingAsset()
    {
        yield return StartCoroutine(Main.instance.wordSearch.ClickButton());
        

        assetName = Main.instance.web.namaKata;
        truePath = "Assets/3D Model/" + assetName + "/" + assetName + ".blend";
        Debug.Log(assetName);
        Debug.Log(truePath);

        if (GameObject.Find("AsetDisplay(Clone)") == null)
        {
            prefab = (GameObject)AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));
            Instantiate(prefab, parentTransform);
        }
        
    }
}
