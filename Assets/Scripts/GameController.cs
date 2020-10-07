using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

    public Canvas controlCanvas;
    public Canvas scoreCanvas;
    public Canvas resultsCanvas;
    [SerializeField]
    private PlayerController playerMovement;
    public GameObject player;
	private string levelName;
	public Text levelNameToChange;
	private int resultsScore;
	public Image[] scoreStars;
	private Animator anim1;
	private Animator anim2;
	private Animator anim3;
	public static GameController instance;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
		
}
