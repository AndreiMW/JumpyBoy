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
		public Rigidbody Rigidbody => this._rigidbody;
		private RigidbodyConstraints _originalConstraints;

		private Vector3 _originalPosition;

		#region Lifecycle

		private void Start() {
			this._rigidbody = this.GetComponent<Rigidbody>();
			//get original RigidBody constraints (pre ramp jumping)
			this._originalConstraints = this._rigidbody.constraints;
			//get original position
			this._originalPosition = this.transform.position;

			//set the current state to idle
			this._currentState = this.IdleState;
			this._currentState.EnterState(this);
		}

		private void Update() {
			this._currentState.UpdateState(this);
		}

		#endregion
	
		#region Collision
	
		private void OnCollisionEnter(Collision other) {
			this._currentState.OnCollisionEnter(other,this);
		}

		private void OnTriggerEnter(Collider other) {
			this._currentState.OnTriggerEnter(other,this);
		}

		#endregion
	
		#region Public
	
		/// <summary>
		/// Switch state.
		/// </summary>
		/// <param name="state">The state to switch to.</param>
		public void SwitchState(BasePlayerState state) {
			this._currentState = state;
			this._currentState.EnterState(this);
		}

		/// <summary>
		/// Push the player down the ramp;
		/// </summary>
		public void PushPlayerToRamp() {
			//push player to ramp
		}
		
		/// <summary>
		/// Boost the player.
		/// </summary>
		public void Boost() {
			//boost
		}

		/// <summary>
		/// Slow the player down.
		/// </summary>
		public void Slow() {
			//set drag to 1 to slow down faster
			this._rigidbody.drag = 1f;
			
			//set y velocity to 0 to avoid bounce on landing
			Vector3 rigidbodyVelocity = this._rigidbody.velocity;
			rigidbodyVelocity.y = 0f;
			this._rigidbody.velocity = rigidbodyVelocity;
		}

		/// <summary>
		/// Set x rotation constraint to the rigidbody so the player keeps the angle he had while leaving the ramp.
		/// </summary>
		public void SetInAirConstraints() {
			this._rigidbody.constraints = RigidbodyConstraints.FreezeRotationX;
		}

		/// <summary>
		/// Reset constraints.
		/// </summary>
		public void ResetConstraints() {
			this._rigidbody.constraints = this._originalConstraints;
		}

		/// <summary>
		/// Reset player properties.
		/// </summary>
		public void Reset() {
			this.transform.position = this._originalPosition;
			this._rigidbody.drag = 0f;
		}

		#endregion
	}
}