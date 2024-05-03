using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DieBehaviour : MonoBehaviour
{
    public GameObject Player;
    public Animator Animator;
    private bool _isDie = false;

    public void killPlayer(string message)
    {
        if (_isDie) return;
        _isDie = true;
        // debug
        Debug.Log(message);
        ResetAnimation();
        Animator.SetTrigger("die");
        // Bloquer le joueur a la position actuelle
        Player.GetComponent<PlayerMovementBehaviour>().enabled = false;
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(2);
        Player.transform.position = new Vector3(0, 0, 0);
        Player.GetComponent<PlayerMovementBehaviour>().enabled = true;
        _isDie = false;
    }

    private void ResetAnimation()
    {
        Animator.ResetTrigger("jump");
        Animator.SetFloat("velocityX", 0);
        Animator.SetFloat("velocityY", 0);
        Animator.ResetTrigger("fall");
        Animator.ResetTrigger("die");
    }
}
