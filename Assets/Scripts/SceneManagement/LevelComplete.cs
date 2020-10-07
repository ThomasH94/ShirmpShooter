using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{

    public LevelLoader levelLoader;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            levelLoader.LoadLevel("SelectMenu");
        }
    }

}
