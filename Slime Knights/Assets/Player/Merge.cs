using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    public Transform P1;
    public Transform P2;
    public Transform Merged;
    
    public GameObject mergedPlayer;
    public GameObject P1obj;
    public GameObject P2obj;
    public GameObject MergeControl;
    
    bool cansSwap = true;
    public int state = 2;
    [SerializeField] private States stateEn;

    [SerializeField] private enum States
    {
        TwoP = 1,
        OneP = 2
    };
    void Update()
    {
         stateEn = (States)(state%2);
        if (stateEn == States.TwoP)
        {
            Vector2 Pos = new Vector2((P1.position.x + P2.position.x) / 2, (P1.position.y + P2.position.y) / 2);
            Vector2 MergedPos = new Vector2(Pos.x, Pos.y);
            Merged.position = new Vector3(MergedPos.x, MergedPos.y + 0.75f, 0f);

        }
        else
        {

        }

        


        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.S) && cansSwap)
        {
            state++;
            cansSwap = false;
            StartCoroutine(StateSwapper());

        }

        if (stateEn == States.TwoP)
        {
            mergedPlayer.SetActive(false);
            P1obj.SetActive(true);
            P2obj.SetActive(true);

           mergedPlayer.GetComponent<CharacterController2D>().enabled= false;


        }
        else
        {
            mergedPlayer.SetActive(true);
            P1obj.SetActive(false);
            P2obj.SetActive(false);
           mergedPlayer.GetComponent<CharacterController2D>().enabled = true;
        }

        
        
    }

    private IEnumerator StateSwapper()
    {
        yield return new WaitForSeconds(0.5f);
        cansSwap = true; 
    }
}
