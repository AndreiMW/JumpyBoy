/**
* Created Date: 12/6/2021
* Author: Andrei-Florin Ciobanu
* 
* Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
*/

using UnityEngine;

namespace Player.PlayerStates {
	public sealed class PlayerLandedState : BasePlayerState {
		
		/// <inheritdoc />
		public override async void EnterState(PlayerManager player) {
			player.ResetConstraints();
			player.Slow();
		}

		/// <inheritdoc />
		public override void UpdateState(PlayerManager player) {
			if (player.Rigidbody.velocity.z == 0.0f) {
				player.SwitchState(player.IdleState);
			}
		}

		/// <inheritdoc />
		public override void FixedUpdateState(PlayerManager player) { }

		/// <inheritdoc />
		public override void OnTriggerEnter(Collider other, PlayerManager player) { }

		/// <inheritdoc />
		public override void OnCollisionEnter(Collision other, PlayerManager player) { }
	}
}