using UnityEngine;
using System.Collections;

public class LootProgressScript : MonoBehaviour {
	Transform rotForeground;
	GameObject background1;
	GameObject background2;

	void Awake() {
		rotForeground = this.transform.Find ("Foreground 1");
		background1 = GameObject.Find ("Background 1");
		background2 = GameObject.Find ("Background 2");
	}

}
