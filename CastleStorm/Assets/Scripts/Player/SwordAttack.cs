using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {

    public int damage = 1;
    public float swingTime = 2.0f;

    private float timer;
    private bool swinging = false;

    private Animation m_animation;
    private BoxCollider boxCollider;
    public AudioClip swing;
    public AudioSource playerAudio;
    // Use this for initialization
    void Start () {
        timer = swingTime;
        m_animation = gameObject.GetComponent<Animation>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && timer == swingTime) {
            swinging = true;
            boxCollider.enabled = true;
            m_animation.Play("SwordSwing");
            playerAudio.PlayOneShot(swing);
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

    private void OnTriggerStay(Collider other) {
        if (other.GetComponent<Enemy>()) {
            other.GetComponent<Enemy>().Damage(damage);
        }
    }
}
