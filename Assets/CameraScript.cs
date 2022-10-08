using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript :  MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;             //メインカメラ格納用
    [SerializeField] private GameObject playerCamera;           //プレイヤーカメラ格納用
    [SerializeField] private GameObject player;
    private Vector3 Distance;

    void Start()
    {
        playerCamera.SetActive(false);                          //プレイヤーカメラを非アクティブにする
        Distance=playerCamera.transform.position-player.transform.position;
    }

    void Update()
    {
        playerCamera.transform.position=player.transform.position+Distance;
        if(Input.GetKeyDown(KeyCode.Return))                    //エンターキーが押されたら
        {
            mainCamera.SetActive(!mainCamera.activeSelf);       //メインカメラのアクティブ切り替え
            playerCamera.SetActive(!playerCamera.activeSelf);   //プレイヤーカメラのアクティブ切り替え
        }

    }
}
