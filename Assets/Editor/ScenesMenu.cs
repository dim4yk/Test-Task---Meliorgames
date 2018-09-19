using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public static class ScenesMenu
{
	private static void OpenScene ( string path )
	{
		OpenSceneMode openMode = OpenSceneMode.Single;
		if ( EditorUtility.DisplayDialog ( "Select open scene mode", "Chose scene opening mode.", "Single", "Additive" ) )
		{
			Scene [ ] scenes = new Scene [ SceneManager.sceneCount ];
			for ( int i = 0; i < scenes.Length; i++ )
			{
				scenes [ i ] = SceneManager.GetSceneAt ( i );
			}
			EditorSceneManager.SaveModifiedScenesIfUserWantsTo ( scenes );
		}
		else
		{
			openMode = OpenSceneMode.Additive;
		}
		EditorSceneManager.OpenScene ( path, openMode );
	}

	[MenuItem ( "Scenes/MainMenu.unity" )]
	public static void Scene0 ( )
	{
		OpenScene ( "Assets/Scenes/MainMenu.unity" );
	}

	[MenuItem ( "Scenes/GameScene.unity" )]
	public static void Scene1 ( )
	{
		OpenScene ( "Assets/Scenes/GameScene.unity" );
	}
}
