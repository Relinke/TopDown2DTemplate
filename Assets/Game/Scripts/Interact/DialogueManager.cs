using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Game {
	public class DialogueManager : MonoBehaviour {
		public static DialogueManager instance;

		[SerializeField]
		private Transform uiParent;
		[SerializeField]
		private Text textPrefab;
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
			this.gameObject.SetActive (false);
		}

		public void ShowStory (TextAsset interactInkJson) {
			story = new Story (interactInkJson.text);
			this.gameObject.SetActive (true);
			ContinueStory (-1);
			// TODO: 显示选项
		}

		private void ContinueStory (int choice) {
			if ((!story.canContinue) && (story.currentChoices.Count <= 0)) {
				EndStory ();
				return;
			}
			RemoveUIChildren ();
			if (choice >= 0) {
				// TODO: 做选项
			} else {
				string text = story.Continue ();
				Text storyText = Instantiate (textPrefab) as Text;
				storyText.text = text;
				storyText.transform.SetParent (uiParent, false);
			}
		}

		private void EndStory () {
			RemoveUIChildren ();
		}

		private void RemoveUIChildren () {
			int childCount = uiParent.childCount;
			for (int i = childCount - 1; i >= 0; --i) {
				GameObject.Destroy (uiParent.GetChild (i).gameObject);
			}
		}

		public void OnClickChoice (int choice) {
			ContinueStory(choice);
		}

		public void OnClickDialoguePanel () {
			ContinueStory(-1);
		}
	}
}