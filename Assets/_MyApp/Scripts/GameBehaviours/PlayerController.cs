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

    //Horizontal and vertical point at start of touch
    private Vector2 touchStart;

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
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //Capture touch start
                touchStart = Input.touches[0].position;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //Calculate direction in reference of start of touch, calculate leght of vector using screen
                direction = (Input.touches[0].position - touchStart) / (Screen.width / 20);

                //Force axis to be between -1 and 1 so the max speed of player doesn't change between platform
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

        //Simulate touch using mouse when playing on editor
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            direction = ((Vector2)Input.mousePosition - touchStart) / (Screen.width / 20);
            direction.x = direction.x > 1 ? 1 : direction.x;
            direction.x = direction.x < -1 ? -1 : direction.x;

            direction.y = direction.y > 1 ? 1 : direction.y;
            direction.y = direction.y < -1 ? -1 : direction.y;
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
