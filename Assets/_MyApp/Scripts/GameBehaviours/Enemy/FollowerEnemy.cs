using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* FollowerEnemy Enemy
 - Calculate direction of player at start of lifetime
 - Recalculate directions from time to time
 - Destroyed if collides with anything
*/
public class FollowerEnemy : EnemyBehaviour
{
    //Calculated at start relative to player position, recalculate every x seconds
    private Vector2 direction;
    private float timer;

    public override void Init()
    {
        direction = player.transform.position - transform.position;
        speed = GlobalGameVariables.Instance.variables.enemySpeed;
        timer = GlobalGameVariables.Instance.variables.enemyChangeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            direction = player.transform.position - transform.position;
            timer = GlobalGameVariables.Instance.variables.enemyChangeTime;
        }
    }

    public override void Move()
    {
        rigidBody.MovePosition(rigidBody.position + (direction * speed * Time.fixedDeltaTime));
    }

    public override void OnOtherCollided(Collider2D collision)
    {
        Destroy(gameObject);
    }

    public override void OnPlayerCollided(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
