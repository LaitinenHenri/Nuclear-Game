using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THis script controls the "control rods" the player can move
//Important features are to absorb the neutrons when colliding and moving rods up and down

public class absorbScript : MonoBehaviour
{
    //Object of the rod
    public GameObject rodObj;

    //INitializing random speed and pos limits
    public float raisingSpeed = 8f;
    public float maxHeight = 34f;
    private float minHeight = 2.0f;

    //Flags
    private bool raisingInProgress = false;
    private bool loweringInProgress = false;
    bool raiseStatus = true;
    private int numOfObj = 0;
    
    
    //This function will just give a name to the object so every rod has different name
    void Start()
    {
        string nameS = "rod";
        nameS += numOfObj.ToString();
        rodObj.name = nameS;


    }


    //This function will handel the input control
    //Flags are used to determinn how rods should behave so we wont get stuck in a function
    void Update()
    {
        //Setting flags to raise if up arrow pressed
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            raisingInProgress = true;
            loweringInProgress = false;
        }
        //SEt flags to stop if left arrow pressed
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            raisingInProgress = false;
            loweringInProgress = false;
        }
        //SEt flags to lower if down arrow is pressed
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            loweringInProgress = true;
            raisingInProgress = false;
        }

        if (raisingInProgress)
        {
            raiseRod();
        }
        else if (loweringInProgress)
        {
            lowerRod();
        }
    }

    //Calling this fuction will cause the active rods to raise until at the max height
    void raiseRod()
    {
        if (rodObj.transform.position.y < maxHeight && raiseStatus)
        {
            rodObj.transform.Translate(Vector3.up * raisingSpeed * Time.deltaTime);
        }
        else
        {
            raisingInProgress = false;
        }
    }

    //This funtion will cause the active rods to lower until at the min height
    void lowerRod()
    {
        if (rodObj.transform.position.y > minHeight && raiseStatus)
        {
            rodObj.transform.Translate(Vector3.down * raisingSpeed * Time.deltaTime);
        }
        else
        {
            raisingInProgress = false;
        }
    }

    //This function will change the raiseStatus of the rod that determines if the rod moves when arrows are pressed by player
    //This function is called from the switchScript ehre player can click the activation switches on the screen
    public void activity()
    {
        raiseStatus = !raiseStatus;
        Debug.Log("sattus changed");
    }
}
