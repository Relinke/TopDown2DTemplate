using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
	public class InputManager : MonoBehaviour {
		public static InputManager instance;
		private Player player;

		public void SetPlayer (Player p) {
			if (instance != null) {
				Destroy (this);
				return;
			} else {
				instance = this;
			}
			this.player = p;
		}

		void Update () {
			if (Input.GetKeyDown (KeyCode.E)) {
				player.DoInteract ();
			}

			Vector2 moveDir = Vector2.zero;
			if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
				moveDir.x = -1;
			} else if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
				moveDir.x = 1;
			}
			if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
				moveDir.y = 1;
			} else if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
				moveDir.y = -1;
			}
			player.Move (moveDir);
		}
	}
}