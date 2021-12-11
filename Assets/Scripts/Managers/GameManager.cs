/**
 * Created Date: 12/6/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

using UI.Shop;

namespace Managers {
	public class GameManager : MonoBehaviour {
		private static GameManager s_instace;
		public static GameManager Instance => s_instace ?? (s_instace = FindObjectOfType<GameManager>());

		[SerializeField] 
		private Transform _distanceStartPosition;
		public Vector3 DistanceStartPosition => this._distanceStartPosition.position;

		[SerializeField] 
		private Material _material;
		
		private int _rampBoostLevel;
		public int RampBoostLevel => this._rampBoostLevel;

		private int _boostDurationLevel;
		public int BoostDurationLevel => this._boostDurationLevel;
		
		[HideInInspector]
		public int BoostUpgradesAvailable = 0;

		[HideInInspector]
		public int RampUpgradesAvailable = 0;
		
		#region Lifecycle

		private void Awake() {
			this._rampBoostLevel = UserSettings.Instance.RampLevel;
			this._boostDurationLevel = UserSettings.Instance.BoostLevel;

			Application.targetFrameRate = 60;

			UIManager.Instance.ShopViewController.OnColorBought += color => this._material.color = color;
		}

		#endregion
		
		#region Public

		/// <summary>
		/// Upgrade ramp level.
		/// </summary>
		public void UpgradeRampLevel() {
			if (this._rampBoostLevel == 10) {
				return;
			}
			this._rampBoostLevel++;
			this.RampUpgradesAvailable--;
			UserSettings.Instance.RampLevel = this._rampBoostLevel;
			UIManager.Instance.SetRampLevel(this._rampBoostLevel);

			if (this.RampUpgradesAvailable < 1) {
				UIManager.Instance.SetUpgradeRampButtonInteractableState(false);
			}
		}
		
		/// <summary>
		/// Upgrade boost level.
		/// </summary>
		public void UpgradeBoostLevel() {
			if (this._boostDurationLevel == 10) {
				return;
			}
			this._boostDurationLevel++;
			this.BoostUpgradesAvailable--;
			UserSettings.Instance.BoostLevel = this._boostDurationLevel;
			UIManager.Instance.SetBoostLevel(this._boostDurationLevel);
			
			if (this.BoostUpgradesAvailable < 1) {
				UIManager.Instance.SetUpgradeBoostButtonInteractableState(false);
			}
		}
		
		#endregion
		
	}
}