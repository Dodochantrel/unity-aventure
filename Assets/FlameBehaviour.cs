using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBehaviour : MonoBehaviour
{
    public FireBehaviour fireBehaviour;

    // Update is called once per frame
    void Update()
    {
        if (fireBehaviour._isOn) {
            transform.localScale = new Vector3(1, 1, 1);
        } else {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && fireBehaviour._isOn)
        {
            collision.GetComponent<DieBehaviour>().killPlayer("Player is dead");
        }
    }
}
