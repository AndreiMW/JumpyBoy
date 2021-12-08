/**
 * Created Date: 12/8/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

namespace Car {
	public class CarManager : MonoBehaviour {
		[Header("Wheel mesh Transform")]
		
		[SerializeField]
		private Transform _frontLeftWheelTransform;
		[SerializeField] 
		private Transform _frontRightWheelTransform;
		[SerializeField] 
		private Transform _backLeftWheelTransform;
		[SerializeField] 
		private Transform _backRightWheelTransform;

		[Header("Wheel Colliders")]
		
		[SerializeField] 
		private WheelCollider _frontLeftWheelCollider;
		[SerializeField] 
		private WheelCollider _frontRightWheelCollider;
		[SerializeField] 
		private WheelCollider _backLeftWheelCollider;
		[SerializeField] 
		private WheelCollider _backRightWheelCollider;
		
		#region Lifecycle

		private void FixedUpdate() {
			this._frontLeftWheelTransform.Rotate(this.ComputeWheelRotation(this._frontLeftWheelCollider));
			this._frontRightWheelTransform.Rotate(this.ComputeWheelRotation(this._frontRightWheelCollider));
			this._backLeftWheelTransform.Rotate(this.ComputeWheelRotation(this._backLeftWheelCollider));
			this._backRightWheelTransform.Rotate(this.ComputeWheelRotation(this._backRightWheelCollider));
		}

		#endregion
		
		#region Public

		/// <summary>
		/// Set the motor torque of the wheel colliders.
		/// </summary>
		/// <param name="value">The value of the motor torque.</param>
		public void SetMotorTorqueValue(float value) {
			this._frontLeftWheelCollider.motorTorque = value;
			this._frontRightWheelCollider.motorTorque = value;
			this._backLeftWheelCollider.motorTorque = value;
			this._backRightWheelCollider.motorTorque = value;
		}
		
		#endregion
		
		#region Private
		
		private Vector3 ComputeWheelRotation(WheelCollider wheelCollider) {
			Vector3 wheelRotation = new Vector3(wheelCollider.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
			return wheelRotation;
		}
		
		#endregion
	}
}