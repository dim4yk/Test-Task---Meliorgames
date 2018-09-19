using UnityEngine.UI;
using UnityEngine;
using GameHelpers;

namespace MainMenu
{
	[RequireComponent ( typeof ( Button ) )]
	public class PlayGameButton : ButtonClickHandler
	{
		protected override void OnButtonClick ( )
		{
			EventsManager.PlayGameButtonPress ( );
		}
	}
}