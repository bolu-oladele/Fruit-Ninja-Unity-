using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    private Vector3 acceleration;
    private Vector3 grav;
    private Vector3 push;
    private Vector3 velocity;
    private int mass = 10;

    private void applyForce(Vector3 force){
        Vector3 a = force/mass;
        acceleration += a;
    }

    private void updatePos(){
        velocity = velocity + acceleration ;
        transform.position += velocity*Time.deltaTime;
        acceleration = new Vector3 (0.0f,0.0f); //reset to zero
    }

    // Start is called before the first frame update
    void Start(){
        grav = new Vector3(0,-1, 0);
        push = new Vector3(-100, 200, 0); //upward left
        applyForce(push); //apply only once
    }

    // Update is called once per frame
    void LateUpdate() {
        applyForce(grav); //apply continuously
        updatePos();
    }
}

