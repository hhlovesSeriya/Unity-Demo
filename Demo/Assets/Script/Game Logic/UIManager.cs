using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class UIManager: MonoBehaviour  {
    //控制UI界面显示的




    /// Game Scene
    
    [SerializeField]
    GameObject Evesystem;
    
    GameObject Scene1Canvas;

    [SerializeField]
    GameObject PauseInterface;
    public void PauseChange()
    {
        UIBehavior.UIStateChange(PauseInterface);
    }

    [SerializeField]
    GameObject InteractionUI;
    public void Interaction()
    {
        UIBehavior.UIStateChangeTrue(InteractionUI);
        Debug.Log("弹出对话框");
        Game.ActionLock = !Game.ActionLock;
        
    }

    private void Awake()
    {
        Scene1Canvas = GameObject.Find("Canvas");
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(Scene1Canvas);
        DontDestroyOnLoad(Evesystem);
        


        
        
        PauseInterface = Scene1Canvas.transform.Find("PauseInterface").gameObject;
        InteractionUI = Scene1Canvas.transform.Find("DiologeUI").gameObject;
      
    }

    
       
        
    
}
