using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.EventSystems;
using System;
using AssemblyCSharp;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    public bool ProductionApp;

    //String AppID = "ca-app-pub-5370839760111710~6588389303";

    public string Admob_Banner_id;
    public string Admob_Interstitial_id;
    public string Admob_Rewarded_Interstitial_id;
    public string Admob_Rewarded_Video_id;


    //Production App IDS
    private string BannerAdID;
    private string InterstitialAdID;
    private string RewardedInterstitialAdID;
    private string RewardedVideoAdID;

    //Test Ads IDs
    private string Test_BannerAdID = "ca-app-pub-3940256099942544/6300978111";
    private string Test_InterstitialAdID = "ca-app-pub-3940256099942544/1033173712";
    private string Test_Rewared_InterstitialAdID = "ca-app-pub-3940256099942544/1033173712";
    private string Test_RewardedAdID = "ca-app-pub-3940256099942544/5224354917";

    //Production Ads IDs
    //private string BannerAdID = "ca-app-pub-5370839760111710/5352179319";
    //private string InterstitialAdID = "ca-app-pub-5370839760111710/2726015975";
    //private string RewardedAdID = "ca-app-pub-5370839760111710/2457572605";

    #region Old Ads
    //    //string appID = "ca-app-pub-5558528618918107~1937403280";

    //    private BannerView bannerAd;
    //    private InterstitialAd interstitialAd;
    //    private RewardBasedVideoAd rewardBasedVideo;
    //    private RewardedAd rewardedAd;

    //    private string testBannerAdID = "ca-app-pub-3940256099942544/6300978111";
    //    private string testInterstitialAdID = "ca-app-pub-3940256099942544/1033173712";
    //    private string testRewardedAdID = "ca-app-pub-3940256099942544/5224354917";

    //    public bool UnityAds;
    //    public string UnityAndroidAppID;



    //    public bool AdMob;
    //    public bool isProductionApp;

    //    [Header("AdMob")]
    //    public string AppID;
    //    public string BannerAdID;
    //    public string InterstitialAdID;
    //    public string RewardedAdID;

    //    string bannerAdID = "";
    //    string interstitialAdID = "";
    //    string rewardedAdID = "";

    //    //public bool showBannerOnLoadingScreen;


    //    private void Awake()
    //    {
    //        if (instance == null)
    //        {
    //            instance = this;
    //        }
    //        else
    //        {
    //            Destroy(this);
    //        }
    //        DontDestroyOnLoad(this);
    //    }

    //    private void Start()
    //    {
    //        //Unity Ads  Rewarded_Android
    //        if (UnityAds) {
    //            //Advertisement.Initialize("4502575");

    //        }
    //        //Advertisement.Initialize("4502575");

    //        if (Settings.Instance.ProductionApp)
    //        {
    //            bannerAdID = BannerAdID;
    //            interstitialAdID = InterstitialAdID;
    //            rewardedAdID = RewardedAdID;
    //        }
    //        else {
    //            bannerAdID = testBannerAdID;
    //            interstitialAdID = testInterstitialAdID;
    //            rewardedAdID = testRewardedAdID;
    //        }


    //        if (Settings.Instance.ShowDebugLog)
    //        {
    //            Debug.Log("BannerAdID: " + bannerAdID);
    //            Debug.Log("InterstitialAdID: " + interstitialAdID);
    //            Debug.Log("RewardedAdID: " + rewardedAdID);
    //        }



    //        //MobileAds.SetiOSAppPauseOnBackground(true);
    //        MobileAds.Initialize(AppID);
    //        //ShowBannerAd();
    //        this.RequestInterstitialAd();

    //        this.rewardBasedVideo = RewardBasedVideoAd.Instance;
    //        this.rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
    //        this.rewardBasedVideo.OnAdClosed += this.HandleRewardBaseVideoClosed;
    //        this.RequestRewardBaseVideoAd();

    //        //Show banner add on app load
    //        //if (showBannerOnLoadingScreen) {
    //        //    ShowBannerAd();
    //        //}
    //    }

    //    private AdRequest CreateAdRequest()
    //    {
    //        return new AdRequest.Builder().Build(); 
    //    }

    //    #region GoogleAdMob

    //    #region Banner Ads
    //    public void ShowBannerAd()
    //    {
    //        bannerAd = new BannerView(bannerAdID, AdSize.Banner, AdPosition.Bottom);
    //        AdRequest request = new AdRequest.Builder().Build();
    //        bannerAd.LoadAd(request);
    //        bannerAd.Show();
    //    }

    //    public void HideBanerAd()
    //    {
    //        bannerAd.Hide();
    //        bannerAd.Hide();
    //    }
    //    #endregion

    //    #region Interstial Ads
    //    public void RequestInterstitialAd()
    //    {
    //        if (interstitialAd != null)
    //            this.interstitialAd.Destroy();
    //        interstitialAd = new InterstitialAd(interstitialAdID);
    //        interstitialAd.LoadAd(CreateAdRequest());
    //    }

    //    public void ShowInterstitialAd()
    //    {
    //        if (interstitialAd.IsLoaded())
    //        {
    //            interstitialAd.Show();
    //            RequestInterstitialAd();
    //        }
    //        else
    //        {
    //            Debug.Log("interstitialAd not loaded");
    //            RequestInterstitialAd();
    //        }
    //    }
    //    #endregion

    //    #region Rewarded Ad

    //    public void RequestRewardBaseVideoAd()
    //    {
    //        this.rewardBasedVideo.LoadAd(this.CreateAdRequest(), rewardedAdID);


    //    }

    //    public void ShowRewardBaseVideo()
    //    {
    //        if (rewardBasedVideo.IsLoaded())
    //        {
    //            this.rewardBasedVideo.Show();
    //        }
    //        else
    //        {


    //        }
    //    }

    //    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    //    {
    //        Debug.Log("Reward base video Rewarded");
    //        GameManager.Instance.playfabManager.addCoinsRequest(StaticStrings.rewardForVideoAd);
    //        this.RequestRewardBaseVideoAd();

    //    }

    //    public void HandleRewardBaseVideoClosed(object sender, EventArgs args)
    //    {
    //        Debug.Log("Reward base video closed");
    //        this.RequestRewardBaseVideoAd();


    //    }

    //    #endregion

    //    #endregion

    //    #region UnityAds

    //    public void PlayAd() {
    //        Debug.Log("Unity Video Ad Played");
    //        if (Advertisement.IsReady("video"))
    //        {
    //            Debug.Log("Unity Ad is ready to play");
    //            Advertisement.Show();
    //        }
    //        else {
    //            Debug.Log("Unity Ad is not ready to play");
    //        }
    //    }

    //    public void UnityBannerAd() {
    //        if (Advertisement.IsReady("banner"))
    //        {
    //            Debug.Log("Unity BAnner Ad is ready to play");
    //            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    //            Advertisement.Banner.Show("banner");

    //        }
    //        else {

    //            Debug.Log("Unity Banner Ad is not ready to play");

    //        }


    //    }

    //    #endregion

    #endregion

    private BannerView bannerAd;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideoAd;



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

        //if (!PlayerPrefs.HasKey("productionapp"))
        //{
        //    Debug.Log("Playerpref HasKey productionapp");
        //    PlayerPrefs.SetInt("productionapp", 0);
        //}

    }


    private void Start()
    {

        if (ProductionApp)
        {
            BannerAdID = Admob_Banner_id;
            InterstitialAdID = Admob_Interstitial_id;
            RewardedInterstitialAdID = Admob_Rewarded_Interstitial_id;
            RewardedVideoAdID = Admob_Rewarded_Video_id;
        }
        else {
            BannerAdID = Test_BannerAdID;
            InterstitialAdID = Test_InterstitialAdID;
            RewardedInterstitialAdID = Test_Rewared_InterstitialAdID;
            RewardedVideoAdID = Test_RewardedAdID;
        }

        MobileAds.Initialize(InitializationStatus => { });

        this.rewardBasedVideoAd = RewardBasedVideoAd.Instance;
        this.rewardBasedVideoAd.OnAdRewarded += this.HandleRewardBasedVideoReward;
        this.rewardBasedVideoAd.OnAdClosed += this.HandleRewardBasedVideoClosed;
        this.RequestRewardBaseVideo();

        this.ShowBannerAd();

        this.RequestInterstitialAd();
    }

    private AdRequest CreateRequest() { 
        return new AdRequest.Builder().Build(); ;
    }

    #region Banner Ads
    public void ShowBannerAd() {
        if (PlayerPrefs.GetInt("showad") == 1)
        {
            this.bannerAd = new BannerView(this.BannerAdID, AdSize.Banner, AdPosition.Bottom);
            this.bannerAd.LoadAd(this.CreateRequest());
        }
            
    }

    public void HideBanerAd() {
        this.bannerAd.Hide();
    }

    #endregion

    #region Interstitial Ads
    public void RequestInterstitialAd() {

        //Clean previous
        if (this.interstitial != null)
            this.interstitial.Destroy();

        //create new
        this.interstitial = new InterstitialAd(this.InterstitialAdID);

        //Load Ad
        this.interstitial.LoadAd(this.CreateRequest());

    }

    public void ShowInterstitial() {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
            RequestInterstitialAd();
        }
        else
        {
            Debug.Log("interstitialAd not loaded");
            RequestInterstitialAd();
        }
    }

    #endregion

    #region Reward Video Ads
    public void RequestRewardBaseVideo() {
        this.rewardBasedVideoAd.LoadAd(this.CreateRequest(), RewardedVideoAdID);
    }

    public void ShowRewardBaseVideo() {
        Debug.Log("Show Rewardbase videoAd");
        if (this.rewardBasedVideoAd.IsLoaded())
        {
            this.rewardBasedVideoAd.Show();
        }
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args) {
        Debug.Log("Reward base video closed");
        this.RequestRewardBaseVideo();
    }

    public void HandleRewardBasedVideoReward(object sender, Reward args) {
        Debug.Log("Reward base video Rewarded");
        GameManager.Instance.playfabManager.addCoinsRequest(StaticStrings.rewardForVideoAd);
    }

    #endregion
}
