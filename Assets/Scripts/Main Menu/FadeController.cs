using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

namespace MainMenu
{
	public class FadeController : MonoBehaviour
	{
		[Header ( "Fade Parametrs" )]

		[SerializeField] private float timeFade;
		[SerializeField] private Ease easeFade;

		private Image fadeImage;

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
			fadeImage = GetComponent<Image> ( );
			fadeImage.enabled = false;
		}

		private void Subscribe ( )
		{
			EventsManager.OnHideMenuPanel += Fade;
		}

		private void Unsubscribe ( )
		{
			EventsManager.OnHideMenuPanel -= Fade;
		}

		private void Fade ( )
		{
			fadeImage.enabled = true;

			fadeImage.DOFade ( 1, timeFade ).SetEase ( easeFade )
				.OnComplete ( EventsManager.FadeComplete );
		}
	}
}