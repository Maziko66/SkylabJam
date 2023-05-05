using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadderTrigger : MonoBehaviour
{
    Collider2D myCollider;
    [SerializeField] private bool isTouchingLadder = false;

    void Awake()
    {
        myCollider = GetComponent<Collider2D>();
    }    

    void Update()
    {
        if(myCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            
            isTouchingLadder = true;
            //Debug.Log("isTouchingLadder: " + isTouchingLadder);
        }
        else
        {
            
            isTouchingLadder = false;
            //Debug.Log("isTouchingLadder: " + isTouchingLadder);
        }
        
    }

    public bool GetLadderCheck()
    {
        return isTouchingLadder;
    }
}
