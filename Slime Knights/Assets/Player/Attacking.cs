using Enemy;
using UnityEngine;

namespace Player
{
    public class Attacking : MonoBehaviour
    {
        public string key;
        public Transform atkPoint;
        public int dmg = 24;
        public float atkRange = 0.5f;

        public LayerMask enemyLayers;

        private void Update()
        {
            if (Input.GetKeyDown(key))
            {
                Attack();
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void Attack()
        {
            Collider2D[] hitEnemy =  Physics2D.OverlapCircleAll(atkPoint.position, atkRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemy)
            {
                enemy.GetComponent<EnemyHealth>().TakeDmg(dmg);
            }
        }

        private void OnDrawGizmosSelected()
        {
        
            Gizmos.DrawWireSphere(atkPoint.position,atkRange);
        }
    }
}
