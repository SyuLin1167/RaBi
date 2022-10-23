using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]private GameObject enemyprefab;
   
    private float x,z;
    void Start()
    {
         for(int i=0;i<3;i++)
        {
        x=Random.Range(-800,800);
        z=Random.Range(-800,800);
        Vector3 emyPos=new Vector3(x,0,z);
        Instantiate(enemyprefab,emyPos,Quaternion.identity);
        }
    }

    void Update()
    {
       
    }
}
