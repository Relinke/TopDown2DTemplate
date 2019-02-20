using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
	public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T> {
		protected static T instance = null;
		protected static string instanceName = typeof (T).Name;

		public static T Instance () {
			if (instance == null) {
				T[] componentArray = FindObjectsOfType<T> ();
				if (componentArray.Length < 1) {
					// 创建组件对象
					GameObject instanceObject = new GameObject (instanceName);
					instanceObject.AddComponent<T> ();
					DontDestroyOnLoad (instanceObject);
				} else if (componentArray.Length >= 1) {
					instance = componentArray[0];
					if (componentArray.Length > 1) {
						Debug.LogWarning (instanceName + " Instance count more than 1.");
					}
				}
			}
			return instance;
		}

		protected virtual void OnDestroy () {
			instance = null;
		}
	}
}