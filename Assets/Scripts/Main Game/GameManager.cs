using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
	public class GameManager : MonoBehaviour
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
			EventsManager.OnFailFortress += GameOver;
		}

		private void Unsubscribe ( )
		{
			EventsManager.OnFailFortress -= GameOver;
		}

		private void GameOver ( )
		{
			EventsManager.FailGame ( );
		}
	}
}