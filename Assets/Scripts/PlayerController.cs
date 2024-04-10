using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 40.0f;
    public float speedMultiplier = 2;

    public float xnRange = 1628;
    public float xmRange = -1492;
    public float zBottomLimit = -1360;
    public float zTopLimit = -1310;

    private Vector3 movementDirection = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = 0;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            horizontalInput -= 1; // Move left
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            horizontalInput += 1; // Move right
        }

        float verticalInput = 0;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            verticalInput += 1; // Move up
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            verticalInput -= 1; // Move down
        }

        movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        float sprintModifier = Input.GetKey(KeyCode.LeftShift) ? speedMultiplier : 1f;

        // Move the player based on movement direction and sprint modifier
        transform.Translate(movementDirection * speed * sprintModifier * Time.deltaTime);

        ClampPlayerPosition();
    }

    void ClampPlayerPosition()
    {
        // Clamp X position within xRange
        float clampedX = Mathf.Clamp(transform.position.x, -xnRange, xmRange);

        // Clamp Z position within zBottom and zTop
        float clampedZ = Mathf.Clamp(transform.position.z, zBottomLimit, zTopLimit);

        // Update player position
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);

    }
}
