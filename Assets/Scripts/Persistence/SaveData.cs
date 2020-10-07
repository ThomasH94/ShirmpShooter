using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LevelManagement.Data
{
	[Serializable]
	public class SaveData
	{
		[SerializeField]
		private Level[] levels;
	
		public string playerName;
		private readonly string defaultPlayerName = "Player";
	
		public float masterVolume;
		public float sfxVolume;
		public float musicVolume;
	
		//Not a monbehavior, needs a constructor
		public SaveData()
		{
			playerName = defaultPlayerName;
			masterVolume = 0.5f;
			sfxVolume = 0.5f;
			musicVolume = 0.5f;
		
			//When we start the game, set the default values of the stats and the levels
			//Lock all the levels except the first one
			foreach(Level l in levels)
			{
				if(l.levelName == "Level01")
				{
					l.isUnlocked = true;
				}
			
				else
				{
					l.isUnlocked = false;
				}
			}
		}
	

	}
}

