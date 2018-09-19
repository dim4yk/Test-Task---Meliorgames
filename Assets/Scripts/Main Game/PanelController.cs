using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameHelpers;

namespace MainGame
{
	public class PanelController : ButtonClickHandler
	{
		public enum PanelControllerType
		{
			Hide,
			Show,
		}

		[SerializeField] private Panel.Panels panelType;
		[SerializeField] private PanelControllerType controllerType;

		protected override void OnButtonClick ( )
		{
			Action ( );
		}

		private void Action ( )
		{
			switch ( controllerType )
			{
				case PanelControllerType.Show:
				{
					PanelShow ( );
					break;
				}

				case PanelControllerType.Hide:
				{
					PanelHide ( );
					break;
				}
			}
		}

		private void PanelShow ( )
		{
			EventsManager.PanelActiveStart ( panelType, UIManagerParametrs.easeShow );
		}

		private void PanelHide ( )
		{
			EventsManager.PanelHide ( panelType, UIManagerParametrs.easeHide );
		}

	}
}