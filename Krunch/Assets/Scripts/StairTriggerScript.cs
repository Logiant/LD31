using UnityEngine;
using System.Collections;

public class StairTriggerScript : MonoBehaviour {

	public bool top; //is this the top of a staircase?

	bool ready; //is the player in the trigger zone?

	StairScript parent;
	GameObject stairMenu;

	void Awake() {
		parent = GetComponentInParent<StairScript> (); //get the parent which moves the player
		stairMenu = GameObject.Find ("StairMenu");
	}

	void Start(){
		//stairMenu.SetActive (false);
	}

	void Update() {
		if (ready){ //if we are in the zone and press action
				if (top && Input.GetAxis ("Vertical") < -0.5)
						parent.UseStairs (top); //tell the parent we're ready!
			else if (!top && Input.GetAxis ("Vertical") > 0.5)
						parent.UseStairs (top);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			ready = true;
			//stairMenu.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			ready = false;
			//stairMenu.SetActive(false);
		}

	}
}
