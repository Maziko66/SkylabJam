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
public class PlayerComp
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

    public GameObject GetPlayer() => player.gameObject;
}
    public class GameManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCam;
    //[SerializeField] private GameObject popup;

    [Header("Players")]
    [SerializeField] private List<PlayerComp> players;

    [Header("Tilemap Layers")]
    [SerializeField] private List<JaggedLayers> jaggedLayers;

    [Header("Variables")]
    [SerializeField] private int currentPlayer = 1;
    [SerializeField] private int targetPlayer = 0;
    [SerializeField] private int currentLayerIndex = 1;
    [SerializeField] private int targetLayerIndex = 0;

    [Header("Bools")]
    [SerializeField] private bool showPopup = false;

    void Start()
    {
        SetPlayerActiveStatus();
        ChangeLayer();
        SetInitialLayers();
    }

    public void SetPlayerActiveStatus()
    {
        int tempPlayer = currentPlayer;
        currentPlayer = targetPlayer;

        for (int i = 0; i < players.Count; i++)
        {
            if (i != currentPlayer)
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

    public void ChangeLayer()
    {
        int tempLayerIndex = currentLayerIndex;

        // current layer
        var currentLayer = jaggedLayers[currentLayerIndex];
        var currentLayerLength = currentLayer.layer.Length;
        for (int i = 0; i < currentLayerLength; i++)
            currentLayer.layer[i].SetActive(false);

        // target layer
        var targetLayer = jaggedLayers[targetLayerIndex];
        var targetLayerLength = targetLayer.layer.Length;
        for (int i = 0; i < targetLayerLength; i++)
            targetLayer.layer[i].SetActive(true);

        currentLayerIndex = targetLayerIndex;
        targetLayerIndex = tempLayerIndex;
    }

    private void SetInitialLayers()
    {
        var jaggedLayersCount = jaggedLayers.Count;

        for (int i = 0; i < jaggedLayersCount; i++)
        {
            if (i != currentLayerIndex)
            {
                var layerLength = jaggedLayers[i].layer.Length;

                for (int j = 0; j < layerLength; j++)
                    jaggedLayers[i].layer[j].SetActive(false);
            }
        }
    }

    private void TilemapColorChanger(Tilemap tilemap, Color color)
    {
        tilemap.color = color;
    }

    private void TilemapColliderDisabler(Collider2D collider)
    {
        collider.enabled = false;
    }
    
    //private void ShowPopup()
    //{
    //    if(showPopup)
    //    {
    //        popup.SetActive(true);
            
    //    }
    //}

    //private void DisablePopup()
    //{
    //    popup.SetActive(false);
    //}

    // todo!!!! there was something here, check version control
}