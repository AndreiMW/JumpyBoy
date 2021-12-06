/**
 * Created Date: 12/6/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

namespace Player.PlayerStates {
	public abstract class BasePlayerState {
		public abstract void EnterState(PlayerManager player);
		public abstract void UpdateState(PlayerManager player);
		public abstract void OnTriggerEnter(PlayerManager player);
		public abstract void OnCollisionEnter(PlayerManager player);
	}	
}