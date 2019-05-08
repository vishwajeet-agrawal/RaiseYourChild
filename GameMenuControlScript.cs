using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenuControlScript : MonoBehaviour {

	// Use this for initialization
	public Button submit_button;
	public GameObject notification;
	public GameObject question;
	public GameObject choice_1_implication;
	public GameObject choice_2_implication;
	public GameObject choice_1_text;
	public GameObject choice_2_text;
	public GameObject event_bank;
	public GameObject statKeeper;
	QuestionBankScript.Event new_event;
	QuestionBankScript.Event curr_event;
	//public GameObject 
	int timer = 0;
	private void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable() {
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}


	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		//event_bank.GetComponent<QuestionBankScript> ().initialize_all ();
		//new_event = event_bank.GetComponent<QuestionBankScript> ().GetNextEvent (0);
		//Debug.Log (new_event);
	}

	void Start(){
		event_bank.GetComponent<QuestionBankScript> ().initialize_all ();
		statKeeper.GetComponent<StatKeeperScript> ().OnSceneLoaded ();
		curr_event = event_bank.GetComponent<QuestionBankScript> ().GetNextEvent (0);
		new_event = curr_event;
		Debug.Log (new_event);
		question.SetActive (true);
		notification.SetActive (false);
		submit_button.gameObject.SetActive (true);
		//notification.transform.Find ("Notification_text").gameObject.GetComponent<TextMeshProUGUI> ().text = new_event.not.notification_text;
		choice_1_implication.SetActive(true);
		choice_2_implication.SetActive(false);
		display_next_event ();
	}

	public void display_next_event(){ // also submit the current event
		//question_bank 
		if (curr_event.type_of_event == 1) {
			if (choice_1_implication.activeSelf) {
				new_event = event_bank.GetComponent<QuestionBankScript> ().GetNextEvent (0);
			} else if (choice_2_implication.activeSelf) {
				new_event = event_bank.GetComponent<QuestionBankScript> ().GetNextEvent (1);
			} 
		}
		else {
			new_event = event_bank.GetComponent<QuestionBankScript> ().GetNextEvent (0);
		}
		//submit_button.gameObject.SetActive (false);
		if (curr_event.type_of_event == 0) {
			Dictionary<string, int> temp = new Dictionary<string, int> ();
			Debug.Log (curr_event.not);
			Debug.Log (new_event.time);
			statKeeper.GetComponent<StatKeeperScript> ().updateStats (curr_event.not.statEffectImpulse, temp, new_event.time);
		} 
		else if (curr_event.type_of_event == 1){
			if (choice_1_implication.activeSelf) {
				statKeeper.GetComponent<StatKeeperScript>().updateStats (curr_event.qs.choice_1.statEffectImpulse, curr_event.qs.choice_1.statEffectRate, new_event.time);
			} 
			else if(choice_2_implication.activeSelf){
				statKeeper.GetComponent<StatKeeperScript>().updateStats(curr_event.qs.choice_2.statEffectImpulse, curr_event.qs.choice_2.statEffectRate, new_event.time);
			}
		}


			if (!(new_event.is_display)) {
				question.SetActive (false);
				notification.SetActive (false);
				display_next_event ();
			}
			 else {
				if (new_event.type_of_event == 0) {
					notification.SetActive (true);
					question.SetActive (false);
					submit_button.gameObject.SetActive (true);
					notification.transform.Find ("Notification_text").gameObject.GetComponent<TextMeshProUGUI> ().text = new_event.not.notification_text;
				} else if (new_event.type_of_event == 1) {
					question.SetActive (true);
					notification.SetActive (false);
					question.transform.Find ("Scenario_text").gameObject.GetComponent<TextMeshProUGUI>().text = new_event.qs.question_text;
					/*choice_1_implication.SetActive (false);
					choice_2_implication.SetActive (false);*/
					//choice_1_implication.transform.parent.gameObject.SetActive (true);
					//choice_2_implication.transform.parent.gameObject.SetActive (true);
					choice_1_implication.SetActive(false);
					choice_2_implication.SetActive(false);
					choice_1_implication.GetComponent<TextMeshProUGUI>().text = new_event.qs.choice_1.choice_implication;
					choice_2_implication.GetComponent<TextMeshProUGUI>().text = new_event.qs.choice_2.choice_implication;
					//choice_1_implication.transform.parent.gameObject.transform.Find("Choice_1_button")
					//choice_1_implication.transform.Fi
					choice_1_text.transform.parent.gameObject.SetActive(true);
					choice_2_text.transform.parent.gameObject.SetActive(true);
					choice_1_text.GetComponent<TextMeshProUGUI> ().text = new_event.qs.choice_1.choice_text;
					choice_2_text.GetComponent<TextMeshProUGUI> ().text = new_event.qs.choice_2.choice_text;
					
					submit_button.gameObject.SetActive (false);
				}

			}
		
		curr_event = new_event;
	}

	void Update(){
		//display_next_event ();
		//timer += Time.deltaTime*1000;
	}

	public void onSubmit(){
		/*bool ques_prev = question.activeSelf;
		bool notification_prev = notification.activeSelf;
		bool submit_prev = submit_button.gameObject.activeSelf;
		question.SetActive(false);
		notification.SetActive(false);
		submit_button.gameObject.SetActive(false);

		for (int i = 0; i < 1000000000 * curr_event.wait_time; ++i) {
		
		}*/

		/*question.SetActive(ques_prev);
		notification.SetActive(notification_prev);
		submit_button.gameObject.SetActive(submit_prev);*/
		display_next_event ();

		if (notification.activeSelf) {


		}
		else if(question.activeSelf){


		}

	}


}
