/**
* Created Date: 12/6/2021
* Author: Andrei-Florin Ciobanu
* 
* Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
*/

using UnityEngine;

namespace Player.PlayerStates { 
	public sealed class PlayerOnRampState : BasePlayerState {
		
		/// <inheritdoc />
		public override void EnterState(PlayerManager player) {
			throw new System.NotImplementedException();
		}

		/// <inheritdoc />
		public override void UpdateState(PlayerManager player) {
		}

		/// <inheritdoc />
		public override void OnTriggerEnter(Collider other, PlayerManager player) {
			if (other.CompareTag("RampEnd")) {
				player.SwitchState(player.InAirState);
			}
		}

		/// <inheritdoc />
		public override void OnCollisionEnter(Collision other, PlayerManager player) {
			throw new System.NotImplementedException();
		}
	}
}