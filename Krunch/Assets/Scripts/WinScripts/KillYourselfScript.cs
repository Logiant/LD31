using UnityEngine;
using System.Collections;

public class KillYourselfScript : MonoBehaviour {
	
	FaderScript fader;
	void Start(){
		fader = GameObject.Find("Fader").GetComponent<FaderScript>();
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.CompareTag (Tags.Player)){
			// reset the fader (fade to black)
			Destroy (GameObject.Find("2D Character"));
			fader.FadeOut();
		}
	}
}
