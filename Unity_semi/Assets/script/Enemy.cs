using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Transform player;    //プレイヤーを代入
    public float speed = 0.1f; //移動速度
    public int enemyLife = 3;
    private enum Level{
        level1,
        level2,
        level3
    }
    private Level level;

    //オーディオ関係
	public AudioClip explotion;
    private AudioSource audioSource;


	// Use this for initialization
	void Start () {
        level = Level.level1;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = player.position;    //プレイヤーの位置
        Vector3 direction = playerPos - transform.position; //方向
        direction = direction.normalized;   //単位化（距離要素を取り除く）
        transform.position = transform.position + (direction * speed * Time.deltaTime);
        transform.LookAt(player);   //プレイヤーの方を向く

        if (enemyLife == 0){
            switch (level){
                case Level.level1:
                    level = Level.level2;
                    
                    changeMode();
                    break;
                case Level.level2:
                
                    break;
                 case Level.level3:

                    break;
            }
            
            StartCoroutine("destrySound");
            Destroy(this.gameObject);
        }
	}

    IEnumerator destrySound()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = explotion;
        audioSource.Play ();
        yield return null;
    }

    private void changeMode(){
        int i;
        
        GameObject enemy = (GameObject)Resources.Load("prefab/Enemy");
        switch (level){
            case Level.level2:
                for(i = 0; i <= 1; ++i)
                {
                    //オブジェクトの座標
		            float x = Random.Range(-5.0f, 5.0f);
		            float z = Random.Range(-5.0f, 5.0f);
                    Instantiate(enemy, new Vector3(x,0,z), Quaternion.identity);
                    Debug.Log(i);

                }
                break;
            case Level.level3:

                break;
        }
    }

	void OnTriggerEnter(Collider col) {
        
		
        if (col.tag == "Player")
        {
            Debug.Log("GameOver");
            GameOver.setGameOver();
        }
        if (col.tag == "bullet")
        {
            Debug.Log(enemyLife);
            //Destroy(this.gameObject);
            --enemyLife;
        }

	}

    

}
