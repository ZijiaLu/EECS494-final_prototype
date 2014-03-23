using UnityEngine;
using System.Collections;

public class menu_scr : MonoBehaviour {
	string text1;
	string text2;
	string text3;
	string text4;
	void Start(){
		text1 = "Welcome to Crazy Bullets!";
		text2 = "Bssic Control: ← → ↑ ↓ to move Z to fire X,C to change fire angle R to restart and P to pause";
		text3 = "Use your bullet to kill the blue enemies! Both the enemy and your own bullet can kill you!";
		text4 = "If the bullet lives for five seconds, it will explode and the game wil be over!";
	}
	void OnGUI() {
		GUI.Label(new Rect(100,200,900,40),"<color=white><size=20>"+text1+"</size></color>");
		GUI.Label(new Rect(100,230,900,40),"<color=white><size=20>"+text2+"</size></color>");
		GUI.Label(new Rect(100,260,900,40),"<color=white><size=20>"+text3+"</size></color>");
		GUI.Label(new Rect(100,290,900,40),"<color=white><size=20>"+text4+"</size></color>");

		if (GUI.Button (new Rect (400, 400, 100, 40), "Start")) {
			Application.LoadLevel ("_scene0");
		}
	}
}


