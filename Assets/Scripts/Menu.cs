using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace KoMa
{
	public class Menu : MonoBehaviour
	{

		public Text FunnyText;
		public Text PlayerText;
		public Image PlayerImage;

		public string[] FunnyTextSelector;

		private string ProfileScene = "PlayerProfileScene";
		private string StartScene = "SongSelectScene";
		private string JoinScene = "JoinScene";

		private void SetPlayer ()
		{
			string playerName = PlayerPrefs.GetString ("PlayerName", "Player1");
			PlayerText.text = playerName;
			PlayerImage.overrideSprite = Resources.Load ("picture") as Sprite;
		}

		void Awake ()
		{
			FunnyText.text = FunnyTextSelector [Random.Range (0, FunnyTextSelector.Length)];
			SetPlayer ();
		}

		public void CallProfiles ()
		{
			SceneManager.LoadSceneAsync (ProfileScene);		
		}

		public void CallStart ()
		{
			SceneManager.LoadSceneAsync (StartScene);		
		}

		public void CallJoin ()
		{
			SceneManager.LoadSceneAsync (JoinScene);		
		}

		public void CallQuit ()
		{
			Application.Quit ();
		}
	}
}