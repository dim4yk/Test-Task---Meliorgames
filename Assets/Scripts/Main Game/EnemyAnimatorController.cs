using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
	public class EnemyAnimatorController : AnimatorController
	{

		protected override void SetAttackAnimation ( bool loop )
		{
			animator.SetBool ( "Attack", true );
			animator.SetBool ( "Move", false );
			animator.SetBool ( "Death", false );
		}

		protected override void SetIdleAnimation ( bool loop )
		{
			
		}

		protected void AttackEvent ( )
		{
			EventsManager.AttackFortress ( );
		}

		protected void DeathEvent ( )
		{
			transform.parent.gameObject.SetActive ( false );
		}

		protected override void SetMoveAnimation ( bool loop )
		{
			animator.SetBool ( "Move", true );
			animator.SetBool ( "Attack", false );
			animator.SetBool ( "Death", false );
		}

		protected override void SetDeathAnimation ( bool loop )
		{
			animator.SetBool ( "Death", true );
			animator.SetBool ( "Attack", false );
			animator.SetBool ( "Move", false );
		}


	}
}