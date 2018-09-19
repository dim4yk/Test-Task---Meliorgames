using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameHelpers;

namespace MainGame
{
	public class PanelsManager : MonoBehaviour
	{
		[SerializeField] private Panel [ ] panels;

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
			EventsManager.OnFailGame += GameOverPanelActive;

			EventsManager.OnStartGame += AttackControlPanelActive;

			EventsManager.OnWinGame += WinGamePanelActive;
		}

		private void Unsubscribe ( )
		{
			EventsManager.OnFailGame -= GameOverPanelActive;

			EventsManager.OnStartGame -= AttackControlPanelActive;

			EventsManager.OnWinGame -= WinGamePanelActive;
		}

		private void AttackControlPanelActive ( )
		{
			PanelActive ( Panel.Panels.AttackControlPanel );
		}

		private void WinGamePanelActive ( )
		{
			PanelActive ( Panel.Panels.WinGamePanel );

			PanelHide ( Panel.Panels.AttackControlPanel );
		}

		private void GameOverPanelActive ( )
		{
			PanelActive ( Panel.Panels.FailGamePanel );

			PanelHide ( Panel.Panels.AttackControlPanel );
		}

		private void PanelActive( Panel.Panels panel)
		{
			panels [ ( int ) panel ].gameObject.SetActive ( true );

			EventsManager.PanelActiveStart ( panel, UIManagerParametrs.easeShow );
		}

		private void PanelHide ( Panel.Panels panel )
		{
			EventsManager.PanelHide ( panel, UIManagerParametrs.easeHide );
		}

	}
}