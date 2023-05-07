using UnityEngine;

public class ControlLayerObject : MonoBehaviour
{
    [SerializeField] private GameObject Player0;
    [SerializeField] private GameObject Layer0Objects;
    [SerializeField] private GameObject Layer1Objects;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player0.activeInHierarchy)
        {
            Layer0Objects.SetActive(true);
            Layer1Objects.SetActive(false);
        }
        else
        {
            Layer0Objects.SetActive(false);
            Layer1Objects.SetActive(true);
        }
    }
}
