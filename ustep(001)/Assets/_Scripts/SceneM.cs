using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnBtnClick(string Name)
	{
		if(Name == "1")
		{
			SceneManager.LoadScene("Main");
		}
	}
}
