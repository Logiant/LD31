using UnityEngine;
using System.Collections;

public class LootableScript : MonoBehaviour {

	LootProgressScript lootScript;
	bool ready; 
	public PlayerInventoryScript player;
	public float lootTime = 2.5f;
	public GameObject[] contained;
	float cooldown;
	bool looting;
	GameObject lootMenu;
	PlayerController character;

	void Awake() {
		lootScript = GameObject.Find ("LootBar").GetComponent<LootProgressScript>();
		lootMenu = GameObject.Find ("LootMenu");
		character = GameObject.FindWithTag (Tags.Player).GetComponent<PlayerController> ();;
	}

	void Start(){
		lootMenu.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (looting && !ready) {
			looting = false;
			lootScript.interrupt();
		}
		if (ready && Input.GetButtonUp ("Loot") && !looting) {
			looting = true;
			character.looting = true;
			cooldown = lootTime;
			lootScript.Loot (lootTime);
		}
		if (looting) {
			cooldown -= Time.deltaTime;
			if(cooldown <= 0){
				looting = false;
				// play idle animation
				// re-enable player control
				player.GiveItem(contained);
				contained = new GameObject[0];
				character.looting = false;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.CompareTag (Tags.Player)){
			ready = true;
			lootMenu.SetActive(true);
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.CompareTag (Tags.Player)){
			ready = false;
			lootMenu.SetActive(false);
		}
	}
}
