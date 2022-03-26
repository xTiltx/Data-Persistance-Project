using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{

    public static DataManager instance;
    public string nameInput;
    public int highScore;
    public string bestPlayer;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    [System.Serializable]

    class SaveData
    {
        public string nameInput;
        public int highScore;
        public string bestPlayer;
    }

    public void Save()
    {
        SaveHighScore();
    }

    public void Load()
    {
        LoadHighScore();
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.nameInput = nameInput;
        data.highScore = highScore;
        data.bestPlayer = bestPlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameInput = data.nameInput;
            highScore = data.highScore;
            bestPlayer = data.bestPlayer;
        }
    }


}
