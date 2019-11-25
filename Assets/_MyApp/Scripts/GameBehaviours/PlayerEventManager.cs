using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    PlayerCanvasStats playercanvas;

    int currentHealth;
    int currentScore;

    void Start()
    {
        playercanvas = FindObjectOfType<PlayerCanvasStats>();
        currentHealth = GlobalGameVariables.Instance.variables.playerHealthPoints;
        playercanvas.UpdatePlayersHP(currentHealth);
    }

    public void EnemyHit()
    {
        currentHealth--;
        if(currentHealth > 0)
        {
            playercanvas.UpdatePlayersHP(currentHealth);
        }
        else
        {
            SceneController.Instance.GoToScoreBoard();
        }
    }

    public void PlayerScore(int amount)
    {
        currentScore += amount;
        playercanvas.UpdateScore(currentScore);
    }
}
