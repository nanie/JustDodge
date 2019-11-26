using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataSave
{
    public ScoreSave[] score;

    public DataSave(ScoreBoard scoreboard)
    {
        //Create array from list so it serializes
        score = scoreboard.score.ToArray();
    }
}

[System.Serializable]
public class ScoreSave
{
    public string playerName;
    public int playerScore;

    public ScoreSave(string name, int score)
    {
        playerName = name;
        playerScore = score;
    }

    public ScoreSave()
    {
        playerName = "";
        playerScore = 0;
    }
}