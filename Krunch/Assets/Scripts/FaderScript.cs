using UnityEngine;
using System.Collections;

public class FaderScript : MonoBehaviour {

	SpriteRenderer render;
	bool fadeOut;
	bool fadeIn;
	public bool gameOver;
	float fadeSpeed = 0.01f;

	// Use this for initialization
	void Start () {
		fadeIn = true;
		render = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(fadeIn){
			render.color = new Vector4 (render.color.r, render.color.g, render.color.b, render.color.a - fadeSpeed);
			if(render.color.a <=0.01f)
				fadeIn = false;
		} else if(fadeOut){
			render.color = new Vector4 (render.color.r, render.color.g, render.color.b, render.color.a + fadeSpeed);
			if(render.color.a >=0.99f)
				fadeOut = false;
				gameOver = true;
		}
	}

	// Fade from clear screen to black
	public void FadeOut(){
		fadeOut = true;
	}
}
