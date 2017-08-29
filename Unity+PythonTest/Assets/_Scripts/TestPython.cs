using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TestPython : MonoBehaviour {

	public int a, b;

	// Use this for initialization
	void Start () {
		StartCoroutine(Start_Shell());
	}
	IEnumerator Start_Shell()
	{
		Process p;
		//工作路径
		string workingDirectory = "F:\\SoftWares\\PYTHONRELATED\\Code";
		ProcessStartInfo proc = new ProcessStartInfo("python", workingDirectory + "\\Unity_Python.py" + " " + a + " " + b);
		proc.WorkingDirectory = workingDirectory;

		//setting
		proc.UseShellExecute = false;
		proc.CreateNoWindow = true;
		proc.WindowStyle = ProcessWindowStyle.Normal;

		//重定向数据流
		proc.RedirectStandardOutput = true;
		proc.RedirectStandardError = true;

		//启动
		p = Process.Start(proc);

		//重定向数据流
		StreamReader sr = p.StandardOutput;
		StreamReader srerr = p.StandardError;

		//等待程序完成，防假死
		while (!p.HasExited)
		{
			yield return null;
		}

		//读取结果
		//error
		while (!srerr.EndOfStream)
		{
			string readline = srerr.ReadLine();
			Debug.LogError(readline);
		}
		//output
		while (!sr.EndOfStream)
		{
			string readline = sr.ReadLine();
			Debug.Log(readline);
		}

		Debug.Log("Done!");
		yield return null;
	}
}
