using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController controller;

    public int health = 10;
    public int damage = 1;

    public float movementSpeed = 10;
    public float turnSpeed = 50;
    public float jumpSpeed = 10.0f;
    public float fallSpeed = 11.0f;

    public int maxEnemies = 10;
    public List<GameObject> enemies = new List<GameObject>();
    
    private bool isGrounded = false;
    private Vector3 moveDirection;
    private float verticalVelocity;

    // Use this for initialization
    void Start () {
        controller = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= movementSpeed;

        controller.transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X"),0) * turnSpeed * Time.deltaTime);

        isGrounded = Physics.Raycast(controller.transform.position, Vector3.down, 1.1f);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            verticalVelocity = jumpSpeed;
        }
        if (!isGrounded) {
            verticalVelocity -= fallSpeed;
        }
        moveDirection.y = verticalVelocity;
        controller.Move(moveDirection * Time.deltaTime);
    }
    

    private void OnTriggerEnter(Collider other) {
        if (other.transform.GetComponent<Enemy>() != null) {
            other.gameObject.GetComponent<Enemy>().DetectsSecondary(true);
            //enemies.Add(collision);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.transform.GetComponent<Enemy>() != null) {
            other.gameObject.GetComponent<Enemy>().DetectsSecondary(false);
            //enemies.Add(collision);
        }
    }
}
