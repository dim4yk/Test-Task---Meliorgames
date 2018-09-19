using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MainMenu
{
	public class CameraController : MonoBehaviour
	{
		[Header ( "Moving Parametrs" )]

		[SerializeField] private float timeMoving;
		[SerializeField] private float ortoSizeFinal;
		[SerializeField] private Ease easeMoving;

		private Camera thisCamera;

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

		private void Initialize ( )
		{
			thisCamera = GetComponent<Camera> ( );
		}

		private void Subscribe ( )
		{
			EventsManager.OnHideMenuPanel += Move;
		}

		private void Unsubscribe ( )
		{
			EventsManager.OnHideMenuPanel -= Move;
		}

		private void Move ( )
		{
			thisCamera.DOOrthoSize ( ortoSizeFinal, timeMoving ).SetEase ( easeMoving );
		}
	}
}