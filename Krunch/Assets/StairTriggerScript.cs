using UnityEngine;
using System.Collections;

public class StairTriggerScript : MonoBehaviour {

	public bool top;

	bool ready;

	StairScript parent;

	void Awake() {
		parent = GetComponentInParent<StairScript> ();
	}

	void Update() {

		if (ready && Input.GetKeyDown (KeyCode.F))
			parent.UseStairs (top);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			ready = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			ready = false;
		}
	}
}
