using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealManager : MonoBehaviour
{
    [SerializeField] private GameObject healScript;               //HealScriptオブジェクト
    GameObject heals =null;
    private int x,z;
    void Start()
    {
        for(int i=0;i<3;i++)
        {
            x=Random.Range(-600,600);                               //ポジションはランダム
            z=Random.Range(-600,600);
            Vector3 healPos=new Vector3(x,this.transform.position.y,z);                      //vectorに代入
            heals= Instantiate(healScript,healPos,Quaternion.identity);    //複製
        }
    }

    void OmCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Player")                               //地面についていたら
        {
           Destroy(gameObject);
        }   
    }
}
