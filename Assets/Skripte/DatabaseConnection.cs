using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Data.SqlClient;

public class DatabaseConnection{
	
	private DataTable dt;
	private SqlDataAdapter da;
	private static DatabaseConnection obj = null;
	private static readonly object myLockObject = new object();

	public static DatabaseConnection getInstance(){
		lock (myLockObject) {
			if(obj == null){
				obj = new DatabaseConnection ();
			}
		}
		return obj;
	}
	private DatabaseConnection(){
	}

	public static SqlConnection connect(){
		string dataSource= "127.0.0.1";
		string userId= "sa";
		string password= "newpassword";
		string initialCatalog = "ProstoriEntitetiVeze";
		string _conString = @"Data Source = " + dataSource + ";" + 
			"user id = " + userId + ";" + 
			"password = " + password + ";" + 
			"Initial Catalog = " + initialCatalog + ";";
		
		SqlConnection con = new SqlConnection (_conString);
		
		if (con.State == ConnectionState.Closed) {
			con.Open ();
		} else {
			con.Close ();
		}

		return con;
	}

	public DataTable Query(string _query){
		da = new SqlDataAdapter (_query, DatabaseConnection.connect ());
		dt = new DataTable ();
		da.Fill (dt);
		return dt;
	}
}
