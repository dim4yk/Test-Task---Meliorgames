using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace GameHelpers
{
	public class UIManager : MonoBehaviour
	{
		public delegate void CallBack ( );

		protected float timeShow;
		protected float timeHide;

		private Tween fadeTween;
		private Tween activeTween;

		protected virtual void Awake ( )
		{
			Initialize ( );
		}

		protected virtual void Initialize ( )
		{

		}

		protected virtual void Start ( )
		{
			InitializeParametrs ( );
		}

		protected virtual void InitializeParametrs ( )
		{
			timeShow = UIManagerParametrs.timeShow;

			timeHide = UIManagerParametrs.timeHide;
		}

		public void Fade (Image fadeImage, float fade, float fadeTime, Ease fadeEase, bool active, CallBack callback = null )
		{
			if ( active )
				fadeImage.gameObject.SetActive ( true );

			fadeTween = fadeImage.DOFade ( fade, fadeTime ).SetEase ( fadeEase ).OnComplete ( delegate
			{
				if ( !active )
					fadeImage.gameObject.SetActive ( false );

				if ( callback != null )
					callback ( );
			} );
		}

		public void PanelActive ( GameObject panel, bool active )
		{
			panel.SetActive ( active );
		}

		public void ShowPanel ( GameObject panel, float scale, Ease ease )
		{
			panel.SetActive ( true );

			activeTween = panel.transform.DOScale ( scale, timeShow ).SetEase ( ease );
		}

		public void HidePanel ( GameObject panel, float scale, Ease ease )
		{
			activeTween = panel.transform.DOScale ( scale, timeHide ).SetEase ( ease )
				.OnComplete ( delegate
				{
					panel.SetActive ( false );
				} );
		}

		public void ShowPanel ( GameObject panel, float scale, Ease ease, CallBack callback )
		{
			panel.SetActive ( true );

			activeTween = panel.transform.DOScale ( scale, timeShow ).SetEase ( ease )
				.OnComplete ( delegate
				{
					if ( callback != null )
						callback ( );
				} );
		}

		public void HidePanel( GameObject panel, float scale, Ease ease, CallBack callback )
		{
			activeTween = panel.transform.DOScale ( scale, timeHide ).SetEase ( ease )
				.OnComplete ( delegate
				{
					panel.SetActive ( false );

					if ( callback != null )
						callback ( );
				} );
		}

	}
}
