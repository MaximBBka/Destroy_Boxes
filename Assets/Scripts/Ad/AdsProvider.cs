using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class AdsProvider : MonoBehaviour
{
    private int chekIndex;
    private float timer = 0f;
    private float timerPause = 3f;
    private int reawrdId = -1; // 0 - реклама для получения абилки 1 - для продолжения после смерти

    public static AdsProvider Instance { get; private set; }
    private void Awake()
    {
        if (!Instance)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    private void Update()
    {
        chekIndex = SceneManager.GetActiveScene().buildIndex;
        if (chekIndex != 0 && !MainUI.Instance.panelLose.gameObject.activeSelf && !MainUI.Instance.panelPause.gameObject.activeSelf)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 300f)
        {
            Time.timeScale = 0f;
            MainUI.Instance.WindowAds.gameObject.SetActive(true);
            MainUI.Instance.AdsTimerText.gameObject.SetActive(true);
            MainUI.Instance.AdsTimerText.text = $"Реклама {MathF.Round(timerPause)}..";
            timerPause -= Time.unscaledDeltaTime;
            if (timerPause <= 0)
            {
                ShowAds();
                timerPause = 3f;
                MainUI.Instance.AdsTimerText.gameObject.SetActive(false);
                MainUI.Instance.buttonContinueAds.gameObject.SetActive(true);
                timer = 0f;
            }
        }
    }
    public void RewardedAbyliti(int index)
    {
        if (reawrdId == -1)
        {
            reawrdId = index;
            YandexGame.RewVideoShow(0);
        }
    }
    public void ShowAds()
    {
        if (chekIndex != 0 && !MainUI.Instance.panelPause.gameObject.activeSelf && !MainUI.Instance.panelLose.gameObject.activeSelf)
        {
            YandexGame.FullscreenShow();
        }
    }
    public void AddAbility()
    {
        if (reawrdId == 0)
        {
            MainUI.Instance.UpdateAbility(MainUI.Instance.totalAbility += 1);
            Time.timeScale = 1f;
            reawrdId = -1;
        }
    }
    public void AdsContinueGame()
    {
        if (reawrdId == 1)
        {
            MainUI.Instance.buttonContinueAdsLose.gameObject.SetActive(true);
            MainUI.Instance.buttonReturnAds.gameObject.SetActive(false);
            reawrdId = -1;
        }
    }
}
