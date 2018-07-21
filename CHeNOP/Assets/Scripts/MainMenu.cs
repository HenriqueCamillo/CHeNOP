using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame(){
		SceneManager.LoadScene(3);
	}

	public void Credtis(){
		SceneManager.LoadScene(1);
	}

	public void BackToMenu(){
		SceneManager.LoadScene(0);
	}

	public void HowToPlay(){
		SceneManager.LoadScene(2);
	}

	public void QuitGame(){
		Application.Quit();
	}

	void Start () {
		
	}
	
	void Update () {
		
	}
}