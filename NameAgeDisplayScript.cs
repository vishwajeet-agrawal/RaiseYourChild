using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameAgeDisplayScript : MonoBehaviour {

	public GameObject display; 
	//public TextMeshProUGUI meshpro;

	// Use this for initialization

	public void DisplayPlayerAge(){
		string playerName = PlayerPrefs.GetString("Child_Name", "Child");
		int age_years = (StatKeeperScript.gameTime) / 12;
		int age_months = (StatKeeperScript.gameTime) % 12;
		TextMeshProUGUI temp = display.GetComponent<TextMeshProUGUI> ();
		temp.text = playerName + "\n" + age_years.ToString () + " years " + age_months.ToString () + " months";
	}
	// Update is called once per frame

}
