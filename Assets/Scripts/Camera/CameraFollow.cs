/**
 * Created Date: 12/8/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

public class CameraFollow : MonoBehaviour {
	private static CameraFollow s_instace;
	public static CameraFollow Instace => s_instace ?? (s_instace = FindObjectOfType<CameraFollow>());
		[SerializeField]
		private Transform _target;
		
		[SerializeField] 
		private Vector3 _offset;

		private bool _boostEffect = false;
		private float _originalZOffset;

		#region Lifecycle
		
		private void Start() {
			this._originalZOffset = this._offset.z;
		}

		private void LateUpdate() {
			if (this._boostEffect) {
				if (this._offset.z >= this._originalZOffset + this._originalZOffset * 0.2f) {
					this._offset.z -= Time.deltaTime * 4;
				}
			} else {
				if (this._offset.z <= this._originalZOffset) {
					this._offset.z += Time.deltaTime * 4;
				}
			}
			
			this.transform.position = this._target.position + this._offset;
		}
		
		#endregion
		
		#region Public

		public void BoostEffect(bool shouldBoost) {
			this._boostEffect = shouldBoost;
		}
		
		#endregion
	}