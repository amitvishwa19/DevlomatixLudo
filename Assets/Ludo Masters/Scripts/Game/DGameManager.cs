using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGameManager : MonoBehaviour
{
    public static DGameManager instance;
    public GameObject ExitWindow;

    GameObject exitWindow;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("DGameManagerUpdate");
        if (Input.GetKey(KeyCode.Escape)) {
            Debug.Log("Back Button Click");
            ShowExitWindow();
        }
    }


    public void ShowExitWindow() {
        exitWindow = GameObject.Find("ExitWindow");
        exitWindow.SetActive(true);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
