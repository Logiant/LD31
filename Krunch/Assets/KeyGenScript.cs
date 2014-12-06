using UnityEngine;
using System.Collections;

public class KeyGenScript : MonoBehaviour {

	FloorScript[] floors;


	// Use this for initialization
	void Start () {
		floors = this.GetComponentsInChildren<FloorScript> ();
		int rand = (int) Random.Range (1f, 3f);
		floors[0]
		for (int i = 0; i < floors.Length; i++) {
			if(floors[i].gameObject.name.Equals ("Floor_01")){
				floors[i].AddLoot("Wallet");
			}else if(floors[i].gameObject.name.Equals ("Floor_01")){
				floors[i].AddLoot("Wallet");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
