using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameHelpers;


namespace MainMenu
{
	public class MainMenuManager : MonoBehaviour
	{
		private void OnEnable ( )
		{
			Subscribe ( );
		}

		private void OnDisable ( )
		{
			Unsubscribe ( );
		}

		private void Subscribe ( )
		{
			EventsManager.OnFadeComplete += GoToScene;
		}

		private void Unsubscribe ( )
		{
			EventsManager.OnFadeComplete -= GoToScene;
		}

		private void GoToScene ( )
		{
			ScenesManager.LoadScene ( ScenesManager.Scenes.GameScene );
		}
	}
}