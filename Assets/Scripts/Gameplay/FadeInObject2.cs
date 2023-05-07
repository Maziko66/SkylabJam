using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FadeInObject2 : MonoBehaviour
{
    Tilemap sr;
    TilemapCollider2D col;
    //Tilemap otherSR;

    void Awake()
    {
        sr = GetComponent<Tilemap>();
        col = GetComponent<TilemapCollider2D>();
    }


    void Start()
    {
        Color c;
        c = sr.color;
        c.a = 0f;
        sr.color = c;
        col.enabled = false;
        Debug.Log(col.enabled);
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
        Debug.Log("col.enabled: " + col.enabled);
    }

    public void StartFadeIn()
    {
        Debug.Log("start fade in");
        StartCoroutine("FadeIn");
    }

}
