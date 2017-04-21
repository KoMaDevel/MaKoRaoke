using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KoMa
{
	public class Version : MonoBehaviour
	{
		public string AppTitle = "MaKoRaoke";

		void Awake ()
		{
			gameObject.GetComponent<Text> ().text = AppTitle + " v" + Application.version;
		}
	}
}