using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondChanger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            //Scene sc = SceneManager.GetSceneByName("Second Scene");
            SceneManager.LoadScene("Game Scene First");//可能要异步加载，或者增加一个加载界面
            //SceneManager.MoveGameObjectToScene(other.gameObject, sc);
            Debug.Log("切换场景");
        }
    }
}
