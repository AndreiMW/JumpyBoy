/**
 * Created Date: 12/7/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

namespace Distance {
	public static class DistanceHelper {
		public static float CalculateDistanceTo(this Vector3 currentPos, Vector3 startPos) {
			return Vector3.Distance(currentPos, startPos);
		}
	}
}