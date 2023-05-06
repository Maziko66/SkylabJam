using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ukte.PlayerRelated
{
    public class PlayerLadderTrigger : MonoBehaviour
    {
        Collider2D myCollider;
        [SerializeField] private bool isTouchingLadder = false;
        [SerializeField] private bool isTouchingGate = false;

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

        }

        public bool GetLadderCheck()
        {
            return isTouchingLadder;
        }

        public bool GetGateCheck()
        {
            return isTouchingGate;
        }
    }
}