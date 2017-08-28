using UnityEngine;
using System.Collections;

public static class Difficulty{
	static float secondsToMaxDifficulty = 60;

	public static float getDifficultyPercentage(){
		//return 1;
		return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
	}
}
