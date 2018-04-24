using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {

    public int damage = 1;
    public float swingTime = 2.0f;

    private float timer;
    private bool swinging = false;

    private BoxCollider boxCollider;
	// Use this for initialization
	void Start () {
        timer = swingTime;
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && timer == swingTime) {
            swinging = true;
            boxCollider.enabled = true;
        }

        if (timer <= 0) {
            swinging = false;
            boxCollider.enabled = false;
            timer = swingTime;
        }

        if (swinging) {
            timer -= 1 * Time.deltaTime;
        }
	}

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Enemy>()) {
            other.GetComponent<Enemy>().Damage(damage);
        }
    }
}
