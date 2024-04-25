using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

[Serializable]
public class LevelSetting
{
    public Hand hand;
    public int score;
    public float newSpeed;
}

public class HandSystem : MonoBehaviour
{
    [SerializeField] private float timeUpdate;
    [SerializeField] private List<LevelSetting> settings;
    private WaitForSeconds wait;
    private float speed = 0f;
    private HashSet<Hand> hands;

    private void Start()
    {
        hands = new HashSet<Hand>(settings.Count);
        StartCoroutine(OnUpdater());
    }
    public IEnumerator OnUpdater()
    {
        while (true)
        {
            yield return wait;
            for (int i = 0; i < settings.Count; i++)
            {
                if (settings[i].score <= MainUI.Instance.totalScore)
                {
                    LevelSetting setting = settings[i];
                    setting.hand.gameObject.SetActive(true);
                    speed = setting.newSpeed;
                    hands.Add(setting.hand);
                }
            }
            foreach (Hand hand in hands) 
            {
                hand.moveSpeed = speed;
            }
        }
    }
}
