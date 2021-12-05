using UnityEngine;
using System.Collections;

using System;

public class IAPController : MonoBehaviour
{
    public static IAPController instance;


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
    }

    public void BuyCoins(int coins) {
        GameManager.Instance.playfabManager.addCoinsRequest(coins);
        Debug.Log(coins + " coins purchasedzl");
    }

}
