using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlotter : MonoBehaviour {

	// The prefab for the data points that will be instantiated
	public GameObject PointPrefab;

	// Object which will contain instantiated prefabs in hiearchy
	public GameObject PointHolder;

	public float plotScale = 10.0f;

	/// <summary>
	/// 数据文件
	/// </summary>
	public string InputFile;

	/// <summary>
	/// 存放数据点的字典结构
	/// </summary>
	private List<Dictionary<string, object>> pointlist;

	// Indices for columns to be assigned
	public int columnX = 0;
	public int columnY = 1;
	public int columnZ = 2;

	// Full column names
	public string xName;
	public string yName;
	public string zName;

	// Use this for initialization
	void Start () {
		pointlist = CSVReader.Read(InputFile);
		Debug.Log(pointlist);
		List<string> columnList = new List<string>(pointlist[1].Keys);
		// Print number of keys (using .count)
		Debug.Log("There are " + columnList.Count + " columns in CSV");
		foreach (string key in columnList)
			Debug.Log("Column name is " + key);

		// Assign column name from columnList to Name variables
		xName = columnList[columnX];
		yName = columnList[columnY];
		zName = columnList[columnZ];

		//Loop through Pointlist
		for (var i = 0; i < pointlist.Count; i++)
		{
			#region
			// Get maxes of each axis
			//float xMax = FindMaxValue(xName);
			//float yMax = FindMaxValue(yName);
			//float zMax = FindMaxValue(zName);

			// Get minimums of each axis
			//float xMin = FindMinValue(xName);
			//float yMin = FindMinValue(yName);
			//float zMin = FindMinValue(zName);

			// Get value in poinList at ith "row", in "column" Name, normalize
			//float x = (System.Convert.ToSingle(pointlist[i][xName]) - xMin) / (xMax - xMin);
			//float y = (System.Convert.ToSingle(pointlist[i][yName]) - yMin) / (yMax - yMin);
			//float z = (System.Convert.ToSingle(pointlist[i][zName]) - zMin) / (zMax - zMin);
			#endregion
			// Get value in poinList at ith "row", in "column" Name
			float x = System.Convert.ToSingle(pointlist[i][xName]);
			float y = System.Convert.ToSingle(pointlist[i][yName]);
			float z = System.Convert.ToSingle(pointlist[i][zName]);

			//instantiate the prefab with coordinates defined above
			Instantiate(PointPrefab, new Vector3(x, y, z), Quaternion.identity);

			// Instantiate as gameobject variable so that it can be manipulated within loop
			GameObject dataPoint = Instantiate(
					PointPrefab,
					new Vector3(x, y, z) * plotScale,
					Quaternion.identity);

			// Make child of PointHolder object, to keep points within container in hierarchy
			dataPoint.transform.parent = PointHolder.transform;

			// Assigns original values to dataPointName
			string dataPointName =
				pointlist[i][xName] + " "
				+ pointlist[i][yName] + " "
				+ pointlist[i][zName];

			// Assigns name to the prefab
			dataPoint.transform.name = dataPointName;
			// Gets material color and sets it to a new RGBA color we define
			dataPoint.GetComponent<Renderer>().material.color = new Color(x, y, z, 1.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	#region 
	//private float FindMaxValue(string columnName)
	//{
	//	//set initial value to first value
	//	float maxValue = Convert.ToSingle(pointlist[0][columnName]);
	//
	//	//Loop through Dictionary, overwrite existing maxValue if new value is larger
	//	for (var i = 0; i < pointlist.Count; i++)
	//	{
	//		if (maxValue < Convert.ToSingle(pointlist[i][columnName]))
	//			maxValue = Convert.ToSingle(pointlist[i][columnName]);
	//	}
	//
	//	//Spit out the max value
	//	return maxValue;
	//}

	//private float FindMinValue(string columnName)
	//{
	//	float minValue = Convert.ToSingle(pointlist[0][columnName]);
	//
	//	//Loop through Dictionary, overwrite existing minValue if new value is smaller
	//	for (var i = 0; i < pointlist.Count; i++)
	//	{
	//		if (Convert.ToSingle(pointlist[i][columnName]) < minValue)
	//			minValue = Convert.ToSingle(pointlist[i][columnName]);
	//	}
	//
	//	return minValue;
	//}
	#endregion
}
