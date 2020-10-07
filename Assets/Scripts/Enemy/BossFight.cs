using UnityEngine;
using System.Collections;

public class BossFight : MonoBehaviour {

	private float playerMovement;
	public GameObject bossScript;

	// Use this for initialization
	void Awake () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			col.GetComponentInParent<PlayerController>().forwardSpeed = 0;
		}


	}
}
