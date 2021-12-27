using UnityEngine;
using System.Collections;

using System;

public class IAPController : MonoBehaviour
{
    public static IAPController instance;
    public GameObject AdSection;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this);}

        if (!PlayerPrefs.HasKey("showad")) {
            PlayerPrefs.SetInt("showad", 1);
        }

    }

    private void Start()
    {
        PlayerPrefs.SetInt("showad", 0);
        if (PlayerPrefs.GetInt("showad") == 0) {
            AdSection.SetActive(false);
        }
    }

    public void BuyCoins(int coins) {
        GameManager.Instance.playfabManager.addCoinsRequest(coins);
        Debug.Log(coins + " coins purchased");
    }


    public void BuyMagicDice(int count) {
        GameManager.Instance.playfabManager.addSupersixRequest(count);
        Debug.Log("Supersix Purchased");
    }


    public void RemoveAds() {
        PlayerPrefs.SetInt("showad", 0);
        AdSection.SetActive(false);
        AdManager.instance.HideBanerAd();
    }
}
