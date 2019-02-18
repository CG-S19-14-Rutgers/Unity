using UnityEngine;

public class SWCamera : MonoBehaviour {
    private float X;
    private float Y;
    public float dragSpeed = 2f;
    public float rotateSpeed = 0.00001f;
    private Vector3 dragOrigin;

    float heightMax = 10f;
    float heightMin = 3f;
    float scrollSpeed = 5f;

    //
    public float dragSpeede = 2;
    private Vector3 dragOrigine;

    public bool cameraDragging = true;

    public float outerLeft = -10f;
    public float outerRight = 10f;

    void Update() {
        MoveCamera();
        //RotateCamera();
        ZoomCamera();
    }

    //click and drag to move camera
    void MoveCamera() {
        if (!Input.GetMouseButton(1)) {
            return;
        }
        if (Input.GetMouseButtonDown(1)) {
            dragOrigin = Input.mousePosition;
            return;
        }
        
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        transform.Translate(move, Space.World);
    }


    //middle click to rotate camera
    void RotateCamera() {
        float X;
        float Y;
        if (Input.GetMouseButton(2)) {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * rotateSpeed, -Input.GetAxis("Mouse X") * rotateSpeed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }
    }

    //scroll to zoom camera
    void ZoomCamera() {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            GetComponent<Camera>().fieldOfView--;
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            GetComponent<Camera>().fieldOfView++;
        }
    }
}