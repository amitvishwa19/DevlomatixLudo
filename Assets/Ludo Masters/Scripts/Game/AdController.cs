using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdController : MonoBehaviour
{
    public void ShowUnityVideoAd() {
        AdManager.instance.UnityBannerAd();
    }
}
