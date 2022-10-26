using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private Slider _emysl;                                //スライダー
    private NavMeshAgent _nma;
    [SerializeField] private GameObject target;
     [SerializeField] private float maxHp=100.0f;                        //Hp最大値
    [SerializeField] private float nowHp=100.0f;                        //現在のHp
     int damageValue;
    private float damageCounter;
    bool damageFlag=false;
// 配列（同じ種類の複数のデータを収納するための箱を作る）
	private GameObject[] enemyObjects;
    void Start()
    {
       _nma=GetComponent<NavMeshAgent>();
        HpManager emyHpManager=new HpManager();
        damageValue=emyHpManager.plyDamage;
       _emysl.maxValue=maxHp;
       _emysl.value=nowHp;
    }

        void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="PlayerShot")                              //プレイヤー弾が当たったら
        {
            Debug.Log("Hit");                                         //ログを出す
           damageFlag=true;
        }   
    }

    void Update()
    {
        MoveConotroll();
        DamageControll();
       
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

    public void MoveConotroll()
    {
        _nma.destination=target.transform.position;
    } 

    public void DamageControll()
    {
        _emysl.transform.position=gameObject.transform.position+new Vector3(0,50,0);
        if(damageFlag)
        {
              if(damageCounter<damageValue)
            {
                damageCounter+=0.5f;
                _emysl.value-=0.5f;
                Debug.Log(_emysl.value);
            }
            else
            {
                damageCounter=0;
                damageFlag=false;
            }
        }
        if( _emysl.value<=0)
        {
            Destroy(gameObject);
            _emysl.gameObject.SetActive(false);
        }
    }
}
