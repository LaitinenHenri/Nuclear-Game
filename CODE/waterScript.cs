using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code is created by Henri Laitinen
// laitinenhenri@hotmail.com

//This script controls water blocks


public class waterScript : MonoBehaviour
{
    SpriteRenderer sr;
    int colorLimit = 4;
    int colorIndex = 0;
    List<Color> colors;

    //The gauge object is set in unity
    //This controls the cooltime
    public GameObject gaugeObj;

    
    private float coolWaterTimeLimit = 2.5f;
    float waterTimer;

    //Init the color of boilded water (white)
    Color boiledColor = new Color(255 / 255f, 255 / 255f, 255 / 255f);
    // Start is called before the first frame update
    void Start()
    {
        //Intializing the different colors of different tempurature water
        Color colorOne = new Color(173 / 255f, 216 / 255f, 230 / 255f);
        Color colorTwo = new Color(126 / 255f, 156 / 255f, 196 / 255f);
        Color colorThree = new Color(166 / 255f, 153 / 255f, 222 / 255f);
        Color colorSix = new Color(255 / 255f, 0 / 255f, 0 / 255f);
        colors = new List<Color> { colorOne, colorTwo, colorThree, colorSix , boiledColor};

        
        //Getting the spriterenderer of this object and setting the initial color
        sr = GetComponent<SpriteRenderer>();
        sr.color = colors[colorIndex];

        //Setting the time to zero, This time will be used to determin if cooldown time has been passed
        waterTimer = 0.0f;

    }

    // Update is called once per frame
    //Checking if cooldown time has been passed, and is it has changes the water temp, aka color
    void Update()
    {
        //Setting the tag to boiled when needed so neutron wont be destroye by boiled water blocks
        if (colorIndex == 4)
        {
            gameObject.tag = "boiled";
        }else if (colorIndex < colorLimit && gameObject.tag == "boiled")
        {
            gameObject.tag = "water";

        }

        //Setting the different cooldown times according to the gauges temp, that is set by player
        //Clicking the floww add and decrease buttons
        string gaugeTag = gaugeObj.tag;
        if (gaugeTag == "water0")
        {
            coolWaterTimeLimit = 100000f;
        }else if (gaugeTag == "water2")
        {
            coolWaterTimeLimit = 10f;
        }
        else if (gaugeTag == "water4")
        {
            coolWaterTimeLimit = 6f;
        }
        else if (gaugeTag == "water6")
        {
            coolWaterTimeLimit = 3f;
        }
        else if (gaugeTag == "water8")
        {
            coolWaterTimeLimit = 1.5f;
        }
        else if (gaugeTag == "water10")
        {
            coolWaterTimeLimit = 0.5f;
        }


        //If cooldown time has passed tempurature is brought down one stage
        waterTimer += Time.deltaTime;
        if(colorIndex > 0 && waterTimer >= coolWaterTimeLimit)
        {
            waterTimer = 0.0f;
            --colorIndex;
            sr.color = colors[colorIndex];
        }

        
    }

    //This function will handel interactions with nautrons
    //aka will "heat" up water is collided
    private void OnTriggerEnter2D(Collider2D collision)

    {
        // Handle interactions with neutrons
        if (collision.gameObject.CompareTag("neutron"))
        {
            //If the water hasn't already boiled index is increased by one and cooldown brough back to zero
            if (colorIndex < colorLimit)
            {
                waterTimer = 0.0f;
                ++colorIndex;
                //setting new color
                sr.color = colors[colorIndex];
                
            }
        }

    }

}
