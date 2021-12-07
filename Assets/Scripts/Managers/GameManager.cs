/**
 * Created Date: 12/6/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

namespace Managers {
	public class GameManager : MonoBehaviour {
		private static GameManager s_instace;
		public static GameManager Instance => s_instace ?? (s_instace = FindObjectOfType<GameManager>());

		[SerializeField] private Transform _distanceStartPosition;

		public Vector3 DistanceStartPosition => this._distanceStartPosition.position;
	}
}