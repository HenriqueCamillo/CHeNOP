using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour {
	private Rigidbody2D rb;
	[SerializeField] float speed;
	[SerializeField] float jump;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
			//Movement
		rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
		if(Input.GetKeyDown(KeyCode.W))
			rb.AddForce(jump * Vector2.up, ForceMode2D.Impulse);
	}
}
