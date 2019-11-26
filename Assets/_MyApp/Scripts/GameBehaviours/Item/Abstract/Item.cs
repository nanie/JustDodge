using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerCollected(collision.GetComponent<PlayerEventManager>());
        }
    }

    public abstract void PlayerCollected(PlayerEventManager playerEvent);
}
