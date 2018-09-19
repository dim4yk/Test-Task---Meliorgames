using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
	public class Fortress : MonoBehaviour
	{
		private enum FortressStates
		{
			damagged0,
			damagged1,
			damagged2,
			damaggedFail,
		}

		[Header ( "Components" )]

		[SerializeField] private Sprite [ ] fortressStateSprites;

		private SpriteRenderer spriteRendererComponent;

		private FortressStates fortressState;

		private void Awake ( )
		{
			Initialize ( );
		}

		private void OnEnable ( )
		{
			Subscribe ( );
		}

		private void OnDisable ( )
		{
			Unsubscribe ( );
		}

		private void Start ( )
		{
			
		}

		private void Initialize ( )
		{
			spriteRendererComponent = GetComponent<SpriteRenderer> ( );

			fortressState = FortressStates.damagged0;
		}

		private void Subscribe ( )
		{
			EventsManager.OnAttackFortress += ReactionToAttack;
		}

		private void Unsubscribe ( )
		{
			EventsManager.OnAttackFortress -= ReactionToAttack;
		}

		private void ReactionToAttack ( )
		{
			if ( fortressState == FortressStates.damaggedFail )
				FailFortress ( );
			else
				DamaggedFortress ( );
		}

		private void FailFortress ( )
		{
			EventsManager.FailFortress ( );
		}

		private void DamaggedFortress ( )
		{
			fortressState = NextFortressState ( );

			spriteRendererComponent.sprite = fortressStateSprites [ ( int ) fortressState ];
		}
		
		private FortressStates NextFortressState ( )
		{
			FortressStates nextState = FortressStates.damaggedFail;

			switch ( fortressState )
			{
				case FortressStates.damagged0:
				{
					nextState = FortressStates.damagged1;
					break;
				}

				case FortressStates.damagged1:
				{
					nextState = FortressStates.damagged2;
					break;
				}
			}

			return nextState;
		}
	}
}
