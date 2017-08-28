using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo01 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject goObj1 = GameObject.Find("Cube_1");
		goObj1.GetComponent<Renderer>().material.color = Color.blue;

		GameObject goObj2 = GameObject.FindWithTag("SphereTag");
		goObj2.GetComponent<Renderer>().material.color = Color.red;

		GameObject goObj3 = GameObject.FindGameObjectWithTag("CapsuleTag");
		goObj3.GetComponent<Renderer>().material.color = Color.magenta;

		GameObject[] goObj4 = GameObject.FindGameObjectsWithTag("CubeTest");
		foreach(var list in goObj4)
		{
			list.GetComponent<Renderer>().material.color = Color.yellow;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
