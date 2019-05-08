using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour {

	public GameObject statKeeper;

	public Slider wisdomSlider;
	public Slider satisfactionSlider;
	public Slider respectSlider;
	public Slider confidenceSlider;
	public Slider physicalHealthSlider;
	public Slider motivationSlider;
	public Slider awarenessSlider;
	public Slider experienceSlider;
	// Use this for initialization
	public void displayStats(){
		Dictionary<string, int> stats = StatKeeperScript.stats;
		try{
		satisfactionSlider.value = stats["Satisfaction"];
		respectSlider.value = stats["Respect"];
		confidenceSlider.value = stats["Confidence"];
		physicalHealthSlider.value = stats["PhysicalHealth"];
		motivationSlider.value = stats ["Motivation"];
		awarenessSlider.value = stats["Awareness"];
		experienceSlider.value = stats["Experience"]; 
		}
		catch(Exception e){
		}
	}

	void Update(){
		displayStats ();
	}

}
