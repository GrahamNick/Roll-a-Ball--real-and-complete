using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

	Animator animator;
	bool doorOpen;
	public PlayerController playcont;
	void Start() {
		doorOpen = false;
		animator = GetComponent<Animator> ();
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player" && playcont.count >= 6) {
			doorOpen = true;
			DoorTrigs ("Open");
		}
	}
	void OnTriggerExit(Collider col) {
		if (doorOpen) {
			doorOpen = false;
			DoorTrigs ("Close");
		}
	}
	void DoorTrigs(string direction){
		animator.SetTrigger(direction);
	}
}
