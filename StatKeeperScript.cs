using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatKeeperScript : MonoBehaviour {

	public GameObject statBars;
	// Use this for initialization
	public static Dictionary<string, int> stats = new Dictionary<string, int>();
    public static Dictionary<string, int> statrate = new Dictionary<string, int>();
	public static int gameTime = 0;




	public void OnSceneLoaded() {
		/*stats.Add ("Wisdom", 0); //change in initial values remaining
		stats.Add ("Satisfaction", 0);
		stats.Add ("Respect", 0);
		stats.Add ("Confidence", 0);
		stats.Add ("PhysicalHealth", 0);
		stats.Add ("Motivation", 0);
		stats.Add ("Awareness", 0);
		stats.Add ("Experience", 0);
		stats.Add ("Wisdom", 0); //change in initial values remaining */
		stats = new Dictionary<string, int>();
		statrate = new Dictionary<string, int>();
		stats ["Wisdom"] = 0;
		stats["Satisfaction"] = 50;
		stats["Respect"] = 50;
		stats["Confidence"] = 50;
		stats["PhysicalHealth"] = 50;
		stats["Motivation"] = 50;
		stats["Awareness"] = 50;
		stats["Experience"] = 0;
        statrate["Wisdom"] = 0;
        statrate["Satisfaction"] = 0;
        statrate["Respect"] = 0;
        statrate["Confidence"] = 0;
        statrate["PhysicalHealth"] = 0;
        statrate["Motivation"] = 0;
        statrate["Awareness"] = 0;
        statrate["Experience"] = 0;
        gameTime = 0;
	}


	public void updateStats(Dictionary<string, int> changeInStats,Dictionary<string,int> rateOfChangeOfStats, int time){

		foreach (KeyValuePair<string, int> stat in changeInStats) {
			stats [stat.Key] += stat.Value;
		}

		foreach (KeyValuePair<string, int> stat in statrate) {
			stats [stat.Key] += stat.Value * (time - gameTime);
		}

		foreach (KeyValuePair<string, int> stat in rateOfChangeOfStats)
        {
            statrate[stat.Key] += stat.Value;
        }
           
		gameTime = time;

        statBars.GetComponent<DisplayStats> ().displayStats ();
	}
    

}
