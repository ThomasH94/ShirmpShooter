using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    /* 
     * This will need to be refactored, but for now, this class will use the player coins to update the coins
    */


	public int score = 0;
	int highScore = 0;
	private Text scoreText;
    private Text scoreToDisplayText;
    public Text coinsToDisplayText;
    public PlayerController playerController;
    //Events

	void Start() 
	{
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = string.Format("Score: " + score.ToString().PadLeft(5, '0'));
        GetComponent<Text>().text = "Score: " + score + "\nHigh Score: " + highScore;
        coinsToDisplayText.text = "x " + 0;
    }

    void OnEnable()
    {
        EnemyAI.scoreEvent += UpdateScore;
    }

    void OnDisable()
    {
        EnemyAI.scoreEvent -= UpdateScore;
    }

	void Update () 
	{
        //Will bog down the game, create a singleton that manages player health later
        UpdateHealth();
	}

    public void UpdateScore(int points)
    {

        score += points;

        if (score > highScore)
        {
            highScore = score;
        }

        scoreText.text = string.Format("Score: " + score.ToString().PadLeft(5, '0'));
        GetComponent<Text>().text = "Score: " + score + "\nHigh Score: " + highScore;
    }

    public void UpdateHealth()
    {
        coinsToDisplayText.text = "x " + playerController.playerCoins.ToString();
    }
}
