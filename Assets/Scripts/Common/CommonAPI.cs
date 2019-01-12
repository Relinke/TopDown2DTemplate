﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game{
	public class CommonAPI : MonoBehaviour {
		public static bool IsCharacter(GameObject obj){
			if (obj.GetType() != typeof(GameObject)) {
				return false;
			}
			if (obj.GetComponent<Character>() == null){
				return false;
			}
			return true;
		}
	}
}