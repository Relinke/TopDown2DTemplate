using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
	public class Player : Character {
		[SerializeField]
		private GameObject interactTip;
		private List<Character> interactCharacterList = new List<Character> ();

		public Player () {
			this.characterType = CharacterType.PLAYER;
		}

		private void Awake () {
			AddInputManager ();
		}

		private void AddInputManager () {
			this.gameObject.AddComponent<InputManager> ().Init (this);
		}

		private void Start () {

		}

		private void Update () {

		}

		public void TryInteract () {
			if (interactCharacterList.Count <= 0) {
				return;
			}

			Character interactCharacter = interactCharacterList[0];
			for (int i = 1; i < interactCharacterList.Count; ++i) {
				if (interactCharacter.GetDistanceTo (this) > interactCharacterList[i].GetDistanceTo (this)) {
					interactCharacter = interactCharacterList[i];
				}
			}

			interactCharacter.OnInteract (this);
		}

		private void OnTriggerEnter2D (Collider2D col) {
			Debug.Log ("Enter");
			if (CommonAPI.IsCharacter (col.gameObject)) {
				Character character = col.GetComponent<Character> ();
				this.AddInteractCharacter (character);
			}
		}

		private void OnTriggerExit2D (Collider2D col) {
			Debug.Log ("Exit");
			if (CommonAPI.IsCharacter (col.gameObject)) {
				Character character = col.GetComponent<Character> ();
				this.RemoveInteractCharacter (character);
			}
		}

		private void AddInteractCharacter (Character character) {
			if (this.IsCharacterInInteractList (character)) {
				return;
			}
			interactCharacterList.Add (character);
			this.UpdateInteractTip ();
		}

		private void RemoveInteractCharacter (Character character) {
			if (!this.IsCharacterInInteractList (character)) {
				return;
			}
			interactCharacterList.Remove (character);
			this.UpdateInteractTip ();
		}

		private bool IsCharacterInInteractList (Character character) {
			return interactCharacterList.Contains (character);
		}

		private void UpdateInteractTip () {
			if (interactCharacterList.Count > 0) {
				this.ShowInteractTip ();
			} else {
				this.HideInteractTip ();
			}
		}

		private void HideInteractTip () {
			interactTip.SetActive (false);
		}

		private void ShowInteractTip () {
			interactTip.SetActive (true);
		}
	}
}