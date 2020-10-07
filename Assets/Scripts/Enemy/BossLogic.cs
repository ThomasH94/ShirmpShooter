using UnityEngine;
using System.Collections;

public class BossLogic : MonoBehaviour 
{

	private Animator anim;
	private Collider2D thisColl;
	private float timer = 2.0f;
	private Rigidbody2D rb;
	public float forwardSpeed;
	public int pointsToAdd;
	private float dieTrajectory = 100.0f;
	private bool dead;
	public float speed;
	private SpriteRenderer bossSprite;
	private Color colorFlash;
	private float actionTimer;
	private int timeToAction; 
	//private Text scoreText;


	// Use this for initialization
	void Start () 
	{
		actionTimer = 3.0f;
		anim = GetComponentInChildren<Animator>();
		thisColl = GetComponent<Collider2D>();
		rb = GetComponent<Rigidbody2D>();
		dead = false;
		bossSprite = GameObject.Find("BossGraphics").GetComponent<SpriteRenderer>();
		//bossSprite.color = new Color(1f, 0f, 0f, 1f);
		//InvokeRepeating("Timing", 0.0f, 3.0f);
		Invoke("Timing", 0.0f);
	}

	void Update()
	{
		//Debug.Log(timeToAction);
		//timeToAction = Random.Range(1,3);
//		actionTimer -= Time.deltaTime;
//		if(actionTimer <= 0)
//		{
//			Debug.Log("This");
//			GenerateRandomNumber();
//			PerformAction();
//			actionTimer = timeToAction;
//		}
	}

	void Timing()
	{
			GenerateRandomNumber();
			PerformAction();

	}

	void PerformAction()
	{
		switch(timeToAction)
		{
		case 1:
			anim.SetBool("Jumping",true);
			Debug.Log("First Action");
			StartCoroutine(ActionTimer(2.0f));
			anim.SetTrigger("Landing");
			Invoke("Timing", 3.0f);
			//Do the attack void
			break;
		case 2:
			anim.SetBool("Attacking",true);
			Debug.Log("Second Action");
			StartCoroutine(ActionTimer(1.0f));
			Invoke("Timing", 3.0f);
			break;
		case 3:
			anim.SetTrigger("Idle");
			Debug.Log("Idle");
			StartCoroutine(ActionTimer(1.0f));
			Invoke("Timing", 3.0f);
			break;
		}

	}

	void Attack(int attackNumber)
	{
		switch(attackNumber)
		{
		case 1:
			print ("Attack1");
			//Instatiate Attack thing
			break;
		case 2:
			print ("Attack2");
			//Attack thing 2
			break;
		}
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Projectile")
		{
			//bossSprite.color =  new Color(1.0f,0.0f,0.0f,0.0f);
			//StartCoroutine(collideFlash());
			//Instantiate(scoreText, col.gameObject.transform.position, col.transform.rotation);
			Destroy(col.gameObject);
			//anim.SetBool("Dead", true);
			//thisColl.enabled = false;
			//Score.AddPoint(pointsToAdd);
			//dead = true;
			StartCoroutine(collideFlash());
		}
		
	}

	void GenerateRandomNumber()
	{
		timeToAction = Random.Range(1,4);
		Debug.Log(timeToAction);
	}
	
	IEnumerator DeathTimer() 
	{
		yield return new WaitForSeconds(5.0f);
		Destroy(gameObject);
	}
	IEnumerator ActionTimer(float actionTime) 
	{
		yield return new WaitForSeconds(actionTime);
		anim.SetBool("Jumping",false);
		anim.SetBool("Attacking",false);
	}
	IEnumerator collideFlash() 
	{
		thisColl.enabled = false;
		bossSprite.enabled = true;
		yield return new WaitForSeconds(0.1f);
		bossSprite.enabled = false;
		yield return new WaitForSeconds(0.1f);
		bossSprite.enabled = true;
		yield return new WaitForSeconds(0.1f);
		bossSprite.enabled = false;
		yield return new WaitForSeconds(0.1f);
		bossSprite.enabled = true;
		thisColl.enabled = true;

		
	}


	void PlayDead(Collider2D col)
	{
		timer -= Time.deltaTime;
		if(timer <= 0.0f)
		{
			Destroy(col.gameObject);
		}
	}
}
