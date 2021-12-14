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

    private void Awake()
    {
        if (Instance == null){ Instance = this; }
        else { Destroy(this);}
        DontDestroyOnLoad(this);

        if (!PlayerPrefs.HasKey("productionapp"))
        {
            Debug.Log("Playerpref HasKey productionapp");
            PlayerPrefs.SetInt("productionapp", 0);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("productionapp")) {
            if (PlayerPrefs.GetInt("productionapp") == 1)
            { ProductionApp = true; }
            else { ProductionApp = false; }
        }
        
    }

    private void OnEnable()
    {
        Debug.Log("DevlomatixSetting Enable Method" + SceneManager.GetActiveScene().name);

        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            ProductionAppToggle = GameObject.Find("ProductionToggle");
            Debug.Log(ProductionAppToggle.name);

        }
        //Debug.Log(SceneManager.GetActiveScene().name);
    }
}
