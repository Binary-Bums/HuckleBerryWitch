using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public Transform[] targetPositions;
    public float movementSpeed = 1f;

    private GameObject player;   
    private int currentTargetIndex = 0;
    private bool isMoving = false;
    private float distance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (targetPositions.Length > 0)
        {
            MoveToNextTarget();
        }
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if( distance < 1){

        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }
    }

    private void MoveToNextTarget()
    {
        if (targetPositions.Length > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
            Debug.LogWarning("No target positions set for the cat.");
        }
    }

    private void MoveTowardsTarget()
    {
        Vector3 targetPosition = targetPositions[currentTargetIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // Check if the cat has reached the current target position
        if (transform.position == targetPosition)
        {
            // Perform any actions you want when the cat reaches the target position

            currentTargetIndex++;
            if (currentTargetIndex >= targetPositions.Length)
            {
                currentTargetIndex = 0;
            }

            MoveToNextTarget();
        }
    }
}