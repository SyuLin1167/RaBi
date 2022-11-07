using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody _rb;                                         //リジッドボディ
    private NavMeshAgent _nma;                                     //ナブメッシュ
    [SerializeField] private GameObject playerCamera;           //プレイヤーカメラ格納用
    [SerializeField]private Slider _emysl;                         //Hpスライダー
    [SerializeField] private GameObject target;                    //ターゲット
    [SerializeField] private float maxHp=200.0f;                   //Hp最大値
    [SerializeField] private float nowHp;                          //現在のHp

    private float damageValue;
    private float damageCounter=0;
    private bool damageFlag=false;

// Start is called before the first frame update
    void Start()
    {
        HpManager emyHpManager=new HpManager();
        damageValue=emyHpManager.plyDamage;

       _nma=GetComponent<NavMeshAgent>();

        _emysl.maxValue=maxHp;                                        //Hpの最大値を設定
        _emysl.value=nowHp;                                               //現在のHpを最大値に設定
    }


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="PlayerShot")                              //プレイヤー弾が当たったら
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
            Debug.Log("Hit");                                         //ログを出す
            damageFlag=true;
        }
    }

    void Update()
    {
        MoveConotroll();
        DamageControll();
       // スライダーの向きをカメラ方向に固定
        _emysl.transform.rotation = playerCamera.transform.rotation;
    }

    public void MoveConotroll()
    {
        _nma.destination=target.transform.position;
    } 

    public void DamageControll()
    {
        if(damageFlag)
        {
            if(damageCounter<damageValue)
            {
                damageCounter+=0.5f;
                nowHp-=0.5f;
                _emysl.value=nowHp;
            }
            else
            {
                damageCounter=0;
                damageFlag=false;
            }
        
            if(nowHp<=0)
            {
                Destroy(gameObject);
                
            }
        }
    }
}
