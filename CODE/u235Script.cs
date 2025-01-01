using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code is created by Henri Laitinen
// laitinenhenri@hotmail.com

//this script is running on every U235 object and controlls them

public class u235Script : MonoBehaviour
{

    SpriteRenderer sr;

    public GameObject neutronObj;

    public GameObject uraniumObj;

    bool canShoot = true;

    float cooldownTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the sprite renderer of thhis object and set the color to blue
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.blue;
    }


    private void OnTriggerEnter2D(Collider2D collision)

    {
        // Handle interactions neutron
        //aka when (slow)neutron hits U235 the u235 gets destroyed, spawns two new (fast)neutrons
        //and spawns an uranium object in its place
        if (collision.gameObject.CompareTag("neutron"))
        {
            sr.color = Color.red;
            //Debug.Log("COllision");
            if (canShoot)
            {
                spawnNeutron();
                spawnNeutron();

            }

            spawnUranium();

            


        }

    }

    IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldownTime);  // Wait for the cooldown period
        canShoot = true;  // Allow shooting again after cooldown
    }

    //this function will spawn and nerw neutron
    void spawnNeutron()
    {
        //Initializing the position of the neutron
        Vector2 positionVec = new Vector2(transform.position.x, transform.position.y);

        //Spawning the neutron (copy of original)
        Instantiate(neutronObj, positionVec, Quaternion.identity);
    }

    //This function will spawn an Uranium in the place of the u235 that is destroyed
    void spawnUranium()
    {
        //Initializing the position
        Vector2 positionVec = new Vector2(transform.position.x, transform.position.y);

        //spawing the uranium
        Instantiate(uraniumObj, positionVec, Quaternion.identity);

        //Destroying the U235
        Destroy(gameObject);
    }
}
