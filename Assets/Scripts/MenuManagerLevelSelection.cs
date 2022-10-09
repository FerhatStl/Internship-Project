using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerLevelSelection : MonoBehaviour
{
    public Canvas canvas;
    public Sprite unlockedSprite, lockedSprite;
    public int maxLevel;
    void Start()
    {
        LockUpdater();
    }

    void LockUpdater()
    {
        if (DataManager.Instance.level2Unlocked)
        {
            canvas.transform.GetChild(2).GetComponent<Image>().sprite = unlockedSprite;
        }
        else
        {
            canvas.transform.GetChild(2).GetComponent<Image>().sprite = lockedSprite;
        }
        
        if (DataManager.Instance.level3Unlocked)
        {
            canvas.transform.GetChild(3).GetComponent<Image>().sprite = unlockedSprite;
        }
        else
        {
            canvas.transform.GetChild(3).GetComponent<Image>().sprite = lockedSprite;
        }
    }
   
    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }

    public void Level1Button()
    {
        SceneManager.LoadScene(2);
    }

    public void Level2Button()
    {
        if (DataManager.Instance.level2Unlocked)
        {
            SceneManager.LoadScene(3);
        }
    }
}
