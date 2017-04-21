using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace KoMa
{
public class SongList : MonoBehaviour {

	public string Folder;

	public GameObject SongEntry;
	public Transform SongListGameObject;

	private string[] SongFolders;

	private List<GameObject> InstantiatedObjects;

	void Awake() {
		GameObject tempObject;

		SongFolders = Directory.GetDirectories (Folder);
		InstantiatedObjects = new List<GameObject> ();

		//for (int i = 0; i < SongFolders.Length; i++) {
		for (int i = 0; i < 8; i++) {
			tempObject = Instantiate (SongEntry);

			tempObject.GetComponent<SongEntry>().ChangeEntry (SongFolders[i], Folder);
			tempObject.name = SongFolders[i].Substring (Folder.Length + 1);
			tempObject.transform.SetParent (SongListGameObject);
			tempObject.transform.localPosition = new Vector3 (0, -i * 100, 0);

			InstantiatedObjects.Add (tempObject);
		}
	}
}
}