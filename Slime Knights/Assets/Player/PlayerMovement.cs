using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float speed = 10f;

    public float hmove = 0f;

    private bool _jump = false;
    

 
    public string jump;
    public string left;
    public string right;


    private void Update()
    {
        if (!Input.GetKey(left) && !Input.GetKey(right))
        {
            hmove = 0f;
        }else if(Input.GetKey(left))
        {
            hmove = -1f;
            
        }else if (Input.GetKey(right))
        {
            hmove = 1;
        }

        if (Input.GetKeyDown(jump))
        {
            _jump = true;
            
        }
       
    }

    private void FixedUpdate()
    {
        controller.Move(hmove * speed ,false,_jump);
        
        _jump = false;
        
    }
}
