using UnityEngine;
using System.Collections;

public class Fire_scr : MonoBehaviour {
	private SpriteRenderer mysprenderer;
	float Fireball_speed = 300;
	GameObject theplayer;
	player playerscript;
	private float current_time;
	private int count;
	public Sprite[] mysprite = new Sprite[10];
	// Use this for initialization
	void Start () {
		current_time = Time.time;
		count = 4;
		//Sprite myFruit = Resources.Load("fruits_1", typeof(Sprite)) as Sprite;
		theplayer = GameObject.Find("Player");
		mysprenderer = GetComponentInChildren<SpriteRenderer> ();
		playerscript = theplayer.GetComponent<player>();
		//rigidbody.AddForce (200, 0, 0);
		rigidbody.AddForce (Fireball_speed*Mathf.Sin((180+playerscript.angle.y)/180*Mathf.PI), 0, Fireball_speed*Mathf.Cos((180+playerscript.angle.y)/180*Mathf.PI));
		//transform.Translate (1,0,1);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > current_time + 1 && count>=0) {
			mysprenderer.sprite = mysprite [count];
			count --;
			if(count == -1){
				Time.timeScale =0;
				playerscript.gameover = true;
				playerscript.missile_exploaded = true;
			}

			current_time = Time.time;
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "GameController"||other.gameObject.tag == "Enermy") {
			Destroy(gameObject);
		}
	}
}


