using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
	public class Character : MonoBehaviour
	{
		protected enum CurrentState
		{
			idle,
			attack,
			death,
			move,
		}

		protected CurrentState currentState;

		[SerializeField] protected AnimatorController animatorController;

	}
}