using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo02 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("进入碰撞体 对象名称呢 = " + other.GetComponent<Collider>().name);
	}

	void OnTriggerExit(Collider other)
	{
		Debug.Log("离开碰撞体 对象名称呢 = " + other.GetComponent<Collider>().name);
	}
}
