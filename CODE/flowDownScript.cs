using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This code is created by Henri Laitinen
// laitinenhenri@hotmail.com

//This script will track if the decrese water flow button is clicked

public class flowDownScript : MonoBehaviour
{
    //waterflowObj is set in unity as the waterblock
    public GameObject waterFlowObj;

    //This is the script of the water blocks
    private flowGaugeScript waterScr;


    // Start is called before the first frame update
    void Start()
    {
        //Checking if the Object and script have been obtained
        if (waterFlowObj != null)
        {
            waterScr = waterFlowObj.GetComponent<flowGaugeScript>();
            if(waterScr == null )
            {
                Debug.Log("Cant get script");

            }
        }
        else
        {
            Debug.Log("Obj not assgned");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Checks click position when mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //If the click is on the button the decreseFlow() script is called, from the waterScript
            if (hit.collider != null && hit.transform == transform)
            {
                waterScr.decreaseFlow();
            }
        }

    }
}
