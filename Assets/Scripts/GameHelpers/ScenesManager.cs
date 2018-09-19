using UnityEngine.SceneManagement;
using DG.Tweening;

namespace GameHelpers
{
	public static class ScenesManager
	{
		public enum Scenes
		{
			MainMenu,
			GameScene,
		}

		public static void LoadScene ( Scenes scene )
		{
			SceneManager.LoadScene ( scene.ToString ( ) );
		}

	}
}