using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KoMa
{
	public class JoinMenu : MonoBehaviour
	{

		public void Back ()
		{
			SceneManager.LoadSceneAsync ("MainMenuScene");
		}
	}
}