using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerkari : MonoBehaviour
{
    [SerializeField] private float moveSpeed=10.0f;         //移動速度
    [SerializeField] private float jumpPower=10.0f;         //ジャンプ力

    private CharacterController _characterController;       //CharacterControllerのキャッシュ
    private Transform _transform;                           //Transformのキャッシュ
    private Vector3 _moveVelocity;                          //キャラの移動速度情報

    private void Start()
    {
        _characterController=GetComponent<CharacterController>();   //CharacterController使用宣言
        _transform=transform;
    }

    
    private void Update()
    {
        //入力による移動処理//
        _moveVelocity.x=Input.GetAxis("Horizontal")*moveSpeed;
        _moveVelocity.z=Input.GetAxis("Vertical")*moveSpeed;

        //入力方向に向く//
        _transform.LookAt(_transform.position+new Vector3(_moveVelocity.x,0,_moveVelocity.z));
    }
}
