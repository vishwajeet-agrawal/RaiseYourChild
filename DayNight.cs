using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {

	// Use this for initialization
	public GameObject light;
	float x;
	void Update(){
		x += Time.deltaTime * 10;
		transform.rotation = Quaternion.Euler (41, x, 30);
	}
}
