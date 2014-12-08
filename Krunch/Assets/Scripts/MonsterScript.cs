using UnityEngine;
using System.Collections;

public class MonsterScript : MonoBehaviour {
	
	public float speed = 1;	
	public Transform[] floorPositions;
	public float stalkTime = 5f; //time the monster waits if you disappear
	public float waitMin = .5f; // min time to wait after seeing player
	public float waitMax = 1.5f; // min time to wait after seeing player
	public float timeSinceWait = 0;

	float waitTime; // generated time to wait after seeing player

	bool seen;
	bool hasTarget;

	public TentacleScript tentacle;

	float cooldown;

	Vector3 desiredPosition;
	Transform eyePos;
	float lastPlayerHeight;


	void Awake() {
		tentacle = GameObject.Find ("Tentacle").GetComponent<TentacleScript> ();
		desiredPosition = transform.position;
		eyePos = transform.FindChild ("Eyesight");
		cooldown = stalkTime;
	}
	
	// Update is called once per frame
	void Update () {
		//raycast for player!
		Vector3 distance;
		RaycastHit2D hit;
		// check for hit
		hit = Physics2D.Raycast (new Vector2(eyePos.position.x, eyePos.position.y), new Vector2 (-1, 0), Mathf.Infinity);
		if(!seen){ // if there hasn't been a hit keep looking
			if (hit.collider != null && hit.collider.CompareTag(Tags.Player)) {
				seen = true; // if hit reset wait time
				lastPlayerHeight = hit.transform.position.y;
				timeSinceWait = 0;
				cooldown = 0;
			}else if(!hasTarget){ // if no hit and no target, find new target and start moving
				PickTarget();
				distance = desiredPosition - transform.position;
				float vel = Mathf.Min (distance.magnitude * Time.deltaTime, speed);
				transform.position += (vel * distance.normalized);
				tentacle.follow (new Vector3(eyePos.position.x + 15, eyePos.position.y));
				hasTarget = true;
			}else{ // if not hit and has target
				distance = desiredPosition - transform.position; // get distance
				if(!(distance.sqrMagnitude <= 0.1)){ // if not at target, keep moving
					float vel = Mathf.Min (distance.magnitude * Time.deltaTime, speed * Time.deltaTime);
					transform.position += (vel * distance.normalized);
					tentacle.follow (new Vector3(eyePos.position.x + 15, eyePos.position.y));
				}else{ // else start cooldown and set has target to false
					hasTarget = false;
					cooldown = stalkTime;
				}
			}
		}else{ // if second hit
			timeSinceWait += Time.deltaTime; // inc wait time
			cooldown += Time.deltaTime;
			// if enough time has passed and target is still there punch it
			if(timeSinceWait >= waitTime && hit.collider != null && hit.collider.CompareTag(Tags.Player)){
				tentacle.Punch(hit.transform.position);
			} else if (timeSinceWait >= waitTime && cooldown >= stalkTime && !tentacle.punching){
				seen = false;
				hasTarget = false;
			}
		}
	}

	// pick a target to go to
	void PickTarget() {
		waitTime = Random.Range(waitMin,waitMax);
		int i = Random.Range (0, floorPositions.Length); //dont go to the bottom floor
		desiredPosition = new Vector3 (transform.position.x, floorPositions[i].position.y, transform.position.z);
	}
}
