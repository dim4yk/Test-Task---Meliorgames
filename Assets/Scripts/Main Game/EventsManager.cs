using GameHelpers;
using DG.Tweening;
using UnityEngine;

namespace MainGame
{
	public static class EventsManager
	{
		public delegate void CallBack ( );

		public delegate void CallBackPanels ( Panel.Panels panel, Ease ease );

		public delegate void CallBackEnemyCollision ( Enemy enemy, Collider2D collider );

		public static event CallBack OnStartGame;
		public static event CallBack OnWinGame;
		public static event CallBack OnFailGame;
		public static event CallBack OnPauseGame;
		public static event CallBack OnPlayGame;
		public static event CallBack OnAttackFortress;
		public static event CallBack OnFailFortress;
		public static event CallBack OnAttackButtonPress;
		public static event CallBack OnAttackButtonPressUp;

		public static event CallBackPanels OnPanelActiveStart;
		public static event CallBackPanels OnPanelHide;

		public static event CallBackEnemyCollision OnEnemyCollisionToFortress;


		public static void StartGame ( )
		{
			if ( OnStartGame != null )
				OnStartGame ( );
		}

		public static void WinGame ( )
		{
			if ( OnWinGame != null )
				OnWinGame ( );
		}

		public static void FailGame ( )
		{
			if ( OnFailGame != null )
				OnFailGame ( );
		}

		public static void PauseGame ( )
		{
			if ( OnPauseGame != null )
				OnPauseGame ( );
		}

		public static void PlayGame ( )
		{
			if ( OnPlayGame != null )
				OnPlayGame ( );
		}

		public static void AttackFortress ( )
		{
			if ( OnAttackFortress != null )
				OnAttackFortress ( );
		}

		public static void FailFortress ()
		{
			if ( OnFailFortress != null )
				OnFailFortress ( );
		}

		public static void AttackButtonPress ( )
		{
			if ( OnAttackButtonPress != null )
				OnAttackButtonPress ( );
		}

		public static void AttackButtonPressUp ( )
		{
			if ( OnAttackButtonPressUp != null )
				OnAttackButtonPressUp ( );
		}

		public static void PanelActiveStart ( Panel.Panels panel, Ease ease )
		{
			if ( OnPanelActiveStart != null )
				OnPanelActiveStart ( panel, ease );
		}

		public static void PanelHide ( Panel.Panels panel, Ease ease )
		{
			if ( OnPanelHide != null )
				OnPanelHide ( panel, ease );
		}

		public static void EnemyCollisionToFortress ( Enemy enemy, Collider2D collider )
		{
			if ( OnEnemyCollisionToFortress != null )
				OnEnemyCollisionToFortress ( enemy, collider );
		}

	}
}