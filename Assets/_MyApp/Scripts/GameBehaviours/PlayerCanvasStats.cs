using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasStats : MonoBehaviour
{
    //Panel to show Player's current health
    public Transform playerHPPanel;
    //Text to show current player score
    public Text playerScore;

    public void UpdatePlayersHP(int amount)
    {
        for (int i = 0; i < playerHPPanel.childCount; i++)
        {
            if(i < amount)
            {
                playerHPPanel.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                playerHPPanel.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void UpdateScore(int amount)
    {
        playerScore.text = amount.ToString();
    }
}
