using UnityEngine;
using System.Collections;

public class KillYourselfScript : MonoBehaviour {
	FaderScript fader;
	void Start(){
		fader = GameObject.Find("Fader").GetComponent<FaderScript>();
	}
	void Update(){
		if(fader.gameOver)
			Application.LoadLevel (0);
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.CompareTag (Tags.Player))
			// reset the fader (fade to black)
			fader.FadeOut();
	}
}
