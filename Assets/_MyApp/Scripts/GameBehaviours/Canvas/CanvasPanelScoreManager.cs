using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPanelScoreManager : MonoBehaviour
{
    public Text txtName;
    public Text txtScore;

    //Set score data to panel texts
    public void SetData(ScoreSave score)
    {
        txtName.text = score.playerName;
        txtScore.text = score.playerScore.ToString();
    }
}
