using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;

public class FilterMenu : MonoBehaviour {
	public GameObject player;
	public Button add;
	public Button filter;
	public Dropdown dropdown;
	public InputField input;

	private List<string> atributes;
	private Vector2 position;
	// Use this for initialization
	void Start () {
		atributes = new List<string> ();
		position = new Vector2 ();
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
		moveButton ();
		dropdownInstatiate ();
		inputInstatiate ();
	}

	public void filterClick(){
	
	}

	void dropdownInstatiate(){
		setPosition (dropdown.transform.position.x, dropdown.transform.position.y);
		Dropdown newdd = Instantiate (dropdown, position, Quaternion.identity) as Dropdown;
		newdd.transform.SetParent(dropdown.transform);
	}
	void inputInstatiate(){
		setPosition (input.transform.position.x, input.transform.position.y);
		InputField newif = Instantiate (input, position, Quaternion.identity) as InputField;
		newif.transform.SetParent(input.transform);
	}

	void moveButton(){
		setPosition (add.transform.position.x, add.transform.position.y);
		add.transform.position = position; 
	} 

	private void setPosition(float x, float y){
		position.x = x;
		position.y = y - 45;
	}

	void getAtributes(){
		/*List<string> atributi = new List<string> ();
		Selektor selektor = Selektor.getInstance ();
		dropdown.ClearOptions ();
		foreach (DataRow a in selektor.getAtributi()) {
			atributi.Add(a["Naziv"].ToString () + ": \t" + a ["Vrijednost"].ToString ());
		}
		dropdown.AddOptions (atributi);*/
	}
}
