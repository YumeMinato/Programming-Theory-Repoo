using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentAnimalMoving : AnimalMoving //INHERITANCE
{
    protected override void Update()
    {
        base.Update(); // Call the base class's Update method
        StopIfClose(); // Override stopping behavior for Object B
    }

    protected override void StopIfClose()
    {
        float stoppingDistance = 25.0f; // Adjust this value as needed for Object B
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.position);
        if (distanceToTarget < stoppingDistance)
        {
            speed = 0f; // Stop moving if close to the target
            circleMovement.StartMoving();
        }
    }
}
