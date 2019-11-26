using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHPItem : Item
{
    public override void PlayerCollected(PlayerEventManager playerEvent)
    {
        playerEvent.AddLife();
        Destroy(gameObject);
    }
}
