using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyhole : MonoBehaviour
{
    [SerializeField] FadeInObject2 fadeInObject;
    Collider2D switchCollider;
    InventoryManager inventoryManager;

    [SerializeField] string requiredKeyName = "";
    [SerializeField] bool isColliding;
    [SerializeField] bool isPressedOnce = false;

    void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        switchCollider = GetComponent<Collider2D>();
    }


    // Update is called once per frame
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
        CheckIfPlayerHasKey();

            
    }

    void CheckIfPlayerHasKey()
    {
        if(inventoryManager.GetItem(requiredKeyName) && isColliding && !isPressedOnce)
        {
            Debug.Log("unlocked");
            inventoryManager.RemoveItem(requiredKeyName);
            fadeInObject.StartFadeIn();
        }
    }
}
