using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGame
{
	public class EnemyCollisionChecker : MonoBehaviour
	{
		private Enemy enemy;

		private void Start ( )
		{
			Initialize ( );
		}

		private void Initialize ( )
		{
			enemy = GetComponent<Enemy> ( );
		}

		private void OnTriggerEnter2D ( Collider2D collision )
		{
			switch ( collision.tag )
			{
				case "Fortress":
				{
					EventsManager.EnemyCollisionToFortress ( enemy, collision );
					break;
				}
			}
		}
	}
}