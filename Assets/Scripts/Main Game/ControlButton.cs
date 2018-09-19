using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameHelpers;

namespace MainGame
{
	public class ControlButton : ButtonClickHandler
	{
		public enum ControlButtonTypes
		{
			StartGame,
			PauseGame,

		}

		[SerializeField] private ControlButtonTypes buttonType;


		protected override void OnButtonClick ( )
		{
			base.OnButtonClick ( );

			ButtonActionCheck ( );
		}

		private void ButtonActionCheck ( )
		{
			switch ( buttonType )
			{
				case ControlButtonTypes.StartGame:
				{
					EventsManager.StartGame ( );
					break;
				}

				case ControlButtonTypes.PauseGame:
				{
					EventsManager.StartGame ( );
					break;
				}
			}
		}


	}
}