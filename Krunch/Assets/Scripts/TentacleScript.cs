using UnityEngine;
using System.Collections;

public class TentacleScript : MonoBehaviour {

	public PlayerInventoryScript player;
	GameObject chopper;
	public bool punching;
	public FaderScript fader;
	bool hit;
	Vector3 targetLocation;
	Vector3 returnLocation;
	public float speed = 5;
	bool kopter;

	float range = -8.25f;


	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag (Tags.Player)) {
			Destroy (GameObject.Find("2D Character"));
			fader.FadeOut();
		}
	}
	// Update is called once per frame
	void Update () {
		Vector3 distance;
		if (punching) { // if punching
			distance = targetLocation - transform.position;
			float velocity = Mathf.Min (distance.magnitude, speed * Time.deltaTime);
			transform.position += (velocity * distance.normalized);
			if((targetLocation - transform.position).sqrMagnitude <= 0.1f && !hit){
				targetLocation = returnLocation;
				hit = true;
				Debug.Log ("hit");
				if(kopter){
					chopper.particleSystem.Simulate(1f, true, true);
					fader.FadeOut();
					Debug.Log("tentacle krush");
				}
			}else if ((targetLocation - transform.position).sqrMagnitude <=	0.1f && hit){
				punching = false;
				hit = false;
				Debug.Log ("Tentacle returned");
			}
		}
		if(!punching && kopter){
			targetLocation = chopper.transform.position;
			this.transform.position = new Vector3(35,2,0);
			this.transform.rotation = Quaternion.Euler (0,0,-30);
			punching = true;
		}
	}

	public void follow(Vector3 position) {
		if (!punching) {
			Vector3 distance = position - transform.position;
			transform.position = position;
		}
	}

	public void Punch(Vector3 target){
		if(!punching && target.x > range){
			punching = true;
			targetLocation = new Vector3 (range,target.y, 0);
			returnLocation = this.transform.position;
		}
	}

	public void krushKopter(){
		chopper = GameObject.Find ("Helicopter");
		kopter = true;
	}
}
