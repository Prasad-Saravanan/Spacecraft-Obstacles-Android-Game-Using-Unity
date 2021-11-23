using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

    public GameObject score;
    public GameObject scoreName;
    public GameObject rank;

    public void SetScore(string name, string score, string rank)
    {
        this.score.GetComponent<Text>().text = score;
        this.scoreName.GetComponent<Text>().text = name;
        this.rank.GetComponent<Text>().text = rank;
    }
}
