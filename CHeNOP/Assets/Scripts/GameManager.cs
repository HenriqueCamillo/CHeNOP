using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Vector2 respawn;
	[SerializeField] private GameObject[] atoms;
	[SerializeField] private GameObject currentAtom;
	[SerializeField] private int currentAtomNumber;

	enum atom {
		Mercury = 0,
		Helium = 1,
		Lead = 2,
		Phosphorus = 3,
	};

	void Start () {
		Instantiate(atoms[(int)atom.Mercury], this.transform.position, this.transform.rotation, null);
		currentAtomNumber = (int)atom.Mercury;
		currentAtom = GameObject.FindGameObjectWithTag("Atom");
	}
	
	void Update () {
		if(currentAtom!=null)
			this.transform.position = currentAtom.transform.position;
		else	
			currentAtom = GameObject.FindGameObjectWithTag("Atom");

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
	}

	private void changeAtom(int atomNumber){
		currentAtomNumber = atomNumber;
		var	spawn = currentAtom.transform;
		Destroy(currentAtom);
		Instantiate(atoms[atomNumber], this.transform.position, this.transform.rotation, null);
		currentAtom = GameObject.FindGameObjectWithTag("Atom");
	}
}
