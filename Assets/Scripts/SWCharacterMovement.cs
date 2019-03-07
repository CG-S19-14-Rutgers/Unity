using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWCharacterMovement : MonoBehaviour {

    float speed = 4f;
    float rotationspeed = 80f;
    public float rotation = 0;
    bool grounded = true;
    private Rigidbody rb;

    Vector3 moveDirection = Vector3.zero;

    CharacterController controller;
    Animator anim;

    private void Start() {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        anim.SetBool("Walking", false);
        anim.SetBool("Jumping", false);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if(transform.localPosition.y < 0.01) {
            transform.position += new Vector3(0, (float)0.01 - transform.localPosition.y, 0);
        }
        Jump();
        Move();
        Rotate();
    }

    void Move() {
        if (controller.isGrounded) { 
            if (Input.GetKey(KeyCode.W)) {
                anim.SetBool("Walking", true);
                transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
                return;
            } else {
                anim.SetBool("Walking", false);
            }

            if (Input.GetKey(KeyCode.S)) {
                anim.SetBool("Backward", true);
                transform.Translate(0, 0, -speed * Time.deltaTime, Space.Self);
                return;
            } else {
                anim.SetBool("Backward", false);
            }
        }
    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.LeftShift) && grounded) {
            anim.SetBool("Jumping", true);
            rb.AddForce(new Vector3(0, 30, 0), ForceMode.Impulse);
            grounded = false;
        }
        /*if(transform.localPosition.y <= 0.01) {
            grounded = true;
            anim.SetBool("Jumping", false);
        }*/
    }

    void Rotate() {
        float axis = Input.GetAxis("Horizontal");
        if (axis != 0) {
            rotation += axis * rotationspeed * Time.deltaTime;
            if (axis < 0) {
                anim.SetBool("Left", true);
            } else {
                anim.SetBool("Right", true);
            }
            if (Input.GetKey(KeyCode.W)) {
                anim.SetBool("Left", false);
                anim.SetBool("Right", false);
            }
        } else {
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
        }
        transform.eulerAngles = new Vector3(0, rotation, 0);

        moveDirection.y -= 8 * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
