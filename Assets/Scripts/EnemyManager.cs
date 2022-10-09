using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float health = 100;
    public float damage;
    bool ColliderBusy = false;
    public Slider Slider;

    void Start()
    {
        Slider.value = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if (other.tag == "Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().BulletDamage);
            Destroy(other.gameObject);
        }
        ColliderBusy = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ColliderBusy = false;
        }
    }
    public void GetDamage(float damage)
    {
        if (health > damage)
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
    void AmIDead()
    {
        if (health <= 0)
        {
            DataManager.Instance.EnemyKilled++;
            Destroy(gameObject);
        }
    }
}
