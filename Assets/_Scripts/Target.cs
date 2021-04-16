using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 100;
    void Start()
    {
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(transform.parent.gameObject, 1);
        GlobalAchievements.achCount += 1;
        Debug.Log("die");
    }
}
