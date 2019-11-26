using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    //Initializes the score list as a 10 position array
    public List<ScoreSave> score = new List<ScoreSave>(new ScoreSave[10]);
    public CanvasPanelScoreManager[] canvasPanels;

    void Start()
    {
        //Load Score data from file
        score = new List<ScoreSave>(DataManager.LoadData(this).score);

        //Retrieve player score
        var newScore = DataHolder.Instance.currentScore;

        for (int i = 0; i < 10; i++)
        {
            if (score[i].playerScore < newScore)
            {
                //If the last score is in top 10 updates list and save to file
                score.Insert(i, new ScoreSave(DataHolder.Instance.currentPlayerName, newScore));
                score.RemoveAt(10);
                DataManager.SaveData(this);
                break;
            }
        }

        //Update Canvas with new top 10 score
        UpdateCanvas();
    }

    private void UpdateCanvas()
    {
        for (int i = 0; i < canvasPanels.Length; i++)
        {
            if (score[i] != null)
            {
                canvasPanels[i].SetData(score[i]);
            }

        }
    }
}
