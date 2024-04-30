using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FireBehaviour : MonoBehaviour
{
    public bool _isOn;
    public Animator Animator;
    private float _timer;

    // Update is called once per frame
    void Update()
    {
        // toute les deux secondes switch la valeur de _isOn
        _timer += Time.deltaTime; 
        if (_timer >= 3){
            _timer = 0;
            _isOn = !_isOn;
            Animator.SetBool("isOn", _isOn); 
        }
    }
}
