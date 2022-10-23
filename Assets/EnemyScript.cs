using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody _rb;
     [SerializeField] private Slider _emysl;                                //スライダー
    private NavMeshAgent _nma;
    [SerializeField] private GameObject target;
     [SerializeField] private float maxHp=100.0f;                        //Hp最大値
    [SerializeField] private float nowHp=100.0f;                        //現在のHp
     int damageValue;
    private float damageCounter;

    bool damageFlag=false;
    private float countTimer;

        void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="PlayerShot")                               //プレイヤー弾が当たったら
        {
            Debug.Log("Hit");                                         //ログを出す
           damageFlag=true;
        }   
    }



    void Start()
    {
       _nma=GetComponent<NavMeshAgent>();
        HpManager emyHpManager=new HpManager();

        damageValue=emyHpManager.plyDamage;
       _emysl.maxValue=maxHp;
       _emysl.value=nowHp;
       

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
        _emysl.transform.position=transform.position+new Vector3(0,50,0);
        if(damageFlag)
        {
              if(damageCounter<damageValue)
            {
                damageCounter+=0.5f;
                _emysl.value-=0.5f;
                Debug.Log(_emysl.value);
            }
            else
            {
                damageCounter=0;
                damageFlag=false;
            }
        }
        if( _emysl.value<=0)
        {
            Destroy(gameObject);
            _emysl.gameObject.SetActive(false);
        }
    }
}
