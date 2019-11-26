using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : Item
{
    public override void PlayerCollected(PlayerEventManager playerEvent)
    {
        playerEvent.PlayerScore(10);
        Destroy(gameObject);
    }
}
