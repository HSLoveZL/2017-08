using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeTest : MonoBehaviour {

	/// <summary>
	/// 准星容器
	/// </summary>
	public Canvas GazeCanvas;
	/// <summary>
	/// 准星图片
	/// </summary>
	public Image GazeImage;
	/// <summary>
	/// 击中的当前目标
	/// </summary>
	private GameObject target;
	/// <summary>
	/// 初始位置
	/// </summary>
	private Vector3 originPos;
	/// <summary>
	/// 初始尺寸
	/// </summary>
	private Vector3 originScale;
	/// <summary>
	/// 倒计时
	/// </summary>
	private float countDownTime = 3.0f;
	/// <summary>
	/// 当前时间
	/// </summary>
	private float nowTime = 0.0f;

	// Use this for initialization
	void Start () {
		GazeImage.fillAmount = 0;
		originPos = GazeCanvas.transform.localPosition;
		originScale = GazeCanvas.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 200))
		{
			GazeCanvas.transform.position = hit.point;
			GazeCanvas.transform.localScale = originScale * hit.distance;
			GazeCanvas.transform.forward = hit.normal;//让射线凝视环击中物体表面
			if(hit.transform.gameObject != target)
			{
				//视线初次进入的处理
				target = hit.transform.gameObject;
			}
			else//视线停留
			{
				nowTime += Time.deltaTime;
				if((countDownTime - nowTime) > 0)
				{
					//尚未达到激活条件，倒计时
					GazeImage.fillAmount = nowTime / countDownTime;
				}
				else
				{
					//达到激活条件
					nowTime = 0.0f;
				}
			}
		}
		else
		{
			GazeCanvas.transform.localPosition = originPos;
			GazeCanvas.transform.localScale = originScale;
			GazeCanvas.transform.forward = Camera.main.transform.forward;
			GazeImage.fillAmount = 0;
		}
	}
}
