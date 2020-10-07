using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyList;
    public GameObject[] rockList;
	public GameObject[] propList;
    public GameObject[] obstacleList;
    public Transform[] pointToSpawnEnemies;
	public Transform[] pointToSpawnProps;
    public float distanceBetween;
    public float Timer;
    public float rockTimer;
	public float propTimer;
    public float obstacleTimer;
    private int spawnPicker;
	private int rockPicker;
	private int propPicker;
    private int obstaclePicker;
	private int level;
    

	// Use this for initialization
	void Start ()
    {
        Timer = 1.5f;
        rockTimer = 7.0f;
		propTimer = 5.0f;
        obstacleTimer = 1.0f;
		level = Application.loadedLevel;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (level > 1) 
		{
			Timer -= Time.deltaTime;
			rockTimer -= Time.deltaTime;
			obstacleTimer -= Time.deltaTime;

			if (propTimer <= 0) 
			{
				propTimer = 5.0f;
				SpawnProps ();
			}
			if (rockTimer <= 0) 
			{
				rockTimer = 15.0f;
				SpawnRocks ();
				SpawnProps ();
			}

			if (Timer <= 0) 
			{
				Timer = 1.5f;
				Spawn ();
            
			}
			if (obstacleTimer <= 0) 
			{
				SpawnObstacles ();
				obstacleTimer = 10.0f;
			}
		}
	}

    void Spawn()
    {
        spawnPicker = Random.Range(0, 12);
        if (spawnPicker == 0)
        {
			Instantiate(enemyList[0], pointToSpawnEnemies[0].position, Quaternion.identity);
        }
        if (spawnPicker == 1)
        {
			Instantiate(enemyList[1], pointToSpawnEnemies[1].position, Quaternion.identity);
        }
        if (spawnPicker == 2)
        {
			Instantiate(enemyList[2], pointToSpawnEnemies[2].position, Quaternion.identity);
        }
        if (spawnPicker == 3)
        {
			Instantiate(enemyList[0], pointToSpawnEnemies[0].position, Quaternion.identity);
			Instantiate(enemyList[1], pointToSpawnEnemies[1].position, Quaternion.identity);
        }
        if (spawnPicker == 4)
        {
			Instantiate(enemyList[1], pointToSpawnEnemies[0].position, Quaternion.identity);
			Instantiate(enemyList[2], pointToSpawnEnemies[2].position, Quaternion.identity);
        }
        if (spawnPicker == 5)
        {
			Instantiate(enemyList[0], pointToSpawnEnemies[1].position, Quaternion.identity);
			Instantiate(enemyList[2], pointToSpawnEnemies[2].position, Quaternion.identity);
        }
        if (spawnPicker == 6)
        {
			Instantiate(enemyList[0], pointToSpawnEnemies[0].position, Quaternion.identity);
			Instantiate(enemyList[1], pointToSpawnEnemies[1].position, Quaternion.identity);
			Instantiate(enemyList[2], pointToSpawnEnemies[2].position, Quaternion.identity);
        }
        if (spawnPicker == 7)
        {
            
			Instantiate(enemyList[1], pointToSpawnEnemies[1].position, Quaternion.identity);
			Instantiate(enemyList[2], pointToSpawnEnemies[2].position, Quaternion.identity);
        }
        if (spawnPicker == 8)
        {
            return;
        }
        if (spawnPicker == 9)
        {
            return;
        }
        if (spawnPicker == 10)
        {
            return;
        }
        if (spawnPicker == 11)
        {
            return;
        }
        if (spawnPicker == 12)
        {
            return;
        }
    }
    
    void SpawnRocks()
    {
		rockPicker = Random.Range(0, rockList.Length - 1);
		Instantiate(rockList[rockPicker], pointToSpawnProps[1].position, Quaternion.identity);
    }

	void SpawnProps()
	{
		propPicker = Random.Range(0, propList.Length - 1);
		Instantiate(propList[propPicker], pointToSpawnProps[2].position, Quaternion.identity);
	}

    void SpawnObstacles()
    {
        //obstaclePicker = Random.Range(0, obstacleList.Length - 1);
        //if(obstaclePicker == 0)
        //{
		Instantiate(obstacleList[0], pointToSpawnProps[0].position, Quaternion.identity);
        //}
        //if (obstaclePicker == 1)
        //{
          //  Instantiate(obstacleList[1], pointToSpawn[4].position, Quaternion.identity);
        //}
    }


}
