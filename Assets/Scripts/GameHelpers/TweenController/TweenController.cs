using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace GameHelpers
{
	public static class TweenController
	{
		public static void TweenKill ( Tween tween )
		{
			if ( tween != null && tween.IsActive ( ) )
				tween.Kill ( );
		}

		public static void TweenPause ( Tween tween )
		{
			if ( tween != null && tween.IsActive ( ) )
				tween.Pause ( );
		}

		public static void TweenPlay ( Tween tween )
		{
			if ( tween != null && tween.IsActive ( ) && !tween.IsPlaying ( ) )
				tween.Play ( );
		}
	}
}
