using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "";
    [SerializeField] private Player player;

    private Collider2D playerCollider;
    private void Awake() {
        playerCollider = player.GetComponent<Collider2D>();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == playerCollider)
        {
            Invoke("LoadScene", 1.0f);
        }
        
    }


    private void LoadScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
