using UnityEngine;
using System.Collections;

public class Enermy_scr : MonoBehaviour {
	float Fireball_speed;
	GameObject theplayer;
	player playerscript;
	// Use this for initialization
	void Start () {
		theplayer = GameObject.Find("Player");
		playerscript = theplayer.GetComponent<player>();
		Fireball_speed = Random.value * 300;
		float temp = Random.Range (-2f*Mathf.PI, 2f*Mathf.PI);
		if(Random.value>0.5f)
			rigidbody.AddForce (Fireball_speed*Mathf.Sin(temp), 0, Fireball_speed*Mathf.Cos(temp));
		else
		rigidbody.AddForce (30*(theplayer.transform.position.x-gameObject.transform.position.x), 
		                    0, 30*(theplayer.transform.position.z-gameObject.transform.position.z));
	}

	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "GameController") {
			playerscript.score +=100;
			Destroy(gameObject);
		}
	}
}
