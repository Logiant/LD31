﻿using UnityEngine;
using System.Collections;

public class ChopperScript : MonoBehaviour {


	public PlayerInventoryScript player;
	bool ready;
	FaderScript fader;

	void Start(){
		fader = GameObject.Find("Fader").GetComponent<FaderScript>();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.F) && ready) { //if we are ready to be used and action is pressed
			if (player.chopperKey) { //if the player has the chopper key
				Destroy(player.gameObject); //put the player in the chopper and fly
				//you win! fade the screen out
				fader.FadeOut();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag (Tags.Player))
			ready = true;
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag (Tags.Player))
			ready = false;
	}
}
