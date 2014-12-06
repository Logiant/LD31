using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LootProgressScript : MonoBehaviour {
	Transform rotForeground;
	GameObject background1;
	GameObject background2;

	public Transform player;
	public Text text;

	float maxTime;
	float time;

	void Awake() {
		rotForeground = GameObject.Find ("Foreground 1").transform;
		background1 = GameObject.Find ("Background 1");
		background2 = GameObject.Find ("Background 2");
	}

	void Update() {
		if (time > 0) {
			time -= Time.deltaTime;
			float angle = (time / maxTime) * 360;
			rotForeground.transform.rotation = Quaternion.Euler (0, 0, angle);
			if (time <= maxTime/2) {
				background1.SetActive(false);
				background2.SetActive(false);
			}
			text.text = (Mathf.RoundToInt(time)+1) + "";
		} else {
			this.gameObject.SetActive (false);
		}
	}
	public void Loot(float dt) {
		transform.position = Camera.main.WorldToScreenPoint(new Vector3(player.position.x, player.position.y + 2, player.position.z));
		maxTime = dt;
		time = maxTime;
		this.gameObject.SetActive (true);
		background1.SetActive (true);
		background2.SetActive (true);
	}
}
