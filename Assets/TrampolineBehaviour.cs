using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineBehaviour : MonoBehaviour
{
    public float jumpForce = 10f;
    public float jumpTime = 0.5f;
    public float jumpDelay = 0.5f;
    public Animator Animator;

    // SI l'ia n'est pas trigger
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Animator.SetTrigger("Jump");
            StartCoroutine(Jump(collision.gameObject));
            wait();
            Animator.ResetTrigger("Jump");
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
    }

    private IEnumerator Jump(GameObject player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity;
        rb.velocity = new Vector2(velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(jumpTime);
        rb.velocity = new Vector2(velocity.x, 0);
        yield return new WaitForSeconds(jumpDelay);
    }
}
