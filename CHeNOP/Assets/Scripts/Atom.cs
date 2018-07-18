using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour {
	private Animator atomAnimator;
	private Rigidbody2D rb;
	[SerializeField] float speed;
	[SerializeField] float jump;
	//private GameObject groundCheck;
	[SerializeField] private GroundCheck gndChckScript;
	private GameObject gameManager;
	private GameManager gmMngrScrpit;
//	private bool facingRight = true;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		gmMngrScrpit = gameManager.GetComponent<GameManager>();		
//		groundCheck = GameObject.FindGameObjectWithTag("GroundCheck");
//		gndChckScript = groundCheck.GetComponent<GroundCheck>();
		atomAnimator = GetComponent<Animator>();
	}
	
	void Update () {
			//Movement
		rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
		if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && gndChckScript.grounded)
			rb.AddForce(jump * Vector2.up, ForceMode2D.Impulse);

			//Animations
		if(rb.velocity.x>0)
			atomAnimator.SetBool("FacingRight", true);
		else if(rb.velocity.x<0)
			atomAnimator.SetBool("FacingRight", false);
	}

	void OnTriggerEnter2D(Collider2D other){
			//Collisions
		if(other.gameObject.CompareTag("CheckPoint")){
			gmMngrScrpit.respawn = other.transform.position;
			Destroy(other.gameObject);
			}
		else if(other.gameObject.CompareTag("Antimatter"))
			this.transform.position = gmMngrScrpit.respawn;
	}
}
