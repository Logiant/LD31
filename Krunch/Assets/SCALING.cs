using UnityEngine;
using System.Collections;

public class SCALING : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] objs = GameObject.FindObjectsOfType<GameObject> ();
		float dx = Screen.width - 1920f;
		Camera.main.orthographicSize = Camera.main.orthographicSize - (dx/310f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
