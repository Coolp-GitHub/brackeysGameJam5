using UnityEngine;
using DG.Tweening;
namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public int maxHealth = 100;
        [SerializeField] private int currentHealth;
        public int dmg = 2;
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
}