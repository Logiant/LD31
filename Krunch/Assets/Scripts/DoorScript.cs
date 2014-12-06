using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public bool roof; //is this the roof door?
	public bool penthouse; //is this the penthouse door?
	public bool house; //is this the house door?
	public PlayerInventoryScript player; //the player's inventory

	bool ready; //object is ready to be used
	
	void Update() {
		if (Input.GetKeyDown (KeyCode.F) && ready) { //if we can be used and action was pressed
			Debug.Log ("Attempting Door");
			if (roof) { //check for a matching key
				if (player.roofKey)
					Destroy(this.gameObject); //open the door (this should be animated)
				else
					player.Say("I need the roof key...");
			} else if (penthouse) {
				if (player.penthouseKey)
					Destroy(this.gameObject); //open the door (this should be animated)
				else
					player.Say("I need the penthouse key...");
			} else if (house) {
				if (player.wallet)
					Destroy(this.gameObject); //open the door (this should be animated)
				else
					player.Say("I need my wallet...");
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