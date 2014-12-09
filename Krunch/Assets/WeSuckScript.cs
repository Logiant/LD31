using UnityEngine;
using System.Collections;

public class WeSuckScript : MonoBehaviour {


	public Transform target;

	// Use this for initialization
	void Start () {
		transform.position = Camera.main.WorldToScreenPoint (target.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
