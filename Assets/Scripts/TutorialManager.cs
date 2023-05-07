using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("Gameobjects")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _churchPopUp;
    [SerializeField] private GameObject _fountainPopUp;
    [SerializeField] private GameObject _fountainCollider;
    [SerializeField] private GameObject _key;


    [Header("Others")]
    [SerializeField] private bool _isChurchClosed;
    [SerializeField] private bool _isfountainPopUpClosed;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Church"))
        {
            _isChurchClosed = false;
            print("cuma namazı");
            _churchPopUp.SetActive(true);
            _fountainCollider.SetActive(true);
            _key.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fountain"))
        {
            print("haydo");
            _fountainPopUp.SetActive(true);
            _isfountainPopUpClosed = false;
        }
    }
    private void Update()
    {
        if (!_isChurchClosed)
        {
            StartCoroutine(ClosePopUp());
        }

        if (Input.GetKeyDown(KeyCode.E) && !_isfountainPopUpClosed)
        {
            _fountainPopUp.SetActive(false);

        }
    }



    private IEnumerator ClosePopUp()
    {
        yield return new WaitForSeconds(4f);
        _churchPopUp.SetActive(false);
    }
}
