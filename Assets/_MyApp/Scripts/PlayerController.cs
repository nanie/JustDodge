using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("Player movement speed")]
    public float speed = 5f;

    //Character Animator
    private Animator animator;

    //Character Rigidy Body
    private Rigidbody2D rigidBody;

    //Horizontal and vertical axis from player input
    private Vector2 direction;


    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Find input axis
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        //Animate character to match movement
        animator.SetBool("walking", direction.sqrMagnitude > 0);

        //Invert rect so character looks to right whn walking right
        if (direction.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (direction.x < 0)
            transform.localScale = new Vector3(1, 1, 1);

    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + direction * speed * Time.fixedDeltaTime);
    }
}
