using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.EventSystems;
using System;
using AssemblyCSharp;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;


    //string appID = "ca-app-pub-5558528618918107~1937403280";

    private BannerView bannerAd;
    private InterstitialAd interstitialAd;
    private RewardBasedVideoAd rewardBasedVideo;
    private RewardedAd rewardedAd;

    private string testBannerAdID = "ca-app-pub-3940256099942544/6300978111";
    private string testInterstitialAdID = "ca-app-pub-3940256099942544/1033173712";
    private string testRewardedAdID = "ca-app-pub-3940256099942544/5224354917";

    public bool UnityAds;
    public bool AdMob;
    public bool isProductionApp;

    [Header("AdMob")]
    public string AppID;
    public string BannerAdID;
    public string InterstitialAdID;
    public string RewardedAdID;

    string bannerAdID = "";
    string interstitialAdID = "";
    string rewardedAdID = "";

    //public bool showBannerOnLoadingScreen;
    

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

    private void Start()
    {
        
        if (isProductionApp)
        {
            bannerAdID = BannerAdID;
            interstitialAdID = InterstitialAdID;
            rewardedAdID = RewardedAdID;
        }
        else {
            bannerAdID = testBannerAdID;
            interstitialAdID = testInterstitialAdID;
            rewardedAdID = testRewardedAdID;
        }

        Debug.Log("BannerAdID: " + bannerAdID);
        Debug.Log("InterstitialAdID: " + interstitialAdID);
        Debug.Log("RewardedAdID: " + rewardedAdID);
        //MobileAds.SetiOSAppPauseOnBackground(true);
        MobileAds.Initialize(AppID);
        //ShowBannerAd();
        this.RequestInterstitialAd();

        this.rewardBasedVideo = RewardBasedVideoAd.Instance;
        this.rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
        this.rewardBasedVideo.OnAdClosed += this.HandleRewardBaseVideoClosed;
        this.RequestRewardBaseVideoAd();

        //Show banner add on app load
        //if (showBannerOnLoadingScreen) {
        //    ShowBannerAd();
        //}
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build(); 
    }

    #region Banner Ads
    public void ShowBannerAd()
    {
        bannerAd = new BannerView(bannerAdID, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerAd.LoadAd(request);
        bannerAd.Show();
    }

    public void HideBanerAd()
    {
        bannerAd.Hide();
        bannerAd.Hide();
    }
    #endregion

    #region Interstial Ads
    public void RequestInterstitialAd()
    {
        if (interstitialAd != null)
            this.interstitialAd.Destroy();
        interstitialAd = new InterstitialAd(interstitialAdID);
        interstitialAd.LoadAd(CreateAdRequest());
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
            RequestInterstitialAd();
        }
        else
        {
            Debug.Log("interstitialAd not loaded");
            RequestInterstitialAd();
        }
    }
    #endregion

    #region Rewarded Ad

    public void RequestRewardBaseVideoAd()
    {
        this.rewardBasedVideo.LoadAd(this.CreateAdRequest(), rewardedAdID);


    }

    public void ShowRewardBaseVideo()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            this.rewardBasedVideo.Show();
        }
        else
        {


        }
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        Debug.Log("Reward base video Rewarded");
        GameManager.Instance.playfabManager.addCoinsRequest(StaticStrings.rewardForVideoAd);
        this.RequestRewardBaseVideoAd();
        
    }

    public void HandleRewardBaseVideoClosed(object sender, EventArgs args)
    {
        Debug.Log("Reward base video closed");
        this.RequestRewardBaseVideoAd();
        

    }

    #endregion
   
   
}
