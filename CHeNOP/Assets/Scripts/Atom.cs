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
	private GameManager gmMngrScript;
	public bool usingPower;
	private bool transforming;
	private Checkpoint checkpoint;
	//[SerializeField] private float cooldown;
	//	private bool facingRight = true;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		gmMngrScript = gameManager.GetComponent<GameManager>();		
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
		
		if(gndChckScript.grounded)
			atomAnimator.SetBool("Jumping", false);
		else
			atomAnimator.SetBool("Jumping", true);

		

		if((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.J)) && !transforming){
			StartCoroutine(starTransforming());
		}
	}

	void OnTriggerEnter2D(Collider2D other){
			//Collisions
		if(other.gameObject.CompareTag("CheckPoint")){
			checkpoint = other.gameObject.GetComponent<Checkpoint>();
			if(checkpoint.active)
				gmMngrScript.respawn = other.transform.position;
		}
		else if(other.gameObject.CompareTag("Antimatter"))
			this.transform.position = gmMngrScript.respawn;
	}

	private IEnumerator power(){		
		atomAnimator.SetBool("Liquid", true);
		usingPower = true;
		yield return new WaitForSeconds(5f);
		usingPower = false;
		atomAnimator.SetBool("Liquid", false);
		atomAnimator.SetBool("Transforming", true);
		transforming = true;
		yield return new WaitForSeconds(0.3f);
		transforming = false;
		atomAnimator.SetBool("Transforming", false);
	}

	private IEnumerator starTransforming(){
		atomAnimator.SetBool("Transforming", true);
		transforming = true;
		yield return new WaitForSeconds(0.3f);
		transforming = false;
		atomAnimator.SetBool("Transforming", false);
		StartCoroutine(power());

	}
}
