using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody _rb;                                              //リジッドボディ
    [SerializeField] private Slider _sl;                                //スライダー
    
    [SerializeField] private float playerSpeed=90.0f;                   //移動速度
    [SerializeField] private float jumpPower=200.0f;                    //ジャンプ力

    bool jumpFlag=false;                                                //ジャンプフラグ
    bool damageFlag=false;
   
    private float x,z;                                                  //座標
    [SerializeField] private float maxHp=100.0f;                        //Hp最大値
    [SerializeField] private float nowHp=100.0f;                        //現在のHp
     int damageValue;
    private float damageCounter;

    void Start()
    {
       _rb=GetComponent<Rigidbody>();                                    //リジッドボディ取得

        HpManager plyHpManager=new HpManager();

        damageValue=plyHpManager.Damage;
       _sl.maxValue=maxHp;
       _sl.value=nowHp;
       
    }


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Stage")                               //地面についていたら
        {
            Debug.Log("Stage");                                         //ログを出す
            jumpFlag=true;                                              //ジャンプフラグを立てる
        }   
        if(other.gameObject.tag=="EnemyShot")                           //攻撃が当たったら
        {
            Debug.Log("Damage");                                        //ログを出す
            damageFlag=true;                                            //ダメージフラグを立てる
        }   
    }
   
    void Update()
    {
        //関数呼び出し//
        MoveControll();
        JumpControll();
        HpControll();

    }

    void FixedUpdate()
    {
        MoveDir();
    }

    public void MoveControll()
    {
        x=Input.GetAxisRaw("Horizontal")*playerSpeed;                    //左右キーが押されたときの値をX座標に入れる    
        z=Input.GetAxisRaw("Vertical")*playerSpeed;                      //上下キーが押されたときの値をY座標に入れる
        _rb.AddForce(x,0,z);                                             //値を加える
    }

    public void MoveDir()
    {
        if(Mathf.Abs(x)>0.1f)                                            //左右キーが入力されたら
        {
        Quaternion rotX = Quaternion.AngleAxis(x,Vector3.up);            //最大何度まで回転するか設定
        rotX = Quaternion.Slerp(_rb.transform.rotation, rotX, 0.1f);     //徐々に回転する
        this.transform.rotation = rotX;                                  //取得した方向を向く
        }
        if(Mathf.Abs(z)>0.1f)                                            //上下キーも同じように処理
        {
        Quaternion rotZ = Quaternion.AngleAxis(z-90,Vector3.up);
        rotZ = Quaternion.Slerp(_rb.transform.rotation, rotZ, 0.2f);
        this.transform.rotation = rotZ;
        }
    }

    public void JumpControll()
    {
        if(jumpFlag)                                                     //ジャンプフラグがたっていたら
        { 
           if(Input.GetKeyDown(KeyCode.Space))                           //スペースキーを押すと
            {
                    Debug.Log("jump");                                   //ログを出す
                    Vector3 force=new Vector3(0.0f,jumpPower,0.0f);      //ジャンプ力を設定
                    _rb.AddForce(force,ForceMode.Impulse);               //力を加える
                    jumpFlag=false;                                      //フラグを消す

            }
        }
    }

    public void HpControll()
    {
      if(damageFlag)
       {  
            if(damageCounter<damageValue)
            {
                damageCounter+=0.1f;
                _sl.value-=0.1f;
                Debug.Log(_sl.value);
            }
            else
            {
                damageCounter=0;
                damageFlag=false;
            }
       }
    }
}
