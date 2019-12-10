using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainActor : Actor {

    static MainActor instance;
    //测试专用
    //[SerializeField]
    GameObject[] TargetEnemies;
    //
    Rigidbody rb;
    [SerializeField]
    SkillTree skillTree;

    Animator animator;

    //SphereCollider 

    float SearchProgress = 0;


    [SerializeField]
    Transform Body;
    [Range(0,100)]
    public int Attack=1;
    [Range(0, 1000)]
    public int Health = 20;
    [Range(0, 1000)]
    public int Defence = 10;

    public static Vector3 Position
    {
        get
        {
            return instance.transform.position;
        }
    }

    public static bool IfDie
    {
        get
        {
            if (instance.Health <= 0)
                return true;
            else
                return false;
        }
    }

    [SerializeField]
    float speed = 5f;

     void GetInput()
    {
        if(Game.ActionLock && Game.GameLock)
        {
            if (Input.GetKey(KeyCode.A))
            {
                //Debug.Log("按下了A");
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                //Debug.Log(transform.position);
                //动画机控制部分
            }
            if (Input.GetKey(KeyCode.D))
            {
                //Debug.Log("按下了D");
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                //Debug.Log(transform.position);

            }
            //WS可能会改成旋转
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, 0, speed * Time.deltaTime);
                //Debug.Log("按下了W");

            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
                //Debug.Log("按下了S");


            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("按下了空格");
                //跳跃动画
                Jump();

            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                Debug.Log("按下了J");
                OnFire();
                //动画机控制部分
            }
        }

        

    }
    
    public void Jump()
    {
        rb.AddForce(0, 100 , 0);//参数待调
    }

    public static void GetDamage(int attack)
    {
        //int Damage = attack * (1-instance.Defence / (100 + instance.Defence));
        int Damage = attack;
        instance.Health -= Damage;
    }
    public void SearchEnemy()
    {
        TargetEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("Search Enemy");
    }
    public GameObject GetTarget(GameObject[] enemy)//暂时有个数组越界的问题
    {
        if (enemy != null)
        {
            Debug.Log("有"+enemy.Length+"个敌人");
            int RandomNumber = Random.Range(0, enemy.Length - 1);
            return enemy[RandomNumber];
        }
        else return null;
        
    }

    public void OnFire()
    {
        Vector3 LaunchPoint = transform.position;
       
        //Debug.Log(LaunchPoint);
        if(GetTarget(TargetEnemies)!=null)
        {
            Vector3 TargetPosition = GetTarget(TargetEnemies).transform.position;
            Game.SpawnFire().Initialize(LaunchPoint, TargetPosition, 5, 100, ActorType.EnemyType);//每种指向性攻击都要有一个没有目标的射击方式
        }
        
    }

    private void OnEnable()
    {
        instance = this;
    }

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public override void Update()
    {
        //Debug.Log(instance.Health);
        SearchProgress += Time.deltaTime;//暂时的解决办法是每0.2s搜索一次减少搜索时间
        if (SearchProgress>=0.2)
        {
            SearchEnemy();
            SearchProgress = SearchProgress - 0.2f;
        }
        

        GetInput();
        if(IfDie)
        {
            Destroy(this.gameObject);
            Game.EndGame();
        }
    }
}
