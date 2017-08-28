using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	private float _speed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveController();
	}

	/// <summary>
	/// 物体移动控制器
	/// </summary>
	void MoveController()
	{
		#region 键盘控制移动
		//if (Input.GetKey(KeyCode.W))
		//	this.transform.Translate(Vector3.forward * 0.1f, Space.World);
		//if (Input.GetKey(KeyCode.S))
		//	this.transform.Translate(Vector3.back * 0.1f, Space.World);
		//if (Input.GetKey(KeyCode.A))
		//	this.transform.Translate(Vector3.left * 0.1f, Space.World);
		//if (Input.GetKey(KeyCode.D))
		//	this.transform.Translate(Vector3.right * 0.1f, Space.World);
		#endregion

		float h = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
		float v = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

		transform.Translate(h, 0, v);
	}
}
