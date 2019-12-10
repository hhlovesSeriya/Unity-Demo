using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneInit : MonoBehaviour {

    
    private void Awake()
    {
        Game.SceneLock = true;
        GameObject player;

        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(0, 2, 0);
    }
}
