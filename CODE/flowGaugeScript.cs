using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the water flow gauge (spirits and tags)


public class flowGaugeScript : MonoBehaviour
{
    //The gameObject of the gauge
    public GameObject gaugeObj;

    //The spirits set in unity
    public Sprite sprite0;
    public Sprite sprite2;
    public Sprite sprite4;
    public Sprite sprite6;
    public Sprite sprite8;
    public Sprite sprite10;

    //The spiritrenderer of the object 
    private SpriteRenderer sr;

    //LIst of spirits and tags
    List<Sprite> spriteList;
    List<string> tagNameList;

    //The limit of the tags and the strating point of the tags
    int tagIndex = 3;
    int tagLimit = 5;

    // Start is called before the first frame update
    void Start()
    {
        //create the lists for tags and spirits 
        spriteList = new List<Sprite> () {  sprite0, sprite2, sprite4, sprite6, sprite8, sprite10 };
        tagNameList = new List<string>() { "water0", "water2", "water4", "water6", "water8", "water10" };
        
        
        sr = GetComponent<SpriteRenderer>(); // Initialize the SpriteRenderer and chek if obtained
        if (sr == null)
        {
            Debug.LogError("SpriteRenderer component not found!");
            return;
        }
    }

    
    
    //This is called when the add flow button is clicked
    public void addFlow()
    {
        //Check if the limit is reached
        if (tagIndex < tagLimit) 
        {
            //add one to index
            ++tagIndex;
            //Change tag and spirit
            gaugeObj.tag = tagNameList[tagIndex];
            sr.sprite = spriteList[tagIndex];

        }
    }

    //This is called when the decrese flow button is clicked
    public void decreaseFlow()
    {
        //Check if flow is at lowest
        if (tagIndex > 0)
        {
            //Decrese index by one
            --tagIndex;
            //Change tag and spirit
            gaugeObj.tag = tagNameList[tagIndex];
            sr.sprite = spriteList[tagIndex];

        }
    }
}
