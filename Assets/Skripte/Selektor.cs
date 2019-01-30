using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

public class Selektor {	
	private static Selektor selektor = null;
	private static readonly object myLockObject = new object();
	private static DataTable entiteti;
	private static DataTable atributi;

	public static Selektor getInstance(){
		lock (myLockObject) {
			if(selektor == null){
				selektor = new Selektor ();
			}
		}
		return selektor;
	}

	public void setEntity(DataTable ent){
		entiteti = ent;
	}

	public DataTable getEntites(){
		return entiteti;
	}

	public void setAtributi(DataTable atr){
		atributi = atr;
	}

	public DataTable getAtributi(){
		return atributi;
	}
}
