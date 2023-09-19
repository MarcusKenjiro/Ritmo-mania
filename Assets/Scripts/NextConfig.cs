using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class NextConfig : MonoBehaviour
{
    private static NextConfig _instance = null;

    public bool modo2;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public static NextConfig Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    // Start is called before the first frame update
    public void start()
    {
        StartCoroutine(Play());
    }
    IEnumerator Play(){
		SceneManager.LoadScene("Config");
    	yield return 0;
	 }
    // Update is called once per frame

    public void startgameMod1()
    {
        modo2 = false;
        SceneManager.LoadScene("Config");
    }

    public void startgameMod2()
    {
        modo2 = true;
        SceneManager.LoadScene("Config2");
    }

    void Update()
    {
        
    }
}
