using UnityEngine;
using System.Collections;

public class Gui_scr : MonoBehaviour {
	GameObject player;
	player playerscript;
	string text;
	string text2;
	float score;
	float highscore;
	string gameover;
	string missile;
	void Start()
	{
		score = 0;
		highscore = 0;
		player = GameObject.Find("Player");
		playerscript = player.GetComponent<player> ();
		text = "Score";
		text2 ="HighScore";
		gameover = null;
		missile = null;
	}

	void Update(){
		score = playerscript.score;
		if (playerscript.gameover) {
			gameover = "Game Over! press R to restart!";
		}
		if(playerscript.missile_exploaded)
			missile = "Your bullet exploded!";
	}

	void OnGUI () {
		GUI.Label(new Rect(100,5,900,40),"<color=white><size=20>"+text+" "+score+"</size></color>");
		//GUI.Label(new Rect(1000,5,900,40),"<color=white><size=20>"+text2+"</size></color>");
		GUI.Label(new Rect(450,5,900,40),"<color=white><size=20>"+gameover+"</size></color>");
		GUI.Label(new Rect(450,40,900,40),"<color=white><size=20>"+missile+"</size></color>");
		//GUI.Label(new Rect(20,50,100,90), "<color=white><size=30>"+score.ToString()+"</size></color>");
	}
}
