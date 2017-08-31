using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour {

	public Canvas reticleCanvas;
	public Image reticleImage;
	private Vector3 originPos;
	private Vector3 originScale;

	// Use this for initialization
	void Start () {
		originPos = reticleCanvas.transform.localPosition;
		originScale = reticleCanvas.transform.localScale;

		//获取当前时间并输出到CSV文件
		FileStream f = new FileStream(@"D:\GAZEPOINT\testCar.csv", FileMode.OpenOrCreate, FileAccess.Write);
		StreamWriter sw = new StreamWriter(f);
		sw.BaseStream.Seek(0, SeekOrigin.End);
		sw.WriteLine(Environment.NewLine);

		byte[] inputTime = Encoding.UTF8.GetBytes(
			DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss\r\n"));
		f.Position = f.Length;//在文本的末尾追加字符
		f.Write(inputTime, 0, inputTime.Length);
		f.Close();

		InvokeRepeating("RayAndPoint", 0.0f, 0.05f);
	}

	// RayAndPoint is for coordinate
	// Update is called once per frame
	void RayAndPoint () {
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 100))
		{
			reticleCanvas.transform.position = hit.point;
			//Debug.DrawLine(hit.point, hit.point, Color.red);//划出射线，只有在scene视图中才能看到
			reticleCanvas.transform.localScale = originScale * hit.distance;
			reticleCanvas.transform.forward = hit.normal;

			//当击中物体时输出坐标点
			using (FileStream fileW = new FileStream(@"D:\GAZEPOINT\testCar.csv", FileMode.OpenOrCreate, FileAccess.Write))
			{
				StreamWriter sw = new StreamWriter(fileW);
				sw.BaseStream.Seek(0, SeekOrigin.End);
				sw.WriteLine(Environment.NewLine);

				string coordinate = string.Format("{0:f6},{1:f6},{2:f6}, {3}\n", hit.point.x, hit.point.y, hit.point.z, DateTime.Now.ToString("HH:mm:ss"));
				byte[] data = Encoding.UTF8.GetBytes(coordinate);
				fileW.Position = fileW.Length;
				fileW.Write(data, 0, data.Length);
			}

			Debug.Log("<color=#50cccc>" + "Coordinate：" + hit.point.ToString("f6") + "</color>" + "    "
					+ "<color=#a7311a>" + DateTime.Now.ToString("HH:mm:ss") + "</color>");
		}
		else
		{
			reticleCanvas.transform.localPosition = originPos;
			reticleCanvas.transform.localScale = originScale;
			reticleCanvas.transform.forward = Camera.main.transform.forward;//和主摄像机方向一致
		}
	}
}
