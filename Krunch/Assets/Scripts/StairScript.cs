using UnityEngine;
using System.Collections;

public class StairScript : MonoBehaviour {

	public Transform player;
	
	Transform top; //top region of the stiars
	Transform bottom; //bottom region of the stairs
	PlayerController controller;

	// Use this for initialization
	void Awake () {
		top = transform.Find ("HighPosition").transform; //this is a child game object
		bottom = transform.Find ("LowPosition").transform; //this is a child game object
		controller = GameObject.FindWithTag (Tags.Player).GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if we are in transit, move the player. If we just finished, reenable the player
	}

	public void UseStairs(bool downward) { //called from child
		if(!controller.climbing && !controller.hidden){
			controller.startClimbing (bottom.position, top.position, downward);
			Debug.Log (this.name);
		}
	}
}
