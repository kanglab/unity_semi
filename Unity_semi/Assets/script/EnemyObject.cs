using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour {

	public Transform player;    //プレイヤーを代入
	public GameObject explotionObj;
	private bool levelUpFlg;
	private int killCount;
	//オーディオ関係
	public AudioClip explotion;
    private AudioSource audioSource;


	private enum Level{
        level1,
        level2,
        level3
    }
    private Level level;

	// Use this for initialization
	void Start () {
		levelUpFlg = false;
		killCount = 0;
		level = Level.level1;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (levelUpFlg){
            switch (level){
                case Level.level1:
                    level = Level.level2;
                    changeMode();
                    break;
                case Level.level2:
                    level = Level.level3;
                    changeMode();
                    break;
                 case Level.level3:

                    break;
            }
            
            StartCoroutine("destrySound");
            // Destroy(this.gameObject);
        }
	}


    public void destrySound()
    {
		audioSource.clip = explotion;
        audioSource.Play ();
    }

	public void countEnemyKill(){
		killCount++;
		levelChecker();
        // Debug.Log(killCount);

	}

	public void explotionEffect(Transform obj){
		Instantiate(explotionObj, obj.position, Quaternion.identity);
	}
	private void levelChecker(){
		switch (level){
			case Level.level1:
				if (killCount == 1) levelUpFlg = true;
				break;
			case Level.level2:
				if (killCount == 2) levelUpFlg = true;
				break;
				case Level.level3:
				if (killCount == 6) levelUpFlg = true;
				break;
		}
	}

	private void changeMode(){
        int i;
        
        GameObject enemy = (GameObject)Resources.Load("prefab/Enemy");
        switch (level){
            case Level.level2:
                for(i = 0; i <= 1; ++i)
                {
                    //オブジェクトの座標
		            float x = Random.Range(-10.0f, 10.0f);
		            float z = Random.Range(-10.0f, 10.0f);
                    Instantiate(enemy, new Vector3(player.transform.position.x + x,0,player.transform.position.z + z), Quaternion.identity);

                }
                break;
            case Level.level3:
                for(i = 0; i <= 5; ++i)
                {
                    //オブジェクトの座標
		            float x = Random.Range(-10.0f, 10.0f);
		            float z = Random.Range(-10.0f, 10.0f);
                    Instantiate(enemy, new Vector3(player.transform.position.x + x,0,player.transform.position.z + z), Quaternion.identity);
                }
                break;
			
        }
		killCount = 0;
		levelUpFlg = false;
    }
}
