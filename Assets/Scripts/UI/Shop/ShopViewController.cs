/**
 * Created Date: 12/11/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using System;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using DG.Tweening;

namespace UI.Shop {
	public class ShopViewController : MonoBehaviour {
		[SerializeField]
		private Button _openShopButton;

		[SerializeField] 
		private CanvasGroup _shopView;

		[SerializeField] 
		private ShopButton[] _shopButtons;

		[SerializeField] 
		private Button _closeButton;

		public event Action<Color> OnColorBought;

		#region Lifecycle
		
		private void Awake() {
			this._openShopButton.onClick.AddListener(this.ShowShopView);
			foreach (ShopButton shopButton in this._shopButtons) {
				shopButton.MouseButtonDown.AddListener(this.HandleShopButtonPress);
			}
			this._closeButton.onClick.AddListener(this.CloseShop);
		}
		
		#endregion

		#region Private

		private void ShowShopView() {
			int currentNumberOfJumps = UserSettings.Instance.NumberOfJumps;
			foreach (ShopButton shopButton in this._shopButtons) {
				shopButton.CheckIfEnoughJumps(currentNumberOfJumps);
			}
			
			this._shopView.transform.DOScale(1f, 0.1f);
			this._shopView.DOFade(1f, 0.1f);
		}

		private void HandleShopButtonPress(PointerEventData data, Color color) {
			this.OnColorBought?.Invoke(color);
			this.CloseShop();
		}

		private void CloseShop() {
			this._shopView.transform.DOScale(0f, 0.1f);
			this._shopView.DOFade(0f, 0.1f);
		}
		
		#endregion
		
	}
}