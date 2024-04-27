using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [field: SerializeField] public AudioSource Music { get; private set; }
    public static Audio Instance { get; private set; }
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
    private void Start()
    {
        float musicvalue = Audio.Instance.Music.volume;

        if (PlayerPrefs.HasKey("Music"))
        {
            musicvalue = PlayerPrefs.GetFloat("Music");
        }
        PlayerPrefs.SetFloat("Music", musicvalue);
        Audio.Instance.Music.volume = musicvalue;
    }
}
