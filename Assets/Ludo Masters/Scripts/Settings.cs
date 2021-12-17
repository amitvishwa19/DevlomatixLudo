using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public static Settings Instance;
    public bool ShowDebugLog;
    public bool ProductionApp;

    GameObject ProductionAppToggle;
    GameObject ExitWindow;

    private void Awake()
    {
        if (Instance == null){ Instance = this; }
        else { Destroy(this);}
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Back Button Click");
            //ExitWindow.SetActive(true);
            ExitWindow = GameObject.Find("ExitWindow");
            ExitWindow.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    //private void Start()
    //{
    //    if (PlayerPrefs.HasKey("productionapp")) {
    //        if (PlayerPrefs.GetInt("productionapp") == 1)
    //        { ProductionApp = true; }
    //        else { ProductionApp = false; }
    //    }

    //}

    //private void OnEnable()
    //{
    //    Debug.Log("DevlomatixSetting Enable Method" + SceneManager.GetActiveScene().name);

    //    if (SceneManager.GetActiveScene().name == "MenuScene")
    //    {
    //        ProductionAppToggle = GameObject.Find("ProductionToggle");
    //        Debug.Log(ProductionAppToggle.name);

    //    }
    //    //Debug.Log(SceneManager.GetActiveScene().name);
    //}
}
