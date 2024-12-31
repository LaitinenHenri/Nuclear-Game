using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will set up the game by basically spawing in every object on the screen

public class Spawner : MonoBehaviour
{
    //All objects that are spawned
    public GameObject waterObj;
    public GameObject uraniumObj;
    public GameObject bouncer;
    public GameObject absorbObj;
    public GameObject  u235Obj;
    public GameObject switchObj;

    public int uraniumLimit=9;


    //Setting the grid size and pos as public so easier to test in unity
    public int numOfRows = 7;
    public int numOfColumns = 9;

    private float initY = 14.875f;
    private float initX = -27.125f;

    //LIst of all position where to spawn items (Water and uranium)
    //List within list
    List<List<float>> positionList = new List<List<float>>();

    //LIst of all positions where rods and bouncers are spwned
    private List<GameObject> allRods = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        //set the iniital positions
        initX = -32.175f;
        initY = 16.875f;

        float bouncerx = -33f;
        float bounceRY = 2.0f;

        //set the first postiion manually and add it to the positionList
        List<float> firstPos = new List<float> {bouncerx, bounceRY};

        positionList.Add(firstPos);

        //initialize the big gab between objects
        float bigGab = 7f;

        //Go through every column and create new position
        for (int i =1; i<numOfColumns; ++i)
        {
            //new x pos is always one big gab away from old
            float newBouncerX = bouncerx + bigGab;
            List<float> newPos = new List<float> { newBouncerX, bounceRY };
            positionList.Add(newPos);

            //save old x pos
            bouncerx = newBouncerX;
        }
    
        //spawn an bouncer on each position
        foreach (List<float> bouncerFinalList in positionList)
        {
            spawnItem(bouncer, bouncerFinalList);
        }

        //clear the list so we can re use
        positionList.Clear();


        //Initialize the list for rod positions and set the first position
        List<List<float>> rodPos = new List<List<float>>();
        float absorbX = initX + 2.625f;
        float absorbY = 2.0f;
        float switchY = -16.875f;

        List<float> firstAbsPos = new List<float>() { absorbX, absorbY};
        rodPos.Add(firstAbsPos);


        //Do the same for switches, note that the X is same as in ROds
        List<List<float>> switchList = new List<List<float>>();
        List<float> firstSwitch = new List<float>() { absorbX, switchY };
        switchList.Add(firstSwitch);



        //Go through every row while creating new positinos and adding them to the rrod and switch list
        for (int i = 0; i<numOfRows; ++i)
        {
            absorbX = absorbX + bigGab;
            List<float> newPos = new List<float>() { absorbX, absorbY };
            List<float> switchPos = new List<float>() { absorbX, switchY };
            rodPos.Add(newPos);
            switchList.Add(switchPos);
        }


        //Call function that spwans all the rods and switches
        rodAndSwitchSpawning(absorbObj, switchObj, rodPos, switchList);

        


        float ogX = initX; 
        int keraus=0;

        //Go through every position where a uranium has to be spawned and create new positon that is added to the list
        //19 rows and 33 collumns
        for (int i=1; i<19; ++i)
        {
            for (int ii = 1; ii<33; ++ii)
            {
                //creating new position (LIst<float>)
                List<float> newList = new List<float> { initX, initY };
                //add to list
                positionList.Add(newList);
                //change the x and y for the next position
                keraus += i + ii;
                initX += 1.75f;
            }
            //Bring x back to original and lower y by one for next row
            initX = ogX;
            initY -= 1.75f;
            Debug.Log(initY);
        }

        //This float is randomly assinged and determines if u235 or uranium is spawned
        float spawnU235;


        //this forloop spawns an objectc on each position while going through every position in list
        //water object is spawned on every position first and then either u235 or uranium'
        //20/100 u235 and 80/100 uranium assigned randomly
        foreach (List<float> posList in positionList)
        {
            //Spawn waters for this pos
            spawnItem(waterObj, posList);

            //Assign the random float that determines if spawnable is u235 or uranium
            spawnU235 = Random.Range(0f, 100f);

            if(spawnU235 < 20f)
            {
                spawnItem(u235Obj, posList);
            }
            else 
            {

                spawnItem(uraniumObj, posList);
            }


        }

        
    }


    //This function spwans the object that is given as a parameter (objToSpawn) to the postion given as a parameter (position)
    void spawnItem(GameObject objToSpawn, List<float> position)
    {
        Vector2 positionVec = new Vector2(position[0], position[1]);


        Instantiate(objToSpawn, positionVec, Quaternion.identity);

    }

    //THis function was specificly made for spawning rods and switches
    //Parameters are the gameobjects of rod and switch and postion listst
    //This function goes through those lists and spawns the corresponding object to those positions
    void rodAndSwitchSpawning(GameObject rodObject, GameObject swiObj, List<List<float>>rodPosi, List<List<float>> swiPos)
    {
        GameObject newRod = new GameObject();
        foreach (List<float> posiLista in rodPosi) 
        {
            Vector2 positionVec = new Vector2(posiLista[0],posiLista[1]);

            newRod = Instantiate(rodObject, positionVec, Quaternion.identity);
            allRods.Add(newRod);
        }
        int index = 0;
        foreach (List<float> posiLista in swiPos)
        {
            Vector2 positionVec = new Vector2(posiLista[0], posiLista[1]);

            GameObject newSwitch = Instantiate(swiObj, positionVec, Quaternion.identity);

            switchScript sS = newSwitch.GetComponent<switchScript>();
            sS.SetRod(allRods[index]);
            ++index;
        }
    }
}
