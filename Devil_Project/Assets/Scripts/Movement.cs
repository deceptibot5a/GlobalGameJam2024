using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed = 3f;

    private Rigidbody2D player;

    private Vector2 moveInput;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
    }

    

    private void FixedUpdate()
    {
        player.MovePosition(player.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
