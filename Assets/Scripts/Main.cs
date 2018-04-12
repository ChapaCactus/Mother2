using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	private void Start()
	{
		StartGame();
	}

	public void StartGame()
	{
		new Ness().Talk();
		new Jeff().Talk();
		new Paula().Talk();
		new Poo().Talk();
		new MasterBelch().Talk();
		new Starman().Talk();
		new Mama().Talk();
		new MrSaturn().Talk();
	}
}
