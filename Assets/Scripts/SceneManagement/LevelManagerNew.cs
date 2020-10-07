using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class LevelManagerNew : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public string levelText;
        public int unlocked;
        public bool isInteractable;

        public Button.ButtonClickedEvent OnClickEvent;
    }

    public List<Level> LevelList;
    public GameObject button;
    public Transform spacer; 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FillList()
    {
        foreach(var level in LevelList)
        {
            Debug.Log("FINISH ME");
        }
    }
}
