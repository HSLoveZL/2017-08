using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour {

	public Transform Cube0;
	public Transform Cube1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(Cube0.position, Cube1.position, Color.magenta);
	}
}
