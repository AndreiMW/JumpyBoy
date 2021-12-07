/**
* Created Date: 12/6/2021
* Author: Andrei-Florin Ciobanu
* 
* Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
*/

using UnityEngine;

using Managers;

namespace Player.PlayerStates {
	public sealed class PlayerInAirState : BasePlayerState {
		private float _maxBoostDuration = 3f;
		private float _currentDuration;
		
		/// <inheritdoc />
		public override void EnterState(PlayerManager player) {
			player.SetInAirConstraints();
			this._currentDuration = this._maxBoostDuration;
		}

		/// <inheritdoc />
		public override void UpdateState(PlayerManager player) {}

		/// <inheritdoc />
		public override void FixedUpdateState(PlayerManager player) {
			if (Input.GetMouseButton(0) && this._currentDuration > 0) {
				player.Boost();
				Debug.Log("Boosting");
				this._currentDuration -= Time.fixedDeltaTime;
				UIManager.Instance.SetBoostAmount(this._currentDuration / this._maxBoostDuration);
			}
		}

		/// <inheritdoc />
		public override void OnTriggerEnter(Collider other, PlayerManager player) { }
		
		/// <inheritdoc />
		public override void OnCollisionEnter(Collision other, PlayerManager player) {
			if (other.collider.CompareTag("Ground")) {
				player.SwitchState(player.LandedState);
			}
		}
	}
}