using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetControl : MonoBehaviour
{

    //private Rigidbody2D rbody;
    public Transform waypoint;
    public Transform waypoint2;

    public float speed;             // 3
    private float time = 0f;
    private float timeChange = 0.1f;
    private float timeLimit = 5f;

    private int state;

    // Use this for initialization
    void Start()
    {
        state = 1;
        //rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 1)
        {
            Linear();
            //print(state);
        }
        else if (state == 2)
        {
            timeChange = 0.04f;
            time += timeChange;
            EaseOut();
        }
        else if (state == 3)
        {
            timeChange = 0.04f;
            time += timeChange;
            EaseIn();
        }
        else if (state == 4)
        {
            time += timeChange;
            EaseInOut();
        }
    }

    void Linear()
    {
        speed = 5;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waypoint2.position, step);
        if (transform.position == waypoint2.position)
        {
            time += timeChange;
            if (time >= timeLimit)
            {
                time = 0f;
                state = 2;
            }
        }
    }

    void EaseOut()
    {
        speed = 1;
        float step = ((speed * time) * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, step);
        if (transform.position == waypoint.position)
        {
            time += timeChange;
            if (time >= timeLimit)
            {
                time = 0f;
                state = 3;
            }
        }
    }

    void EaseIn()
    {
        speed = 5;
        float step = ((speed / time) * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, waypoint2.position, step);
        if (transform.position == waypoint2.position)
        {
            time += timeChange;
            if (time >= timeLimit)
            {
                time = 0f;
                state = 4;
            }
        }
    }

    void EaseInOut()
    {
        if (transform.position.x > waypoint.position.x / 2)
        {
            timeChange = 0.04f;
            speed = 3;
            float step = ((speed / time) * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, waypoint.position / 2, step);
            if (transform.position.x == waypoint.position.x / 2)
            {
                time = 0f;
            }
        }
        else
        {
            timeChange = 0.04f;
            speed = 1;
            float step = ((speed * time) * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, waypoint.position, step);
            if (transform.position == waypoint.position)
            {
                state = 1;
            }
        }
    }
}
