using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
	public class DialogueManager : Framework.MonoSingleton<DialogueManager> {
		[SerializeField]
		private GameObject dialogueRootUI;
		[SerializeField]
		private Transform choiceButtonParent;
		[SerializeField]
		private Text dialogueTextUI;
		[SerializeField]
		private Text characterNameTextUI;
		[SerializeField]
		private Button choiceButtonPrefab;

		private Story story;

		private void Awake () {
			Init ();
		}

		private void Init () {
			EndStory ();
		}

		public void SetAndShowStory (TextAsset interactInkJson) {
			story = new Story (interactInkJson.text);
			ShowStoryUI ();
			ContinueStory (-1);
		}

		private void ShowStoryUI () {
			dialogueRootUI.SetActive (true);
		}

		private void HideStoryUI () {
			dialogueRootUI.SetActive (false);
		}

		public void ContinueStory (int choiceIndex) {
			string dialogueText;

			if (choiceIndex >= 0) {
				story.ChooseChoiceIndex (choiceIndex);
			} else if (!story.canContinue) {
				return;
			}
			if ((!story.canContinue) && (story.currentChoices.Count <= 0)) {
				EndStory ();
				return;
			}
			ResetUI ();
			dialogueText = story.Continue ();
			UpdateDialogueUI (dialogueText);
			UpdateChoiceUI ();
		}

		private void UpdateDialogueUI (string dialogueText) {
			dialogueTextUI.text = dialogueText;
		}

		private void UpdateChoiceUI () {
			if (story.currentChoices.Count <= 0) {
				return;
			}
			for (int i = 0; i < story.currentChoices.Count; ++i) {
				Choice choice = story.currentChoices[i];
				Button button = GameObject.Instantiate (choiceButtonPrefab);
				button.transform.SetParent (choiceButtonParent);
				button.GetComponentInChildren<Text> ().text = choice.text;
				button.onClick.AddListener (delegate {
					OnClickChoice (choice.index);
				});
			}
		}

		private void EndStory () {
			ResetUI ();
			HideStoryUI ();
		}

		private void ResetUI () {
			RemoveAllChoiceButton ();
			ResetDialogueUI ();
		}

		private void RemoveAllChoiceButton () {
			int childCount = choiceButtonParent.childCount;
			for (int i = childCount - 1; i >= 0; --i) {
				GameObject.Destroy (choiceButtonParent.GetChild (i).gameObject);
			}
		}

		private void ResetDialogueUI () {
			dialogueTextUI.text = "";
		}

		public void OnClickChoice (int choice) {
			ContinueStory (choice);
		}

		public void OnClickDialoguePanel () {
			ContinueStory (-1);
		}
	}
}