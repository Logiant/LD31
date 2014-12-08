﻿using UnityEngine;
using System.Collections;

public class TentacleScript : MonoBehaviour {

	public bool punching;
	bool hit;
	Vector3 targetLocation;
	Vector3 returnLocation;
	public float speed = 5;

	float range = -8.25f;


	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag (Tags.Player)) {
			Application.LoadLevel(0);
		}
	}
	// Update is called once per frame
	void Update () {
		Vector3 distance;
		if (punching) { // if punching
			distance = targetLocation - transform.position;
			float velocity = Mathf.Min (distance.magnitude, speed * Time.deltaTime);
			Debug.Log (distance.magnitude + " " + speed + " " +velocity);
			transform.position += (velocity * distance.normalized);
			if((targetLocation - transform.position).sqrMagnitude <= 0.1f && !hit){
				targetLocation = returnLocation;
				hit = true;
				Debug.Log ("hit");
			}else if ((targetLocation - transform.position).sqrMagnitude <=	0.1f && hit){
				punching = false;
				hit = false;
				Debug.Log ("Tentacle returned");
			}
		}
	}

	public void follow(Vector3 position) {
		if (!punching) {
			Vector3 distance = position - transform.position;
			transform.position = position;
		}
	}

	public void Punch(Vector3 target){
		if(!punching && target.x > range){
			punching = true;
			targetLocation = new Vector3 (range,target.y, 0);
			returnLocation = this.transform.position;
		}
	}
}
