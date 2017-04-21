using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace KoMa
{
	public class PlayerProfilesMenu : MonoBehaviour
	{

		public enum Difficulty
		{
			Easy   = 1,
			Medium = 2,
			Hard   = 3
		};

		public InputField PlayerName;
		public Image PlayerImage;
		public Difficulty PlayerDifficulty;

		public Button EasyButton;
		public Button MediumButton;
		public Button HardButton;

		private ColorBlock InactiveColors;
		private ColorBlock ActiveColors;

		private IEnumerator WaitUntilActive ()
		{
			yield return new WaitWhile (() => GameObject.Find ("PlayerNameText") == null);

			PlayerName.text = PlayerPrefs.GetString ("PlayerName", "Player1");
			PlayerDifficulty = (Difficulty)PlayerPrefs.GetInt ("PlayerDifficulty", 1);
			PlayerImage.overrideSprite = Resources.Load ("picture") as Sprite;

			InactiveColors = EasyButton.colors;
			ActiveColors = EasyButton.colors;
			ActiveColors.normalColor = Color.green;
			ActiveColors.pressedColor = Color.green;
			ActiveColors.highlightedColor = Color.green;

			switch (PlayerDifficulty) {
			case Difficulty.Easy:
				EasyButton.colors = ActiveColors;
				break;
			case Difficulty.Medium:
				MediumButton.colors = ActiveColors;
				break;
			case Difficulty.Hard:
				HardButton.colors = ActiveColors;
				break;
			}
		}

		void Awake ()
		{
			StartCoroutine (WaitUntilActive ());
		}

		public void Back ()
		{
			PlayerPrefs.SetString ("PlayerName", PlayerName.text);
			PlayerPrefs.SetInt ("PlayerDifficulty", (int)PlayerDifficulty);
			SceneManager.LoadSceneAsync ("MainMenuScene");
		}

		public void SetEasy ()
		{
			EasyButton.colors = ActiveColors;
			MediumButton.colors = InactiveColors;
			HardButton.colors = InactiveColors;

			PlayerDifficulty = Difficulty.Easy;
		}

		public void SetMedium ()
		{
			EasyButton.colors = InactiveColors;
			MediumButton.colors = ActiveColors;
			HardButton.colors = InactiveColors;

			PlayerDifficulty = Difficulty.Medium;
		}

		public void SetHard ()
		{
			EasyButton.colors = InactiveColors;
			MediumButton.colors = InactiveColors;
			HardButton.colors = ActiveColors;

			PlayerDifficulty = Difficulty.Hard;
		}

		public void ChangePicture ()
		{
			Debug.Log ("TODO: ChangePicture()");
		}
	}
}