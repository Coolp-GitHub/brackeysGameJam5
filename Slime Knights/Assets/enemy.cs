using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDmg(int dmg)
    {
        currentHealth -= dmg;
        
        

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}