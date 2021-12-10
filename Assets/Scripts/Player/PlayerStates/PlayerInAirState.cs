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
	public sealed class PlayerInAirState : BasePlayerState {
		private float _maxBoostDuration;
		private float _currentDuration;
		private bool _isPlayingBoostEffect;
		
		/// <inheritdoc />
		public override void EnterState(PlayerManager player) {
			player.SetInAirConstraints();
			this._maxBoostDuration = GameManager.Instance.BoostDurationLevel / 2f;
			this._currentDuration = this._maxBoostDuration;
		}

		/// <inheritdoc />
		public override void UpdateState(PlayerManager player) {}

		/// <inheritdoc />
		public override void FixedUpdateState(PlayerManager player) {
			UIManager.Instance.SetDistanceScore(player.transform.position.CalculateDistanceTo(GameManager.Instance.DistanceStartPosition));
			
			if (Input.GetMouseButton(0) && this._currentDuration > 0.0f) {
				player.Boost();
				this._currentDuration -= Time.fixedDeltaTime;
				UIManager.Instance.SetBoostAmount(this._currentDuration / this._maxBoostDuration);
				if (!this._isPlayingBoostEffect) {
					player.CarManager.StartBoostEffect();
					CameraBoostEffect.Instace.PlayCameraBoostEffect(80f, 0.25f);
					this._isPlayingBoostEffect = true;
				}
			} else {
				if (this._isPlayingBoostEffect) {
					player.CarManager.StopBoostEffect();
					CameraBoostEffect.Instace.PlayCameraBoostEffect(60f, 0.25f);
					this._isPlayingBoostEffect = false;
				}
			}
		}

		/// <inheritdoc />
		public override void OnTriggerEnter(Collider other, PlayerManager player) { }
		
		/// <inheritdoc />
		public override void OnCollisionEnter(Collision other, PlayerManager player) {
			if (other.collider.CompareTag("Ground")) {
				player.CarManager.StopBoostEffect();
				CameraBoostEffect.Instace.PlayCameraBoostEffect(60f, 0.25f);
				this._isPlayingBoostEffect = false;
				player.SwitchState(player.LandedState);
			}
		}
	}
}