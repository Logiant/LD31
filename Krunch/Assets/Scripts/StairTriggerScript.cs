using UnityEngine;
using System.Collections;

public class StairTriggerScript : MonoBehaviour {

	public bool top; //is this the top of a staircase?

	bool ready; //is the player in the trigger zone?

	StairScript parent;

	void Awake() {
		parent = GetComponentInParent<StairScript> (); //get the parent which moves the player
	}

	void Update() {
		if (ready && Input.GetKeyDown (KeyCode.F)) //if we are in the zone and press action
			parent.UseStairs (top); //tell the parent we're ready!
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			ready = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			ready = false;
		}
	}
}
