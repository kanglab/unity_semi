using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    static public GameObject gameOver;

	// Use this for initialization
	void Start () {
        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);
	}

    public static void setGameOver()
    {
        gameOver.SetActive(true);
    }
    
}
