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
		protected float hp;
		protected float mp;
		protected string roleName;
		protected CharacterType characterType = CharacterType.NONE;

		public CharacterType GetCharacterType () {
			return characterType;
		}
	}
}