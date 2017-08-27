using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAroundFromTarget : MonoBehaviour {

	public Transform TraTarget;//环绕旋转的目标对象
	public float FloRotationSpeed = 1.0f;//环绕旋转的速度

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround(TraTarget.position, Vector3.up, FloRotationSpeed);
	}
}
