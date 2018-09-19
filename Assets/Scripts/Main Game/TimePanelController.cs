using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using GameHelpers;

namespace MainGame
{
	public class TimePanelController : MonoBehaviour
	{
		[SerializeField] private Image timeImage;

		private float timingValue;

		private Tween timingTween;

		private void Start ( )
		{
			Initialize ( );
		}

		private void Initialize ( )
		{
			timingValue = GamePropertiesManager.timeGame;
		}

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
			EventsManager.OnStartGame += TimingStart;
			EventsManager.OnFailGame += TimingEnd;
		}

		private void Unsubscribe ( )
		{
			EventsManager.OnStartGame -= TimingStart;
			EventsManager.OnFailGame -= TimingEnd;
		}

		private void TimingStart ( )
		{
			timingTween = timeImage.DOFillAmount ( 1, timingValue ).SetEase ( Ease.Linear )
				.OnComplete ( TimingComplete );
		}

		private void TimingComplete ( )
		{
			EventsManager.WinGame ( );
		}

		private void TimingEnd ( )
		{
			TweenController.TweenKill ( timingTween );
		}
	}
}