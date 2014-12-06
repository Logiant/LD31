using UnityEngine;
using System.Collections;

public class StairScript : MonoBehaviour {

	public Transform player;
	
	Transform top;
	Transform bottom;

	// Use this for initialization
	void Awake () {
		top = GameObject.Find ("HighPosition").transform;
		bottom = GameObject.Find ("LowPosition").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UseStairs(bool downward) {
		Debug.Log ("Going Up");
		if (downward) {
			player.position = bottom.position;
		} else {
			player.position = top.position;
		}
	}
}
