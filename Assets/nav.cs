using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using System.Net.Sockets;
using System.Security.Cryptography;


public class nav : MonoBehaviour 
{
	public GameObject mensaje_descarga;

	void Start()
	{
		mensaje_descarga = GameObject.Find ("mensaje_descarga");
		mensaje_descarga.SetActive (false);

	}



	public void salir()
	{
		SceneManager.LoadScene ("index");
	}

	//ProcessStartInfo process;

	public void reporte () 
	{
		
		string codificado1 = GetMD5 (datosgeneralespaciente.id_cliente.ToString());

		string aux = "";
		string id = datosgeneralespaciente.id_cliente.ToString ();

		for (int i = 0; i < codificado1.Length; i++) 
		{
			if (i == 10) 
			{
				aux = aux + id+"pz";	
			} 
			else if (i < 10) 
			{
				aux=aux+codificado1[i];
			}
			else if (i > 10) 
			{
				aux = aux + codificado1 [i];
			}
		}

		codificado1 = aux;
	
		Application.OpenURL("http://geno.com.mx/genoma/gab/tt/index3_app.php?id="+codificado1);


	}

	
	public static string GetMD5(string str)
	{
		MD5 md5 = MD5CryptoServiceProvider.Create();
		ASCIIEncoding encoding = new ASCIIEncoding();
		byte[] stream = null;
		StringBuilder sb = new StringBuilder();
		stream = md5.ComputeHash(encoding.GetBytes(str));
		for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
		return sb.ToString();
	}




}
