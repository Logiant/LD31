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
	bool atStart;
	bool atEnd;
	Vector3 top;
	Vector3 bottom;
	bool downward;


	BoxCollider2D collider;

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
		inventory = GetComponent<PlayerInventoryScript> ();
		body = GetComponent<Rigidbody2D> ();
		collider = GetComponent<BoxCollider2D> ();
	}

	public void startClimbing(Vector3 bottom, Vector3 top, bool downward){
		climbing = true;
		this.downward = downward;
		this.top = top;
		this.bottom = bottom;
		body.collisionDetectionMode = CollisionDetectionMode2D.None;
		body.gravityScale = 0;
		collider.isTrigger = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float velocity = 0;
		if (looting) {
			// looting animation

		} else if (hidden) {
			// hidden animation

		} else if (climbing) {
			looting = false;
			hidden = false;
			anim.SetFloat ("Speed", 1.5f);
			float speed = this.speed * 3;
			Vector3 distance;
			if (climbing && downward) {
				if(!atStart){
					distance = top - transform.position;
					if(distance.sqrMagnitude > .1){
						float vel = Mathf.Min (distance.magnitude, speed * Time.fixedDeltaTime);
						transform.position += (vel * distance.normalized);
						transform.localScale = new Vector3(1,1,1);
					}else{
						atStart = true;
					}
				}else if (!atEnd){
					distance = bottom - transform.position;
					if(distance.sqrMagnitude > .1){
						float vel = Mathf.Min (distance.magnitude, speed * Time.fixedDeltaTime);
						transform.position += (vel * distance.normalized);
						transform.localScale = new Vector3(-1,1,1);
					}else{
						atEnd = true;
					}
				}else{
					climbing = false;
					atStart = false;
					atEnd = false;
					body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
					body.gravityScale = 3;
					collider.isTrigger = false;
				}
			}else if(climbing && !downward){;
				if(!atStart){
					distance = bottom - transform.position;
					if(distance.sqrMagnitude > .1){
						float vel = Mathf.Min (distance.magnitude, speed * Time.fixedDeltaTime);
						transform.position += (vel * distance.normalized);
						transform.localScale = new Vector3(-1,1,1);
					}else{
						atStart = true;
					}
				}else if (!atEnd){
					distance = top - transform.position;
					if(distance.sqrMagnitude > .1){
						float vel = Mathf.Min (distance.magnitude, speed * Time.fixedDeltaTime);
						transform.position += (vel * distance.normalized);
						transform.localScale = new Vector3(1,1,1);
					}else{
						atEnd = true;
					}
				}else{
					climbing = false;
					atStart = false;
					atEnd = false;
					body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
					body.gravityScale = 3;
					collider.isTrigger = false;
				}
			}
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
		if (!climbing)
			anim.SetFloat ("Speed", Mathf.Abs (velocity) / Time.deltaTime);
		anim.SetBool ("Loot", looting);
		anim.SetBool ("Hide", hidden);
	}
}
