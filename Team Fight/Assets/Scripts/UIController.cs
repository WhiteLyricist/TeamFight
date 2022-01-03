using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    [SerializeField]
    private GameObject _team1;
    [SerializeField]
    private GameObject _team2;

    [SerializeField] 
    private TMP_Text _text;

    private float _timer = 0;

    void Start()
    {
        Move.gameOver += OnGameOver;
    }

    private void Update()
    {
        _timer = _timer + Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene("Game");
        }
    }

    void OnGameOver(string text) 
    {
        Destroy(_team1);
        Destroy(_team2);

        _text.gameObject.SetActive(true);
        _text.text = text + " выиграла! Время игры - " + _timer;
    }

    private void OnDestroy()
    {
        Move.gameOver -= OnGameOver;
    }

}
