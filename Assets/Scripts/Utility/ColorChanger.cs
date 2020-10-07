using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

    [SerializeField]
	private SpriteRenderer spriteR;
    public Color[] colors;

	// Use this for initialization
	void Start () 
	{
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.color = Color.blue;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
        {
            spriteR.color = GetRandomColor();
        }
		
	}

    Color GetRandomColor()
    {
        //int random = Random.Range(0, 2);
        //return colors[random];
        Color color = new Color(1f, 1f, 1f, 0f);
        return color;
    }
}
