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
        titleCountText.text = superDiceCount.ToString();
    }

    public void SuperDice() {
        superDiceWindow.SetActive(true);
        if (superDiceCount <= 0)
        {
            superDiceLock.SetActive(true);
        }
        else { superDiceLock.SetActive(false); }
    
    
    }

    public void SuperDiceValue(int value) {
        superDice = true;
        superDiceValue = value;
        GameManager.Instance.playfabManager.removeSupersixRequest(1);
        superDiceCount = GameManager.Instance.myPlayerData.GetSuperSix();
        titleCountText.text = superDiceCount.ToString();
        iconCount.text = superDiceCount.ToString();
    }
}
