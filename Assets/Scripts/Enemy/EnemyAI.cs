using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EnemyAI : MonoBehaviour, IDamagable 
{

    public float moveSpeed;

    public Animator animator;
	private Collider2D thisColl;

	public Rigidbody2D myRigidBody;


    public int timeToWaitBetweenHits;
    
	public SpriteRenderer enemySprite;

    [SerializeField]
    private int scoreAmount;

    public delegate void ScoreEvent(int points);
    public static event ScoreEvent scoreEvent;

    private ProjectileController projectileController;
    [SerializeField]
	private int health;
    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            if(value > 0)
            {
                health = value;
            }
        }
    }

    bool canBeHurt = true;

    public GameObject powerUpToDrop;


    // Use this for initialization
    protected virtual void Start () 
	{
		thisColl = GetComponent<Collider2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(enemySprite.isVisible)
        {
            MoveEnemy();
        }
    }

    protected virtual void MoveEnemy()
    {
        myRigidBody.velocity = Vector2.right * -moveSpeed * Time.deltaTime;
    }

	void OnTriggerEnter2D(Collider2D col)
	{

		if(col.gameObject.tag == "BaddieDestroy")
		{
			Destroy(gameObject);
		}

	}

    public void TakeDamage(int damageToTake)
    {
        if(canBeHurt)
        {
            health -= damageToTake;

            if(health <= 0)
            {
                Death();
                return;
            }

            StartCoroutine(FlashDamage(0.05f));
        }
        
    }

    public IEnumerator FlashDamage(float waitTime)
    {
        canBeHurt = false;
        for(int i = 2; i > 0; i--)
        {
            //Lerp this value
            enemySprite.color = Color.red;
            yield return new WaitForSeconds(waitTime);
            enemySprite.color = Color.white;
            yield return new WaitForSeconds(waitTime);
        }

        canBeHurt = true;
	}

	void Death()
	{
        if(scoreEvent != null)
        {
            scoreEvent(scoreAmount);
        }

        Instantiate(powerUpToDrop, transform.position, Quaternion.identity);

		Destroy(gameObject); 
	}
}
