using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main instance { get; private set; }
    public WebConfig web;
    public WordSearch wordSearch;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

}
