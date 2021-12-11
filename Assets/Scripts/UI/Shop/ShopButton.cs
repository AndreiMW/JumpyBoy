/**
 * Created Date: 12/11/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using System;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Shop {
	[RequireComponent(typeof(CanvasGroup))]
	public class ShopButton : MonoBehaviour, IPointerClickHandler {
		public ShopButtonEvent MouseButtonDown;
		[SerializeField] 
		private int _numberOfJumpsRequired;

		[SerializeField] 
		private Graphic _targetGraphic;

		[SerializeField]
		private Color _carColorToSet;

		[SerializeField] 
		private Color _availableColor;

		[SerializeField] 
		private Color _notAvailableColor;

		[SerializeField] 
		private CanvasGroup _notEnoughJumpsView;
		
		private Color _originalColor;

		private bool _isAvailableToBuy = false;

		private void Awake() {
			this._originalColor = this._targetGraphic.color;
			this._notEnoughJumpsView.alpha = 0f;
		}

		public void OnPointerClick(PointerEventData eventData) {
			if (this._isAvailableToBuy) {
				this._targetGraphic.color = this._originalColor;
				this.MouseButtonDown?.Invoke(eventData, this._carColorToSet);	
			}
		}

		/// <summary>
		/// Check if there are enough jumps to buy car color.
		/// </summary>
		/// <param name="currentJumps"></param>
		public void CheckIfEnoughJumps(int currentJumps) {
			if (currentJumps < this._numberOfJumpsRequired) {
				this._notEnoughJumpsView.alpha = 1f;
				this._isAvailableToBuy = false;
				this._targetGraphic.color = this._notAvailableColor;
			} else {
				this._notEnoughJumpsView.alpha = 0f;
				this._isAvailableToBuy = true;
				this._targetGraphic.color = this._availableColor;
			}
		}
	}

	[Serializable]
	public class ShopButtonEvent : UnityEvent<PointerEventData, Color> { }

}