using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    Player player1;

    [Header("Tilemap Layers")]
    [SerializeField] private GameObject[] layer1;
    [SerializeField] private GameObject[] layer2;

    [Header("variables")]
    [SerializeField] private int currentLayer = 1;

    void Awake()
    {
        player1 = FindObjectOfType<Player>();
    }

    void Update()
    {
        
    }

    private void OnSwap(InputValue value)
    {
        ChangeLayer();
    }
    
    private void ChangeLayer()                                             //TODO!!
    {                                                                      //CHANGE SORTING LAYER & COLLISION INSTEAD OF SETACTIVE
        if(currentLayer == 1)                                              //ADD LAYER MASKING OR SPRITE SHENANIGANS             
        {
            player1.SetRigidBodyGravityScale(0);
            for(int i = 0; i < layer1.Length; i++)
            {
                layer1[i].SetActive(false);
            }
            for(int i = 0; i < layer2.Length; i++)
            {
                layer2[i].SetActive(true);
            }
            
            currentLayer = 2;
            
        }
        else if(currentLayer == 2)
        {
            for(int i = 0; i < layer2.Length; i++)
            {
                layer2[i].SetActive(false);
            }
            for(int i = 0; i < layer1.Length; i++)
            {
                layer1[i].SetActive(true);
            }
            
            currentLayer = 1;

            player1.SetRigidBodyGravityScale(player1.GetDefaultGravityScale());
        }
    }

    


}
