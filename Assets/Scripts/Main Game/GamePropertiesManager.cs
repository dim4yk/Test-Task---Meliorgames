using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
	public class GamePropertiesManager : MonoBehaviour
	{

		[SerializeField] float _timeGame;

		public static float timeGame;

		private void Awake ( )
		{
			Initialize ( );
		}

		private void Initialize ( )
		{
			timeGame = _timeGame;
		}
	}
}