/**
 * Created Date: 12/6/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;
using UnityEngine.EventSystems;

namespace Player.PlayerStates {
	public sealed class PlayerIdleState : BasePlayerState {
		private bool _hasTouchedScreen;

		/// <inheritdoc />
		public override  void EnterState(PlayerManager player) {
			this._hasTouchedScreen = false;
			player.Reset();
		}

		/// <inheritdoc />
		public override void UpdateState(PlayerManager player) {
			if (Input.GetMouseButtonDown(0) && !this._hasTouchedScreen) {
				if (EventSystem.current.IsPointerOverGameObject()) {
					return;
				}
				this._hasTouchedScreen = true;
				player.PushPlayerToRamp();
				player.SwitchState(player.OnRampState);
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