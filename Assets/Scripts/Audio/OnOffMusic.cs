using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffMusic : MonoBehaviour
{
    public void SwitchVoluem()
    {
        if ( Audio.Instance.Music.volume > 0)
        {
            Audio.Instance.Music.volume = 0f;
        }else
        {
            Audio.Instance.Music.volume = PlayerPrefs.GetFloat("Music");
        }
    }
}
