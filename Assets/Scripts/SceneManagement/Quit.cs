using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Quit : MonoBehaviour 
{
	public Canvas levelSelectCanvas;
	public Canvas quitCanvas;

	// Use this for initialization
	void Start () 
	{
		levelSelectCanvas.enabled = true;
		quitCanvas.enabled = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			levelSelectCanvas.enabled = false;
			quitCanvas.enabled = true;
		}
	}

	public void Yes()
	{
		Application.Quit();
	}
	public void No()
	{
		levelSelectCanvas.enabled = true;
		quitCanvas.enabled = false;
	}
}
