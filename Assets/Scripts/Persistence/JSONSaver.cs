/*
	This class will convert save data from the data manager class into the JSON Format
	Can be used for Paper Mario as well
*/

using UnityEngine;
using System;
using System.IO;	//Used for reading/writing to disk

namespace LevelManagement.Data
{
	public class JSONSaver 
	{
		//Default save data name
		private static readonly string fileName = "saveData1.sav";
		
		public static string GetSaveFileName()
		{
			return Application.persistentDataPath + "/" + fileName;
		}
		
		public void Save(SaveData saveData)
		{
			string json = JsonUtility.ToJson(saveData);
			string saveFileName = GetSaveFileName();
			
			FileStream filestream = new FileStream(saveFileName, FileMode.Create);
			
			using (StreamWriter writer = new StreamWriter(filestream))
			{
				writer.Write(json);
			}
		}
		
		public bool LoadData(SaveData saveData)
		{
			string loadFileName = GetSaveFileName();
			
			if(File.Exists(loadFileName))
			{
				using (StreamReader reader = new StreamReader(loadFileName))
				{
					string json = reader.ReadToEnd();
					JsonUtility.FromJsonOverwrite(json, saveData);
				}
				
				return true;
			}
			
			return false;
		}
		
		public void DeleteData()
		{
			File.Delete(GetSaveFileName());
		}
	}
}
