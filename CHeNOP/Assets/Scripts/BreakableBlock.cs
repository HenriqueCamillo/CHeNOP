using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour {
	[SerializeField] GameObject gm;
	[SerializeField] GameManager gameManager;

	void Start () {
		gm = GameObject.FindGameObjectWithTag("GameManager");
		gameManager = gm.GetComponent<GameManager>();
	}
	
	void OnCollisionStay2D(Collision2D other){
		if(other.gameObject.GetComponent<Atom>().usingPower && gameManager.currentAtomNumber== 2){
			Destroy(this.gameObject);
		}
	}
}
