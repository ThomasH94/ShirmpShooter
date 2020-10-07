using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    public Level[] unlockedLevels;
	
	
	void Start()
	{

	}
	
	public void LoadLevel(string levelToLoad)
	{
        SceneManager.LoadScene(levelToLoad);


        /*if (Application.CanStreamedLevelBeLoaded(levelToLoad))
		{
            for(int i = 0; i < unlockedLevels.Length; i++)
            {
                if(unlockedLevels[i].levelName == levelToLoad && unlockedLevels[i].isUnlocked == true)
                {
                    SceneManager.LoadScene(levelToLoad);
                    break;
                }

                Debug.Log("No unlocked levels match that level name!");
            }

            
            //if (levelToLoad.isUnlocked)
			//{
			//	
			//}
			//
			//else
			//{
			//	Debug.Log("Level is locked");
			//}
		}
		
		else
		{
			Debug.Log(levelToLoad + " does not exist in build settings. If you ment to load this level, please add it to the build settings with the appropriate name!");
			//Play a rejection sound or don't allow the level to load
		}
        */
    }
}