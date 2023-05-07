using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _dialog;
    [SerializeField] private Animator _cutSceneAnim;
    [SerializeField] private TMP_Text _text;
    public Player playerController;
    [SerializeField] private int textindex = 0;

    [SerializeField] List<string> _dialogueSentences = new List<string>();





    public void Start()
    {
        //playerController.playerHasHorizontalSpeed = true;

        _cutSceneAnim.SetBool("isWalking", true);
        transform.DOMove(new Vector3(5, 0, 0), 5);

        _dialogueSentences.Add("alp");
        _dialogueSentences.Add("ali");
        _dialogueSentences.Add("eren");
        _dialogueSentences.Add("nah");
        _dialogueSentences.Add("ters");
        _dialogueSentences.Add("düz");




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DialogStarter"))
        {
            _dialog.SetActive(true);

        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            textindex++;
            print(textindex);
            if (textindex >= 6)
            {
                SceneManager.LoadScene("level1");
            }
            else
            {
                _text.SetText(_dialogueSentences[textindex]);
            }
        }
    }
}

