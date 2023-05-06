using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelFadeIn : MonoBehaviour
{
    [SerializeField] Animator _cutSceneFadeIn;
    void Start()
    {
        _cutSceneFadeIn.SetTrigger("StartFade");
    }

   
}
