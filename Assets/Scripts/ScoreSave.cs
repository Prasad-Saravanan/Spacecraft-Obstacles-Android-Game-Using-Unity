using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSave : MonoBehaviour {

    Text scoresave;

    void OnEnable()
    {

        scoresave = GetComponent<Text>();
        scoresave.text = PlayerPrefs.GetInt("Score").ToString();

    }
}
