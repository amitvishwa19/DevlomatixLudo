using UnityEngine;
using System.Collections;

using System;

public class IAPController : MonoBehaviour
{
    public static IAPController instance;


    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this);}

        if (!PlayerPrefs.HasKey("showbannerad")) {
            PlayerPrefs.SetInt("showbannerad", 1);
        }

    }

    public void BuyCoins(int coins) {
        GameManager.Instance.playfabManager.addCoinsRequest(coins);
        Debug.Log(coins + " coins purchasedzl");
    }


    public void RemoveAds() {
        PlayerPrefs.SetInt("showbannerad", 0);
        AdManager.instance.HideBanerAd();
    }
}
