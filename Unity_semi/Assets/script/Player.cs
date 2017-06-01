﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject bullet;	//bullet prefab
	public Transform muzzle;	//position bullet
	public float speed = 3000f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)){
			GameObject bullets = GameObject.Instantiate(bullet)as GameObject;
			Vector3 force;
			force = this.gameObject.transform.forward * speed;
			bullets.GetComponent<Rigidbody>().AddForce(force);
			bullets.transform.position = muzzle.position;
		}

		if (Input.GetKey(KeyCode.W)){
			this.transform.position += transform.forward * 0.1f;
			muzzle.position += transform.forward * 0.1f;
			// Debug.Log("push left");
		}
		if (Input.GetKey(KeyCode.S)){
			this.transform.position -= transform.forward * 0.1f;
			muzzle.position -= transform.forward * 0.1f;
		}
		if (Input.GetKey(KeyCode.D)){
			this.transform.Rotate(0, 5, 0);
			muzzle.transform.Rotate(0, 5, 0);
		}
		if (Input.GetKey(KeyCode.A)){
			this.transform.Rotate(0, -5, 0);
			muzzle.transform.Rotate(0, -90, 0);
		}
	}
}