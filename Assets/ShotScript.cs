using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private GameObject shot;  
    [SerializeField] private GameObject player;
     private float Count;
    [SerializeField] private float Speed=100.0f;
    private Vector3 shotPosition;
    
    void Start()
    {
       
        
    }
 
    void Update()
    {
        
        Count+=Time.deltaTime;                  //タイムを計測
        if(Count>2.9)                             //二秒たったら
        {
            shot.transform.position=player.transform.position+new Vector3(0,20,0);                       //位置をセット
            shot.transform.rotation=player.transform.rotation;
 
            GameObject shots = Instantiate(shot, shot.transform.position, shot.transform.rotation);  //弾を複製
            _rb = shots.GetComponent<Rigidbody>();                                          //リジッドボディ取得
            
            _rb.velocity=transform.forward*Speed;                                           //弾を移動させる

            Count=0;                                                                        //タイマーを0にする
        }
        Destroy(shot,3.0f);
        
        
    }

    
}

