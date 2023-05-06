using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchLvl1 : MonoBehaviour
{
    [SerializeField] FadeInObject fadeInObject;
    public KeyCode interactionKey = KeyCode.E;
    Collider2D switchCollider;

    [SerializeField] bool isColliding;

    void Awake()
    {
        switchCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (switchCollider.IsTouchingLayers(LayerMask.GetMask("Player Ladder Trigger")))
        {

            isColliding = true;
        }
        else
        {

            isColliding = false;
        }
    }

    void OnSwitchPressed()
    {
        Debug.Log("pressed");
        if(isColliding)
        {
            fadeInObject.StartFadeIn();
        }
    }
        

}
