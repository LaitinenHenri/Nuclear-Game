using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script will control the control rods and if they rase or not

public class switchScript : MonoBehaviour
{
    //TWo different sprites for two states
    public Sprite spriteOn;
    public Sprite spriteOff;

    //This is the sccript for the rods so we can change their status
    private absorbScript absScr;

    //Init spriterenderer
    private SpriteRenderer sr;

    //flag
    private bool activityFlag = true;

    // Start is called before the first frame update
    void Start()
    {

        sr = GetComponent<SpriteRenderer>(); // Initialize the SpriteRenderer and check if obtained
        if (sr == null)
        {
            Debug.LogError("SpriteRenderer component not found!");
            return;
        }
        sr.sprite = spriteOn;
       
    }

    //This function assings a specific rod to a sepcific switch
    //This function is called in the spawner script, when the rod and switch pairs are copmined at the start
    public void SetRod(GameObject rodObj)
    {
        //Getting the script of rodobject and check if can be obtained
        absScr = rodObj.GetComponent<absorbScript>();
        if (absScr == null)
        {
            Debug.LogError("AbsorbScript component not found on the rod!");
        }
    }

    // Update is called once per frame
    //This function will trace players cursor and check if clicks happen on top of switch causing action
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //CCheck click location using Raycast
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            //Change switch sprite if click hit switch
            if ( hit.collider != null && hit.transform == transform)
            {
                changeSprite();
            }
        }
    }

    [ContextMenu("change sprite")]
    void changeSprite()
    {
        //ERror control
        if (sr == null)
        {
            Debug.LogError("SpriteRenderer not assigned.");
            return;
        }

        //changing sprite to on and off status
        //also change the flag that determines 
        //CAtivity flag tells us if the switch is on or not
        if (activityFlag)
        {
            //change sprite
            sr.sprite = spriteOff;
            //Change flag
            activityFlag = false;
            //change the actual activity flag on rod, by calling the absorbScripts activity() fucntion
            absScr?.activity();
        }
        else
        {
            //Change sprite
            sr.sprite = spriteOn;
            //change flag
            activityFlag = true;
            //change the actual activity flag on rod, by calling the absorbScripts activity() function
            absScr?.activity();
        }
    }
}
