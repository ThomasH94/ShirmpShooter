using UnityEngine;
using System.Collections;

public class SeaHorseProjectile : MonoBehaviour
{

    private Rigidbody2D myRigidBody;

    [SerializeField]
    private float speed = 100;

    public GameObject explosionSFX;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveForward();

    }

    void MoveForward()
    {
        myRigidBody.velocity = new Vector2(speed * Time.deltaTime, myRigidBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "OBJDestroy")
        {
            Destroy(this.gameObject);
        }

    }

}
