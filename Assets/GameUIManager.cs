using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bestScoreTextObject;
    private Text bestScoreText;

    void Start()
    {
        bestScoreText = bestScoreTextObject.GetComponent<Text>();    

    }

    // Update is called once per frame
    void Update()
    {
        if (DataManager.instance != null && DataManager.instance.bestScore != null)
        {
            SetBestScoreText(DataManager.instance.bestScore.username, DataManager.instance.bestScore.score);
        }
    }

    private void SetBestScoreText(string username, int score)
    {
        bestScoreText.text = "Best score : " + username + " : " + score;
    }
}
