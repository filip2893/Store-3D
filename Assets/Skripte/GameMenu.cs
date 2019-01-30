using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;

public class GameMenu : MonoBehaviour {
	public GameObject player;
	public Dropdown dropdown;

	private Transform data;
	private int current = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void getNextMenu(){
		current++;
		int previous = current - 1; 
		if ( previous >= 0) {
			this.transform.GetChild (previous).gameObject.SetActive(false);
		}
		data = this.transform.GetChild (current);
		data.gameObject.SetActive(true); 
	}

	public void getPreviousMenu(){
		this.transform.GetChild (current).gameObject.SetActive(false);
		current--;
		this.transform.GetChild (current).gameObject.SetActive(true);
	}

	public void closeMenu(){
		player.SetActive (true);
		data = GameObject.FindGameObjectWithTag ("data").transform.GetChild(0);
		data.gameObject.SetActive (false);
		data.GetChild (0).gameObject.SetActive (true);
		data.GetChild (1).gameObject.SetActive (false);
		current = 0;
	}

	public void entityMenuData(string name, string opis, string sifra){
		data = GameObject.FindGameObjectWithTag ("data").transform.GetChild (0);
		Text[] text = data.GetComponentsInChildren<Text> ();
		text [0].text = name;
		text [1].text = opis;
		text [3].text = sifra;
	}
	public void atributesOfEntityMenuData(string id){
		List<string> atributi = new List<string> ();
		Selektor selektor = Selektor.getInstance ();
		id = "1";
		dropdown.ClearOptions ();
		foreach (DataRow a in selektor.getAtributi().Select("EntietiID>"+id)) {
			atributi.Add(a["Naziv"].ToString () + ": \t" + a ["Vrijednost"].ToString ());
		}
		dropdown.AddOptions (atributi);
	}
}
