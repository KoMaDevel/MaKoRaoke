using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

namespace KoMa
{
	public class SongEntry : MonoBehaviour
	{
		private string mp3;
		private string title;

		private IEnumerator LoadJob (string url)
		{
			WWW www = new WWW ("file://" + url);
			while (!www.isDone) {
				yield return null;
			}

			if (!www.isDone || !string.IsNullOrEmpty (www.error)) {
				Debug.LogError ("Error loading: " + url);
				yield break;
			}

			gameObject.GetComponentsInChildren<Image> () [1].sprite = Sprite.Create (
				www.textureNonReadable, new Rect (0, 0, www.textureNonReadable.width, www.textureNonReadable.height), 
				new Vector2 (0, 0));
		}

		private string GetJpgFilename (string folder)
		{
			return Directory.GetFiles (folder, "*.jpg", SearchOption.TopDirectoryOnly) [0];
		}

		public void ChangeEntry (string folder, string topLevelFolder)
		{
			title = folder.Substring (topLevelFolder.Length + 1);
			gameObject.GetComponentInChildren<Button> ().GetComponentInChildren <Text> ().text = title;

			mp3 = Directory.GetFiles (folder, "*.mp3", SearchOption.TopDirectoryOnly) [0];

			StartCoroutine (LoadJob (GetJpgFilename (folder)));
		}

		public void StartMe ()
		{
			SongEngine.Instance.PlaySong (mp3, title);		
		}

		public void StopMe ()
		{
			SongEngine.Instance.StopSong ();
		}

		public void PreviewMe ()
		{
			SongEngine.Instance.PreviewSong (mp3);
		}
	}
}