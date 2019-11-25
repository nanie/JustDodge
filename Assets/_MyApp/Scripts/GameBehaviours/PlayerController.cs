using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    //Player movement speed
    private float speed = 5f;

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
        speed = GlobalGameVariables.Instance.variables.playerSpeed;
    }


    void Update()
    {
#if (UNITY_ANDROID || UNITY_IOS)
        //Capture input axis from drag on screen
        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Touch touch = Input.touches[0];
                direction.x = touch.deltaPosition.x;
                direction.y = touch.deltaPosition.y;

                direction.x = direction.x > 1 ? 1 : direction.x;
                direction.x = direction.x < -1 ? -1 : direction.x;

                direction.y = direction.y > 1 ? 1 : direction.y;
                direction.y = direction.y < -1 ? -1 : direction.y;
            }           
        }
        else
        {
            direction.x = 0;
            direction.y = 0;
        }
#else
        //Find input axis
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
#endif


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
