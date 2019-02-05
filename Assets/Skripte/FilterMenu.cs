using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;

public class FilterMenu : MonoBehaviour {
	public GameObject player;
	public GameObject dropdowns;
	public GameObject inputs;
	public Button add;
	public Button filter;
	public Dropdown dropdown;
	public InputField input;

	private Vector2 position;
	private static float dropdownY = 0;
	private static float inputY = 0;
	private GameObject[] tagDropdowns;
	private GameObject[] tagInputs;
	// Use this for initialization
	void Start () {
		position = new Vector2 ();
		dropdownY = dropdown.transform.position.y;
		inputY = input.transform.position.y;
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

	public void addClick(){
		dropdownInstatiate ();
		inputInstatiate ();
	}

	public void filterClick(){
		getEntites ();
	}

	private string buildQuery(){
		string query = "";
		query += GameObject.FindGameObjectWithTag("atributesDropdown").GetComponentInChildren<Text> ().text + "=";
		query += "'" + GameObject.FindGameObjectWithTag("atributesInput").GetComponentInChildren<Text> ().text + "'";
		tagDropdowns = GameObject.FindGameObjectsWithTag("atributesDropdownChild");
		tagInputs = GameObject.FindGameObjectsWithTag("atributesInputChild");

		if (tagDropdowns.Length > 0) {
			for(int i = 0; i < tagDropdowns.Length; i++){
				query += "and " + tagDropdowns [i].GetComponentInChildren<Text> ().text + "=";
				query += "'" +  tagInputs [i].GetComponentInChildren<Text> ().text + "'";
			}
		}
		return query;
	}

	void dropdownInstatiate(){
		dropdownY -= 45;
		setPosition (dropdown.transform.position.x, dropdownY);
		Dropdown newdd = Instantiate (dropdown, position, Quaternion.identity) as Dropdown;
		newdd.transform.SetParent(dropdowns.transform);
		newdd.tag = "atributesDropdownChild";
	}
	void inputInstatiate(){
		inputY -= 45;
		setPosition (input.transform.position.x, inputY);
		InputField newif = Instantiate (input, position, Quaternion.identity) as InputField;
		newif.transform.SetParent(inputs.transform);
		newif.tag = "atributesInputChild";
	}

	private void setPosition(float x, float y){
		position.x = x;
		position.y = y;
	}

	void getEntites(){
		Selektor selektor = Selektor.getInstance ();
		string query = buildQuery ();
		Debug.Log (query);
		foreach (DataRow e in selektor.getAtributi().Select(query)) {
			Debug.Log( e["EntietiID"].ToString ());
		}
	}
}
