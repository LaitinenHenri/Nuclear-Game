using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script is used for the start button on the strating screen
//WIll load the game scene when the button is pressed



public class sceneManagingScript : MonoBehaviour
{
    void Update()
    {
        //Tracks the mouse position
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            //If the mouse is clicked on top of the button the loadScene function is called
            if (hit.collider != null && hit.transform == transform)
            {
                Debug.Log("Hit");
                loadScene("SampleScene");
            }
        }
    }

    //THis function will just loadd the Game scene
    //Parameter sceneName is the name of the game scene ("SampleScene")
    void loadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);
    }
}
