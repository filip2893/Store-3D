using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;

public class FilterMenu : MonoBehaviour {
	public GameObject player;
	public Dropdown dropdown;
	public InputField input;

	private static GameObject [] entities;
	// Use this for initialization
	void Start () {
		entities = GameObject.FindGameObjectsWithTag("entity");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnEnable(){
		player.SetActive (false);
	}
	void OnDisable(){
		player.SetActive (true);
	}

	public void search(){
		getEntities ();
	}

	public void showAllEntities(){
		foreach (GameObject en in entities) {
			en.SetActive (true);
		}
		this.gameObject.SetActive (false);
	}

	void getEntities(){	
		bool show = false;
		if (dropdown.value == 0) {
			foreach (GameObject en in entities) {
				show = comparator (en.GetComponent<Entity> ().sifra, input.text.ToString ());
				en.SetActive (show);
			}
		}else if(dropdown.value == 1){
			foreach (GameObject en in entities) {
				show = comparator (en.GetComponent<Entity> ().name, input.text.ToString ());
				en.SetActive (show);
			}					
		}
		this.gameObject.SetActive (false);
	}

	private bool comparator(string val1, string val2){
		if (val1 == val2) {
			return true;
		} else {
			return false;
		}
	}
}
