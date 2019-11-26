using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Ping Pong Enemy
 - Calculate direction of player at start of lifetime
 - If collides with player is destroyed
 - Iff collides with a levelbound, takes a hit
 - Destroyed if hits comes to 0
*/
public class PingPongEnemy : EnemyBehaviour
{
    //Calculated at start relative to player position
    private Vector2 direction;
    int hits;

    public override void Init()
    {
        direction = (player.transform.position - transform.position).normalized;
        speed = GlobalGameVariables.Instance.variables.enemySpeed;
        hits = GlobalGameVariables.Instance.variables.EnemyPingpongHitCount;
    }

    public override void Move()
    {
        rigidBody.MovePosition(rigidBody.position + (direction * speed * Time.fixedDeltaTime));
    }

    public override void OnOtherCollided(Collider2D collision)
    {
        if (collision.tag == "bounds")
        {
            hits--;
            if (hits <= 0)
                Destroy(gameObject);
            direction = (player.transform.position - transform.position).normalized;
        }
    }

    public override void OnPlayerCollided(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
