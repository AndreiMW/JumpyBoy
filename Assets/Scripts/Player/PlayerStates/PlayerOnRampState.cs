/**
* Created Date: 12/6/2021
* Author: Andrei-Florin Ciobanu
* 
* Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
*/

using UnityEngine;

using Managers;

namespace Player.PlayerStates { 
	public sealed class PlayerOnRampState : BasePlayerState {
		private bool _shouldBoost = false;
		private int _rampLevel;

		/// <inheritdoc />
		public override void EnterState(PlayerManager player) {
			this._rampLevel = GameManager.Instance.RampBoostLevel;
			UIManager.Instance.HideUI();
			player.BlendDrivingAnimation();
		}

		/// <inheritdoc />
		public override void UpdateState(PlayerManager player) { }

		/// <inheritdoc />
		public override void FixedUpdateState(PlayerManager player) {
			if (this._shouldBoost) {
				player.Rigidbody.AddForce(player.Rigidbody.transform.forward * (Time.fixedDeltaTime * this._rampLevel * 200f), ForceMode.Impulse);
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
		public override void OnCollisionEnter(Collision other, PlayerManager player) { }
	}
}