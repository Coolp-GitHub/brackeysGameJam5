using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
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
}