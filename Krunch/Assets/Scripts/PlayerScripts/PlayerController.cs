using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Animator anim;

	float speed = 5;

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float velocity = Input.GetAxis ("Horizontal") * speed;
		transform.position = new Vector2(transform.position.x + velocity * Time.deltaTime, transform.position.y);
		anim.SetFloat ("Speed", Mathf.Abs (velocity)/10);
		if (speed < 0) {
			Vector3 rot = transform.rotation.eulerAngles;
			transform.rotation = Quaternion.Euler(rot.x, rot.y+180, rot.z);
		}
	}
}
