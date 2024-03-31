using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WordSearch : MonoBehaviour
{
    public TMP_InputField kataYangDiinput;
    public TMP_Text textKata;
    public Button cariKata;
    public bool isClicked;

    private void Awake()
    {
        isClicked = false;
    }

    void Start()
    {
        cariKata.onClick.AddListener(() => {
            isClicked = true;
            StartCoroutine(ClickButton());
        });
    }

    IEnumerator Display (string Kata)
    {
        yield return StartCoroutine(Main.instance.web.SearchandDisplayWord(Kata));

        if (Main.instance.web.namaKata == "x") textKata.text = "Kata Tidak Terdaftar";
        else textKata.text = Main.instance.web.namaKata;


        Debug.Log(isClicked);
    }
    
    public IEnumerator ClickButton()
    {
        yield return StartCoroutine(Display(kataYangDiinput.text));
    }


}
