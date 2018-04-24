using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public float turnSpeed = 10;
    public float viewClamp = 90.0f;

    private float rotation;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * turnSpeed * Time.deltaTime);
        rotation += Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;
        rotation = Mathf.Clamp(rotation, -viewClamp, viewClamp);
        transform.localEulerAngles = new Vector3(-rotation, transform.rotation.y, transform.rotation.z);

    }
}
