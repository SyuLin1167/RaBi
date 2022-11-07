using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    private Rigidbody _rb;                                  //リジッドボディ
    [SerializeField] private GameObject shot;               //shotオブジェクト
    Vector3 nowPos;

    private float countTimer;                               //タイマー
    [SerializeField] private float shotTimer=2.5f;
    [SerializeField] private float Speed=200.0f;            //弾の速度
    [SerializeField] private float Spacing=0.0f;
    private   GameObject shots = null;
    

    void Start()
    {
       
    }
 
    void Update()
    {
        
        countTimer+=Time.deltaTime;                  //タイムを計測
        if(countTimer>shotTimer)                             //二秒たったら
        {
            if(shotTimer>0.1f)
            {
                shotTimer-= Spacing;
            }
            shots = Instantiate(shot, transform.position, transform.rotation);  //弾を複製
            _rb = shots.GetComponent<Rigidbody>();                                          //リジッドボディ取得
            GetComponent<AudioSource>().Play();
            _rb.AddForce(transform.forward*Speed,ForceMode.Impulse);                                           //弾を移動させる
            countTimer=0;                                                                        //タイマーを0にする
        }

        nowPos=new Vector3(0,this.transform.position.y,0);
        if(nowPos.y>550)
        {
            countTimer=0;
            shotTimer=1;
        }
    }
    
}

