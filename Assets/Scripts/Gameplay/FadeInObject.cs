using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FadeInObject : MonoBehaviour
{
    Tilemap sr;
    TilemapCollider2D col;
    [SerializeField] GameObject otherObj;
    TilemapCollider2D otherCol;
    //Tilemap otherSR;

    void Awake()
    {
        sr = GetComponent<Tilemap>();
        col = GetComponent<TilemapCollider2D>();
        otherCol = otherObj.GetComponent<TilemapCollider2D>();
        //otherSR = otherObj.GetComponent<Tilemap>();
    }


    void Start()
    {
        Color c;
        c = sr.color;
        c.a = 0f;
        sr.color = c;
        col.enabled = false;
    }


    IEnumerator FadeIn()
    {
        for(float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = sr.color;
            c.a = f;
            sr.color = c;
            Debug.Log(sr.color);
            yield return new WaitForSeconds(0.05f);
        }
        col.enabled = true;
        otherCol.enabled = false;
        Debug.Log("col.enabled: " + col.enabled);
    }

    public void StartFadeIn()
    {
        Debug.Log("start fade in");
        StartCoroutine("FadeIn");
    }

}
