using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Hand : MonoBehaviour {

	/// <summary>
	/// 手柄控制器
	/// </summary>
	public GameObject controller;
	/// <summary>
	/// 动画控制器
	/// </summary>
	private Animator ani;

	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator>();
		//controller.GetComponent<VRTK_InteractUse>().UseButtonPressed += this.Hand_UseButtonPressed;
		//controller.GetComponent<VRTK_InteractUse>().UseButtonReleased += this.Hand_UseButtonReleased;
		controller.GetComponent<VRTK_ControllerEvents>().TriggerAxisChanged += this.Hand_TriggerAxisChanged;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void Hand_TriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
	{
		ani.Play("Grab", 0, e.buttonPressure);//播放指定动画片段“Grab”抓取
		ani.speed = 0;
	}

	/// <summary>
	/// Trigger松开的动画
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void Hand_UseButtonReleased(object sender, ControllerInteractionEventArgs e)
	{
		ani.SetTrigger("Release");
	}

	/// <summary>
	/// Trigger按下的动画
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void Hand_UseButtonPressed(object sender, ControllerInteractionEventArgs e)
	{
		ani.SetTrigger("Grab");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
