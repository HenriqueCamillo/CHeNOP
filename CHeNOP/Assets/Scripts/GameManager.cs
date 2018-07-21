using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public Vector2 respawn;
	[SerializeField] private GameObject[] atoms;
	[SerializeField] private GameObject currentAtom;
	[SerializeField] private int currentAtomNumber;
	[SerializeField] private Atom currentAtomScript;
	[SerializeField] private bool darkness;
	[SerializeField] private SpriteRenderer dark;
	private Collider2D mercuryCollider; 
	private Rigidbody2D heliumRb;

	private enum atom {
		Mercury = 0,
		Helium = 1,
		Lead = 2,
		Phosphorus = 3,
	};

	private void Start () {
		Instantiate(atoms[(int)atom.Mercury], this.transform.position, this.transform.rotation, null);
		currentAtomNumber = (int)atom.Mercury;
		currentAtom = GameObject.FindGameObjectWithTag("Atom");
		currentAtomScript = currentAtom.GetComponent<Atom>();
		mercuryCollider = currentAtom.GetComponent<Collider2D>(); 
	}
	
	private void Update () {
		if(currentAtom!=null)
			this.transform.position = currentAtom.transform.position;
		else{	
			currentAtom = GameObject.FindGameObjectWithTag("Atom");
			currentAtomScript = currentAtom.GetComponent<Atom>();
		}

			//Atom change
		if(Input.GetKeyDown(KeyCode.Alpha1) && currentAtomNumber!=(int)atom.Mercury){
			changeAtom((int)atom.Mercury);
		}else if(Input.GetKeyDown(KeyCode.Alpha2) && currentAtomNumber!=(int)atom.Helium){
			changeAtom((int)atom.Helium);
		}else if(Input.GetKeyDown(KeyCode.Alpha3) && currentAtomNumber!=(int)atom.Lead){
			changeAtom((int)atom.Lead);
		}else if(Input.GetKeyDown(KeyCode.Alpha4) && currentAtomNumber!=(int)atom.Phosphorus){
			changeAtom((int)atom.Phosphorus);
		}

		if(darkness && !currentAtomScript.usingPower){
			dark.enabled = true;
		}else if (!darkness || (currentAtomNumber == (int)atom.Phosphorus && currentAtomScript.usingPower)){
			dark.enabled = false;
		}

		if(currentAtomNumber == (int)atom.Mercury){
			if(currentAtomScript.usingPower){
				if(mercuryCollider == null)
					mercuryCollider = currentAtom.GetComponent<Collider2D>(); 
				mercuryCollider.enabled = false;

			}else{
				if(mercuryCollider == null)
					mercuryCollider = currentAtom.GetComponent<Collider2D>(); 
				mercuryCollider.enabled = true;
			}
		}
		else if(currentAtomNumber == (int)atom.Helium){
			if(currentAtomScript.usingPower){
				if(heliumRb==null)
					heliumRb = currentAtomScript.gameObject.GetComponent<Rigidbody2D>();
				//heliumRb.gravityScale = 0f;
				//heliumRb.AddForce(new Vector2(0,2f), ForceMode2D.Force);
				heliumRb.velocity = new Vector2(heliumRb.velocity.x, 2f);
			}else
				heliumRb.gravityScale = 0.5f;
		}	
		

	}

	private void changeAtom(int atomNumber){
		currentAtomNumber = atomNumber;
		Destroy(currentAtom);
		Instantiate(atoms[atomNumber], this.transform.position, this.transform.rotation, null);
		currentAtom = GameObject.FindGameObjectWithTag("Atom");
		currentAtomScript = currentAtom.GetComponent<Atom>();
	}
}