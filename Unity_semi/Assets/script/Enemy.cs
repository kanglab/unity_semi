using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Transform player;    //プレイヤーを代入
    public float speed = 0.1f; //移動速度
    public int enemyLife = 3;
    private GameObject refObj;      //EnemyObjectのインスタンス生成用変数
    
    
    

    

	// Use this for initialization
	void Start () {
        
		player = GameObject.FindGameObjectWithTag("Player").transform;
        refObj = GameObject.Find("EnemyObject");
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = player.position;    //プレイヤーの位置
        Vector3 direction = playerPos - transform.position; //方向
        direction = direction.normalized;   //単位化（距離要素を取り除く）
        transform.position = transform.position + (direction * speed * Time.deltaTime);
        transform.LookAt(player);   //プレイヤーの方を向く

        
	}


    

	void OnTriggerEnter(Collider col) {
        
		
        if (col.tag == "Player")
        {
            Debug.Log("GameOver");
            GameOver.setGameOver();
        }
        if (col.tag == "bullet")
        {
            // Debug.Log(enemyLife);
            //Destroy(this.gameObject);
            --enemyLife;
            if (enemyLife == 0){
                EnemyObject enemy_object = refObj.GetComponent<EnemyObject>();
                enemy_object.countEnemyKill();
                enemy_object.destrySound();
                enemy_object.explotionEffect(this.gameObject.transform);
                Destroy(this.gameObject);
            }
        }

	}

    

}
