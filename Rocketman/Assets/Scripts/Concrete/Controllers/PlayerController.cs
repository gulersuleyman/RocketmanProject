using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PullAndThrow
{
    
    PlayerAnimation _playerAnimation;

    public bool _cameraMover;
    
    void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _cameraMover = false;
    }

    void Update()
    {
        if (_isBeginning)
        {
            if (_input.MouseClick)
            {
                _playerAnimation._animator.SetFloat("Pull", distance);
                
            }
            if (_input.MouseUp)
            {
                _playerAnimation.TurningAnimation(true);
                _cameraMover = true;
            }
        }
        PullThrow();
    }

    
}
