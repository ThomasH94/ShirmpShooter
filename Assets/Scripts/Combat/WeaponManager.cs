using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon[] activeWeapon;
    public int weaponIndex;
    public Transform firePoint;
    private bool canShoot = true;
    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        if(playerController == null)
        {
            Debug.Log("Player controller on Weapon manager not found!");
        }

        weaponIndex = 0;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(canShoot)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        switch (weaponIndex)
        {
            //Shotgun
            case 1:
                {
                    Instantiate(activeWeapon[1].projectile, firePoint.position, firePoint.rotation);
                    StartCoroutine(ShootCoolDown(activeWeapon[1].weaponCoolDown));
                    //audioSource.Play();
                    break;
                }

            case 2:
                {
                    Instantiate(activeWeapon[2].projectile, firePoint.position, firePoint.rotation);
                    //audioSource.Play();
                    break;
                }

            //Default bullet
            default:
                Instantiate(activeWeapon[0].projectile, firePoint.position, firePoint.rotation);
                break;
        }
    }

    IEnumerator ShootCoolDown(float timeToWait)
    {
        canShoot = false;
        yield return new WaitForSeconds(timeToWait);
        canShoot = true;
    }
}
