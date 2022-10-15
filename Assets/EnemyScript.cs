using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody _rb;
    private NavMeshAgent _nma;
    [SerializeField] private GameObject target;

    bool Damage=false;
    private float countTimer;
    private Vector3 targetPos;

        void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="PlayerShot")                               //プレイヤー弾が当たったら
        {
            Debug.Log("Hit");                                         //ログを出す
           Damage=true;
        }   
    }



    void Start()
    {
       _nma=GetComponent<NavMeshAgent>();
       
    }

    
    void Update()
    {
        MoveConotroll();
        DamageControll();
       
       
    }

    public void MoveConotroll()
    {
        _nma.destination=target.transform.position;
    } 

    public void DamageControll()
    {
        if(Damage)
        {
            
        }
    }
}
