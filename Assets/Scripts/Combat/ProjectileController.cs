using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour 
{

	private Rigidbody2D myRigidBody;

    [SerializeField]
	private float speed = 100;
    public float ySpeed;

	public GameObject explosionSFX;

	// Use this for initialization
	void Start () 
	{
		myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        MoveForward();

	}

    void MoveForward()
    {
        myRigidBody.velocity = new Vector2(speed * Time.deltaTime, ySpeed * Time.deltaTime);
    }

	void OnTriggerEnter2D(Collider2D collider)
	{

		if(collider.gameObject.tag == "Damagable")
		{
            Debug.Log("Hit " + collider.name);
            IDamagable damageAble = collider.GetComponent<IDamagable>();
            if(damageAble != null)
            {
                damageAble.TakeDamage(1);
                Debug.Log("Hit the enemy");
            }

		}

		if(collider.tag == "OBJDestroy")
		{
			Destroy(this.gameObject);
		}
			
	}

	private IEnumerator Explosion()
	{
		Instantiate(explosionSFX,transform.position,Quaternion.identity);
		yield return new WaitForSeconds(0.2f);
		Destroy(gameObject);
	}


}
