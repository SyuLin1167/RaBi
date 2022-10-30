using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript :  MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;             //メインカメラ格納用
    [SerializeField] private GameObject playerCamera;           //プレイヤーカメラ格納用
    [SerializeField] private GameObject player;
    private Vector3 Distance;
    private Vector3 mCameraPosition;
    private float countTimer=0;

    void Start()
    {
        playerCamera.SetActive(false);                          //プレイヤーカメラを非アクティブにする
        Distance=playerCamera.transform.position-player.transform.position;
    }

    void Update()
    {
        playerCamera.transform.position=player.transform.position+Distance;
        countTimer+=Time.deltaTime;                  //タイムを計測
        if(countTimer>=2.0f)                             //二秒たったら
        {
            mainCamera.SetActive(false);       //メインカメラのアクティブ切り替え
            playerCamera.SetActive(true);   //プレイヤーカメラのアクティブ切り替え
        }

    }
}
