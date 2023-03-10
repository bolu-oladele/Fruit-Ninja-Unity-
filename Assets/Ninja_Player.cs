using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_Player : MonoBehaviour
{
    public int score= 0; //Score
    public GameObject splat;

    void Start () {
        //Set screen orientation to landscape
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        //Set sleep timeout to never
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        
    }

    void Update () {
        //If the game is running on an iPhone device
        if (Application.platform == RuntimePlatform.IPhonePlayer) {
            //If we are hitting the screen
            if (Input.touchCount == 1)
                {
                //Find screen touch position, by
                //transforming position from screen space into game world space.
                //Set position of the player object
                transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 1)).x,Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 1)).y,3);
                //Set collider to true
                GetComponent<Collider2D>().enabled = true;
                return;
                }
            //Set collider to false
            GetComponent<Collider2D>().enabled = false;
            }
            //If the game is not running on an iPhone device
        else {
            //Set position
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)).x,Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)).y,3);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Fruit")
        {
            other.GetComponent<Fruit2D>().Hit();
            score ++;
            Debug.Log (score);
            Instantiate(splat, transform.position, transform.rotation);
        }
        else if (other.tag == "Enemy")
        {
            other.GetComponent<Fruit2D>().Hit();
            score = score - 2;
            Debug.Log (score);
        }
    }
}
