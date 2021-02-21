using System;
using UnityEngine;
using DG.Tweening;
namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public int maxHealth = 100;
        [SerializeField] private int currentHealth;
        public int dmg = 2;
        public Transform deathPoint;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        private void Update()
        {
            if (deathPoint.position.y > transform.position.y)
            {
                Die();
            }
        }

        public void TakeDmg(int dmg)
        {
            currentHealth -= dmg;
        
        

            if (currentHealth <= 0)
            {
                Die();
            }

            
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}