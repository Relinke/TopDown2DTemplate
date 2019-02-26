using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
	public enum RoleType {
		NONE,
		PLAYER,
		NPC,
		MONSTER
	}

	public class Role : MonoBehaviour {

		[SerializeField]
		protected string roleName;
		[SerializeField]
		protected float speed;
		[SerializeField]
		protected float hp;
		[SerializeField]
		protected float mp;
		[SerializeField]
		protected GameObject interactTip;
		protected RoleType roleType = RoleType.NONE;

		public RoleType GetCharacterType () {
			return roleType;
		}

		public virtual void OnInteract (Role other) {
			Debug.Log ("OnInteract: " + other.roleName.ToString ());
		}

		public float GetDistanceTo (Transform trans) {
			return Vector2.Distance (transform.position, trans.position);
		}

		public void Move (Vector2 dir) {
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

		public virtual void ShowInteractTip () {
			if (interactTip) {
				interactTip.SetActive (true);
			}
		}

		public virtual void HideInteractTip () {
			if (interactTip) {
				interactTip.SetActive (false);
			}
		}
	}
}