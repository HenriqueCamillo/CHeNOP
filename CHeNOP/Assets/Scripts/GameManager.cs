using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Vector2 respawn;
	private var spawn;
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
		Instantiate(atoms[(int)atom.Mercury], this.transform);
		currentAtomNumber = (int)atom.Mercury;
		currentAtom = GameObject.FindGameObjectWithTag("Atom");
	}
	
	void Update () {
		if(currentAtom == null)
			currentAtom = GameObject.FindGameObjectWithTag("Atom");

		if(Input.GetKeyDown(KeyCode.Alpha1) && currentAtomNumber!=(int)atom.Mercury){
			currentAtomNumber = (int)atom.Mercury;
			spawn = currentAtom.transform;
			Destroy(currentAtom);
			Instantiate(atoms[(int)atom.Mercury], spawn);
			currentAtom = GameObject.FindGameObjectWithTag("Atom");
		}
		if(Input.GetKeyDown(KeyCode.Alpha2) && currentAtomNumber!=(int)atom.Helium){
			currentAtomNumber = (int)atom.Helium;
			spawn = currentAtom.transform;
			Destroy(currentAtom);
			Instantiate(atoms[(int)atom.Helium], spawn);
			currentAtom = GameObject.FindGameObjectWithTag("Atom");
		}
		if(Input.GetKeyDown(KeyCode.Alpha3) && currentAtomNumber!=(int)atom.Lead){
			currentAtomNumber = (int)atom.Lead;
			spawn = currentAtom.transform;
			Destroy(currentAtom);
			Instantiate(atoms[(int)atom.Lead], spawn);
			currentAtom = GameObject.FindGameObjectWithTag("Atom");
		}
		if(Input.GetKeyDown(KeyCode.Alpha4) && currentAtomNumber!=(int)atom.Phosphorus){
			currentAtomNumber = (int)atom.Phosphorus;
			spawn = currentAtom.transform;
			Destroy(currentAtom);
			Instantiate(atoms[(int)atom.Phosphorus], spawn);
			currentAtom = GameObject.FindGameObjectWithTag("Atom");
		}
	}
}
