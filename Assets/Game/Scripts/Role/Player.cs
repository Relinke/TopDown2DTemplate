using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
	public class Player : Role {
		private List<Role> canInteractRoleList = new List<Role> ();
		private Role interactRole;

		public Player () {
			this.roleType = RoleType.PLAYER;
		}

		private void Awake () {
			Init ();
		}

		private void Init () {
			InitInputManager ();
		}

		private void InitInputManager () {
			InputManager inputManager = gameObject.AddComponent<InputManager> ();
			inputManager.SetPlayer (this);
		}

		private void Start () {

		}

		private void Update () {

		}

		public void DoInteract () {
			if (interactRole == null) {
				return;
			}

			interactRole.OnInteract (this);
		}

		private void OnTriggerEnter2D (Collider2D col) {
			Debug.Log ("Enter");
			if (CommonAPI.IsRole (col.gameObject)) {
				AppendCanInteractRoleList (col.gameObject);
			}
		}

		private void OnTriggerStay2D (Collider2D col) {
			UpdateInteractRole ();
		}

		private void OnTriggerExit2D (Collider2D col) {
			Debug.Log ("Exit");
			if (CommonAPI.IsRole (col.gameObject)) {
				RemoveFromCanInteractRoleList (col.gameObject);
			}
		}

		private void AppendCanInteractRoleList (GameObject roleObject) {
			Role role = roleObject.GetComponent<Role> ();
			if (canInteractRoleList.Contains (role)) {
				return;
			}
			canInteractRoleList.Add (role);
		}

		private void RemoveFromCanInteractRoleList (GameObject roleObject) {
			Role role = roleObject.GetComponent<Role> ();
			if (!canInteractRoleList.Contains (role)) {
				return;
			}
			canInteractRoleList.Remove (role);
			role.HideInteractTip ();
			if (role == interactRole) {
				SetInteractRole (null);
			}
		}

		private void UpdateInteractRole () {
			if (canInteractRoleList.Count <= 0) {
				return;
			}

			Role role = null;
			for (int i = 0; i < canInteractRoleList.Count; ++i) {
				if (role == null) {
					role = canInteractRoleList[i];
				} else {
					Role other = canInteractRoleList[i];
					if (GetDistanceTo (role.transform) > GetDistanceTo (other.transform)) {
						role.HideInteractTip ();
						role = other;
					} else {
						other.HideInteractTip ();
					}
				}
			}
			SetInteractRole (role);
		}

		private void SetInteractRole (Role role) {
			interactRole = role;
			if (interactRole != null) {
				Debug.Log (interactRole.gameObject.name);
				interactRole.ShowInteractTip ();
			}
		}
	}
}