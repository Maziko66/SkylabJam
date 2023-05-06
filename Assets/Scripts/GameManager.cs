using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[System.Serializable]
public class JaggedLayers
{
    public GameObject[] layer;
}

public class GameManager : MonoBehaviour
{
    [Header("Players")]
    Player player1;
    [SerializeField] private Player[] players;

    [Header("Tilemap Layers")]
    [SerializeField] private GameObject[] layer0;
    [SerializeField] private GameObject[] layer1;
    [SerializeField] private List<JaggedLayers> jaggedLayers = new List<JaggedLayers>();

    

    [Header("Variables")]
    [SerializeField] private int currentLayerIndex = 0;
    [SerializeField] private int targetLayerIndex = 1;
 
    void Awake()
    {
        player1 = FindObjectOfType<Player>();
    }

    void Start()
    {
        for(int i = 0; i < jaggedLayers.Count; i++)
        {
            if(i != currentLayerIndex)
            {
                for(int j = 0; j < jaggedLayers[i].layer.Length; j++)
                {
                    jaggedLayers[i].layer[j].SetActive(false);
                }
            }
        }
    }

    void Update()
    {
        
    }

    private void OnSwap(InputValue value)
    {
        ChangeLayer(currentLayerIndex, targetLayerIndex);
    }
    
    

    private void TilemapColorChanger(Tilemap tr, Color clr)
    {
        tr.color = clr;
    }

    private void TilemapColliderDisabler(Collider2D collider)
    {
        collider.enabled = false;
    }

    private void ChangeLayer(int currentIndex, int targetIndex)
    {
        for(int i = 0; i < jaggedLayers[currentIndex].layer.Length; i++)
        {
            //Collider2D currentLayerCollider = jaggedLayers[currentIndex].layer[i].GetComponent<Collider2D>();
            jaggedLayers[currentIndex].layer[i].SetActive(false);
            currentLayerIndex = targetIndex;
        }
        for(int i = 0; i < jaggedLayers[targetIndex].layer.Length; i++)
        {
            jaggedLayers[targetIndex].layer[i].SetActive(true);
            targetLayerIndex = currentIndex;
        }
        
    }


    /* private void ChangeLayer()                                             //TODO!!
    {                                                                      //CHANGE SORTING LAYER & COLLISION INSTEAD OF SETACTIVE
        if(currentLayer == 0)                                              //ADD LAYER MASKING OR SPRITE SHENANIGANS (if required)            
        {
            player1.SetRigidBodyGravityScale(0);
            for(int i = 0; i < layer0.Length; i++)
            {
                layer0[i].SetActive(false);
            }
            for(int i = 0; i < layer1.Length; i++)
            {
                layer1[i].SetActive(true);
            }
            
            currentLayer = 1;
            
        }
        else if(currentLayer == 1)
        {
            for(int i = 0; i < layer1.Length; i++)
            {
                layer1[i].SetActive(false);
            }
            for(int i = 0; i < layer0.Length; i++)
            {
                layer0[i].SetActive(true);
            }
            
            currentLayer = 0;

            player1.SetRigidBodyGravityScale(player1.GetDefaultGravityScale());
        }
    } */

}
