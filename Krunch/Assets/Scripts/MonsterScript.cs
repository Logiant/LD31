using UnityEngine;
using System.Collections;

public class MonsterScript : MonoBehaviour {
	
	public Transform player;
	public float speed = 5;	

	Vector3 desiredPosition;

	
	// Update is called once per frame
	void Update () {
		desiredPosition = new Vector3(transform.position.x, player.position.y - 5f, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, desiredPosition, speed*Time.deltaTime);
	}
}
