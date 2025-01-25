using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public Vector2 moveDirection { get; private set; }
    public void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }
    public Vector2 lookVector { get; private set; }
    public void OnLookJoypad(InputValue value)
    {
        lookVector = value.Get<Vector2>();
    }
    public void OnLookMouse(InputValue value)
    {
        //Might need a different vector for the mouse, might not be between -1 and 1 like the joypad
        lookVector = value.Get<Vector2>();
    }
    public bool isShooting { get; private set; }
    public void OnShoot(InputValue value)
    {
        if (value.isPressed)
        {
           isShooting = true;
        }
    }
    public void OnControlsChanged()
    {
        Debug.Log("Controls Changed");
    }
    private void LateUpdate()
    {
        isShooting = false; // Reset the shooting state at the end of each frame // ONLY WORKS IF THE SHOOTING IS IN UPDATE FUNCTION
    }
    
}
