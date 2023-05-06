using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using Cinemachine;

[System.Serializable]
public class JaggedLayers
{
    public GameObject[] layer;
}

[System.Serializable]
public struct PlayerComp
{
    [SerializeField] Player player;
    [SerializeField] PlayerFeet playerFeet;
    [SerializeField] PlayerLadderTrigger playerLadderTrigger;

    public void ActiveStatusAll(bool state) 
    {
        player.gameObject.SetActive(state);
        playerFeet.gameObject.SetActive(state);
        playerLadderTrigger.gameObject.SetActive(state);
    }

    public GameObject GetPlayer()
    {
        return player.gameObject;
    }
}


public class GameManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCam;

    [Header("Players")]
    [SerializeField] private List<PlayerComp> players = new List<PlayerComp>();

    [Header("Tilemap Layers")]
    [SerializeField] private List<JaggedLayers> jaggedLayers = new List<JaggedLayers>();

    

    [Header("Variables")]
    [SerializeField] private int currentPlayer = 0;
    [SerializeField] private int targetPlayer = 1;
    [SerializeField] private int currentLayerIndex = 0;
    [SerializeField] private int targetLayerIndex = 1;
 
    void Awake()
    {
        //player1 = FindObjectOfType<Player>();
    }

    void Start()
    {
        SetPlayerActiveStatus();
        ChangeLayer();

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
        ChangeLayer();
        SetPlayerActiveStatus();
    }
    
    

    private void TilemapColorChanger(Tilemap tr, Color clr)
    {
        tr.color = clr;
    }

    private void TilemapColliderDisabler(Collider2D collider)
    {
        collider.enabled = false;
    }

    private void ChangeLayer()
    {
        int tempLayerIndex = currentLayerIndex;
        
        for(int i = 0; i < jaggedLayers[currentLayerIndex].layer.Length; i++)
        {
            //Collider2D currentLayerCollider = jaggedLayers[currentLayerIndex].layer[i].GetComponent<Collider2D>();
            jaggedLayers[currentLayerIndex].layer[i].SetActive(false);

        }
        for(int i = 0; i < jaggedLayers[targetLayerIndex].layer.Length; i++)
        {
            jaggedLayers[targetLayerIndex].layer[i].SetActive(true);
        }
        currentLayerIndex = targetLayerIndex;
        targetLayerIndex = tempLayerIndex;        
    }

    private void SetPlayerActiveStatus()
    {
        int tempPlayer = currentPlayer;
        currentPlayer = targetPlayer;
        for(int i = 0; i < players.Count; i++)
        {
            if(i != currentPlayer)
            {
                players[i].ActiveStatusAll(false);
            }
            else
            {
                players[i].ActiveStatusAll(true);
                followCam.Follow = players[i].GetPlayer().transform;
            }
        }

        targetPlayer = tempPlayer;
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
