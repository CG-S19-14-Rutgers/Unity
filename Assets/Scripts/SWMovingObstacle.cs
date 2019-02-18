using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWMovingObstacle : MonoBehaviour{
    float speed = 4f;
    float boundary = 10f;
    bool forwards = true;
    bool started = false;
    Vector3 startingLocation;

    void Start() {
        startingLocation = transform.position;
    }
    // Update is called once per frame
    void Update() {
        if (forwards) {
            if (transform.position.z < startingLocation.z + boundary) { //has not hit boundary
                transform.Translate((Vector3.forward * speed) * Time.deltaTime);
            } else {
                forwards = false;
            }
        } else {
            if (transform.position.z > startingLocation.z - boundary) { //has not hit boundary
                transform.Translate((Vector3.back * speed) * Time.deltaTime);
            } else {
                forwards = true;
            }
        }
    }
}
