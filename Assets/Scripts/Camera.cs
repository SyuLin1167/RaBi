using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //---オブジェクト格納---//
    [SerializeField] private GameObject mainCamera;     //メインカメラオブジェクト
    [SerializeField] private GameObject plyCamera;      //プレイヤーカメラオブジェクト
    [SerializeField] private GameObject Player;         //プレイヤーオブジェクト

    //---ベクトル変数---//
    private Vector3 _plyDistance;                       //プレイヤーとの距離

    //---変数---//
    private float _Timer=0;                             //タイマー

//---コンストラクター---//
    void Start()
    {
        plyCamera.SetActive(false);                     //プレイヤーカメラは非アクティブ化
        _plyDistance=plyCamera.transform.position-Player.transform.position;    //プレイヤーとカメラの距離を求める
    }
    
    
    void Update()
    {
        plyCamera.transform.position=Player.transform.position+_plyDistance;    //プレイヤーと一定の距離にカメラを設置
        _Timer+=Time.deltaTime;                         //タイマー計測
        if(_Timer>=2.0f)                                //二秒たったら
        {
            mainCamera.SetActive(false);                //メインカメラは非アクティブ化
            plyCamera.SetActive(true);                  //プレイヤーカメラはアクティブ化
        }
    }
}
