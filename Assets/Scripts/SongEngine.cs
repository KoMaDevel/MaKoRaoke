using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KoMa
{
	[RequireComponent(typeof(AudioSource))]
	public class SongEngine : MonoBehaviour
	{
		private static SongEngine _Instance;
		AudioSource audio;

		public static SongEngine Instance {
			get {
				return _Instance;
			}
		}

		void Awake() {
			if (_Instance != null && _Instance != this) {
				Destroy (this.gameObject);
			} else {
				_Instance = this;
			}
		}

		private IEnumerator LoadMp3(string url) {
			WWW www = new WWW ("file://" + url);
			while (!www.isDone) {
				yield return null;
			}

			if (!www.isDone || !string.IsNullOrEmpty (www.error)) {
				Debug.LogError ("Error loading: " + url);
				yield break;
			}

			audio.clip = www.GetAudioClip ();
			audio.Play ();
		}


		public void PlaySong(string url) {
		}

		public void StopSong() {
			if (audio.isPlaying) {
				audio.Stop ();
			}
		}

		public void PreviewSong(string url) {
			Debug.Log ("Loading: " + url);
			StartCoroutine (LoadMp3(url));
		}
	}
}
