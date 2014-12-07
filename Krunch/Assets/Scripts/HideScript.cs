using UnityEngine;
using System.Collections;

public class HideScript : MonoBehaviour {
	bool ready; 
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
