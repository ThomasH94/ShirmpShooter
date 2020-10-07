using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]

    Rigidbody2D myRigidBody;
    Vector3 velocity = Vector3.zero;
	public float flapSpeed = 100f;
	public  float forwardSpeed = 1f;
	public float fallSpeed = 1.0f;
	private int weaponID;
	public AudioSource audioSource;
	private AudioClip soundToPlay;

    private WeaponManager weaponManager;

    private enum WeaponTypes
    {
        Pistol,
        Shotgun
    }
    private WeaponTypes weaponType;
    public int weaponIndex;

    [Header("Health")]
    public int playerCoins = 0; //Mifht want to make this private later

    bool floatUp = false;
    bool floatDown = false;

	Animator animator;

	public bool dead = false;
	public bool resultsDisplay;
	public bool shootable;
	float deathCooldown;

	public bool godMode = false;

	public Transform firePoint;
	public Transform[] shotGunFirePoints;
	public GameObject projectile;
	public GameObject[] shotGunBullet;

    private bool useGravity;


	// Use this for initialization
	void Start ()
	{
		animator = transform.GetComponentInChildren<Animator>();
		shootable = true;
        useGravity = true;

		if(animator == null) 
		{
			Debug.LogError("Didn't find animator!");
		}

        weaponID = 1;

        myRigidBody = GetComponent<Rigidbody2D>();

        weaponManager = GetComponent<WeaponManager>();
    }

	// Do Graphic & Input updates here
	void Update() 
	{
        if(Input.GetKeyDown(KeyCode.L))
        {
            useGravity = !useGravity;
        }

        //Only for testing
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            JumpDown();
        }

        if(Input.GetKeyDown(KeyCode.Space) && !dead)
        {
            JumpUp();
        }

        if(useGravity)
        {
            myRigidBody.simulated = true;
        }

        else
        {
            myRigidBody.simulated = false;
        }

		if(dead) 
		{
			shootable = false;
			animator.SetBool("Dead",true);
		}

	}
	
	// Do physics engine updates here
	void FixedUpdate () 
	{
        myRigidBody.velocity = new Vector2(forwardSpeed * Time.deltaTime, myRigidBody.velocity.y);

		if (floatUp) 
		{
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x,0);
            myRigidBody.AddForce (Vector2.up * flapSpeed * fallSpeed);
			animator.SetTrigger ("DidFlap");


			floatUp = false;
		}

        if (floatDown)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0);
            myRigidBody.AddForce(Vector2.up * flapSpeed * -fallSpeed);
            animator.SetTrigger("DidFlap");


            floatDown = false;
        }


        else
        {
			animator.SetBool ("Falling", true);
		}
	}

	void OnTriggerEnter2D(Collider2D collision) 
	{
		if(godMode)
			return;

        switch (collision.gameObject.tag)
        {
            case "Damagable":
                if (playerCoins > 0)
                {
                    playerCoins -= playerCoins;
                }

                else
                {
                    animator.SetTrigger("Dead");
                    Debug.Log(collision.gameObject);
                    dead = true;
                    deathCooldown = 0.5f;
                }
                break;

            case "Coin":
                playerCoins++;
                break;

            case "PowerUp":
                weaponManager.weaponIndex = collision.GetComponent<Weapon>().weaponID;
                break;
        }

	}

	public void Shoot()
	{/*
		if (shootable == true) 
		{
			shootable = false;
			WeaponHandler ();
			StartCoroutine (ShootCoolDown (0.35f));
		}
		*/
    }

	void WeaponHandler()
	{
		switch(weaponID)
		{
		case 1:
			{
				Instantiate(projectile, firePoint.position, firePoint.rotation);
				StartCoroutine(ShootCoolDown(0.35f));
				audioSource.Play();
				break;
			}
		case 2:
			{
				Instantiate(shotGunBullet[0], shotGunFirePoints[0].transform.position,shotGunFirePoints[0].rotation);
				Instantiate(shotGunBullet[1], shotGunFirePoints[1].transform.position,shotGunFirePoints[1].rotation);
				Instantiate(shotGunBullet[2], shotGunFirePoints[2].transform.position,shotGunFirePoints[2].rotation);
				StartCoroutine(ShootCoolDown(1.5f));
				break;
			}

		}
	}

	IEnumerator ShootCoolDown(float timeToWait) 
	{
		shootable = false;
		yield return new WaitForSeconds(timeToWait);
		shootable = true;
	}

    //NEED TO BE REFACTORED
    //CREATE A METHOD THAT SENDS UP OR DOWN AND MULTIPLY BY THAT
	public void JumpUp()
	{
		floatUp = true;
	}

    public void JumpDown()
    {
        floatDown = true;
    }
}
