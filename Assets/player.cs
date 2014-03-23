using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	private float current_time;
	public float		speed = 10;
	public int 			mag_count = 1;
	public int 			enermy_count = 2;
	public bool 		attr = true;
	public bool gameover;
	public bool missile_exploaded;
	public int score;
	public int highscore = 0;
	private float weapon_cooldown;
	MeshRenderer mesh;
	public GameObject Fire;
	public GameObject enermy;
	private readonly static float gravity = 4000f; 
	public Vector3 angle;
	void Start() {
		missile_exploaded = false;
		highscore += 100;
		current_time = Time.time;
		score = 0;
		weapon_cooldown = Time.time;
		angle = new Vector3(0,10,0);
		gameover = false;
		//attraction = new GameObject[mag_count];
		//allenermy = new GameObject[enermy_count];
		//mesh = GetComponentInChildren<MeshRenderer> ();
	}
	void Update () { // Every Frame
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Vector3 vel = rigidbody.velocity;
		vel.x = h*speed;
		vel.z = v * speed;
		rigidbody.velocity = vel;

		if (Time.time > current_time + 1) {
			float temp_rand = Random.value;
			if(temp_rand<0.25)
				Instantiate(enermy,new Vector3(7.5f,-1.015302f,4.5f*Random.Range(-1f,1f)),Quaternion.identity);
			else if(temp_rand<0.5)
				Instantiate(enermy,new Vector3(7.5f*Random.Range(-1f,1f),-1.015302f,4.5f),Quaternion.identity);
			else if(temp_rand<0.75)
				Instantiate(enermy,new Vector3(-7.5f,-1.015302f,4.5f*Random.Range(-1f,1f)),Quaternion.identity);
			else
				Instantiate(enermy,new Vector3(7.5f*Random.Range(-1f,1f),-1.015302f,-4.5f),Quaternion.identity);
			current_time = Time.time;
		}

		if (Input.GetKey (KeyCode.X)) {	
			angle =transform.eulerAngles+new Vector3(0,3,0);
			transform.eulerAngles = angle;
		}

		if (Input.GetKey (KeyCode.C)) {	
			angle =transform.eulerAngles+new Vector3(0,-3,0);
			transform.eulerAngles = angle;
		}


		if (Input.GetKeyDown (KeyCode.Z)) {	
			if((Time.time-weapon_cooldown)>0.5){
				Instantiate (Fire, this.transform.position+new Vector3(1.1f*Mathf.Sin((180+angle.y)/180*Mathf.PI), 0, 1.1f*Mathf.Cos((180+angle.y)/180*Mathf.PI)), Quaternion.identity);
				weapon_cooldown = Time.time;
			}
		}


		if (Input.GetKeyDown(KeyCode.P)){
			if(Time.timeScale ==0)
				Time.timeScale =1;
			else
				Time.timeScale =0;
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel("_scene0");
			Time.timeScale =1;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "GameController" ||other.gameObject.tag == "Enermy"  ) {
			Time.timeScale =0;
			gameover = true;
		}
	}
	void OnTriggerExit2D(Collider2D other) {
	}
}
