using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {

	public GameObject bullet;	//bullet prefab
	public Transform muzzle;	//position bullet
	public float speed = 1000f;

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

		if (Input.GetKeyDown(KeyCode.A)){
			this.transform.position += transform.forward * 0.5f;
			muzzle.position += transform.forward * 0.5f;
			// Debug.Log("push left");
		}
		if (Input.GetKeyDown(KeyCode.D)){
			this.transform.position -= transform.forward * 0.5f;
			muzzle.position -= transform.forward * 0.5f;
		}
		if (Input.GetKeyDown(KeyCode.W)){
			this.transform.Rotate(0, 90, 0);
			muzzle.transform.Rotate(0, 90, 0);
		}
		if (Input.GetKeyDown(KeyCode.S)){
			this.transform.Rotate(0, -90, 0);
			muzzle.transform.Rotate(0, -90, 0);
		}
	}
}
