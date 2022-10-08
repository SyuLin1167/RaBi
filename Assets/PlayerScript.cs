using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Vector3 moving;          //プレイヤーの向き
    Rigidbody rb;               
    public float Speed=90.0f;
    public float Grabity=9.0f;
    public float jumpPower=200.0f;
    bool jumpFlag=true;
    float x,z;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの重力コンポーネントを取得し、倒れないように回転を制御
       rb=GetComponent<Rigidbody>();
    }


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Stage")
        {
            Debug.Log("Stage");
            jumpFlag=true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        MoveControll();
        JumpControll();
       // rb.velocity=moving;
        
    }

    void FixedUpdate()
    {
         MoveDir();
    }

    void MoveControll()
    {
      x=Input.GetAxisRaw("Horizontal")*Speed;
      z=Input.GetAxisRaw("Vertical")*Speed; 
      rb.AddForce(x,0,z);
    }

    public void MoveDir()
    {
        if(Mathf.Abs(x)>0.1f)                                            //左右キーが入力されたら
        {
        Quaternion rotX = Quaternion.AngleAxis(x+90,Vector3.up);            //最大何度まで回転するか設定
        rotX = Quaternion.Slerp(rb.transform.rotation, rotX, 0.1f);             //徐々に回転する
        this.transform.rotation = rotX;                                         //取得した方向を向く
        }
        if(Mathf.Abs(z)>0.1f)    
        {
        Quaternion rotZ = Quaternion.AngleAxis(z,Vector3.up);
        rotZ = Quaternion.Slerp(rb.transform.rotation, rotZ, 0.2f);
        this.transform.rotation = rotZ;
        }
    }

    void JumpControll()
    {
        if(jumpFlag)
        {
           if(Input.GetKeyDown(KeyCode.Space))
            {
                    Debug.Log("jump");
                    Vector3 force=new Vector3(0.0f,jumpPower,0.0f);             //ジャンプ力を設定
                    rb.AddForce(force,ForceMode.Impulse);                       //力を加える
                    jumpFlag=false;                                             //フラグを消す

            }
        }
    }
}
