using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider audio;

    private void OnEnable()
    {
        audio.value = Audio.Instance.Music.volume;
        audio.onValueChanged.AddListener(SettingsMusic);
    }
    private void OnDisable()
    {
        audio.onValueChanged.RemoveListener(SettingsMusic);
    }
    private void SettingsMusic(float value)
    {
        Audio.Instance.Music.volume = value;
        PlayerPrefs.SetFloat("Music", value);
    }
}
