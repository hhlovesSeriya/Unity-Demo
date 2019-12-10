using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    //Time
    const float pausedTimeScale = 0f;
    float playSpeed = 1f;
    //

    

    static Game instance;
    
    [SerializeField]
    UIManager uiManager;
    
    [SerializeField]
    EnemyFactory Enemyfactory;
    [SerializeField]
    WarFactory warFactory;

    public static bool ActionLock = true;
    public static bool GameLock = true;
    public static bool SceneLock = true;
    public static int GameProgress = 1;

    public static Fire SpawnFire()
    {
        Fire f = instance.warFactory.fire;
        return f;
    }

    public static void SpawnEnemy(EnemyFactory factory, EnemyType type)
    {
        
        Enemy enemy = factory.Get(type);
       
    }

    public static void PauseGame()
    {
        
        //Debug.Log("按下了ESC");
        Time.timeScale =
            Time.timeScale > pausedTimeScale ? pausedTimeScale : instance.playSpeed;

        GameLock = !GameLock;
        //ActionLock = !ActionLock;
        //弹出UI界面
        instance.uiManager.PauseChange();
        //
        
        
    }

    public static void EndGame()
    {
        //弹出UI
        Debug.Log("游戏结束");
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }

    private void OnEnable()
    {
        instance = this;
    }

    private void Update()
    {
        if(Game.SceneLock)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
            else if (Time.timeScale > pausedTimeScale)
            {
                Time.timeScale = instance.playSpeed;
            }
            if (MainActor.IfDie)
            {
                EndGame();
            }
        }
        
        
        
    }
}
