using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager 
{
    private const string PROGRESS_KEY = "Progress";
    public static UserProgressData Progress = new UserProgressData();
    public static void Load()
    {
        // untuk cek apakah ada data yang tersimpan sebagai PROGRESS_KEY
        if(!PlayerPrefs.HasKey(PROGRESS_KEY))
        {
            // untuk tidak ada, maka simpan data baru
            Save();
        }
        else
        {
            // untuk jika ada, kaka timpa progress dengan yang sebelumnya
            string json = PlayerPrefs.GetString(PROGRESS_KEY);
            Progress = JsonUtility.FromJson<UserProgressData>(json);
        }
    }
    public static void Save()
    {
        string json = JsonUtility.ToJson(Progress);
        PlayerPrefs.SetString(PROGRESS_KEY, json);
    }
    public static bool HasResources(int index)
    {
        return index + 1 <= Progress.ResourcesLevels.Count;
    }
}
