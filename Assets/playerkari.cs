using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerkari : MonoBehaviour
{
    private Rigidbody rb; //リジッドボディを取得するための変数
    public float upForce = 200f; //上方向にかける力
    private bool isGround; //着地しているかどうかの判定
 
 
 void Start()
    {
        rb = GetComponent<Rigidbody>(); //リジッドボディを取得
    }
    void Update()
    {
        if(Input.GetKey("up"))
        {
            transform.position += transform.forward * 0.03f;
            
        }
 
        if(Input.GetKey("right"))
        {
            transform.Rotate(0,1,0);
        }
 
        if(Input.GetKey("left"))
        {
            transform.Rotate(0,-1,0);
        }
 
        if (isGround == true)//着地しているとき
        {
            if(Input.GetKeyDown("space"))
            {
                isGround = false;//  isGroundをfalseにする
                rb.AddForce(new Vector3(0, upForce, 0)); //上に向かって力を加える
            }
        }
    }
    
    void OnCollisionEnter(Collision other) //地面に触れた時の処理
    {
        if (other.gameObject.tag == "Stage") //Groundタグのオブジェクトに触れたとき
        {
            isGround = true; //isGroundをtrueにする
        }
    }
}
