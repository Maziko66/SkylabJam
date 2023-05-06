using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMovement : MonoBehaviour
{
    public Animator InvBool;
    bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isOpen)
        {
            InvBool.SetBool("inventory", true);
            isOpen = true;
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && isOpen)
        {
            InvBool.SetBool("inventory", false);
            isOpen = false;
        }

    }
}
