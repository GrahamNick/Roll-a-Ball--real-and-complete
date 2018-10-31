using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
	public float speed;
	public Text CountText;
	public Text winText;
	public float distanceToGround = 0.5f;
	private Rigidbody rb;
	private int count;


	void Start() {
		setCountText ();
		count = 0;
		rb = GetComponent<Rigidbody> ();
		winText.text = "";
	}
	void FixedUpdate (){
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		if(Input.GetKey(KeyCode.Space) && isGrounded()){
			rb.AddForce (0, 500f, 0);
		}
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count += 1;
			setCountText ();
		}
	}


	void setCountText () {
		CountText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!!";
		}
	}
	bool isGrounded() {
		return Physics.Raycast (transform.position, Vector3.down, distanceToGround);
	}
}