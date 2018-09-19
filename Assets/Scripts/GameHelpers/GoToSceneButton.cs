using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameHelpers
{
	public class GoToSceneButton : ButtonClickHandler
	{
		[SerializeField] private ScenesManager.Scenes scene;

		protected override void OnButtonClick ( )
		{
			ScenesManager.LoadScene ( scene );
		}

	}
}