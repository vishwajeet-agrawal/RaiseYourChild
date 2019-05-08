using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SubmitScript : MonoBehaviour {

	// Use this for initialization
	public GameObject name;
	public void OnSubmit(){
		PlayerPrefs.SetString ("Child_Name", name.GetComponent<TMP_InputField>().text);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
