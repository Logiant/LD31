using UnityEngine;
using System.Collections;

public class TentacleScript : MonoBehaviour {

	bool punching;
	bool hit;
	Vector3 targetLocation;
	Vector3 returnLocation;
	public float speed = 5;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 distance;
		if (punching == true) { // if punching
			distance = targetLocation - transform.position;
			float velocity = Mathf.Min (distance.magnitude * Time.deltaTime, speed * Time.deltaTime);
			transform.position += (velocity * distance.normalized);
			if((targetLocation - transform.position).sqrMagnitude <= 0.1 && !hit){
				targetLocation = returnLocation;
				hit = true;
				Debug.Log ("hit");
			}else if ((targetLocation - transform.position).sqrMagnitude <=	0.1f && hit){
				punching = false;
				Debug.Log ("Tentacle returned");
			}
		}
	}

	public void Punch(float height){
		if(!punching){
			Debug.Log ("PUNCH");
			punching = true;
			targetLocation = new Vector3 (0,height, 0);
			returnLocation = this.transform.position;
		}
	}
}
