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
	public int count;

	void Start() {
		
		setCountText ();
		count = 0;
		rb = GetComponent<Rigidbody> ();
		winText.text = "";
	}
	void FixedUpdate (){
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		if(Input.GetKey(KeyCode.Space) && isGrounded()){
			rb.AddForce (0, 300f, 0);
		}
		if (Input.GetKey (KeyCode.R)) {
			transform.position = new Vector3 (0, 10, 0);
			rb.AddForce (0, 9.8f, 0);
		}


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
		Win ();
	}
	bool isGrounded() {
		return Physics.Raycast (transform.position, Vector3.down, distanceToGround);
	}
	void Win(){
		if (count >= 12) {
			winText.text = "You Win!!";
			transform.Rotate (new Vector3(15,30,45) * Time.deltaTime * Time.deltaTime);
		}
	}
}
