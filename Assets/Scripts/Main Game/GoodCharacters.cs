using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
	public class GoodCharacters : Character
	{
		protected delegate void CallBack ( );

		protected virtual void Start ( )
		{
			Initialize ( );
		}

		protected virtual void OnEnable ( )
		{
			Subscribe ( );
		}

		protected virtual void OnDisable ( )
		{
			Unsubscribe ( );
		}

		protected virtual void Subscribe ( )
		{
			EventsManager.OnAttackButtonPress += StartAttack;

			EventsManager.OnAttackButtonPressUp += Idle;

			EventsManager.OnWinGame += Idle;
		}

		protected virtual void Unsubscribe ( )
		{
			EventsManager.OnAttackButtonPress -= StartAttack;

			EventsManager.OnAttackButtonPressUp -= Idle;

			EventsManager.OnWinGame -= Idle;
		}

		protected virtual void Initialize ( )
		{
			Idle ( );
		}

		protected virtual void StartAttack ( )
		{
			currentState = CurrentState.attack;

			Attack ( );
		}

		protected virtual void Attack ( )
		{
			animatorController.SetAnimation ( AnimatorController.Animations.attack, true );
		}

		protected virtual void Idle ( )
		{
			animatorController.SetAnimation ( AnimatorController.Animations.idle, true );

			currentState = CurrentState.idle;
		}

		protected virtual void Death ( )
		{
			animatorController.SetAnimation ( AnimatorController.Animations.death, false );

			currentState = CurrentState.death;
		}
	}
}