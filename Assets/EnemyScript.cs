using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody _rb;
    private Renderer _rd;
    //[SerializeField] private GameObject target;
    public Transform target;

    bool Damage=false;
    private float countTimer;
    private Vector3 targetPos;

        void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Shot")                               //プレイヤー弾が当たったら
        {
            Debug.Log("Hit");                                         //ログを出す
           Damage=true;
        }   
    }



    void Start()
    {
       
    }

    
    void Update()
    {
        DamageControll();
        targetPos=target.position;
        targetPos.y=transform.position.y;
        transform.LookAt(target);
    }

    public void MoveConotroll()
    {
        //target.transform.position;
    } 

    public void DamageControll()
    {
        if(Damage)
        {
            countTimer+=Time.deltaTime;
            if(countTimer>3)
                {
                    countTimer=0;
                    Damage=false;
                }
        }
    }
}
