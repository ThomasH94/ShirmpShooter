using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour 
{
	public float destroyTime;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		StartCoroutine(DestroyThis(destroyTime));
	}

	IEnumerator DestroyThis(float timer)
	{
		yield return new WaitForSeconds(timer);
		Destroy(gameObject);
	}
}
