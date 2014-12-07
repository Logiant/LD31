using UnityEngine;
using System.Collections;

public class StairTriggerScript : MonoBehaviour {

	public bool top; //is this the top of a staircase?

	static bool first = true;

	bool ready; //is the player in the trigger zone?

	StairScript parent;

	void Awake() {
		parent = GetComponentInParent<StairScript> (); //get the parent which moves the player
	}

	void Update() {
		if (ready){ //if we are in the zone and press action
				if (top && Input.GetKeyDown (KeyCode.S))
						parent.UseStairs (top); //tell the parent we're ready!
			else if (!top && Input.GetKeyDown (KeyCode.W))
						parent.UseStairs (top);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			ready = true;
			if (first) { //the first time you enter
				parent.tutorial();
				first = false;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			ready = false;
		}
	}
}
