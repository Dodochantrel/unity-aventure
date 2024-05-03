using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaBehaviour : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    private Vector2 _direction = new Vector2(-1, 0);
    public SpriteRenderer SpriteRenderer;
    public float maxLeft = 5.2f;
    public float maxRight = 10;

    void start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Si la position de l'IA est inférieure à -10, on relance move dans l'autre sens
        if (_rigidbody.position.x < maxLeft)
        {
            SpriteRenderer.flipX = false;
            _direction = new Vector2(1, 0);
        }
        // Si la position de l'IA est supérieure à 10, on relance move dans l'autre sens
        else if (_rigidbody.position.x > maxRight)
        {
            SpriteRenderer.flipX = true;
            _direction = new Vector2(-1, 0);
        }
        Move(_direction);
    }

    void Move(Vector2 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + direction * Time.fixedDeltaTime);
    }

    // Si l'ia est trigger
    // private void OnTriggerStay2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Player"))
    //     {
    //         collision.GetComponent<DieBehaviour>().killPlayer("Player is dead");
    //     }
    // }

    // SI l'ia n'est pas trigger
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<DieBehaviour>().killPlayer("Player is dead by IA");
        }
    }
}
