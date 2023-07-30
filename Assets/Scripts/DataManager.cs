using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager instance;
    public string Username { get; set; }
    public BestScore bestScore { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {  
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadBestScore();
        } else
        {
            Destroy(gameObject);
        }
        
    }

    public void CalculateNewBestScore(int score)
    {
        Debug.Log("Calculating score");
        if (this.bestScore == null || this.bestScore.score < score)
        {
            this.bestScore = new BestScore(this.Username, score);
            SaveBestScore();
        }
    }

    public void SaveBestScore()
    {
        if (this.bestScore == null)
            return;

        string json = JsonUtility.ToJson(this.bestScore);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath + "/savefile.json");
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            this.bestScore = JsonUtility.FromJson<BestScore>(json);
        }
    }

}

[Serializable]
public class BestScore
{
    public BestScore() { }
    public BestScore(string username, int score)
    {
        this.username = username;
        this.score = score;
    }
    public string username;
    public int score;
}
