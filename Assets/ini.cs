using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Events;
#endif

public class ini : MonoBehaviour 
{
	public GameObject mensaje;
	public GameObject mensaje2;


	void Start () 
	{
		mensaje = GameObject.Find ("mensaje");
		mensaje.SetActive (false);
		mensaje2 = GameObject.Find ("mensaje2");
		mensaje2.SetActive (false);


	}

	IEnumerator Esperar4Segundos(int n)
	{
		yield return new WaitForSeconds(3f);

		if (n == 1) 
		{
			mensaje.SetActive (false);
		} 
		else 
		{
			mensaje2.SetActive (false);
		}
	}

	IEnumerator GetData(string correo, string pass) 
	{
		//gameObject.guiText.text = "Loading...";
		WWW www = new WWW("http://geno.com.mx/genoma/gab/c/login_app.php?correo="+correo+"&pass="+pass); //GET data is sent via the URL

		while(!www.isDone && string.IsNullOrEmpty(www.error)) 
		{
			//gameObject.guiText.text = "Loading... " + www.Progress.ToString("0%"); //Show progress
			yield return null;
		}

		if (string.IsNullOrEmpty (www.error)) 
		{
			//Debug.Log (www.text);
			if (!www.text.Contains("-1")) 
			{
				string[] datos = www.text.Split(';');

				datosgeneralespaciente.id_cliente= Int32.Parse(datos [0]);
				datosgeneralespaciente.codigo_lab = datos [1];
				datosgeneralespaciente.nombre_cliente = datos [2];
				SceneManager.LoadScene ("menu");
			} 
			else 
			{
				mensaje.SetActive (true);
				StartCoroutine (Esperar4Segundos (1));
			}
		}			
		else 
		{
			//Debug.LogWarning(www.error);
			mensaje2.SetActive (true);
			StartCoroutine (Esperar4Segundos (2));
		} 


	}

	public void ingresar1()
	{
		Text gamertag = GameObject.Find ("usuario").GetComponent<Text> ();
		Text pass = GameObject.Find ("pass").GetComponent<Text> ();

		StartCoroutine(GetData(gamertag.text,pass.text));
	}


}
