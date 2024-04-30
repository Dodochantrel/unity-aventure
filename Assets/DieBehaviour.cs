using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DieBehaviour : MonoBehaviour
{
    public GameObject Player;
    public Animator Animator;
    private float _timer;

    public void killPlayer(string message)
    {
        // debug
        Debug.Log(message);
        Animator.SetTrigger("die");
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(2);
        Player.transform.position = new Vector3(0, 0, 0);
    }
}
