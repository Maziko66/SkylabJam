using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeet : MonoBehaviour
{
    Collider2D myCollider;
    [SerializeField] private bool isTouchingGround = false;

    void Awake()
    {
        myCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {

            isTouchingGround = true;
            //Debug.Log("istouching ground: "+ isTouchingGround);
        }
        else
        {

            isTouchingGround = false;
            //Debug.Log("istouching ground: "+ isTouchingGround);
        }
    }

    public bool GetGroundCheck()
    {
        return isTouchingGround;
    }
}