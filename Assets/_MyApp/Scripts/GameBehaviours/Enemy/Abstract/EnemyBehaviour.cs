using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyBehaviour : MonoBehaviour
{
    //Enemy Rigidy Body
    protected Rigidbody2D rigidBody;     
    //player reference
    protected Transform player;
    //Enemy movement speed
    protected float speed = 0.5f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Init();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnPlayerCollided(collision);
            collision.gameObject.GetComponent<PlayerEventManager>().EnemyHit();
        }
        else
        {
            OnOtherCollided(collision);
        }
    }

    public abstract void OnPlayerCollided(Collider2D collision);
    public abstract void OnOtherCollided(Collider2D collision);
    public abstract void Move();
    public abstract void Init();
}
