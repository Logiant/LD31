using UnityEngine;
using System.Collections;

public class MonsterScript : MonoBehaviour {
	
	public float speed = 1;	
	public Transform[] floorPositions;
	public float stalkTime = 5f; //time the monster waits if you disappear

	public TentacleScript tentacle;

	float cooldown;

	Vector3 desiredPosition;
	Transform eyePos;
	float lastPlayerHeight;


	void Awake() {
		tentacle = GameObject.Find ("Tentacle").GetComponent<TentacleScript> ();
		desiredPosition = transform.position;
		eyePos = transform.FindChild ("Eyesight");
	}
	
	// Update is called once per frame
	void Update () {
		//raycast for player!
		RaycastHit2D hit;
		hit = Physics2D.Raycast (new Vector2(eyePos.position.x, eyePos.position.y), new Vector2 (-1, 0), Mathf.Infinity);
		if (hit.collider != null && hit.collider.CompareTag(Tags.Player)) {
			lastPlayerHeight = hit.transform.position.y;
			cooldown = stalkTime;
		}
		//if we are at our destination, chose a new course of action
		Vector3 distance = desiredPosition - transform.position;
		if (distance.sqrMagnitude <= 0.1) { //if we are at our target
			PickTarget();
			distance = desiredPosition - transform.position;
		}
		float vel = Mathf.Min (distance.magnitude * Time.deltaTime, speed * Time.deltaTime);
		transform.position += (vel * distance.normalized);

		//check if we are staring at the player
		if (Mathf.Abs (transform.position.y - lastPlayerHeight) < 0.1f && hit.collider != null && hit.collider.CompareTag(Tags.Player)) { 
			//PUNCH!
			tentacle.Punch(hit.transform.position.y);
		}
		tentacle.follow (new Vector3(eyePos.position.x + 8, eyePos.position.y));
	}

	void PickTarget() {
		//if we know where the player is, move to them
		if (lastPlayerHeight != 0) {
			MoveToPlayer ();
			if (Mathf.Abs (transform.position.y - lastPlayerHeight) < 0.1f) { 
				//if we are where the player last was and don't see them, wait a few seconds
				cooldown -= Time.deltaTime;
				if (cooldown <= 0) { //forget where the player was
					lastPlayerHeight = 0;
				}
			}
		}
		//randomly move between floors
		else if (floorPositions.Length > 0)
			RandomMovement ();
	}

	void RandomMovement() {
		int i = Random.Range (0, floorPositions.Length); //dont go to the bottom floor
		desiredPosition = new Vector3 (transform.position.x, floorPositions[i].position.y, transform.position.z);
	}

	void MoveToPlayer() { //placeholder method
		desiredPosition = new Vector3(transform.position.x, lastPlayerHeight, transform.position.z);
	}
}
