using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movespeed = 5f;

    public Rigidbody2D rb;

    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    //Better with physic
    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }
}
