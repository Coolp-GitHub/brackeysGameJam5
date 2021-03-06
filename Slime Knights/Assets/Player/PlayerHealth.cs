using System;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;
using UnityEngine.UI;



namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {

        public int maxHealth;
        public int currentHealth;

        public Transform deathLine;

        

        public Image deathImage;

        public HealthBar hpBar;



        public Color originalBG;

        private Color black = Color.black;
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
                // DeathScreen();
                //StartCoroutine(respawnCooldown());
                Respawn();

            }

            if (transform.position.y <= deathLine.position.y)
            {
                Respawn();
                
            }
        }

        private void OnCollisionStay2D(Collision2D ci)
        {
            timer += 1;

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
            hpBar.SetHealth(currentHealth);
        }

        void Respawn()
        {
            currentHealth = maxHealth;
            transform.position = new Vector3(0, 0, 0);
            hpBar.MaxHealth(maxHealth);
            gameObject.SetActive(true);
            
        }

        void DeathScreen()
        {

            StartCoroutine(respawnCooldown());
            
        }

        IEnumerator respawnCooldown()
        {
            yield return new WaitForSeconds(3f);
           
            Respawn();
        }
    }
}
