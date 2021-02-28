using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject closestObj;
    public GameObject enemy;
    float seeRange = 1.5f;
   // [SerializeField] float closestDistance = Mathf.Infinity;
    public LayerMask playerLayer;


    private Vector2 x;
    private Vector2 vectorxy;
    void Start()
    {
        x = new Vector2(9999999, 9999999);
    }

   
    void Update()
    {
        Collider2D[] closestOBJ = Physics2D.OverlapCircleAll(enemy.transform.position, seeRange, playerLayer);

        foreach (Collider2D obj in closestOBJ)
        {
            vectorxy = new Vector2(Mathf.Abs(enemy.transform.position.x - obj.transform.position.x), Mathf.Abs( enemy.transform.position.y - obj.transform.position.y));

            vectorxy = new Vector2(Mathf.Pow(vectorxy.x,vectorxy.x) , Mathf.Pow(vectorxy.y, vectorxy.y));

            float c = vectorxy.x + vectorxy.y;

            c = Mathf.Sqrt(c); 
        }

        for (int i = 0; i > closestOBJ.Length; i++)
        {
            if (closestOBJ[i].transform.position.x> x.x  && (closestOBJ[i].transform.position.y > x.y))
            {
                closestObj = closestOBJ[i].gameObject;
            }
        }
    }
}
