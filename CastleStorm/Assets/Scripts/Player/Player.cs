using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController controller;

    public float movementSpeed = 10;
    public float turnSpeed = 50;

    // Use this for initialization
    void Start () {
        controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 movement = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
            movement.z += (movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            movement.z -= (movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            movement.x += (movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            movement.x -= (movementSpeed * Time.deltaTime);

        controller.transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X"),0) * turnSpeed * Time.deltaTime);

        transform.Translate(movement);
    }
}
