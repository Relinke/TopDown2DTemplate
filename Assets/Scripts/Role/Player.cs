using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game{
	public class Player : Character {
		private void Start () {
			
		}
		
		private void Update () {
			
		}

		private void OnTriggerEnter2D(Collider2D col){
			if(Game.CommonAPI.IsCharacter(col.gameObject)){

			}
		}
	}
}
