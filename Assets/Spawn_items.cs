using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_items : MonoBehaviour
{
    public float spawnTime=1; //Spawn Time
    public GameObject apple; //Apple prefab
    public GameObject bomb; //Bomb prefab
    public GameObject banana;
    public GameObject plum;
    public GameObject watermelon;
    public float upForce = 750; //Up force
    public float leftRightForce = 200; //Left and right force
    public float maxX = -7; //Max x spawn position
    public float minX = 7; //Min x spawn position

    void Start() {
        //Start the spawn update
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn() {
        //Wait spawnTime
        yield return new WaitForSeconds(spawnTime);
        //Spawn prefab is apple
        GameObject prefab = apple;
        //If random is over 30
        int randint = Random.Range(0,100);
        if (randint < 20) {
            //Spawn prefab is bomb
            prefab = bomb;
        } else if (randint < 40) {
            prefab = plum;
        } else if (randint < 60) {
            prefab = banana;
        } else if (randint < 80) {
            prefab = watermelon;
        }


        //Spawn prefab add randomc position
        GameObject go = Instantiate(prefab,new Vector3(Random.Range(minX,maxX + 1),transform.position.y, 0f),Quaternion.Euler(0,0, Random.Range (-90F, 90F))) as GameObject;
        //If x position is over 0 go left
        if (go.transform.position.x > 0)
        {
        go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-leftRightForce,upForce));
        }
        //Else go right
        else
        {
        go.GetComponent<Rigidbody2D>().AddForce(new Vector2(leftRightForce,upForce));
        }
        //Start the spawn again
        StartCoroutine("Spawn");
    }
}
