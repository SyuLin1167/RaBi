using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    private Rigidbody _rb;                                  //リジッドボディ
    [SerializeField] private GameObject shot;               //shotオブジェクト
    [SerializeField] private GameObject owner;             //playerオブジェクト
     private float countTimer;                              //タイマー
    [SerializeField] private float Speed=100.0f;            //弾の速度
    
   
    private Vector3 shotPos;

    void Start()
    {
       
        
    }
 
    void Update()
    {
        
        countTimer+=Time.deltaTime;                  //タイムを計測
        if(countTimer>2.5)                             //二秒たったら
        {
            shotPos=owner.transform.position+new Vector3(0,20,0);                       //位置をセット
            shot.transform.rotation=owner.transform.rotation;
 
            GameObject shots = Instantiate(shot, shotPos, shot.transform.rotation);  //弾を複製
            _rb = shots.GetComponent<Rigidbody>();                                          //リジッドボディ取得
            
            _rb.AddForce(transform.forward*Speed,ForceMode.Impulse);                                           //弾を移動させる

            countTimer=0;                                                                        //タイマーを0にする
        }
        Destroy(shot,3.0f);
        
        
    }

    
}

