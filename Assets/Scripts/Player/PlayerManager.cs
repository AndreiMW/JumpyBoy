/**
 * Created Date: 12/5/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

using DG.Tweening;

using Car;
using Player.PlayerStates;

namespace Player {
	public class PlayerManager : MonoBehaviour {
		[Header("Car Manager")]
		[SerializeField]
		private CarManager _carManager;
		public CarManager CarManager => this._carManager;
		
		[Header("Driver Animator")]
		[SerializeField]
		private Animator _playerAnimator;
		
		[Header("Heart beats effect")]
		[SerializeField] 
		private AudioClip[] _heartBeatClips;
		
		private Rigidbody _rigidbody;
		public Rigidbody Rigidbody => this._rigidbody;
		
		private RigidbodyConstraints _originalConstraints;

		private Vector3 _originalPosition;

		private readonly int _blendSpeedHash = Animator.StringToHash("BlendSpeed");
		private float _blendSpeed {
			get =>  this._playerAnimator.GetFloat(this._blendSpeedHash);
			set => this._playerAnimator.SetFloat(this._blendSpeedHash, value);
		}

		private AudioSource _audioSource;

		public enum HeartBeatStates {
			Idle = 0,
			OnRamp = 1,
			Boosting = 2
		}
		
		private BasePlayerState _currentState;

		public readonly PlayerIdleState IdleState = new PlayerIdleState();
		public readonly PlayerOnRampState OnRampState = new PlayerOnRampState();
		public readonly PlayerInAirState InAirState = new PlayerInAirState();
		public readonly PlayerLandedState LandedState = new PlayerLandedState();
		
		#region Lifecycle

		private void Start() {
			this._audioSource = this.GetComponent<AudioSource>();
			
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

		private void FixedUpdate() {
			this._currentState.FixedUpdateState(this);
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
			this._carManager.SetMotorTorqueValue(0.000001f);			
			this._rigidbody.AddForce(this.transform.forward * (Time.fixedDeltaTime * 500 * this._rigidbody.mass), ForceMode.Impulse);
		}
		
		/// <summary>
		/// Boost the player.
		/// </summary>
		public void Boost() {
			this._rigidbody.AddForce(this.transform.forward * (Time.fixedDeltaTime * 20f * this._rigidbody.mass), ForceMode.Impulse);
		}

		/// <summary>
		/// Slow the player down.
		/// </summary>
		public void Slow() {
			//set drag to 1 to slow down faster
			this._rigidbody.drag = 0.25f;
			
			//set y velocity to 0 to avoid bounce on landing
			Vector3 rigidbodyVelocity = this._rigidbody.velocity;
			rigidbodyVelocity.y = 0f;
			this._rigidbody.velocity = rigidbodyVelocity;
		}

		/// <summary>
		/// Set x rotation constraint to the rigidbody so the player keeps the angle he had while leaving the ramp.
		/// </summary>
		public void SetInAirConstraints() {
			this._rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
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
			this._rigidbody.velocity = Vector3.zero;
			this._carManager.SetMotorTorqueValue(0f);
		}

		/// <summary>
		/// Blend to driving animation.
		/// </summary>
		public void BlendDrivingAnimation() {
			DOTween.To(() => this._blendSpeed, value => this._blendSpeed = value, 0.5f, 1f);
		}
		
		/// <summary>
		/// Blend to cheer animation.
		/// </summary>
		public void BlendCheerAnimation() {
			DOTween.To(() => this._blendSpeed, value => this._blendSpeed = value, 1f, 1f);
		}
		
		/// <summary>
		/// Blend to clap animation.
		/// </summary>
		public void BlendClapAnimation() {
			this._blendSpeed = 0f;
		}

		/// <summary>
		/// Set the heart beat sound effect.
		/// </summary>
		/// <param name="state">The state of the heart beat audio source.</param>
		public void SetHeartBeatAudioClip(HeartBeatStates state) {
			this.StopHeartBeatAudioSource();
			this._audioSource.clip = this._heartBeatClips[(int) state];
			this._audioSource.Play();
		}

		/// <summary>
		/// Stop the heart beat sound effect.
		/// </summary>
		public void StopHeartBeatAudioSource() {
			this._audioSource.Stop();
		}

		#endregion
	}
}