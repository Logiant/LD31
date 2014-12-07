using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInventoryScript : MonoBehaviour {

	public bool chopperKey;
	public bool roofKey;
	public bool penthouseKey;
	public bool wallet;

	public Transform speechBubble;
	public Text speech;

	string text;

	public float speechDelay = 0.5f;
	float delay;

	public float airTime = 1;
	float currentTime;

	void Update() {
		//display speech bubble
		if (currentTime > 0) {
			if (delay > 0) {
				delay -= Time.deltaTime;
			} else {
				Debug.Log (text);
				speech.text = text;
				currentTime -= Time.deltaTime;
			}
		} else {
			speech.text = "";
		}
	}

	public void Say(string msg) {
		text = msg;
		delay = speechDelay;
		currentTime = airTime;
		speechBubble.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z));
	}

	public void GiveItem(GameObject[] items) {
		string msg = " ";
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
				} else if (items[i].CompareTag (Tags.Wallet)) {
					wallet = true;
				}
				msg = ("Got " + items[i].tag);
			}
		} else { //no items found
			//create speech bubble, eg "Nothing here..."
			msg = ("Nothing...");
		}
		Debug.Log (msg);
		Say (msg);
	}
}
