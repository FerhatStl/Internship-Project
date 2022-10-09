using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private int shotBullet;
    public int totalShotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;
    public bool level2Unlocked = false;
    public bool level3Unlocked = false;
    EasyFileSave myFile;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LevelUnlocked(int levelID)
    {
        if(levelID == 2)
        {
            level2Unlocked = true;
        }
        else if(levelID == 3)
        {
            level3Unlocked = true;
        }
    }

    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("ShootBulletText").GetComponent<Text>().text = "SHOOT BULLET: " + shotBullet.ToString();
        }
    }

    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "ENEMY KILLED: " + enemyKilled.ToString();
        }
    }

    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();
    }

    public void SaveData()
    {
        totalShotBullet += shotBullet;
        totalEnemyKilled += enemyKilled;

        shotBullet = 0;
        enemyKilled = 0;

        myFile.Add("totalShotBullet", totalShotBullet);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);
        
        myFile.Save();
    }

    public void LoadData()
    {
        if (myFile.Load())
        {
            totalShotBullet = myFile.GetInt("totalShotBullet");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");

        }
    }

    public void ClearData()
    {
        totalEnemyKilled = 0;
        totalShotBullet = 0;
        myFile.Delete();
        StartProcess();
        level2Unlocked = false;
        level3Unlocked = false;
    }
}
