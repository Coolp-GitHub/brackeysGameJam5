using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject closestObj;

    public GameObject enemy;

    float seeRange = 3f;

    public LayerMask playerLayer;
    public LayerMask ground;
    
    private Vector2 vectorxy;

    void Update()
    {
       
        
        Collider2D[] closestOBJ = Physics2D.OverlapCircleAll(enemy.transform.position, seeRange, playerLayer);

        

        foreach (Collider2D obj in closestOBJ)
        {
            vectorxy = new Vector2(Mathf.Abs(enemy.transform.position.x - obj.transform.position.x), Mathf.Abs( enemy.transform.position.y - obj.transform.position.y));


            vectorxy = new Vector2(Mathf.Pow(vectorxy.x,vectorxy.x) , Mathf.Pow(vectorxy.y, vectorxy.y));


            float c = vectorxy.x + vectorxy.y;

            float pc = 100000;

            c = Mathf.Sqrt(c);

            if (c < pc)
            {
                closestObj = obj.gameObject;
            }

            pc = c;

          
        }


        if (closestObj != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, (gameObject.transform.position - closestObj.transform.position).normalized, seeRange, ground);

          
            Debug.Log(hit.collider);
        }
    }
    void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(enemy.transform.position, seeRange);

    }


}
