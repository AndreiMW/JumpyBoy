/**
* Created Date: 12/6/2021
* Author: Andrei-Florin Ciobanu
* 
* Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
*/

using UnityEngine;

using Distance;
using Managers;

namespace Player.PlayerStates {
	public sealed class PlayerLandedState : BasePlayerState {

		/// <inheritdoc />
		public override void EnterState(PlayerManager player) {
			player.ResetConstraints();
			player.Slow();
			player.BlendCheerAnimation();
			UserSettings.Instance.NumberOfJumps++;
		}

		/// <inheritdoc />
		public override void UpdateState(PlayerManager player) { }

		/// <inheritdoc />
		public override void FixedUpdateState(PlayerManager player) {
			UIManager.Instance.SetDistanceScore(player.transform.position.CalculateDistanceTo(GameManager.Instance.DistanceStartPosition));
			if (player.Rigidbody.velocity.z <= 0.5f) {
				player.SwitchState(player.IdleState);
			}
		}

		/// <inheritdoc />
		public override void OnTriggerEnter(Collider other, PlayerManager player) { }

		/// <inheritdoc />
		public override void OnCollisionEnter(Collision other, PlayerManager player) { }
	}
}