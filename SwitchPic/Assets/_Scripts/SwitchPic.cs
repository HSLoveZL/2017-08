using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPic : MonoBehaviour {
    public GameObject Pic_1;
    public GameObject Pic_2;

	// Use this for initialization
	void Start () {
        StartCoroutine(SwitchPicture());
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public IEnumerator SwitchPicture()
    {
        yield return new WaitForSeconds(1f);
        Pic_1.SetActive(true);
        Pic_2.SetActive(false);
        yield return new WaitForSeconds(1f);
        Pic_1.SetActive(false);
        Pic_2.SetActive(true);
        yield return StartCoroutine(SwitchPicture());
    }
}
