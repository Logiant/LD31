﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HideScript : MonoBehaviour {
	bool ready; 
	bool hiding;
	public GameObject player; // will become player controller once written
	PlayerController controller;

	GameObject hideMenu;

	// Use this for initialization
	void Awake () {
	//potentially things with player
		player = GameObject.FindWithTag (Tags.Player);
		hideMenu = GameObject.Find ("HideMenu");
		controller = player.GetComponent<PlayerController> ();
	}

	void Start(){
		hideMenu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (ready && Input.GetButtonUp ("Hide") && !hiding) { // player can hide, is not hiding and presses to hide
			hiding = true;
			Debug.Log ("Hiding");
			player.layer = 2; // layer 2 is Ignore Raycast layer
			controller.hidden = true;
			// set player state to hiding
		}
		else if (hiding && Input.GetButtonUp ("Hide")) { // player is hiding and presses to leave hide
			hiding = false;
			Debug.Log ("Stop Hiding");
			controller.hidden = false;
			// set player to not hiding
			player.layer = 0; // layer 0 is defult layer
		}
		else if (hiding && !ready){ // player is hiding and leaves hide area
			hiding = false;
			Debug.Log ("stop hiding, left area");
			controller.hidden = false;
			// set player to state not hiding
			player.layer = 0; // layer 0 is defult layer
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.CompareTag (Tags.Player)){ // if player enters hide area toggle ready to true
			ready = true;
			hideMenu.SetActive(true);
		}
	}
	
	void OnTriggerExit2D (Collider2D other){
		if (other.CompareTag (Tags.Player)){ // if player leave hide area toggle ready to false
			ready = false;
			hideMenu.SetActive(false);
		}
	}
}
