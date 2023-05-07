using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPopup : MonoBehaviour
{
    [SerializeField] private GameObject popup;

    [SerializeField] private Collider2D myCollider;

    [SerializeField] private bool isPlayerTouching;


    private void Awake()
    {
        myCollider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {

            isPlayerTouching = true;
        }
        else
        {

            isPlayerTouching = false;

        }

        if(isPlayerTouching)
        {
            popup.SetActive(true);
        }
        else
        {
            popup.SetActive(false);
        }


    }
}
