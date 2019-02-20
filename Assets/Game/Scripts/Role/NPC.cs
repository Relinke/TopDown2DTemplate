using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
	public class NPC : Character {
		[SerializeField]
		private TextAsset interactInkJson;

		public NPC () {
			this.characterType = CharacterType.NPC;
		}

		void Start () {

		}

		void Update () {

		}

		public override void OnInteract (Character other) {
			base.OnInteract (other);
			DialogueManager.Instance ().SetAndShowStory (interactInkJson);
		}
	}
}