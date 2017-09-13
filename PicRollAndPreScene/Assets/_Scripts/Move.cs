 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	

	// Use this for initialization
	void Start () {
		InvokeRepeating("ChangePic", 0.0f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		#region 
		//transform.Translate(Vector3.left * Time.deltaTime * speed);
		//if (transform.position.x < -20.48f)
		//{
		//	transform.position += new Vector3(20.48f * 2, 0, 0);
		//}
		#endregion
	}

	void ChangePic()
	{

	}
}
