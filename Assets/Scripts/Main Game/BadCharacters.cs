using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
	public class BadCharacters : Character
	{
		protected delegate void CallBack ( );

		protected CallBack CurrentAction;

		[Header ( "Move Parametrs" )]

		[SerializeField] private float speedMove;

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
			EventsManager.OnStartGame += StartMoving;

			EventsManager.OnWinGame += Death;

			EventsManager.OnAttackButtonPress += Stay;

			EventsManager.OnAttackButtonPressUp += StartMoving;
		}

		protected virtual void Unsubscribe ( )
		{
			EventsManager.OnStartGame -= StartMoving;

			EventsManager.OnWinGame -= Death;

			EventsManager.OnAttackButtonPress -= Stay;

			EventsManager.OnAttackButtonPressUp -= StartMoving;
		}

		protected virtual void Start ( )
		{
			Initialize ( );
		}

		protected virtual void Initialize ( )
		{
			Idle ( );
		}

		protected virtual void FixedUpdate ( )
		{
			CurrentAction ( );
		}

		protected virtual void StartMoving ( )
		{
			CurrentAction = Move;

			animatorController.SetAnimation ( AnimatorController.Animations.move, true );

			currentState = CurrentState.move;
		}

		protected virtual void Move ( )
		{
			transform.Translate ( Vector2.right * speedMove * Time.fixedDeltaTime );
		}

		protected virtual void Stay ( )
		{
			CurrentAction = ( ) => { };
		}

		protected virtual void StartAttack ( )
		{
			animatorController.SetAnimation ( AnimatorController.Animations.attack, true );

			currentState = CurrentState.attack;

			Attack ( );
		}

		protected virtual void Attack ( ) { }

		protected virtual void Idle ( )
		{
			animatorController.SetAnimation ( AnimatorController.Animations.idle, true );

			currentState = CurrentState.idle;

			Stay ( );
		}

		protected virtual void Death ( )
		{
			Stay ( );

			animatorController.SetAnimation ( AnimatorController.Animations.death, false );

			currentState = CurrentState.death;
		}

	}
}