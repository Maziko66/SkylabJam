using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryBox : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Player0;
    [SerializeField] private Rigidbody2D Player1;
    private Rigidbody2D rb;
    private bool isIn = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isIn = false;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isIn && Input.GetKey(KeyCode.E))
        {
            if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && Player0.gameObject.activeInHierarchy)
            {
                rb.velocity = new(Player0.velocity.x, rb.velocity.y);
            }
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && Player1.gameObject.activeInHierarchy)
            {
                rb.velocity = new(Player1.velocity.x, rb.velocity.y);
            }

        }
    }
}
