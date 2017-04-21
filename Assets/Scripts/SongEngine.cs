using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

namespace KoMa
{
	[RequireComponent (typeof(AudioSource))]
	public class SongEngine : MonoBehaviour
	{
		private static SongEngine _Instance;
		public AudioSource audio;

		public bool EnableLocalHack = true;

		public static SongEngine Instance {
			get {
				return _Instance;
			}
		}

		void Awake ()
		{
			if (_Instance != null && _Instance != this) {
				Destroy (this.gameObject);
			} else {
				_Instance = this;
			}
		}

		private IEnumerator LoadMp3 (string url)
		{
			WWW www = new WWW ("file://" + url);
			while (!www.isDone) {
				yield return null;
			}

			if (!www.isDone || !string.IsNullOrEmpty (www.error)) {
				Debug.LogError ("Error loading: " + url);
				yield break;
			}

			if (EnableLocalHack) {
				File.WriteAllBytes (Application.dataPath + "/Resources/test.mp3", www.bytes);

				audio.clip = Resources.Load ("test") as AudioClip;
			} else {
				audio.clip = www.GetAudioClip (false, true);
			}
			audio.Play ();
		}


		public void PlaySong (string url, string name)
		{
			PlayerPrefs.SetString ("SongUrl", url);
			PlayerPrefs.SetString ("SongTitle", name);
			SceneManager.LoadSceneAsync ("SongScene");
		}

		public void StopSong ()
		{
			if (audio.isPlaying) {
				audio.Stop ();
			}
		}

		public void PreviewSong (string url)
		{
			StartCoroutine (LoadMp3 (url));
		}
	}
}
