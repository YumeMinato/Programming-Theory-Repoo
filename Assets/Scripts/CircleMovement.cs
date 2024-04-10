using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public Transform centerObject; // The center object of the circle
    protected float radius = 10f; // The radius of the circle
    protected float speed = 1f; // The speed of the movement
    protected Vector3 initialPosition; // The initial position of the object
    protected float angle = 0f; // The current angle of the object in the circle
    protected bool isMoving = false;
    protected Vector3 targetPosition;

    protected virtual void Start()
    {
        // Set the initial position of the object to the current position of the transform
        initialPosition = transform.position;
        targetPosition = new Vector3(-1572.305f, 6, -1351);
    }

    protected virtual void Update()
    {
        if (isMoving)
        {
            MoveInCircle();
        }
    }

    protected virtual void MoveInCircle()
    {
        // Calculate the new position of the object based on the current angle
        float x = radius * Mathf.Cos(angle);
        float z = radius * Mathf.Sin(angle);
        transform.position = new Vector3(x, 0, z) + centerObject.position;

        // Increase the angle for the next frame
        angle += speed * Time.deltaTime;

        // If the angle is greater than 2*PI, reset it to 0 and stop the object
        if (angle > 2 * Mathf.PI)
        {
            angle = 0;
            isMoving = false;
        }

        // Rotate the object around the Y axis to face the center of the circle
        transform.rotation = Quaternion.Euler(0, Mathf.Atan2(-z, x) * Mathf.Rad2Deg, 0);
    }

    public void StartMoving()
    {
        isMoving = true;
    }

}