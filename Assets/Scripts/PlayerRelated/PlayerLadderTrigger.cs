using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadderTrigger : MonoBehaviour
{
    Collider2D myCollider;
    [SerializeField] private bool isTouchingLadder = false;
    [SerializeField] private bool isTouchingGate = false;
    [SerializeField] private bool isTouchingSwitch = false;

    void Awake()
    {
        myCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {

            isTouchingLadder = true;
            //Debug.Log("isTouchingLadder: " + isTouchingLadder);
        }
        else
        {

            isTouchingLadder = false;
            //Debug.Log("isTouchingLadder: " + isTouchingLadder);
        }

        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Gate Trigger")))
        {

            isTouchingGate = true;
            //Debug.Log("isTouchingLadder: " + isTouchingLadder);
        }
        else
        {

            isTouchingGate = false;
            //Debug.Log("isTouchingLadder: " + isTouchingLadder);
        }

        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Switch")))
        {

            isTouchingSwitch = true;
            //Debug.Log("isTouchingLadder: " + isTouchingLadder);
        }
        else
        {

            isTouchingSwitch = false;
            //Debug.Log("isTouchingLadder: " + isTouchingLadder);
        }

    }

    public bool GetLadderCheck()
    {
        return isTouchingLadder;
    }

    public bool GetGateCheck()
    {
        return isTouchingGate;
    }

    public bool GetSwitchCheck()
    {
        return isTouchingSwitch;
    }
}