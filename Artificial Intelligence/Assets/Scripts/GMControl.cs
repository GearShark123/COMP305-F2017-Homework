using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GMControl : MonoBehaviour
{
    public Vector3 mousePosition;
    public Vector3 screenToWorldPoint_Position;

    public float screenWidth;
    public float screenHeight;

    public GameObject checkpointMarker;
    public Transform ship;
    public Button startBtn;
    public Transform newRotation;

    private int counter;
    private int counter2;

    public bool isNotBtn;
    public bool goNext;
    private List<Transform> checkpointList = new List<Transform>();

    void Start()
    {
        isNotBtn = true;
        startBtn.interactable = false;
        goNext = false;
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
        if (counter >= 3)
        {
            EnableBtn();
        }

        if (goNext == true && counter2 < checkpointList.Count)
        {
            ship.rotation = Quaternion.RotateTowards(ship.rotation, newRotation.rotation, 10f);
            ship.position = Vector3.MoveTowards(ship.position, checkpointList[counter2].position, 3 * Time.deltaTime);
            if (ship.position == checkpointList[counter2].position)
            {
                counter2 += 1;
                if (counter2 < checkpointList.Count)
                {
                    newRotation.rotation = Quaternion.FromToRotation(Vector3.up, checkpointList[counter2].position - ship.position);
                }
            }
        }
    }

    public void Begin()
    {
        counter2 = 0;
        goNext = true;
        newRotation.rotation = Quaternion.FromToRotation(Vector3.up, checkpointList[0].position - ship.position);
    }

    public void Rest()
    {
        SceneManager.LoadScene("Cutscenes Upgrade 1");
    }

    void EnableBtn()
    {
        startBtn.interactable = true;
    }

    public void DisableCheckpointDrop()
    {
        isNotBtn = false;
    }
    public void EnableCheckpointDrop()
    {
        isNotBtn = true;
    }
}
