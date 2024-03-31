using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebConfig : MonoBehaviour
{
    [HideInInspector]
    public string hasilData, namaKata ,alamatDisplay, alamatAudio;
    [HideInInspector]
    public string[] dataKata;

    
    public IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    public IEnumerator SearchandDisplayWord(string Kata)
    {
        WWWForm form = new WWWForm();
        form.AddField("Kata", Kata);

        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1/KamusBahasaDaerah_BackEnd/SearchWord.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                //Dapatkan data dari SearchWord php
                hasilData = www.downloadHandler.text;
                dataKata = hasilData.Split('/');

                for (int i = 0; i < dataKata.Length; i++)
                {
                    Debug.Log(dataKata[i]);
                    if (dataKata[1] == "Kata yang dicari tidak terdaftar") namaKata = "x";
                    else namaKata = dataKata[1];

                    alamatDisplay = dataKata[2];
                    alamatAudio = dataKata[3];
                }
            }
        }
    }
}
