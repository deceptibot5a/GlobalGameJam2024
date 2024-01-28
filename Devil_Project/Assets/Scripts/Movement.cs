using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed = 3f;
    SpriteRenderer spriteRenderer;

    bool facingRight = true;
    private Rigidbody2D player;

    private Vector2 moveInput;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
        if (moveX < 0 && facingRight)
        {
            Flip();
        }
        else if (moveX > 0 && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    private void FixedUpdate()
    {
        player.MovePosition(player.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
