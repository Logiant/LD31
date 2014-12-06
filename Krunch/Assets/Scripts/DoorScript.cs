using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public bool roof; //is this the roof door?
	public bool penthouse; //is this the penthouse door?
	public PlayerInventoryScript player; //the player's inventory

	bool ready; //object is ready to be used
	
	void Update() {
		if (Input.GetKeyDown (KeyCode.F) && ready) { //if we can be used and action was pressed
			if ((penthouse && player.penthouseKey) || (roof && player.roofKey)) //check for a matching key
				Destroy(this.gameObject); //open the door (this should be animated)
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