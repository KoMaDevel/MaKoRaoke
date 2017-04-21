using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace KoMa {
	public class SongMenu : MonoBehaviour {

		public Text SongTitle;

		private IEnumerator WaitUntilActive() {
			yield return new WaitWhile (() => GameObject.Find ("SongTitle") == null);

			SongTitle.text = PlayerPrefs.GetString ("SongTitle", "KoMa - This is my Song");
		}

		void Awake() {
			StartCoroutine (WaitUntilActive ());
		}

		public void Back() {
			SceneManager.LoadSceneAsync ("SongSelectScene");
		}
	}
}