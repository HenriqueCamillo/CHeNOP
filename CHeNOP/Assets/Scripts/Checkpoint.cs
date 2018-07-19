using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	public bool active = true;
	[SerializeField] Animator checkpointAnimator;

	void Start(){
		checkpointAnimator.SetBool("Active", true);
	}

	private void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Atom")){
			active = false;
			checkpointAnimator.SetBool("Active", false);
		}
	}
}