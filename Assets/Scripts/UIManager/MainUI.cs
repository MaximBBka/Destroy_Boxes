using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private GameObject panelLose;
    [SerializeField] private TextMeshProUGUI coinsTetx;
    [SerializeField] private TextMeshProUGUI scoreTetx;
    [SerializeField] private TextMeshProUGUI totalAbilityText;
    [SerializeField] private Button buttonAds;
    [SerializeField] private Button buttonBuyAbility;
    public int totalCoins;
    public int totalScore;
    public int totalAbility = 2;
    [field: SerializeField] public static MainUI Instance {  get; private set; }
    public bool IsAbility = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Update()
    {
        UpdateAbility(totalAbility);
    }

    public void ShowPanelLose()
    {
        OnPauseGame();
        panelLose.SetActive(true);
    }
    public void OnPauseGame()
    {
        Time.timeScale = 0f;
    }
    public void OffPauseGame()
    {
        Time.timeScale = 1f;
    }
    public void EnableAbility()
    {
        IsAbility = true;
    }
    public void DisableAbility()
    {
        IsAbility = false;
    }
    public void UpdateCoins(int total)
    {
        coinsTetx.SetText($"{total}");
    }
    public void UpdateScore(int total)
    {
        scoreTetx.SetText($"—чет: {total}");
    }
    public void UpdateAbility(int total)
    {
        totalAbilityText.SetText($"{total}");
        if (total <= 0 && totalCoins < 50f)
        {
            buttonBuyAbility.gameObject.SetActive(false);
            totalAbilityText.gameObject.SetActive(false);
            buttonAds.gameObject.SetActive(true);
        }else if (total >= 1 && totalCoins < 50) 
        {
            buttonAds.gameObject.SetActive(false);
            buttonBuyAbility.gameObject.SetActive(false);
            totalAbilityText.gameObject.SetActive(true);           
        }else if (total <= 0 && totalCoins >= 50)
        {
            buttonAds.gameObject.SetActive(false);
            buttonBuyAbility.gameObject.SetActive(true);
            totalAbilityText.gameObject.SetActive(false);
        }
    }
    public void BuyAbility()
    {
        if (totalCoins >= 50)
        {
            totalCoins -= 50;
            totalAbility += 1;
        }
    }
}
