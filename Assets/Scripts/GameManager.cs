using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor.Build;

public class GameManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static GameManager Instance;
    public string PlayerName;

    public string HighPlayer;
    public int HighScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerHighScore();
    }


    [System.Serializable]


    class SaveData
    {
        public string HighPlayer;
        public int HighScore;
    }

    public void SavePlayerHighScore()
    {
        SaveData data = new SaveData();
        data.HighPlayer = HighPlayer;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadPlayerHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighPlayer = data.HighPlayer;
            HighScore = data.HighScore;
        }
    }
}
