using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


namespace MainMenu
{
	public class MainMenuPanel : MonoBehaviour
	{
		[Header ( "Showing Parametrs" )]

		[SerializeField] private float timeShowing;
		[SerializeField] private float timeWaitingForShowing;
		[SerializeField] private Ease easeShowing;
		[SerializeField] private Ease easeHide;
		[SerializeField] private Transform [ ] panelPositions;

		[Header ( "Components" )]

		[SerializeField] private Button [ ] buttons;

		private Tween waitTween;


		private void Awake ( )
		{
			Initialize ( );
		}

		private void OnEnable ( )
		{
			Subscribe ( );
		}

		private void OnDisable ( )
		{
			Unsubscribe ( );
		}

		private void Start ( )
		{
			WaitForShow ( );
		}

		private void Initialize ( )
		{
			ButtonsInitialize ( );
			InitPosition ( );
		}

		private void InitPosition ( )
		{
			transform.position = panelPositions [ 1 ].position;
		}

		private void ButtonsInitialize ( )
		{
			EnableButtons ( false );
		}

		private void Subscribe ( )
		{
			EventsManager.OnPlayGameButtonPress += Hide;
		}

		private void Unsubscribe ( )
		{
			EventsManager.OnPlayGameButtonPress -= Hide;
		}

		private void WaitForShow ( )
		{
			waitTween = DOVirtual.DelayedCall ( timeWaitingForShowing, Show, false );
		}

		private void Show ( )
		{
			MoveOnX ( panelPositions [ 0 ].position.x, timeShowing, easeShowing,
				( ) => { EnableButtons ( true ); } );
		}

		public void Hide ( )
		{
			EnableButtons ( false );

			MoveOnX ( panelPositions [ 1 ].position.x, timeShowing, easeHide, 
				EventsManager.HideMenuPanel);
		}

		private void EnableButtons ( bool active )
		{
			foreach ( Button button in buttons )
				button.interactable = active;
		}

		private void MoveOnX ( float posX, float time, Ease ease, TweenCallback callback = null )
		{
			transform.DOMoveX ( posX, time ).SetEase ( ease ).OnComplete ( delegate
			{
				if ( callback != null )
					callback ( );
			} );
		}
	}
}