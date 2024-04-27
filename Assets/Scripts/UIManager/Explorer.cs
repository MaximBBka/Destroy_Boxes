using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explorer : MonoBehaviour
{
    public bool isMobile = false;
    private void Awake()
    {
        isMobile = Application.isMobilePlatform;
    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Repit()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void GoTo(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void AddAby(int index)
    {
        if (AdsProvider.Instance != null)
        {
            AdsProvider.Instance.RewardedAbyliti(index);
        }
    }
}
