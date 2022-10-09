using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float BulletDamage, LifeTime;

    void Start()
    {
        Destroy(gameObject, LifeTime);
    }
}
