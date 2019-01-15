using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
	public class Character : MonoBehaviour {
		public enum CharacterType {
			NONE,
			PLAYER,
			NPC,
			MONSTER
		}

		[SerializeField]
		protected string roleName;
		[SerializeField]
		protected float speed;
		[SerializeField]
		protected float hp;
		[SerializeField]
		protected float mp;
		protected CharacterType characterType = CharacterType.NONE;

		public CharacterType GetCharacterType () {
			return characterType;
		}

		public void OnInteract (Character character) {
			Debug.Log ("OnInteract: " + character.roleName.ToString ());
			// TODO: 响应交互行为
		}

		public float GetDistanceTo (Character character) {
			return Vector2.Distance (this.transform.position, character.transform.position);
		}

		public void MoveTo (Vector2 dir) {
			dir = dir.normalized;
			if (dir == Vector2.zero) {
				return;
			}
			Vector2 delta = dir * speed * Time.deltaTime;
			this.MoveBy (delta);
		}

		public void MoveBy (Vector2 delta) {
			Vector2 pos = this.transform.position;
			pos.x += delta.x;
			pos.y += delta.y;
			this.transform.position = pos;
		}
	}
}