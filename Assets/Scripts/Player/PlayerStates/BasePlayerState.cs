/**
 * Created Date: 12/6/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

namespace Player.PlayerStates {
	public abstract class BasePlayerState {
		/// <summary>
		/// Method for state to handle state entering.
		/// </summary>
		/// <param name="player">The player controller.</param>
		public abstract void EnterState(PlayerManager player);
		
		/// <summary>
		/// Method for state to handle update loops.
		/// </summary>
		/// <param name="player">The player controller.</param>
		public abstract void UpdateState(PlayerManager player);
		
		/// <summary>
		/// Method for the state to handle trigger entering.
		/// </summary>
		/// <param name="other">The object trigger.</param>
		/// <param name="player">The player controller.</param>
		public abstract void OnTriggerEnter(Collider other,PlayerManager player);
		
		/// <summary>
		/// Method for the state to handle collision entering.
		/// </summary>
		/// <param name="other">The object it collided with.</param>
		/// <param name="player">The player controller.</param>
		public abstract void OnCollisionEnter(Collision other,PlayerManager player);
	}	
}