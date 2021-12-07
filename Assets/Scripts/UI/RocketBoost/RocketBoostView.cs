/**
 * Created Date: 12/7/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;
using UnityEngine.UI;

namespace UI.RocketBoost {
	[RequireComponent(typeof(CanvasGroup))]
	public class RocketBoostView : MonoBehaviour {
	
		[SerializeField]
		private Image _durationFillImage;

		#region Lifecycle
	
		private void Awake() {
			this._durationFillImage.fillAmount = 1f;
		}
	
		#endregion
	
		#region Public

		public void SetFillAmount(float fillAmount) {
			this._durationFillImage.fillAmount = fillAmount;
		}
	
		#endregion

	}
}