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
    void Start()
    {
        
    }

    
    void Update()
    {
        if(myCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            
            isTouchingLadder = true;
            Debug.Log("isTouchingLadder: " + isTouchingLadder);
            return;
        }
        else
        {
            
            isTouchingLadder = false;
            Debug.Log("isTouchingLadder: " + isTouchingLadder);
        }
        
    }

    /* void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ladder 1")
        {
            isTouchingLadder = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ladder 1")
        {
            isTouchingLadder = false;
        }
    } */
    

    public bool GetLadderCheck()
    {
        return isTouchingLadder;
    }
}
