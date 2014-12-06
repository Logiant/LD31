using UnityEngine;
using System.Collections;

public class StairScript : MonoBehaviour {

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
			Debug.Log (bottom);
			Debug.Log (top);
		} else {
			Debug.Log (top);
		}
	}
}
