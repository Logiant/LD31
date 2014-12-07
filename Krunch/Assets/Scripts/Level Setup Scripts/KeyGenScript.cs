using UnityEngine;
using System.Collections;

public class KeyGenScript : MonoBehaviour {

	FloorScript[] floors; // floor scripts attached to floors in the building
	public GameObject chopperKey; // key to the chopper
	public GameObject penthouseKey; // key to the penthouse
	public GameObject roofKey; // hey to the roof
	public GameObject wallet; // player's wallet


	// Use this for initialization
	/*
	 * Decides what floor to put what items on.  1 item per floor maximum, penhouse key cannot be in the penthouse.
	 * Adds item to floors using the AddLoot method in the FloorScript.
	 */
	void Start () {
		floors = this.GetComponentsInChildren<FloorScript> ();
		int randPent = Random.Range (2, 5); // floor for penhouse key
		int chopper = 5; // floor for chopper key (always 5)

		int randRoof = Random.Range (2, 5); // floor for roof key
		while (randRoof == randPent) {
			randRoof = Random.Range (2, 5);
		}

		for (int i = 0; i < floors.Length; i++) {
			// add items to floors
			if(floors[i].gameObject.name.Equals ("Floor_01")){
				floors[i].AddLoot((GameObject) Instantiate(wallet));
			}else if(floors[i].gameObject.name.Equals ("Floor_0"+randPent)){
				floors[i].AddLoot((GameObject) Instantiate(penthouseKey));
			}else if(floors[i].gameObject.name.Equals ("Floor_0"+chopper)){
				floors[i].AddLoot((GameObject) Instantiate(chopperKey));
			}else if(floors[i].gameObject.name.Equals ("Floor_0"+randRoof)){
				floors[i].AddLoot((GameObject) Instantiate(roofKey));
			}
		}
	}
}
