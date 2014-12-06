using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {
	LootableScript[] lootables;
	// Use this for initialization
	void Awake () {
		lootables = this.GetComponentsInChildren<LootableScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddLoot(GameObject item){
		// pick a lootable object to add the item to
		int rand = (int)Random.Range (0f, lootables.Length - 1);
		GameObject[] obj = {item};
		// add item
		lootables [rand].contained = obj;
	}
}
