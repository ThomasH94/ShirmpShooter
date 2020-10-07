using UnityEngine;
using System.Collections;

public class SeaHorseAI : EnemyAI
{
    int actionCount;
    public GameObject projectile;
    public Transform firePoint;
    public float swimSpeed;

    public float lerpSpeed = 1.0f;
    private float lerpStartTime;
    private float lerpTotalDistance;

    public Transform[] transformPoints;
    private Vector2 currentPosition;

    protected override void Start()
	{
        int random = GetRandomNumber();
        DecideAction(random);
        currentPosition = transform.position;
    }
	
	int GetRandomNumber()
	{
		int randomNumber = Random.Range(0,2);
        return randomNumber;
	}
	
	void DecideAction(int random)
	{
		switch(random)
		{
			case 0:
                MoveUp();
			break;
			
			case 1:
                MoveDown();
			break;
		}
		

		StartCoroutine(CoolDown(1.25f));
        actionCount++;
		
	}

    protected override void MoveEnemy()
    {
        base.MoveEnemy();
    }

    void MoveUp()
    {
        //Move up
        Debug.Log("Moved up");
        transform.position = transformPoints[0].position;
        //StartCoroutine(Move(transformPoints[0]));
        Shoot();
    }

    void MoveDown()
    {
        //Move Down
        Debug.Log("Moved down");
        transform.position = transformPoints[1].position;
        //StartCoroutine(Move(transformPoints[1]));
        Shoot();
    }
	
	void Shoot()
	{
        animator.SetTrigger("Shot");
        //ShootEvent();
    }

    public void ShootEvent()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
	
	IEnumerator CoolDown(float timeToWait)
	{
		yield return new WaitForSeconds(timeToWait);
		int random = GetRandomNumber();
        DecideAction(random);
    }

    /*
    IEnumerator Move(Transform transformToMoveTo)
    {
        lerpStartTime = Time.time;
        lerpTotalDistance = Vector3.Distance(currentPosition, transformToMoveTo.position);

        //Move the positions with a lerp, then shoot

        Shoot();
    }
    */
}