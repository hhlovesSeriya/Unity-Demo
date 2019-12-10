using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour {
    [SerializeField]
    Button ContinueBotton;
    [SerializeField]
    Button DebugBotton;

    private void Start()
    {
        DebugBotton.onClick.AddListener(DebugOutPut);
        ContinueBotton.onClick.AddListener(ContinueGame);
    }

    void DebugOutPut()
    {
        Debug.Log("按下了调试按钮");
    }
    void ContinueGame()
    {
        Game.PauseGame();
        Debug.Log("PressContinue");
    }

}
