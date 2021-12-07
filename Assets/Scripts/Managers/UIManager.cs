/**
* Created Date: 12/7/2021
* Author: Andrei-Florin Ciobanu
* 
* Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
*/

using UnityEngine;
using UnityEngine.UI;

using UI.RocketBoost;

namespace Managers {
	public class UIManager : MonoBehaviour {
		private static UIManager s_instace;
		public static UIManager Instance => s_instace ?? (s_instace = FindObjectOfType<UIManager>());

		[SerializeField] 
		private RocketBoostView _rocketBoostView;

		[SerializeField] 
		private Text _scoreText;

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
		
	}
}