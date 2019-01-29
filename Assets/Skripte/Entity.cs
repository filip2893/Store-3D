using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour {
	public string EntitetID;
	public string sifra;
	public string opis;

	private Color startcolor = new Color ();
	private bool mouseEnter = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && mouseEnter) {
			setData ();
			//data.GetComponentInChildren<Text> = this.transform.name;
			mouseEnter = false;
		}
	}
	private void setData(){
		GameObject.FindGameObjectWithTag ("Player").gameObject.SetActive (false);//.GetComponent<CharacterController>().enabled = false;
		Transform data = GameObject.FindGameObjectWithTag ("data").transform;
		data.GetChild(0).gameObject.SetActive (true);
		data.GetComponent<GameMenu> ().entityMenuData (this.transform.name, opis, sifra);
		data.GetComponent<GameMenu> ().atributesOfEntityMenuData (EntitetID);
	}

	void OnMouseEnter()
	{
		startcolor = this.GetComponent<Renderer> ().material.color;
		this.GetComponent<Renderer> ().material.color = Color.red;
		mouseEnter = true;
	}

	void OnMouseExit()
	{
		this.GetComponent<Renderer> ().material.color = startcolor;
		mouseEnter = false;
	}
}
