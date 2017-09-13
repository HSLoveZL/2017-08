using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRGazeItem : MonoBehaviour {

	/// <summary>
	/// 高亮材质
	/// </summary>
	public Material HighlightMat;
	/// <summary>
	/// 普通材质
	/// </summary>
	public Material NormalMat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/// <summary>
	/// 视线移入
	/// </summary>
	public void OnGazeIn()
	{
		if(gameObject.tag == "_UITag")
		{
			ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerEnterHandler);
		}
		else if(gameObject.tag == "_CubeTag")
		{
			//替换材质
			gameObject.GetComponent<Renderer>().material = HighlightMat;
		}
	}
	/// <summary>
	/// 视线移出
	/// </summary>
	public void OnGazeOut()
	{
		if (gameObject.tag == "_UITag")
		{
			ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
		}
		else if (gameObject.tag == "_CubeTag")
		{
			//替换材质
			gameObject.GetComponent<Renderer>().material = NormalMat;
		}
	}
	/// <summary>
	/// 凝视激活
	/// </summary>
	public void OnGazeFire(RaycastHit hit)
	{
		if (gameObject.tag == "_UITag")
		{
			gameObject.SetActive(false);
		}
		else if (gameObject.tag == "_CubeTag")
		{
			gameObject.GetComponent<Rigidbody>().AddForceAtPosition(hit.point.normalized * 100.0f, hit.point);
		}
	}
}
