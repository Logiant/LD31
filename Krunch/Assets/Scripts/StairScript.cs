using UnityEngine;
using System.Collections;

public class StairScript : MonoBehaviour {

	public Transform player;
	
	Transform top; //top region of the stiars
	Transform bottom; //bottom region of the stairs

	// Use this for initialization
	void Awake () {
		top = transform.Find ("HighPosition").transform; //this is a child game object
		bottom = transform.Find ("LowPosition").transform; //this is a child game object
	}
	
	// Update is called once per frame
	void Update () {
		//if we are in transit, move the player. If we just finished, reenable the player
	}

	public void UseStairs(bool downward) { //called from child
		if (downward) {
			player.position = new Vector3(bottom.position.x, bottom.position.y + 0.5f); //set bool descending = true;
		} else {
			player.position = new Vector3(top.position.x, top.position.y + 0.5f); //set bool ascending = true;
		}
	}
}
