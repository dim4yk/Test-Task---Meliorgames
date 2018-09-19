using UnityEngine;
using System.Collections;

namespace GameHelpers
{
	public class Alignment : MonoBehaviour
	{
		public enum vAlignment
		{
			none,
			top,
			center,
			bottom
		}
		public enum hAlignment
		{
			none,
			left,
			center,
			right
		}

		public bool
			relative = false;

		public vAlignment vAlign = vAlignment.none;
		public hAlignment hAlign = hAlignment.none;

		public float xOffset = 0f;
		public float yOffset = 0f;

		private void Start ( )
		{
			SetAlignment ( );
		}

		public void SetAlignment ( )
		{
			Vector3 pos = transform.position;
			Camera mainCam = GetScreen.FindCamera ( );
			Vector3 centerCamera = mainCam.transform.position;
			Vector3 minWorl = mainCam.MinWorld ( );
			Vector3 maxWorl = mainCam.MaxWorld ( );

			switch ( hAlign )
			{
				case hAlignment.left:
					pos.x = minWorl.x;
					break;
				case hAlignment.right:
					pos.x = maxWorl.x;
					break;
				case hAlignment.center:
					pos.x = centerCamera.x;
					break;
			}

			switch ( vAlign )
			{
				case vAlignment.top:
					pos.y = maxWorl.y;
					break;
				case vAlignment.bottom:
					pos.y = minWorl.y;
					break;
				case vAlignment.center:
					pos.y = centerCamera.y;
					break;
			}

			if ( relative )
			{
				if ( hAlign == hAlignment.center )
				{
					pos.x += Mathf.Abs ( maxWorl.x - centerCamera.x ) * xOffset;
				}
				else
				{
					pos.x *= xOffset;
				}

				if ( vAlign != vAlignment.center )
				{
					pos.y *= yOffset;
				}
				else
				{
					pos.y += Mathf.Abs ( maxWorl.y - centerCamera.y ) * yOffset;
				}
			}
			else
			{
				pos += new Vector3 ( xOffset, yOffset );
			}
			transform.position = pos;
		}


		public void GetRelativePosition ( )
		{
			vAlign = vAlignment.center;
			hAlign = hAlignment.center;

			Vector3 pos = transform.position;
			Camera mainCam = GetScreen.FindCamera ( );
			Vector3 centerCamera = mainCam.transform.position;
			Vector3 maxWorl = mainCam.MaxWorld ( );

			float halfWidth = Mathf.Abs ( maxWorl.x - centerCamera.x );
			float halfHeight = Mathf.Abs ( maxWorl.y - centerCamera.y );

			if ( halfWidth != 0 )
			{
				xOffset = ( pos.x - centerCamera.x ) / halfWidth;
			}
			if ( halfHeight != 0 )
			{
				yOffset = ( pos.y - centerCamera.y ) / halfHeight;
			}
		}

#if UNITY_EDITOR
		[UnityEditor.CustomEditor ( typeof ( Alignment ) )]
		[UnityEditor.CanEditMultipleObjects]
		public class AlignerEditor : UnityEditor.Editor
		{
			public override void OnInspectorGUI ( )
			{
				DrawDefaultInspector ( );

				Alignment Aligner = ( Alignment ) target;
				if ( GUILayout.Button ( "Align" ) )
				{
					Aligner.SetAlignment ( );
				}

				if ( Aligner.relative )
				{
					if ( GUILayout.Button ( "GetRelativePosition" ) )
					{
						Aligner.GetRelativePosition ( );
					}
				}
			}
		}
#endif
	}
}