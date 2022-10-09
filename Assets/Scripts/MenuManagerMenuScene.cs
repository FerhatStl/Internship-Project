using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerMenuScene : MonoBehaviour
{
    public GameObject dataBoard, playButton, dataBoardButton, settingsButton, settingScreen, closeAppButton;

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void DataBoardButton()
    {
        DataManager.Instance.LoadData();

        dataBoard.transform.GetChild(1).GetComponent<Text>().text = "Total Shot Bullet: " + DataManager.Instance.totalShotBullet.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text = "Total Enemy Killed: " + DataManager.Instance.totalEnemyKilled.ToString();
        dataBoard.SetActive(true);
        playButton.SetActive(false);
        dataBoardButton.SetActive(false);
        settingsButton.SetActive(false);
        closeAppButton.SetActive(false);
    }

    public void XButton()
    {
        dataBoard.SetActive(false);
        playButton.SetActive(true);
        dataBoardButton.SetActive(true);
        settingsButton.SetActive(true);
        closeAppButton.SetActive(true);
    }

    public void ClearDataButton()
    {
        DataManager.Instance.ClearData();
        settingScreen.SetActive(false);
        playButton.SetActive(true);
        dataBoardButton.SetActive(true);
        settingsButton.SetActive(true);
        closeAppButton.SetActive(true);
    }

    public void SettingsButton()
    {
        settingScreen.SetActive(true);
        settingsButton.SetActive(false);
        playButton.SetActive(false);
        dataBoardButton.SetActive(false);
        closeAppButton.SetActive(false);
    }
    public void SettingsCloseButton()
    {
        settingScreen.SetActive(false);
        playButton.SetActive(true);
        dataBoardButton.SetActive(true);
        settingsButton.SetActive(true);
        closeAppButton.SetActive(true);
    }
    
    public void CloseAppButton()
    {
        Application.Quit();
    }
}
