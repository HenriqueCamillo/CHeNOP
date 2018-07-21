using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	[SerializeField] private GameObject gameManager;
	[SerializeField] private float distanceVertical;
	[SerializeField] private float distanceHorizontal;
	[SerializeField] private float speedHorizontal;
	[SerializeField] private float speedVertical;
	private Rigidbody2D rb;

	void Start () {
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if((Mathf.Abs (this.transform.position.x - gameManager.transform.position.x))>distanceHorizontal){
			if(this.transform.position.x > gameManager.transform.position.x)
				rb.velocity = new Vector2(-speedHorizontal, rb.velocity.y);
			else
				rb.velocity = new Vector2(speedHorizontal, rb.velocity.y);
		}else
			rb.velocity = new Vector2(0, rb.velocity.y);

		if((Mathf.Abs (this.transform.position.y - gameManager.transform.position.y))>distanceHorizontal){
			if(this.transform.position.y > gameManager.transform.position.y)
				rb.velocity = new Vector2(rb.velocity.x ,-speedVertical);
			else
				rb.velocity = new Vector2(rb.velocity.x ,speedVertical);
		}else
			rb.velocity = new Vector2(rb.velocity.x, 0);
	}
}