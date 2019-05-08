using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonScript : MonoBehaviour {

	// Use this for initialization
	public void BackGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 2);
	}
}
