using UnityEngine;
using System.Collections;

namespace GameHelpers
{
	/// <summary>
	/// Calculate World points by main camera. Only work with a orthographic camera.
	/// </summary>
	public static class GetScreen
	{
		/// <summary>
		/// Camera.ScreenToWorldPoint(Vector3 point) with Find camera on scene.
		/// Finding a camera on the scene is very expensive.
		/// </summary>
		public static Vector3 ScreenToWorldPoint ( Vector3 point )
		{
			return FindCamera ( ).ScreenToWorldPoint ( point );
		}

		/// <summary>
		/// Camera.WorldToScreenPoint(Vector3 point) with Find camera on scene.
		/// Finding a camera on the scene is very expensive.
		/// </summary>
		public static Vector2 WorldToScreenPoint ( Vector3 point )
		{
			return FindCamera ( ).WorldToScreenPoint ( point );
		}

		public static float left
		{
			get
			{
				Camera cam = FindCamera ( );
				return cam.transform.position.x - cam.orthographicSize * cam.aspect;
			}
		}

		public static float right
		{
			get
			{
				Camera cam = FindCamera ( );
				return cam.transform.position.x + cam.orthographicSize * cam.aspect;
			}
		}

		public static float bottom
		{
			get
			{
				Camera cam = FindCamera ( );
				return cam.transform.position.y - cam.orthographicSize;
			}
		}

		public static float top
		{
			get
			{
				Camera cam = FindCamera ( );
				return cam.transform.position.y + cam.orthographicSize;
			}
		}

		public static float width
		{
			get
			{
				Camera cam = FindCamera ( );
				return cam.orthographicSize * cam.aspect * 2.0f;
			}
		}

		public static float height
		{
			get
			{
				return FindCamera ( ).orthographicSize * 2;
			}
		}

		/// <summary>
		/// Minimal visible world point. Bottom left corner.
		/// </summary>
		public static Vector3 MinWorld ( this Camera cam )
		{
			float cameraHeight = cam.orthographicSize * 2;
			return cam.transform.position - new Vector3 ( cameraHeight * cam.aspect, cameraHeight, 0 ) * 0.5f;
		}

		/// <summary>
		/// Maximum visible world point. Upper right corner.
		/// </summary>
		public static Vector3 MaxWorld ( this Camera cam )
		{
			float cameraHeight = cam.orthographicSize * 2;
			return cam.transform.position + new Vector3 ( cameraHeight * cam.aspect, cameraHeight, 0 ) * 0.5f;
		}

		/// <summary>
		/// Finding a camera on the scene is very expensive.
		/// Recomended buffer this result.
		/// </summary>
		public static Camera FindCamera ( )
		{
			Camera m_cam = Camera.main;
			if ( m_cam )
			{
				return m_cam;
			}
			Camera [ ] allCameras = Camera.allCameras;
			for ( int i = 0; i < allCameras.Length; i++ )
			{
				if ( allCameras [ i ].name == "Main Camera" )
				{
					return allCameras [ i ];
				}
			}
			if ( allCameras.Length > 0 )
			{
				return allCameras [ 0 ];
			}
			return null;
		}
	}
}