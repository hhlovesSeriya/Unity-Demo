using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehavior  {

    public static void UIStateChange(GameObject Interface)
    {
        Interface.SetActive(!Interface.activeInHierarchy);
    }
    public static void UIStateChangeTrue(GameObject Interface)
    {
        Interface.SetActive(true);
    }
    public static void UIStateChangeFalse(GameObject Interface)
    {
        Interface.SetActive(false);
    }

}
