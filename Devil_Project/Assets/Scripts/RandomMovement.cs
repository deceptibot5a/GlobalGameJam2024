using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomMovement : MonoBehaviour
{
    [Header("RandomMovement parameters")]
    [SerializeField] float speed;
    [SerializeField] float minMovementTime;
    [SerializeField] float maxMovementTime;
    [SerializeField] float minWaitTime;
    [SerializeField] float maxWaitTime;

    bool facingRight = true;
    SpriteRenderer spriteRenderer;

    Vector2 direction;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        direction = RandomDirection();
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            direction = RandomDirection();

            yield return new WaitForSeconds(Random.Range(minMovementTime, maxMovementTime));
            
            direction = Vector2.zero;
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        }
        
    }

    private Vector2 RandomDirection()
    {
        int x = Random.Range(0, 8);

        return x switch
        {
            0 => Vector2.up,
            1 => Vector2.down,
            2 => Vector2.left,
            3 => Vector2.right,
            4 => new Vector2(1, 1),
            5 => new Vector2(1, -1),
            6 => new Vector2(-1, 1),
            _ => new Vector2(-1, -1),
        };
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.5f);

        if (hit.collider != null)
        {
            direction *= 0;
        }
        if (direction.x < 0 && facingRight)
        {
            Flip();
        }
        else if (direction.x > 0 && !facingRight)
        {
            Flip();
        }

    }
    void Flip()
    {
        facingRight = !facingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;

    }
    private void StopBehaviour()
    {
        StopAllCoroutines();
        direction = Vector2.zero;
    }
}
