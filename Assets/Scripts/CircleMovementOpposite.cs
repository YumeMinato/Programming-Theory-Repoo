using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CircleMovementOpposite : CircleMovement
{
    protected override void Start() //POLYMORPHIS
    {
        // Set the center object to the same object as the base class
        centerObject = base.centerObject;

        // Reset the angle to start moving in the opposite direction
        angle = Mathf.PI;

        // Set the initial position of the object to the current position of the transform
        initialPosition = transform.position;

        // Move the object to the starting position relative to the center object
        transform.position = initialPosition;

        base.targetPosition = new Vector3(-1547.695f, 6, -1351);
    }

    protected override void MoveInCircle() //POLYMORHPIS
    {
        // Calculate the new position of the object based on the current angle
        float x = radius * Mathf.Cos(angle);
        float z = radius * Mathf.Sin(angle);
        float y = transform.position.y;
        transform.position = new Vector3(x, y, -z) + centerObject.position;

        // Increase the angle for the next frame
        angle -= speed * Time.deltaTime;

        // If the angle is less than 0, reset it to 2*PI
        if (angle < -3.15)
        {
            angle = 2 * Mathf.PI;
            isMoving = false;
        }

        // Rotate the object around the Y axis to face the center of the circle
        transform.rotation = Quaternion.Euler(0, Mathf.Atan2(z, x) * Mathf.Rad2Deg, 0);
    }
}