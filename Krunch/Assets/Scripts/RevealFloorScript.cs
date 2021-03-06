﻿using UnityEngine;
using System.Collections;

public class RevealFloorScript : MonoBehaviour {

	SpriteRenderer render;
	bool visible;

	void Awake() {
		render = GetComponent<SpriteRenderer> ();
		render.enabled = true;
	}

	void Update() {
		if (visible) {
			render.color = new Vector4 (render.color.r, render.color.g, render.color.b, render.color.a - 0.01f);
			if (render.color.a <= 0.1)
				Destroy(this.gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(Tags.Player))
			visible = true;
	}
}
