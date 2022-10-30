using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyprefab;
    GameObject enemys=null;
    private float x,z;
    [SerializeField] private int EnemyMaxNum=12;
    // 配列（同じ種類の複数のデータを収納するための箱を作る）
	private GameObject[] enemyObjects;


    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<EnemyMaxNum;i++)
        {
            x=Random.Range(-600,600);                               //ポジションはランダム
            z=Random.Range(0,800);
            Vector3 emyPos=new Vector3(x,this.transform.position.y,z);                      //vectorに代入
            enemys= Instantiate(enemyprefab,emyPos,Quaternion.identity);    //複製
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Enemyというタグが付いているオブジェクトのデータを箱の中に入れる。
		enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

		// データの入った箱の数をコンソール画面に表示する。
		print(enemyObjects.Length);

		// データの入った箱のデータが０に等しくなった時（Enemyというタグが付いているオブジェクトが全滅したとき）
		if(enemyObjects.Length == 0)
        {

			// ゲームクリアーシーンに遷移する。
			SceneManager.LoadScene("ResultScene");
        }
    }
}


