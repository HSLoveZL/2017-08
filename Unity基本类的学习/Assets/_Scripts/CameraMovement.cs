using System.Collections;
using System.Collections.Generic;
using Assets._Scripts;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float Smooth = 1.5f;
	private Transform player;//表示Player对象的Transform组件
	private Vector3 relCameraPos;//表示Player到摄像机的向量
	private float relCameraPosMag;//表示Player到摄像机向量的长度
	private Vector3 newPos;

	void Awake()
	{
		player = GameObject.FindWithTag(Tags.Player).transform;
		relCameraPos = transform.position - player.position;
		relCameraPosMag = relCameraPos.magnitude - 0.5f;//relCameraPos.magnitude表示向量的长度
	}
	
	/// <summary>
	/// 检测给定位置是否合适
	/// </summary>
	/// <param name="checkPos"></param>
	/// <returns></returns>
	bool ViewingPosCheck(Vector3 checkPos)
	{
		RaycastHit hit;
		if(Physics.Raycast(checkPos, player.position-checkPos, out hit, relCameraPosMag))
		{
			if (hit.transform != player)
				return false;
		}
		newPos = checkPos;
		return true;
	}

	/// <summary>
	/// 使相机始终对准角色
	/// </summary>
	void SmoothLookAt()
	{
		Vector3 relPlayerPos = player.position - transform.position;//表示摄像机到Player的向量
		Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPos, Vector3.up);//摄像机从当前位置旋转到Player位置的旋转量
		transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, Smooth * Time.deltaTime);
	}

	void FixedUpdate()
	{
		Vector3 standardPos = player.position + relCameraPos;//求解出当前帧中摄像机的目标位置（始终保持摄像机与Player间距不变）
		Vector3 abovePos = player.position + Vector3.up * relCameraPosMag;//表示Player正上方relCameraPosMag的位置
		Vector3[] checkPoints = new Vector3[5];
		checkPoints[0] = standardPos;
		checkPoints[1] = Vector3.Lerp(standardPos, abovePos, 0.25f);
		checkPoints[2] = Vector3.Lerp(standardPos, abovePos, 0.5f);
		checkPoints[3] = Vector3.Lerp(standardPos, abovePos, 0.75f);
		checkPoints[4] = abovePos;
		for (int i = 0; i < checkPoints.Length; i++)
		{
			if (ViewingPosCheck(checkPoints[i]))
				break;
		}
		transform.position = Vector3.Lerp(transform.position, newPos, Smooth * Time.deltaTime);
		SmoothLookAt();
	}
}
