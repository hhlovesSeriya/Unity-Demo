using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

    GameObject UIManager;
    UIManager ui;

    private void Awake()
    {
        UIManager = GameObject.Find("UIManager").gameObject;
        ui =UIManager.GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider other)//有只执行了一次的问题
    {
        if(other.gameObject.layer==10)
        {
            //弹出UI
            ui.Interaction();
            //Debug.Log("弹出对话框");
        }
    }
}
