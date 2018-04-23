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

    // the target the agent will seek first
    public Transform primaryTarget;
    // the target the agent will seek when needed
    public Transform secondaryTarget;

    private Transform target;

    public GameObject control;

    // Use this for initialization
    void Start () {
        control = GameObject.Find("GameController");
        primaryTarget = control.GetComponent<GameController>().EnemyPrimaryTarget;
        secondaryTarget = control.GetComponent<GameController>().EnemySecondaryTarget;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

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

        // checks if the player is close enough to chase, and chases them
        //if (Vector3.Distance(controller.transform.position, secondaryTarget.position) < chaseRange) {
        //    target = secondaryTarget;
        //}
        //else {
        //    target = primaryTarget;
        //}
	}

    public void DetectsSecondary(bool detected) {
        if (detected)
            target = secondaryTarget;
        else
            target = primaryTarget;
    }
}
