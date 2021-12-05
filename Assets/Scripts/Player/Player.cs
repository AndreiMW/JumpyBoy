/**
 * Created Date: 12/5/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using System;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody _rigidbody;
	private RigidbodyConstraints _originalConstraints;
	
	
	#region Lifecycle

	private void Start() {
		this._rigidbody = this.GetComponent<Rigidbody>();
		this._originalConstraints = this._rigidbody.constraints;
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
}