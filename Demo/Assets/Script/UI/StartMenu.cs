using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    [SerializeField]
    Button StartButton;
    private void Awake()
    {
        //StartButton = gameObject.transform.Find("StartGameButton")
    }
    private void Start()
    {
        StartButton.onClick.AddListener(StartGame);
    }
    void StartGame()
    {
        SceneManager.LoadScene("Game Scene First");
    }
}
