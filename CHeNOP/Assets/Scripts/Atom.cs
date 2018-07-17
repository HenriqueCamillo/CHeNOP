using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour {
	private Rigidbody2D rb;
	[SerializeField] float speed;
	[SerializeField] float jump;
	private GameObject groundCheck;
	private GroundCheck gndChckScript;
	private Vector2 respawn;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		groundCheck = GameObject.FindGameObjectWithTag("GroundCheck");
		gndChckScript = groundCheck.GetComponent<GroundCheck>();
	}
	
	void Update () {
			//Movement
		rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
		if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && gndChckScript.grounded)
			rb.AddForce(jump * Vector2.up, ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D(Collider2D other){
			//Collisions
		if(other.gameObject.CompareTag("CheckPoint")){
			respawn = other.transform.position;
			Destroy(other.gameObject);
			}
		else if(other.gameObject.CompareTag("Antimatter"))
			this.transform.position = respawn;
	}
}
