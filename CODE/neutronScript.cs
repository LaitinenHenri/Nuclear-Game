using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code is created by Henri Laitinen
// laitinenhenri@hotmail.com

//This script handles how the flying neutrons act. 
//These neutrons are spawned from the Uraniums at random to an random direction and when neutron collides with U235
//Each neutron is running this script
//This scripts is called when uranium script "spawns" neutron and creates neutron object
//NEutrons will not interact with U235 Object before bouncing off of a bouncer


public class neutronScript : MonoBehaviour
{
    //Set speed of neutron public so they can be alterd in unity
    public float speed = 15;

    //The rigidbody of the neutron that is set on unity
    public Rigidbody2D body;

    //The new speed of neutron after it has collided with an bouncer
    public float newSpeed = 4f;

    //The lenght of grace period as public so we can alter on unity
    //During grace period neutro will not effect other unities
    public float gracePeriod = 1.0f;

    //Odds of water destroying the neutron 20 out of 100
    public float waterOdd = 20f;

    //float to track how long neutron has been "alive"
    private float timeSinceSpawn;

    //the direction of the neutron when it spawns initialized
    private Vector2 initDir;

    /* Start is called before the first frame update
    This function will randomly assing an direction for this neutron and sets
    the neutron to move to that direction with the initial speed (15) */
    void Start()
    {

        // Assinging the body as the rigidbody of the neutron
        body = GetComponent<Rigidbody2D>();

        //Set neutron direction to random
        float randomDir = Random.Range(0f, 6.28318530718f);
        
        //Set the direction of the neutron
        initDir = new Vector2(Mathf.Cos(randomDir), Mathf.Sin(randomDir));
        
        //SEt the object tag as "youngNeutron" so it will not effect other objects during graceperiod
        gameObject.tag = "youngNeutron";

        
        //Set the velocity of the rigidBody so the object will actually move
        body.velocity = initDir * speed;

        
        timeSinceSpawn = 0f;
    }

    // Update is called once per frame
    //This function will just check if graceperiod is over and updagte the tag if it is
    void Update() {

        //Add time alive to the float
        timeSinceSpawn += Time.deltaTime;

        //If the neutron has been "alive" longer then the graceperiod the object tag will be vhnaged to "neutron"
        if(timeSinceSpawn > gracePeriod)
        {
            gameObject.tag = "neutron";
        }
    }

    
    //This function will be ran when th eneutron passes through an object
    //Parameter collision is the Object the neutron is passing through 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle interactions with uranium or water, ie destroy neutron if
        if (collision.gameObject.CompareTag("U235"))
        {
            //Debug.Log("Neutron destroy! & hit obios");
            Destroy(gameObject);


        }
        //Handle interaction with border, ie destroys the neutron when off screen
        else if (collision.gameObject.CompareTag("border"))
        {
            //Debug.Log("Neuron out of bounds");
            Destroy(gameObject);
        }
        //Handels interaction with stop block
        //Used for storing original netron object off screen
        else if (collision.gameObject.CompareTag("stop"))
        {
            //Debug.Log("Neuron stoppped");
            Vector2 stopDir = new Vector2(0, 0);
            body.velocity = stopDir * 0;
        }
        //Handles interaction with water blocks
        //Netrons are destroyad randomly when passing through water block, that is set by watrerDestroy float
        else if (collision.gameObject.CompareTag("water"))
        {
            float waterDestroy = Random.Range(0f, 100f);
            if (waterDestroy < waterOdd )
            {
                Destroy(gameObject);
            }
        }

    }

    //This function will be ran when the nettron collides with an object (bouncer)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If neutron collides with bouncer the New direction is set and speed is set as newSpeed (4)
        // Also the objet layer is changed so it can interact with U235
        if (collision.gameObject.CompareTag("bouncer"))
        {

            Vector2 currentVelocity = body.velocity;

            Vector2 currentDirection = currentVelocity.normalized;

            body.velocity = currentDirection * newSpeed;

            gameObject.layer = 7;

        }
    }

}
