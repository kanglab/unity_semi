﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSphere : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "yuka")
		{
			Debug.Log("Red Sphere fall down!!");
		}
	}
}
