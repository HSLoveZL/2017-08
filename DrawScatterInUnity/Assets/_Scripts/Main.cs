using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	void Awake()
	{
		List<Dictionary<string, object>> data = CSVReader.Read("testCar1");

		for (var i = 0; i < data.Count; i++)
		{
			print("X " + data[i]["axisX"] + " " +
				   "Y " + data[i]["axisY"] + " " +
				   "Z " + data[i]["axisZ"]);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
