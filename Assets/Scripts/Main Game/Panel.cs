using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameHelpers;
using DG.Tweening;

namespace MainGame
{
	public class Panel : UIManager
	{
		public enum Panels
		{
			ExitPanel,
			WinGamePanel,
			FailGamePanel,
			StartGamePanel,
			AttackControlPanel,
		}

		[SerializeField] protected Panels panelType;
		[SerializeField] protected bool isEnableOnAwake = false;


		protected override void Initialize ( )
		{
			base.Initialize ( );

			if ( isEnableOnAwake )
				return;

			transform.localScale = new Vector3 ( 0, 0, 0 );

			transform.gameObject.SetActive ( false );
		}

		protected virtual void OnEnable ( )
		{
			Subscribe ( );
		}

		protected virtual void OnDisable ( )
		{
			Unsubscribe ( );
		}

		protected virtual void Subscribe ( )
		{
			EventsManager.OnPanelActiveStart += PanelActiveStart;

			EventsManager.OnPanelHide += HidePanel;
		}

		protected virtual void Unsubscribe ( )
		{
			EventsManager.OnPanelActiveStart -= PanelActiveStart;

			EventsManager.OnPanelHide -= HidePanel;
		}

		protected virtual void PanelActiveStart ( Panels panel, Ease ease )
		{
			if ( ( int ) panel == ( int ) panelType )
				ShowPanel ( gameObject, 1, ease, PanelActive );
		}

		protected virtual void HidePanel ( Panels panel, Ease ease )
		{
			if ( panel != panelType )
				return;
			
			PanelDeactivate ( );

			HidePanel ( gameObject, 0, ease, PanelDeactivate );
		}

		protected virtual void PanelActive ( )
		{

		}

		protected virtual void PanelDeactivate ( )
		{

		}
	}
}