using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LevelManagement.Data
{
    public class DataManager : MonoBehaviour
    {
        private SaveData saveData;

        //Trying to find the level by the sent value, then changing it's isUnlocked bool = true
        public bool[] levelsUnlocked
        {
            set {; }
        }

        public float MasterVolume
        {
            get { return saveData.masterVolume; }
            set { saveData.masterVolume = value; }
        }

        public float SfxVolume
        {
            get { return saveData.sfxVolume; }
            set { saveData.sfxVolume = value; }
        }

        public float MusicVolume
        {
            get { return saveData.musicVolume; }
            set { saveData.musicVolume = value; }
        }




        private void Awake()
        {
            saveData = new SaveData();
        }
    }
}

