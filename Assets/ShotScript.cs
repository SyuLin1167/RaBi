using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private GameObject shot;  
    [SerializeField] private GameObject player;
     private float Count;
    [SerializeField] private float Speed=50.0f;
    private Vector3 shotPosition;
    
    void Start()
    {
       
        shotPosition=player.transform.position+new Vector3(0,20,0);
    }
 
    void Update()
    {
        
        Count+=Time.deltaTime;                  //タイムを計測
        if(Count>2)                             //二秒たったら
        {
            
 
            GameObject shots = Instantiate(shot, shotPosition, player.transform.rotation);  //弾を複製
            _rb = shots.GetComponent<Rigidbody>();                                          //リジッドボディ取得
            
            shot.transform.rotation=player.transform.rotation;
            _rb.velocity=transform.forward*Speed;                                           //弾を移動させる

            Count=0;                                                                        //タイマーを0にする
        }
        Destroy(shot,3.0f);
        
        
    }

    
}

