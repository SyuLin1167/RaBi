using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]private GameObject enemyprefab;                 //エネミープレハブ
    private float x,z;

    void Start()
    {
         for(int i=0;i<3;i++)                                       //for文で敵を三体出す
        {
            x=Random.Range(-800,800);                               //ポジションはランダム
            z=Random.Range(-800,800);
            Vector3 emyPos=new Vector3(x,enemyprefab.transform.position.y,z);                      //vectorに代入
            Instantiate(enemyprefab,emyPos,Quaternion.identity);    //複製
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    
}
