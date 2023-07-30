using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TMP_Text bestScoreTextObject;

    void Start()
    {  
    }

    void Update()
    {
        if (DataManager.instance != null && DataManager.instance.bestScore != null)
        {
            this.bestScoreTextObject.text = "Best score : " + DataManager.instance.bestScore.username + " : " + DataManager.instance.bestScore.score;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }
}
