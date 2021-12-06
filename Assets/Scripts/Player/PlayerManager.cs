/**
 * Created Date: 12/5/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using Player.PlayerStates;
using UnityEngine;

namespace Player {
	public class PlayerManager : MonoBehaviour {
		private BasePlayerState _currentState;

		public readonly PlayerIdleState IdleState = new PlayerIdleState();
		public readonly PlayerOnRampState OnRampState = new PlayerOnRampState();
		public readonly PlayerInAirState InAirState = new PlayerInAirState();
		public readonly PlayerLandedState LandedState = new PlayerLandedState();
	
		private Rigidbody _rigidbody;
		private RigidbodyConstraints _originalConstraints;
	
	
		#region Lifecycle

		private void Start() {
			this._rigidbody = this.GetComponent<Rigidbody>();
			this._originalConstraints = this._rigidbody.constraints;

			this._currentState = this.IdleState;
			this._currentState.EnterState(this);
		}

		#endregion
	
		#region Collision
	
		private void OnCollisionEnter(Collision other) {
			if (other.gameObject.CompareTag("Ground")) {
				this._rigidbody.constraints = this._originalConstraints;
			}
		}

		private void OnTriggerEnter(Collider other) {
			if (other.gameObject.CompareTag("RampEnd")) {
				this._rigidbody.constraints = RigidbodyConstraints.FreezeRotationX;
			}
		}

		#endregion
	
		#region Public
	
		public void SwitchState(BasePlayerState state) {
			this._currentState = state;
			this._currentState.EnterState(this);
		}

		public void PushPlayerToRamp() {
			//implement pushing player to ramp
		}
	
		#endregion
	}
}