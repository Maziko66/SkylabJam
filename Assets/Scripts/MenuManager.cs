using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditorInternal;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Animator _fadeoutAnim;
    [SerializeField] private float _fadeOutDuration;

    public void Play()
    {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelindex)
    {
        _fadeoutAnim.SetTrigger("Start");

        yield return new WaitForSeconds(_fadeOutDuration);

        SceneManager.LoadScene(levelindex);
    }
   
}
