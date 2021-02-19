using System;
using System.Security.Cryptography;
using Enemy;
using UnityEngine;
using DG.Tweening;
namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {

        public int maxHealth;
        [SerializeField] private int currentHealth;
        [SerializeField] private float timer;
        [SerializeField] private int enemyDmg;
        void Start()
        {
           Respawn();
        }

        private void Update()
        {
            if (currentHealth <= 0)
            {
                Respawn();
            }
        }

        private void OnCollisionStay2D(Collision2D ci)
        {
            timer += 1;//Time.deltaTime
            
            if (Mathf.FloorToInt(timer) % 7 == 0)
            {
                if (!ci.collider.CompareTag("enemy"))
                    return;
                enemyDmg = ci.gameObject.GetComponent<EnemyHealth>().dmg;
                Dmg(enemyDmg);
            }
        }
    

         void Dmg(int dmg)
         {
             currentHealth -= dmg;
         }

         void Respawn()
         {
             currentHealth = maxHealth;
             transform.position = new Vector3(0, 0, 0);
         }
    }
}
