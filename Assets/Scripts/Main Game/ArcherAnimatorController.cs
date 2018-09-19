using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
	public class ArcherAnimatorController : AnimatorController
	{

		protected override void SetAttackAnimation ( bool loop )
		{
			animator.SetBool ( "Shoot", true );
			animator.SetBool ( "Idle", false );
		}

		protected override void SetIdleAnimation ( bool loop )
		{
			animator.SetBool ( "Idle", true );
			animator.SetBool ( "Shoot", false );
		}

		protected override void SetDeathAnimation ( bool loop )
		{

		}
	}
}