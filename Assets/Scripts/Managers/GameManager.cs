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

		[SerializeField] 
		private Transform _distanceStartPosition;
		public Vector3 DistanceStartPosition => this._distanceStartPosition.position;

		private int _rampBoostLevel = 1;
		public int RampBoostLevel => this._rampBoostLevel;
		
		private int _boostDurationLevel = 1;
		public int BoostDurationLevel => this._boostDurationLevel;
		
		#region Public

		/// <summary>
		/// Upgrade ramp level.
		/// </summary>
		public void UpgradeRampLevel() {
			if (this._rampBoostLevel == 10) {
				return;
			}
			this._rampBoostLevel++;
			UIManager.Instance.SetRampLevel(this._rampBoostLevel);
		}
		
		/// <summary>
		/// Upgrade boost level.
		/// </summary>
		public void UpgradeBoostLevel() {
			if (this._boostDurationLevel == 10) {
				return;
			}
			this._boostDurationLevel++;
			UIManager.Instance.SetBoostLevel(this._boostDurationLevel);
		}
		
		#endregion
		
	}
}