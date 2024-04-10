using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMoving : MonoBehaviour
{

    public float speed = 40.0f;
    public Transform targetObject;
    public CircleMovement circleMovement;


    // Update is called once per frame
    protected virtual void Update()
    {
        MoveTowardsTarget();
        StopIfClose();
    }

    protected void MoveTowardsTarget()
    {
        float stoppingDistance = 25.0f; // Adjust this value as needed
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.position);
        if (distanceToTarget > stoppingDistance)
        {
            Vector3 targetDirection = (targetObject.position - transform.position).normalized;
            transform.Translate(targetDirection * speed * Time.deltaTime);
        }
    }

    protected virtual void StopIfClose()
    {
        float stoppingDistance = 25.0f  ; // Adjust this value as needed
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.position);
        if (distanceToTarget < stoppingDistance)
        {
            speed = 0f; // Stop moving if close to the target
            circleMovement.StartMoving();
        }
    }

}
