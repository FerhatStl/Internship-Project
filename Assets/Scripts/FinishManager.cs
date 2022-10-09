using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishManager : MonoBehaviour
{
    public GameObject menuManagerInGameScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            menuManagerInGameScene.GetComponent<MenuManagerInGame>().WonScreen();
        }
    }
}
