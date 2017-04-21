using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace KoMa
{
public class Menu : MonoBehaviour {

	public Text FunnyText;

	public string[] FunnyTextSelector;

	private string ProfileScene = "PlayerProfileScene";
	private string StartScene = "SongSelectScene";
	private string JoinScene = "JoinScene";

	void Awake() {
		FunnyText.text = FunnyTextSelector [Random.Range (0, FunnyTextSelector.Length)];
	}

	public void CallProfiles() {
		SceneManager.LoadSceneAsync (ProfileScene);		
	}

	public void CallStart () {
		SceneManager.LoadSceneAsync (StartScene);		
	}

	public void CallJoin() {
		SceneManager.LoadSceneAsync (JoinScene);		
	}

	public void CallQuit() {
		Application.Quit ();
	}
}
}