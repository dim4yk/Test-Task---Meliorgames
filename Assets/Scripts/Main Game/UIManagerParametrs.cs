using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GameHelpers
{
	public class UIManagerParametrs : MonoBehaviour
	{
		public static UIManagerParametrs Instance;

		[SerializeField] private Ease _easeShow;
		[SerializeField] private Ease _easeHide;
		[SerializeField] private float _timeShow;
		[SerializeField] private float _timeHide;
		[SerializeField] private float _fadeOnSimulation;

		public static Ease easeHide;
		public static Ease easeShow;
		public static float timeShow;
		public static float timeHide;
		public static float fadeOnSimulation;
		
		private void Awake ( )
		{
			Instance = this;

			Initialize ( );
		}

		private void Initialize ( )
		{
			easeShow = _easeShow;
			easeHide = _easeHide;
			timeShow = _timeShow;
			timeHide = _timeHide;
			fadeOnSimulation = _fadeOnSimulation;
		}
	}
}