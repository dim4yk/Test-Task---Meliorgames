using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
	public class Enemy : BadCharacters
	{
		protected override void Subscribe ( )
		{
			base.Subscribe ( );

			EventsManager.OnEnemyCollisionToFortress += ReactionToFortressCollision;
		}

		protected override void Unsubscribe ( )
		{
			base.Unsubscribe ( );

			EventsManager.OnEnemyCollisionToFortress -= ReactionToFortressCollision;
		}

		private void ReactionToFortressCollision ( Enemy enemy, Collider2D collider )
		{
			if ( enemy != this )
				return;

			Stay ( );

			StartAttack ( );
		}

		protected override void Attack ( )
		{
			base.Attack ( );
		}

		protected override void Death ( )
		{
			base.Death ( );
		}

		protected override void Idle ( )
		{
			base.Idle ( );
		}



	}
}