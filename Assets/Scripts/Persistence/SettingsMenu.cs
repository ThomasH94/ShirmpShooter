using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement.Data;

namespace LevelManagement
{
    public class SettingsMenu 
    {
        [SerializeField]
        private Slider _masterVolumeSlider;

        [SerializeField]
        private Slider _sfxVolumeSlider;

        [SerializeField]
        private Slider _musicVolumeSlider;

        private DataManager dataManager;

		void Awake()
		{
            
			//dataManager = GetComponent<DataManager>();
            //_dataManager = Object.FindObjectOfType<DataManager>();
		}

		private void Start()
		{
            LoadData();
		}

		public void OnMasterVolumeChanged(float volume)
        {
            if (dataManager != null)
            {
                dataManager.MasterVolume = volume;
            }
            //PlayerPrefs.SetFloat("MasterVolume", volume);
        }

        public void OnSFXVolumeChanged(float volume)
        {
            if (dataManager != null)
            {
                dataManager.SfxVolume = volume;
            }
            //PlayerPrefs.SetFloat("SFXVolume", volume);
        }

        public void OnMusicVolumeChanged(float volume)
        {
            if (dataManager != null)
            {
                dataManager.MusicVolume = volume;
            }
            //PlayerPrefs.SetFloat("MusicVolume", volume);
        }

        public void LoadData()
        {
            _masterVolumeSlider.value = dataManager.MasterVolume;
            _sfxVolumeSlider.value = dataManager.SfxVolume;
            _musicVolumeSlider.value = dataManager.MusicVolume;

        }
    }
}