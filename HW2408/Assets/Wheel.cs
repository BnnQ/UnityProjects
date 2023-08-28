using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    #region Movement logic
    private void HandleMovement()
    {
        var horizontalOffset = Input.GetAxis("Horizontal"); //1 (right) or -1 (left)
        if (horizontalOffset != 0)
        {
            var speed = 1f;
            if (Input.GetKey(KeyCode.LeftShift))
                speed *= 5f;
         
            rigidBody.AddForce(Vector2.right * horizontalOffset * speed);
        }
    }
    #endregion

    #region Jump logic
    public float jumpForce = 5f;
    public float chargeStepRate = 1f;
    private float currentCharge = 0f;
    public float maximumCharge = 45f;
    private bool isCharging = false;

    private void Jump()
    {
        //Debug.Log("Jumping with charge: " + currentCharge);
        rigidBody.AddForce(Vector3.up * (jumpForce + currentCharge), ForceMode2D.Impulse);
    }
    
    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCharging = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isCharging = false;
            Jump();
            currentCharge = 0f;
        } 

        if (isCharging && currentCharge < maximumCharge)
        {
            currentCharge += chargeStepRate;
        }
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJumping();
    }
    
}
