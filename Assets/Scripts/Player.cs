using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //---コンポーネント---//
    private Rigidbody _rb;               //リジッドボディ
    private Quaternion _rot;
    private Quaternion _rotMove;

    //---オブジェクト格納---//

    //---変数---//
    private Vector3 _input;                    //入力方向
    private float _plySpeed=1.0f;          //移動速度

    /* コンストラクタ― */
    void Start()
    {
        _rb=GetComponent<Rigidbody>();   //コンポーネント取得
    }

    /* 更新処理 */
    void Update()
    {
        MoveControll();
        MoveDir();
    }

    void MoveControll()
    {
        _input=new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        _rb.AddForce(_input*_plySpeed);
    }

    void MoveDir()
    {
         if(Mathf.Abs(_input.x)>0.1f)                                            //左右キーが入力されたら
        {
        Quaternion rotX = Quaternion.AngleAxis(_input.x*90,Vector3.up);            //最大何度まで回転するか設定
        rotX = Quaternion.Slerp(_rb.transform.rotation, rotX, 1*Time.deltaTime);     //徐々に回転する
        this.transform.rotation = rotX;                                  //取得した方向を向く
        }
        if(Mathf.Abs(_input.z)>0.1f)                                            //上下キーも同じように処理
        {
        Quaternion rotZ = Quaternion.AngleAxis(_input.z*90-90,Vector3.up);
        rotZ = Quaternion.Slerp(_rb.transform.rotation, rotZ, 1*Time.deltaTime);
        this.transform.rotation = rotZ;
        }
    }
}
