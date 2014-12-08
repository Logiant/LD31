using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Animator anim;
	PlayerInventoryScript inventory;
	public float speed = 4;
	float facing = 1;

	private Rigidbody2D body;

	public bool hidden;
	public bool looting;
	public bool climbing;

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
		inventory = GetComponent<PlayerInventoryScript> ();
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float velocity = 0;
		if (looting) {


		} else if (hidden) {


	//	} else if (climbing) {

		} else {
			velocity = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			if (velocity > 0) {
				facing = 1;
			} else if (velocity < 0) {
				facing = -1;
			}
			Vector3 localScale = new Vector3(facing, 1, 1);
			transform.localScale = localScale;
		}
		rigidbody2D.velocity = new Vector2(velocity * 100, rigidbody2D.velocity.y);
		Debug.Log (velocity);
		anim.SetFloat ("Speed", Mathf.Abs (velocity) / Time.deltaTime);
		anim.SetBool ("Loot", looting);
		anim.SetBool ("Hide", hidden);
	}
}
