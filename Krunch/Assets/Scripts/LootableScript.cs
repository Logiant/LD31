﻿using UnityEngine;
using System.Collections;

public class LootableScript : MonoBehaviour {

	bool ready; 
	public PlayerInventoryScript player;
	public float lootTime = 2.5f;
	public GameObject[] contained;
	float cooldown;
	bool looting;

	// Update is called once per frame
	void Update () {
		looting = looting && ready;
		if (ready && Input.GetKeyUp (KeyCode.F) && !looting) {
			looting = true;
			cooldown = lootTime;
		}
		if (looting) {
			cooldown -= Time.deltaTime;
			if(cooldown <= 0){
				looting = false;
				// play idle animation
				// re-enable player control
				player.GiveItem(contained);
				contained = new GameObject[0];
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.CompareTag (Tags.Player))
						ready = true;
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.CompareTag (Tags.Player))
			ready = false;
	}
}
