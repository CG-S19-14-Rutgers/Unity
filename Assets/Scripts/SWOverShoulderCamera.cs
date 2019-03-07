using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWOverShoulderCamera : MonoBehaviour{

    private const float yAngleMin = 0f;
    private const float yAngleMax = 50.0f;

    public Transform lookAt;
    public Transform camTransform;

    public Camera camera;

    public Vector3 camerapos = new Vector3(-0.5f,1.5f,-3);

    private float distance = 0.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;

    private void Start() {
        camTransform = transform;
        camera = Camera.main;
    }

    private void Update() {
        currentX = lookAt.GetComponent<SWCharacterMovement>().rotation;
        currentY += Input.GetAxis("Mouse Y") * 2;

        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
    }

    private void LateUpdate() {
        Quaternion rotation = Quaternion.Euler(currentY, currentX,0);
        camTransform.position = lookAt.position + (rotation * camerapos);
        camTransform.LookAt(lookAt.position);
    }
}