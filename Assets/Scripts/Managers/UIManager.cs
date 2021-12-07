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

namespace Managers {
	public class UIManager : MonoBehaviour {
		private static UIManager s_instace;
		public static UIManager Instance => s_instace ?? (s_instace = FindObjectOfType<UIManager>());

		[SerializeField] 
		private RocketBoostView _rocketBoostView;

		[SerializeField] 
		private Text _scoreText;

		[SerializeField]
		private CanvasGroup _tapToStart;

		[SerializeField] 
		private CanvasGroup _upgradeRampButton;
		
		[SerializeField]
		private CanvasGroup _upgradeBoostButton;
		
		[SerializeField]
		private Text _rampLevelText;
		
		[SerializeField]
		private Text _boostLevelText;
		
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
		}

		/// <summary>
		/// Show UI.
		/// </summary>
		public void ShowUI() {
			this._tapToStart.DOFade(1f, 0.5f);
			this._upgradeRampButton.DOFade(1f, 0.5f);
			this._upgradeBoostButton.DOFade(1f, 0.5f);
		}
		
		#endregion
		
	}
}