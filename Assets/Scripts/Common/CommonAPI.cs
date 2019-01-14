using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
	public class CommonAPI {
		public static bool IsCharacter (GameObject obj) {
			if (obj.GetComponent<Character> () == null) {
				return false;
			}
			return true;
		}
	}
}