using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePowerPlay : MonoBehaviour
{
    public static GamePowerPlay Instance;

    public Text iconCount;
    public Text titleCountText;
    [SerializeField] public bool superDice;
    [SerializeField] private int superDiceCount;
    [SerializeField] public int superDiceValue;

    [SerializeField] private bool immunity;
    [SerializeField] private int immunityCount;

    public GameObject superDiceWindow;
    public GameObject superDiceLock;

    public int steps;

    public Animator SuperSixGlow;
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
    }

    private void Start()
    {
        if (superDice)
        {
            steps = superDiceValue;
        }
        else { 
            steps = Random.Range(1, 7);
        }

        superDiceCount = GameManager.Instance.myPlayerData.GetSuperSix();

        //if (superDiceCount <= 0)
        //{
        //    superDiceLock.SetActive(true);
        //}
        //else { superDiceLock.SetActive(false); }


        //titleCountText.text = superDiceCount.ToString();
    }

    private void OnEnable()
    {
        superDiceCount = GameManager.Instance.myPlayerData.GetSuperSix();
        Debug.Log(superDiceCount);
        SuperDice();    }

    public void SuperDice() {
        
        //superDiceWindow.SetActive(true);
        if (superDiceCount <= 0)
        {
            superDiceLock.SetActive(true);
        }
        else { superDiceLock.SetActive(false); }
    
    
    }

    public void SuperDiceValue(int value) {
        Debug.Log("Super dice number selected " + value);
        superDice = true;
        superDiceValue = value;
        GameManager.Instance.playfabManager.removeSupersixRequest(1);
        superDiceCount = GameManager.Instance.myPlayerData.GetSuperSix();
        //titleCountText.text = superDiceCount.ToString();
        iconCount.text = superDiceCount.ToString();
        //superDiceWindow.SetActive(false);
    }
}
