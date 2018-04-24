using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class Enemy : MonoBehaviour {

    public UnityEngine.AI.NavMeshAgent agent { get; private set; }
    CharacterController controller;

    public float chaseRange = 5;
    public float movementSpeed = 1;
    public int health = 1;
    public int damage = 1;

    public bool attacking = false;
    public float attackInterval = 1;

    // the target the agent will seek first
    public Transform primaryTarget;
    // the target the agent will seek when needed
    public Transform secondaryTarget;

    public GameObject gController;

    private Transform target;
    private Animator animator;
    public float timer;

    // Use this for initialization
    void Start () {
        timer = attackInterval;
        gController = GameObject.Find("GameController");
        primaryTarget = gController.GetComponent<GameController>().EnemyPrimaryTarget;
        secondaryTarget = gController.GetComponent<GameController>().EnemySecondaryTarget;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();

        controller = GetComponent<CharacterController>();
        agent.updatePosition = true;
        agent.updateRotation = true;

        target = primaryTarget;

    }
	
	// Update is called once per frame
	void Update () {
        if (target != null) {
            agent.SetDestination(target.position);
        }

        if (agent.remainingDistance > agent.stoppingDistance) {
            controller.Move(agent.desiredVelocity * movementSpeed * Time.deltaTime);
        }
	}

    public void DetectsSecondary(bool detected) {
        if (detected)
            target = secondaryTarget;
        else
            target = primaryTarget;
    }

    public  void Damage(int damageTaken) {
        health -= damageTaken;
        if (health <= 0) {
            gController.GetComponent<GameController>().score++;
            Debug.Log("Hit 'im");
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            if (timer <= 0) {
                attacking = true;
                animator.SetBool("Attacking", attacking);
                other.GetComponent<Player>().Damage(damage);
                timer = attackInterval;
            } else {
                attacking = false;
                animator.SetBool("Attacking", attacking);
                timer -= 1 * Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            timer = attackInterval;
        }
    }
}
