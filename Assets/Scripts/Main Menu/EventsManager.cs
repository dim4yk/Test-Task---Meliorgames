using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
	public static class EventsManager
	{
		public delegate void CallBack ( );

		public static event CallBack OnHideMenuPanel;
		public static event CallBack OnPlayGameButtonPress;
		public static event CallBack OnFadeComplete;


		public static void HideMenuPanel ( )
		{
			if ( OnHideMenuPanel != null )
				OnHideMenuPanel ( );
		}

		public static void PlayGameButtonPress ( )
		{
			if ( OnPlayGameButtonPress != null )
				OnPlayGameButtonPress ( );
		}

		public static void FadeComplete ( )
		{
			if ( OnFadeComplete != null )
				OnFadeComplete ( );
		}
	}
}