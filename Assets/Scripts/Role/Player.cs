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

		}

		private void Start () {

		}

		private void Update () {

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
			// TODO: 根据交互角色列表更新交互提示
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