using UnityEngine;
using System.Collections;

public class PlayerInventoryScript : MonoBehaviour {

	public bool chopperKey;
	public bool roofKey;
	public bool penthouseKey;

	public void GiveItem(GameObject[] items) {
		if (items.Length > 0) { //if we got items
			//check for which item was recieved with a for loop and CompareTag
			//create speech bubble, eg "This is the Penthouse key"
			for (int i = 0; i < items.Length; i++) {
				if (items[i].CompareTag(Tags.ChopperKey)){
					chopperKey = true;
				}else if (items[i].CompareTag(Tags.RoofKey)){
					roofKey = true;
				}else if (items[i].CompareTag(Tags.PenthouseKey)){
					penthouseKey = true;
				}
				Debug.Log("Got " + items[i].tag);
			}
		} else { //no items found
			//create speech bubble, eg "Nothing here..."
			Debug.Log ("Nothing...");
		}
	}
}
