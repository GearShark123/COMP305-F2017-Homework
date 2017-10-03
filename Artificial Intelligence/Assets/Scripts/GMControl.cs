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
    public Transform ship;
    private float counter;
    public bool isNotBtn;
    private List<Transform> checkpointList = new List<Transform>();

    void Start()
    {
        isNotBtn = true;       
    }

    // Update is called once per frame
    void Update()
    {    
        // Testing
        //mousePosition = Input.mousePosition;
        //screenToWorldPoint_Position = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        //screenWidth = Screen.width;
        //screenHeight = Screen.height;

        if (Input.GetMouseButtonDown(0) && counter <= 9 && isNotBtn == true)
        {
            counter += 1;
            GameObject nextcheckpointMarker = Instantiate(checkpointMarker, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z + 10f)), this.transform.rotation);
            nextcheckpointMarker.name = "Checkpoint Marker " + counter;
            checkpointList.Add(nextcheckpointMarker.transform);
        }        
    }

    public void DisableCheckpointDrop()
    {
        isNotBtn = false;
    }
    public void EnableCheckpointDrop()
    {
        isNotBtn = true;
    }

    public void Begin()
    {
        counter = 0;
        foreach (var item in checkpointList)
        {
            ship.position = Vector3.MoveTowards(ship.position, item.position, 3 * Time.deltaTime);
        }
    }
}
