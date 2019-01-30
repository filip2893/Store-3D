using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public Dropdown dropdown;


	// Use this for initialization
	void Start () {
		List<string> prostori = new List<string> ();

		dropdown.ClearOptions ();
		DatabaseConnection database = DatabaseConnection.getInstance ();
		DataTable data = database.Query ("Select Naziv from Prostori;");

		foreach(DataRow r in data.Rows){
			prostori.Add (r["Naziv"].ToString());
		}
		dropdown.AddOptions (prostori);
	}
	// Update is called once per frame
	void Update () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void OnOptionSelected(){
		int sceneIndex = dropdown.value + 1;
		SceneManager.LoadScene (sceneIndex);
	}
	public void closeApplication(){
		Application.Quit ();
	}
}
