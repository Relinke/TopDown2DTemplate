using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
	public class DialogueManager : MonoBehaviour {
		public static DialogueManager instance;

		[SerializeField]
		private GameObject dialogueUI;
		[SerializeField]
		private Transform buttonParent;
		[SerializeField]
		private Text textUI;
		[SerializeField]
		private Button buttonPrefab;
		private Story story;

		private void Awake () {
			if (instance != null) {
				Destroy (this);
				return;
			} else {
				instance = this;
			}
			Init ();
		}

		private void Init () {
			EndStory ();
		}

		public void ShowStory (TextAsset interactInkJson) {
			story = new Story (interactInkJson.text);
			dialogueUI.SetActive (true);
			ContinueStory (-1);
		}

		private void ContinueStory (int choiceIndex) {
			string text;

			if ((!story.canContinue) && (story.currentChoices.Count <= 0)) {
				EndStory ();
				return;
			}
			if (choiceIndex >= 0) {
				story.ChooseChoiceIndex (choiceIndex);
				if ((!story.canContinue) && (story.currentChoices.Count <= 0)) {
					EndStory ();
					return;
				}
			} else if (!story.canContinue) {
				return;
			}
			ResetUI ();
			text = story.Continue ();
			textUI.text = text;
			if (story.currentChoices.Count > 0) {
				for (int i = 0; i < story.currentChoices.Count; i++) {
					Choice choice = story.currentChoices[i];
					Button button = Instantiate (buttonPrefab);
					button.transform.SetParent (buttonParent);
					button.GetComponentInChildren<Text> ().text = choice.text;
					button.onClick.AddListener (delegate {
						OnClickChoice (choice.index);
					});
				}
			}
		}

		private void EndStory () {
			ResetUI ();
			dialogueUI.SetActive (false);
		}

		private void ResetUI () {
			int childCount = buttonParent.childCount;
			for (int i = childCount - 1; i >= 0; --i) {
				GameObject.Destroy (buttonParent.GetChild (i).gameObject);
			}
			textUI.text = "";
		}

		public void OnClickChoice (int choice) {
			ContinueStory (choice);
		}

		public void OnClickDialoguePanel () {
			ContinueStory (-1);
		}
	}
}