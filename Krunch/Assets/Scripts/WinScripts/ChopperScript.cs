﻿using UnityEngine;
using System.Collections;

public class ChopperScript : MonoBehaviour {


	public PlayerInventoryScript player;
	TentacleScript tentacle;
	bool ready;
	FaderScript fader;
	ParticleSystem system;

	void Start(){
		fader = GameObject.Find("Fader").GetComponent<FaderScript>();
		tentacle = GameObject.Find ("Tentacle").GetComponent <TentacleScript> ();
		system = this.GetComponent<ParticleSystem>();
	}

	void Update() {
		if (Input.GetButtonUp ("Loot") && ready) { //if we are ready to be used and action is pressed
			if (player.chopperKey) { //if the player has the chopper key
				Destroy(player.gameObject); //put the player in the chopper and fly
				//you win! fade the screen out
				tentacle.krushKopter();
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
