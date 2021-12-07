/**
* Created Date: 12/6/2021
* Author: Andrei-Florin Ciobanu
* 
* Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
*/

using UnityEngine;

namespace Player.PlayerStates { 
	public sealed class PlayerOnRampState : BasePlayerState {
		private bool _shouldBoost = false;
		
		/// <inheritdoc />
		public override void EnterState(PlayerManager player) {
			throw new System.NotImplementedException();
		}

		/// <inheritdoc />
		public override void UpdateState(PlayerManager player) {
			if (this._shouldBoost) {
				player.Rigidbody.AddForce(player.Rigidbody.transform.forward * (Time.deltaTime * (player.Rigidbody.mass * 20f)), ForceMode.Impulse);
			}
		}

		/// <inheritdoc />
		public override void OnTriggerEnter(Collider other, PlayerManager player) {
			if (other.CompareTag("RampEnd")) {
				this._shouldBoost = false;
				player.SwitchState(player.InAirState);
			}

			if (other.CompareTag("RampBoost")) {
				this._shouldBoost = true;
			}
		}

		/// <inheritdoc />
		public override void OnCollisionEnter(Collision other, PlayerManager player) {
			throw new System.NotImplementedException();
		}
	}
}