using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWManualMovement : MonoBehaviour {

    // Update is called once per frame
    float speed = 3.0f;
    bool selected = false;
    public Camera camera;
    public Color defaultcolor;

    private void Start() {
        defaultcolor = transform.GetComponent<Renderer>().material.color;
    }

    void Update() {
        UserClicked();
        if (selected) {
            Movement();
        }
    }

    void UserClicked() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            var rayCast = Physics.Raycast(ray, out hit); //true if ray hits something
            if (rayCast) {
                if (hit.transform.name == transform.gameObject.name) { //click or unclick
                    if (selected) {
                        selected = false;
                        transform.GetComponent<Renderer>().material.color = defaultcolor;
                    } else {
                        selected = true;
                        transform.GetComponent<Renderer>().material.color = Color.blue;
                    }
                }
            }
        }
    }

    void Movement() {
        var move = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        transform.position += move * speed * Time.deltaTime;
    }
}