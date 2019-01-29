using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {
	public Transform menu;

	private string query;
	private int prostorID = 3;//SceneManager.GetActiveScene ().buildIndex;
	private bool active = false;
	// Use this for initialization
	void Start () {
		setEntiteti ();
		setAtributi ();
	}
	
	// Update is called once per frame
	void Update () {		
		if(Input.GetKeyDown(KeyCode.Escape)){
			setMenu (0, 1);
		}else if(Input.GetKeyDown(KeyCode.F1)){
			setMenu (1, 0);
		}
	}

	private void setMenu(int m1, int m2){
		setStatus (menu.GetChild (m1).gameObject);
		menu.GetChild (m1).gameObject.SetActive (active);
		menu.GetChild (m2).gameObject.SetActive (false);
	}

	private void setStatus(GameObject go){
		if (go.activeSelf) {
			active = false;
		} else {
			active = true;
		}
	}
	private void setEntiteti(){
		//dohvaćanje trenutnog ID prostora
		query = "select *from Entiteti where ProstoriID="+prostorID+";";
		DatabaseConnection database = DatabaseConnection.getInstance ();
		DataTable data = database.Query (query);
		Selektor selektor = Selektor.getInstance ();
		selektor.setEntity (data);
	}

	private void setAtributi(){
		//dohvaćanje trenutnog ID prostora
		query = "select EntietiID, Vrijednost, Naziv from Atributi,AtributiEntiteta " +
		               "where AtributiEntiteta.AtributiID = Atributi.AtributiID and Atributi.ProstoriID = " + prostorID + ";";
		DatabaseConnection database = DatabaseConnection.getInstance ();
		DataTable data = database.Query (query);
		Selektor selektor = Selektor.getInstance ();
		selektor.setAtributi (data);
	}
}
