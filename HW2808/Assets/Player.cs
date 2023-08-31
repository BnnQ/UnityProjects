using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private OnGroundWatcher onGroundWatcher;
    private SpriteRenderer spriteRenderer;
    private CoinService coinService;

    [Header("Animation Settings")] public Animator Animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        onGroundWatcher = GetComponent<OnGroundWatcher>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coinService = ServiceContainer.CoinService;
    }

    #region Movement

    [Header("Movement Settings")] public float Speed = 1f;

    private void FlipFacingSide(float horizontalOffset)
    {
        spriteRenderer.flipX = horizontalOffset < 0;
    }
    
    private void HandleMovement(float horizontalOffset)
    {
        if (horizontalOffset != 0)
        {
            FlipFacingSide(horizontalOffset);
            rigidBody.velocity = new Vector2(horizontalOffset * Speed, rigidBody.velocity.y);
        }
    }
    #endregion

    #region Jumping

    [Header("Jumping Settings")] public float JumpForce = 1f;

    private void HandleJumping(bool isJumpKeyPressed, bool isGrounded)
    {
        if (isJumpKeyPressed && isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, JumpForce);
        }
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        var horizontalOffset = Input.GetAxis(Axis.Horizontal);
        Animator.SetFloat("HorizontalOffset", Mathf.Abs(horizontalOffset));
        HandleMovement(horizontalOffset);

        var isJumpKeyPressed = Input.GetKey(KeyCode.Space);
        var isGrounded = onGroundWatcher.IsGrounded;
        HandleJumping(isJumpKeyPressed, isGrounded);
    }
}
