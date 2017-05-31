using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAction : MonoBehaviour {

	private GameObject src;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pushButton()
	{
		//オブジェクトの座標
		float x = Random.Range(-5.0f, 5.0f);
		float y = Random.Range(0.0f, 10.0f);
		float z = Random.Range(-5.0f, 5.0f);
		src = (GameObject)Resources.Load("prefab/BlueSphere");
		Instantiate(src, new Vector3(x,y,z), Quaternion.identity);
		//Debug.Log("Button Pushed!!");
	}
}
