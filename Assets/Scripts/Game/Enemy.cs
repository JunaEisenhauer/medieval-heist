using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float walkRadius = 20f;
    public View view;

    public Animator animator;

    private Vector3? nextDestination;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        GameObject player = GameManager.Instance().player;

        if (view.IsPlayerInSight(transform.position))
        {
            agent.SetDestination(player.transform.position);
        }
        else if (!agent.hasPath)
        {
            Vector3 randomPosition = UnityEngine.Random.insideUnitSphere * walkRadius + transform.position;

            if (nextDestination.HasValue)
            {
                randomPosition = nextDestination.Value;
                nextDestination = null;
            }

            NavMeshHit hit;
            NavMesh.SamplePosition(randomPosition, out hit, walkRadius, 1);
            agent.SetDestination(hit.position);
        }

        if (agent.path.corners.Length <= 1)
        {
            return;
        }

        Vector3 movement = transform.position - agent.path.corners[1];
        float horizontal = movement.x;
        float vertical = movement.z;

        int direction = 2;
        if (Math.Abs(horizontal) > Math.Abs(vertical))
        {
            direction = horizontal < 0 ? 1 : 3;
        }
        else if (Math.Abs(horizontal) < Math.Abs(vertical))
        {
            direction = vertical < 0 ? 0 : 2;
        }

        animator.SetInteger("direction", direction);
        view.UpdateDirection(movement);
    }

    public void SetNextDestionation(Vector3 destination)
    {
        nextDestination = destination;
    }

    private void OnDrawGizmos()
    {
        if (agent != null)
        {
            Debug.DrawLine(transform.position, agent.destination, Color.blue);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == GameManager.Instance().player)
        {
            GameManager.Instance().Lost();
        }
    }
}
