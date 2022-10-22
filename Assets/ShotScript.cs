using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    private Rigidbody _rb;                                  //リジッドボディ
    [SerializeField] private GameObject shot;               //shotオブジェクト

     private float countTimer;                              //タイマー
    [SerializeField] private float Speed=150.0f;            //弾の速度
    [SerializeField] GameObject explosion;
 
        
    void OnCollisionEnter(Collision collision)
    {

        Instantiate (explosion, transform.position, Quaternion.identity);
        Destroy(explosion);
        Destroy(gameObject);
    }

    void Start()
    {
       
        
    }
 
    void Update()
    {
        GameObject shots = null;
        countTimer+=Time.deltaTime;                  //タイムを計測
        if(countTimer>2.5f)                             //二秒たったら
        {
            shots = Instantiate(shot, transform.position, transform.rotation);  //弾を複製
            _rb = shots.GetComponent<Rigidbody>();                                          //リジッドボディ取得
            
            _rb.AddForce(transform.forward*Speed,ForceMode.Impulse);                                           //弾を移動させる

            countTimer=0;                                                                        //タイマーを0にする
        }
        Destroy(shots,2.0f);
        
        
    }

    
}

