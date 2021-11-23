using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class HighscoreText : MonoBehaviour
{
    Text score;

    void OnEnable()
    {
        //PlayerPrefs.DeleteAll();
        score = GetComponent<Text>();
        score.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        
    }
}
