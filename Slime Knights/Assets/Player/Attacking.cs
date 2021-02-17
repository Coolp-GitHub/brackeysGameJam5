﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public string key;
    public Transform atkPoint;
    public int dmg = 24;
    public float atkRange = 0.5f;

    public LayerMask enemyLayers;
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Attack();
        }
        
    }

    void Attack()
    {
       Collider2D[] hitEnemy =  Physics2D.OverlapCircleAll(atkPoint.position, atkRange, enemyLayers);

       foreach (Collider2D Enemy in hitEnemy)
       {
          Enemy.GetComponent<enemy>().TakeDmg(dmg);
       }
    }

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.DrawWireSphere(atkPoint.position,atkRange);
    }
}
