using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SWNavigation : MonoBehaviour {
    public Camera camera;
    public NavMeshAgent agent;
    public bool selected = false;
    private Color defaultMaterialColor;

    void Start() {
        defaultMaterialColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update() {
        UserClicked();
    }

    void UserClicked() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            var rayCast = Physics.Raycast(ray, out hit); //true if ray hits something
            if (rayCast) {
                if (hit.transform.name == transform.gameObject.name) { //click or unclick
                    selected = !selected;
                    ChangeTexture();
                } else if (selected && !hit.transform.name.Contains("Agent")) { 
                    //if clicked, and destination is not an agent, then set destination
                    agent.SetDestination(hit.point);
                }
            }
        }
    }

    void ChangeTexture() {
        var currMaterial = GetComponent<Renderer>().material;
        if (currMaterial.color == defaultMaterialColor) { //select
            currMaterial.color = Color.blue;
        } else { //deselect
            currMaterial.color = defaultMaterialColor;
        }
    }

}
