using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rbody;
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 movement;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");

            movement = new Vector2(moveHorizontal, moveVertical);

            // Limits max speed
            if (rbody.velocity.magnitude < speed)
            {
                rbody.AddForce(movement * speed);
            }
        }
        else
        {
            // This slows down the speed of the player gradually
            if (rbody.velocity.magnitude > 0)
            {                
                movement = rbody.velocity - (rbody.velocity/10);
                rbody.velocity = movement;               
            }
        }
    }
}
