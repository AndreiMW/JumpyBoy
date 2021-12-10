/**
 * Created Date: 12/8/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using DG.Tweening;
using UnityEngine;

public class CameraBoostEffect : MonoBehaviour {
	private static CameraBoostEffect s_instace;
	public static CameraBoostEffect Instace => s_instace ?? (s_instace = FindObjectOfType<CameraBoostEffect>());
	
	private Camera _camera;

	#region Lifecycle

	private void Awake() {
		this._camera = Camera.main;
	}

	#endregion
	
	#region Public

	public void PlayCameraBoostEffect(float value, float duration) {
		DOTween.To(()=> this._camera.fieldOfView,x => this._camera.fieldOfView = x,value,duration);
	}
	
	#endregion
}