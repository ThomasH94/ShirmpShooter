using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            //Play the collect sound
            Destroy(gameObject);
        }

    }
}
