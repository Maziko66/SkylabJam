using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditorInternal;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Animator _fadeoutAnim;
    [SerializeField] private float _fadeOutDuration;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private GameObject _creditsMenu;

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

    public void OnClickOptions()
    {
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(true);
    }

    public void OnClickBackInOptions()
    {
        _optionsMenu.SetActive(false);
        _creditsMenu.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void OnClickCredit()
    {
        _mainMenu.SetActive(false);
        _creditsMenu.SetActive(true);
    }

    public void OnClickQuit() 
        => Application.Quit();
    

}
