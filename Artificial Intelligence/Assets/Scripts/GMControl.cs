using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMControl : MonoBehaviour
{
    public Vector3 mousePosition;
    public Vector3 screenToWorldPoint_Position;

    public float screenWidth;
    public float screenHeight;

    public GameObject checkpointMarker;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        screenToWorldPoint_Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(checkpointMarker, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z + 10f)), this.transform.rotation);
        }
    }
}
