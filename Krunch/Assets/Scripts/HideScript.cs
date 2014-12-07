using UnityEngine;
using System.Collections;

public class HideScript : MonoBehaviour {
	bool ready; 
	bool hiding;
	public GameObject player; // will become player controller once written
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.CompareTag (Tags.Player))
			ready = true;
	}
	
	void OnTriggerExit2D (Collider2D other){
		if (other.CompareTag (Tags.Player))
			ready = false;
	}
}
