using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSceneInit : MonoBehaviour {

    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(0, 10, 0);
        Debug.Log("新场景");
    }
}
