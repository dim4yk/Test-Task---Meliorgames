using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameHelpers;

namespace MainGame
{
	public class AttackButton : ButtonClickHandler
	{

		protected override void OnButtonClickStart ( )
		{
			EventsManager.AttackButtonPress ( );
		}

		protected override void OnButtonUp ( )
		{
			EventsManager.AttackButtonPressUp ( );
		}

	}
}