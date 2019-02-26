using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
	public class NPC : Role {
		[SerializeField]
		private TextAsset interactInkJson;

		public NPC () {
			this.roleType = RoleType.NPC;
		}

		void Start () {

		}

		void Update () {

		}

		public override void OnInteract (Role other) {
			base.OnInteract (other);
			DialogueManager.Instance ().SetAndShowStory (interactInkJson);
		}
	}
}