using UnityEngine;
using System.Collections;

public class StairScript : MonoBehaviour {

	public Transform player;
	
	Transform top;
	Transform bottom;

	// Use this for initialization
	void Awake () {
		top = transform.Find ("HighPosition").transform;
		bottom = transform.Find ("LowPosition").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UseStairs(bool downward) {
		if (downward) {
			player.position = new Vector3(bottom.position.x, bottom.position.y + 0.5f);
		} else {
			player.position = new Vector3(top.position.x, top.position.y + 0.5f);
		}
	}
}
