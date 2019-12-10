using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInit : MonoBehaviour {

    private void Awake()
    {
        Game.SceneLock = false;
    }
}
