using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour {
	private Rigidbody2D rb;
	[SerializeField] float speed;
	[SerializeField] float jump;
	private GameObject groundCheck;
	private GroundCheck gndChckScript;

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
}
