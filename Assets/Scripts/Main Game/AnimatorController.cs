using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
	public class AnimatorController : MonoBehaviour
	{
		public enum Animations
		{
			idle,
			attack,
			move,
			death,
		}

		protected Animator animator;

		protected virtual void Awake ( )
		{
			Initialize ( );
		}

		protected virtual void Initialize ( )
		{
			animator = GetComponent<Animator> ( );
		}

		public virtual void SetAnimation ( Animations animations, bool loop )
		{
			switch ( animations )
			{
				case Animations.idle:
				{
					SetIdleAnimation ( loop );
					break;
				}
				
				case Animations.attack:
				{
					SetAttackAnimation ( loop );
					break;
				}

				case Animations.move:
				{
					SetMoveAnimation ( loop );
					break;
				}

				case Animations.death:
				{
					SetDeathAnimation ( loop );
					break;
				}
			}
		}

		protected virtual void SetIdleAnimation ( bool loop ) { }

		protected virtual void SetAttackAnimation ( bool loop ) { }

		protected virtual void SetMoveAnimation ( bool loop ) { }

		protected virtual void SetDeathAnimation ( bool loop ) { }

	}
}