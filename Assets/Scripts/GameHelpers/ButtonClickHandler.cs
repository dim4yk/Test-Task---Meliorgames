using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

namespace GameHelpers
{
	[RequireComponent ( typeof ( Button ) )]
	public class ButtonClickHandler : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
	{
		protected Button button;

		private bool clickStart = false;

		virtual protected void Awake ( )
		{
			Anitialize ( );
		}

		private void Anitialize ( )
		{
			button = GetComponent<Button> ( );
		}

		public void OnPointerClick ( PointerEventData eventData )
		{
			OnButtonClick ( );
		}

		public void OnPointerDown ( PointerEventData eventData )
		{
			if (!clickStart )
			{
				OnButtonClickStart ( );
				clickStart = true;
			}

			OnButtonDown ( );
		}

		public void OnPointerUp ( PointerEventData eventData )
		{
			clickStart = false;

			OnButtonUp ( );
		}

		virtual protected void OnButtonClick ( ) { }

		virtual protected void OnButtonDown ( ) { }

		virtual protected void OnButtonClickStart ( ) { }

		virtual protected void OnButtonUp ( ) { }

	}
}
