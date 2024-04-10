using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 movementDirection = Vector3.zero;

    // ENCAPSULATION
    [SerializeField] private float speed = 40.0f;
    [SerializeField] private float speedMultiplier = 2;
    [SerializeField] private float xnRange = 1628;
    [SerializeField] private float xmRange = -1492;
    [SerializeField] private float zBottomLimit = -1360;
    [SerializeField] private float zTopLimit = -1310;

    // Properties can be used to encapsulate access to the private fields if needed
    public float Speed { get => speed; set => speed = value; }
    public float SpeedMultiplier { get => speedMultiplier; set => speedMultiplier = value; }
    public float XnRange { get => xnRange; set => xnRange = value; }
    public float XmRange { get => xmRange; set => xmRange = value; }
    public float ZBottomLimit { get => zBottomLimit; set => zBottomLimit = value; }
    public float ZTopLimit { get => zTopLimit; set => zTopLimit = value; }

    private void Update()
    {
        HandleInput();
        MovePlayer();
        ClampPlayerPosition();
    }

    private void HandleInput()
    {
        float horizontalInput = GetAxisInput(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.A, KeyCode.D);
        float verticalInput = GetAxisInput(KeyCode.DownArrow, KeyCode.UpArrow, KeyCode.S, KeyCode.W);

        movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
    }

    private float GetAxisInput(KeyCode negativeKey, KeyCode positiveKey, KeyCode alternativeNegativeKey, KeyCode alternativePositiveKey)
    {
        float input = 0;
        if (Input.GetKey(negativeKey) || Input.GetKey(alternativeNegativeKey))
        {
            input -= 1; // Negative direction
        }
        if (Input.GetKey(positiveKey) || Input.GetKey(alternativePositiveKey))
        {
            input += 1; // Positive direction
        }
        return input;
    }

    private void MovePlayer()
    {
        float sprintModifier = Input.GetKey(KeyCode.LeftShift) ? SpeedMultiplier : 1f;
        transform.Translate(movementDirection * Speed * sprintModifier * Time.deltaTime);
    }

    private void ClampPlayerPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -XnRange, XmRange);
        float clampedZ = Mathf.Clamp(transform.position.z, ZBottomLimit, ZTopLimit);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }
}
