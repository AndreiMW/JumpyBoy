/**
 * Created Date: 12/7/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

public class UserSettings {
	private static UserSettings s_instance;
	public static UserSettings Instance => s_instance ?? (s_instance = new UserSettings());

	/// <summary>
	/// Persisted ramp level.
	/// </summary>
	public int RampLevel {
		get => this.GetRampLevel();
		set => this.SetRampLevel(value);
	}
	
	/// <summary>
	/// Persisted boost level.
	/// </summary>
	public int BoostLevel {
		get => this.GetBoostLevel();
		set => this.SetBoostLevel(value);
	}

	/// <summary>
	/// Persisted number of jumps.
	/// </summary>
	public int NumberOfJumps {
		get => this.GetJumps();
		set => this.SetJumps(value);
	}

	public bool CanJump = true;
	
	#region Private	

	private int GetRampLevel() {
		return PlayerPrefs.GetInt("ramp_level", 1);
	}

	private void SetRampLevel(int value) {
		PlayerPrefs.SetInt("ramp_level", value);
	}
	
	private int GetBoostLevel() {
		return PlayerPrefs.GetInt("boost_level", 1);
	}

	private void SetBoostLevel(int value) {
		PlayerPrefs.SetInt("boost_level", value);
	}
	
	private int GetJumps() {
		return PlayerPrefs.GetInt("jumps", 0);
	}

	private void SetJumps(int value) {
		PlayerPrefs.SetInt("jumps", value);
	}
	
	#endregion
	
}