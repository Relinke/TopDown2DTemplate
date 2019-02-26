using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
	public class CommonAPI {
		public static bool IsRole (GameObject obj) {
			if (obj.GetComponent<Role> () == null) {
				return false;
			}
			return true;
		}
	}
}