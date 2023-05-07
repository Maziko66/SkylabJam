using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletonnn : MonoBehaviour
{
    public static Singletonnn Instance;

    // Start is called before the first frame update

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
