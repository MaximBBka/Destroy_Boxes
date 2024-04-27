using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Saves : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI title;
    private void Start()
    {
        Load();
        if (title != null)
        {
            title.SetText($"Рекорд: {score}");
        }
    }
    public void Load()
    {
        YandexGame.LoadProgress();
        score = YandexGame.savesData.Savescore;
        if (MainUI.Instance == null) return;
        if (score < MainUI.Instance.totalScore)
        {
            score = MainUI.Instance.totalScore;
            Save();
        }
    }
    public void Save()
    {
        YandexGame.savesData.Savescore = score;
        YandexGame.SaveProgress();
    }
    public void OnDestroy()
    {
        if (MainUI.Instance != null)
        {
            Load();
        }
    }
}
