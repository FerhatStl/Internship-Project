using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{
    public GameObject InGameScreen, PauseScreen, deathScreen, wonScreen;
    public int sceneID;
    public int nextScene;
    
    public void PauseButton()
    {
        Time.timeScale = 0;
        InGameScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        InGameScreen.SetActive(true);
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(sceneID);
        Time.timeScale = 1;
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(0);
    }

    public void DeathScreen()
    {
        Time.timeScale = 0;
        DataManager.Instance.SaveData();
        InGameScreen.SetActive(false);
        deathScreen.SetActive(true);
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(nextScene);
        Time.timeScale = 1;
    }
    public void WonScreen()
    {
        Time.timeScale = 0;
        InGameScreen.SetActive(false);
        wonScreen.SetActive(true);
        if (sceneID == 2)
        {
            DataManager.Instance.level2Unlocked = true;
        }
        else if (sceneID == 3)
            DataManager.Instance.level3Unlocked = true;
    }
}
