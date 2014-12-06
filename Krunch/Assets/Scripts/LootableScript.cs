using UnityEngine;
using System.Collections;

public class LootableScript : MonoBehaviour {

	public float lootTime = 2.5f; //time to loot this object
	public GameObject[] contained;	//contained objects

	public PlayerInventoryScript player; //the player's inventory

	float cooldown; //time left looting

	bool ready; //can this container be looted?
	bool looting; //are we currently looting?
	

	// Update is called once per frame
	void Update () {
		looting = looting && ready; //cancel looting if the player leaves the loot zone
		if (ready && Input.GetKeyUp (KeyCode.F) && !looting) { //if the player presses action, begin looting
			looting = true;
			cooldown = lootTime;
			//pause player
			//start loop animation
		}
		//loot progress
		if (looting) {
			cooldown -= Time.deltaTime;
			if (cooldown <= 0) { //loot success, drop all held items into player inventory
				looting = false;
				//play idle player animation
				//reenable player conrol
				player.GiveItem (contained);
				contained = new GameObject[0];
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player"))
			ready = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag ("Player"))
			ready = false;
	}
}
