using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI playerNameInput;
    public TextMeshProUGUI HighScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScore();
        playerNameInput.text = GameManager.Instance.PlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        NewPlayerNameSelected();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        GameManager.Instance.SavePlayerHighScore();

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void NewPlayerNameSelected()
    {
        GameManager.Instance.PlayerName = playerNameInput.text;
        Debug.Log(playerNameInput.text);
    }

    public void UpdateHighScore()
    {
        string highPlayer = GameManager.Instance.HighPlayer;
        int highScore = GameManager.Instance.HighScore;

        HighScoreText.text = $"High Score {highPlayer} Score : {highScore}";
    }

    public void ResetHighScore()
    {
        GameManager.Instance.HighPlayer = "";
        GameManager.Instance.HighScore = 0;
        UpdateHighScore();
    }
}
