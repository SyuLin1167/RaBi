using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //---オブジェクト格納---//
    [SerializeField] private GameObject mainCamera;         //メインカメラオブジェクト
    [SerializeField] private GameObject plyCamera;          //プレイヤーカメラオブジェクト
    [SerializeField] private GameObject Player;             //プレイヤーオブジェクト

    //---ベクトル変数---//
    private Vector3 _plyDistance;                           //プレイヤーとの距離
    private Vector3 _moveSpeed = new Vector3(0.0f, 0.0f, 5.0f);   //カメラ移動速度
    private Vector3 _moveControl = new Vector3(0.0f, 0.0f, 0.1f); //移動制御

    //---変数---//
    private const float _MaxSpeed=65.0f;                    //最大速度

/* コンストラクター */
    void Start()
    {
        plyCamera.SetActive(false);                         //プレイヤーカメラは非アクティブ化
    }

/* 更新処理 */
    void Update()
    {
        MoveControll();
    }

/* 移動制御 */
    void MoveControll()
    {
         if (_moveSpeed.z<0)                                //速度が0になったら
        {
            mainCamera.SetActive(false);                    //メインカメラは非アクティブ化
            plyCamera.SetActive(true);                      //プレイヤーカメラはアクティブ化
        }
        else                                                //速度が0でなければ
        {
            _moveSpeed += _moveControl;                     //速度加速
            if(_moveSpeed.z>65.0f)                          //速度が最大になったら
            {
                _moveControl *= -1;                         //減速する
            }
            mainCamera.transform.position -= _moveSpeed * Time.deltaTime;   //カメラ移動
            
        }
    }
}
