using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{
    //Player transform
    private Transform player;
    //Camera velocity
    private Vector3 velocity = Vector3.zero;

    [Tooltip("How smooth is the movement of camera")]
    public float smoothTime = 0.3F;

    void Start()
    {
        //Find player gameobject by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void FixedUpdate()
    {
        //Set target position to player's position
        Vector3 targetPosition = player.position;
        //Keep the current Z position
        targetPosition.z = transform.position.z;
        //Follow player smoothly
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
