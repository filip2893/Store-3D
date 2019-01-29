using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

public class Entities : MonoBehaviour {
	public Transform prefab;
	// Use this for initialization
	void Start () {
		Selektor selektor = Selektor.getInstance ();

		Transform olap_kocka;
		Vector3 position = new Vector3 ();
		Vector3 scale = new Vector3 ();
		using (DataTable entiteti = selektor.getEntites ()) {
			foreach (DataRow e in entiteti.Rows) {
				//postavljanje pozicije
				position.x = float.Parse (e ["PositionX"].ToString ());//358.18F;
				position.y = float.Parse (e ["PositionY"].ToString ());//0.67F;
				position.z = float.Parse (e ["PositionZ"].ToString ());//237.87F;
				//postavljanje veličine
				scale.x = float.Parse (e ["ScaleX"].ToString ());
				scale.y = float.Parse (e ["ScaleY"].ToString ());
				scale.z = float.Parse (e ["ScaleZ"].ToString ());

				olap_kocka = Instantiate (prefab, position, Quaternion.identity);
				olap_kocka.name = e ["Naziv"].ToString ();
				//postavljanje rotacije
				olap_kocka.transform.Rotate (float.Parse (e ["RotationX"].ToString ()), 
					float.Parse (e ["RotationY"].ToString ()),
					float.Parse (e ["RotationZ"].ToString ()));
				olap_kocka.transform.localScale += scale;
				olap_kocka.GetComponent<Entity> ().EntitetID = e ["EntitetiID"].ToString ();
				olap_kocka.GetComponent<Entity> ().sifra = e ["Sifra"].ToString ();
				olap_kocka.GetComponent<Entity> ().opis = e ["Opis"].ToString ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
