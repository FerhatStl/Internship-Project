using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health = 100, BulletSpeed, BulletFrequency, nextBulletTime;
    public bool Dead = false;
    Transform MuzzleTransform;
    public Transform Bullet, FloatingText;
    public Slider Slider;
    public MenuManagerInGame menuManager;

    void Start()
    {
        MuzzleTransform = transform.GetChild(1);
        Slider.maxValue = health;
        Slider.value = health;
    }

    void Update()
    {
        AmIDead();
        if (Input.GetKey(KeyCode.X))
        {
            ShootBullet();
        }
    }
    public void GetDamage(float damage)
    {
        Instantiate(FloatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text ="-" + damage.ToString();
        if( health > damage)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        Slider.value = health;
        AmIDead();
    }

    void ShootBullet()
    {
        if (nextBulletTime < Time.timeSinceLevelLoad)
        {
            nextBulletTime = Time.timeSinceLevelLoad + BulletFrequency;
            if (Time.timeScale == 1)
            {
                Transform TempBullet;
                TempBullet = Instantiate(Bullet, MuzzleTransform.position, Quaternion.identity);
                TempBullet.GetComponent<Rigidbody2D>().AddForce(MuzzleTransform.forward * BulletSpeed);
                DataManager.Instance.ShotBullet++;
            }
        }
    }
    public void ShootButton()
    {
        ShootBullet();
    }
    void AmIDead()
    {
        if (health <= 0)
        {
            Dead = true;
        }
        else if (gameObject.transform.position.y < 0)
        {
            Dead = true;
        }

        if (Dead)
        {
            Destroy(gameObject);
            menuManager.DeathScreen();
        }
    }
}
