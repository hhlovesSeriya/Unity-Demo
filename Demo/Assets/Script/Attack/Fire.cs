using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : WarEntity {

    Vector3 StartPoint; Vector3 TargetPoint;float speed; int Damage;
    float progress;
    //测试
    Vector3 Distance;
    ActorType TargetType;

    public void Initialize(Vector3 StartPoint,Vector3 TargetPoint,float speed,int Damage,ActorType TargetType)
    {
        this.StartPoint = StartPoint;
        this.TargetPoint = TargetPoint;
        this.speed = speed;
        this.Damage = Damage;
        this.TargetType = TargetType;
    }
    private void Start()
    {
        transform.position = StartPoint;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(TargetType==ActorType.EnemyType)
        {
            if (other.gameObject.layer == 9)
            {
                Recycle();
                other.gameObject.GetComponent<Enemy>().GetDamage(Damage);
                Debug.Log("击中目标");

            }
        }
        if (TargetType == ActorType.MainActorType)
        {
            if (other.gameObject.layer == 10)
            {
                Recycle();
                MainActor.GetDamage(Damage);
                Debug.Log("击中目标1");
            }
        }
        
        
    }
    


    public override void Update()
    {
        Distance = TargetPoint - StartPoint;
        transform.position += Distance * Time.deltaTime;
        progress += Time.deltaTime;
        
        if(progress>=2)
        {
            Recycle();
            //Debug.Log("击中目标");
            progress -= 2;
        }
            
        
    }
    

    
}
