/**
* Created Date: 12/6/2021
* Author: Andrei-Florin Ciobanu
* 
* Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
*/

using UnityEngine;

namespace Player.PlayerStates {
	public sealed class PlayerInAirState : BasePlayerState {
		private float _boostDuration = 3f;
		
		/// <inheritdoc />
		public override void EnterState(PlayerManager player) {
			player.SetInAirConstraints();
		}

		/// <inheritdoc />
		public override void UpdateState(PlayerManager player) {
			if (Input.GetMouseButtonDown(0) && this._boostDuration > 0) {
				player.Boost();
				Debug.Log("Boosting");
				this._boostDuration -= Time.deltaTime;
			}
		}

		/// <inheritdoc />
		public override void OnTriggerEnter(Collider other, PlayerManager player) {
			throw new System.NotImplementedException();
		}
		
		/// <inheritdoc />
		public override void OnCollisionEnter(Collision other, PlayerManager player) {
			if (other.collider.CompareTag("Ground")) {
				player.SwitchState(player.LandedState);
			}
		}
	}
}