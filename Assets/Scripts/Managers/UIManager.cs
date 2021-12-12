/**
* Created Date: 12/7/2021
* Author: Andrei-Florin Ciobanu
* 
* Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
*/

using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

using UI.RocketBoost;
using UI.Shop;

namespace Managers {
	public class UIManager : MonoBehaviour {
		private static UIManager s_instace;
		public static UIManager Instance => s_instace ?? (s_instace = FindObjectOfType<UIManager>());

		[Header("Rocket boost duration view")]
		[SerializeField] 
		private RocketBoostView _rocketBoostView;

		[Header("Score text")]
		[SerializeField] 
		private Text _scoreText;

		[Header("Tap to start view")]
		[SerializeField]
		private CanvasGroup _tapToStart;

		[Header("Upgrade ramp speed level button")]
		[SerializeField] 
		private CanvasGroup _upgradeRampButton;
		
		[Header("Upgrade boost duration level button")]
		[SerializeField]
		private CanvasGroup _upgradeBoostButton;
		
		[Header("Ramp level button text")]
		[SerializeField]
		private Text _rampLevelText;
		
		[Header("Boost level button text")]
		[SerializeField]
		private Text _boostLevelText;

		[Header("Longest distance view")]
		[SerializeField] 
		private CanvasGroup _longestDistanceTextCanvasGroup;

		[Header("Longest distance score text")]
		[SerializeField] 
		private Text _longestDistanceScoreText;

		[Header("Shop controller")]
		[SerializeField] 
		private ShopViewController _shopViewController;
		public ShopViewController ShopViewController => this._shopViewController;


		#region Lifecycle

		private void Start() {
			this.SetRampLevel(UserSettings.Instance.RampLevel);
			this.SetBoostLevel(UserSettings.Instance.BoostLevel);
		}
		
		#endregion

		#region Public
		
		/// <summary>
		/// Set the fill amount for the boost left.
		/// </summary>
		/// <param name="boostAmount">The available boost amoount.</param>
		public void SetBoostAmount(float boostAmount) {
			this._rocketBoostView.SetBoostAmount(boostAmount);
		}

		/// <summary>
		/// Set the distance in the score text.
		/// </summary>
		/// <param name="distance">The user's current distance.</param>
		public void SetDistanceScore(float distance) {
			this._scoreText.text = ((int) distance).ToString();
		}

		/// <summary>
		/// Set ramp level text.
		/// </summary>
		/// <param name="rampLevel">The ramp level.</param>
		public void SetRampLevel(int rampLevel) {
			this._rampLevelText.text = rampLevel == 10 ? "MAX" : $"LEVEL {rampLevel}";
		}
		
		/// <summary>
		/// Set boost level text.
		/// </summary>
		/// <param name="boostLevel">The boost level.</param>
		public void SetBoostLevel(int boostLevel) {
			this._boostLevelText.text = boostLevel == 10 ? "MAX" : $"LEVEL {boostLevel}";
		}

		/// <summary>
		/// Hide preliminary UI.
		/// </summary>
		public void HideUI() {
			this._tapToStart.DOFade(0f, 0.5f);
			
			this._upgradeRampButton.DOFade(0f, 0.5f);
			this._upgradeBoostButton.DOFade(0f, 0.5f);
			
			this._longestDistanceTextCanvasGroup.DOFade(0f, 0.5f);
			
			this.ShopViewController.ShopIconCanvasGroup.DOFade(0f, 0.5f);
			
			this.SetUpgradeRampButtonInteractableState(false);
			this.SetUpgradeBoostButtonInteractableState(false);
		}

		/// <summary>
		/// Show UI.
		/// </summary>
		public void ShowUI() {
			this._tapToStart.DOFade(1f, 0.5f);
			this._upgradeRampButton.DOFade(1f, 0.5f);
			this._upgradeBoostButton.DOFade(1f, 0.5f);

			this.SetLongestDistanceText();
			this._longestDistanceTextCanvasGroup.DOFade(1f, 0.5f);
			
			this.ShopViewController.ShopIconCanvasGroup.DOFade(1f, 0.5f);
			
			this.SetUpgradeRampButtonInteractableState(true);
			this.SetUpgradeBoostButtonInteractableState(true);
		}

		/// <summary>
		/// Set the interactable state for the upgrade ramp level button.
		/// </summary>
		/// <param name="isEnabled">Is interaction enabled?</param>
		public void SetUpgradeRampButtonInteractableState(bool isEnabled) {
			this._upgradeRampButton.interactable = isEnabled;
		}
		
		/// <summary>
		/// Set the interactable state for the upgrade boost level button.
		/// </summary>
		/// <param name="isEnabled">Is interaction enabled?</param>
		public void SetUpgradeBoostButtonInteractableState(bool isEnabled) {
			this._upgradeBoostButton.interactable = isEnabled;
		}

		/// <summary>
		/// Set the longest distance the user has jumped.
		/// </summary>
		/// <param name="score">The user's score.</param>
		private void SetLongestDistanceText() {
			this._longestDistanceScoreText.text = UserSettings.Instance.LongestJump.ToString();
		}
		
		#endregion
		
	}
}