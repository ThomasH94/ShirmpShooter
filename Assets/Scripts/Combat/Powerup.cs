using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public AudioSource collectSound;
    public Weapon weaponToGive;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            //Play the collect sound
            col.GetComponent<WeaponManager>().weaponIndex = weaponToGive.weaponID;
            Destroy(gameObject);
        }

    }
}
