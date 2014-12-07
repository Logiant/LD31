using UnityEngine;
using System.Collections;

public class KillYourselfScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		if (other.CompareTag (Tags.Player))
						Application.LoadLevel (0);
	}
}
