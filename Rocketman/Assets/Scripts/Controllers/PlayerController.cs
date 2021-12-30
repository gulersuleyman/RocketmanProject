using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _distanceDecreaser = 100;

    
    InputController _input;
    PlayerAnimation _playerAnimation;

    bool _isBeginning;
    bool _release;
    float _firstTouch;
    
    void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _input = new InputController();

        _isBeginning = true;
    }

    void Update()
    {
        if (_isBeginning)
        {

            float currentPosition;
            float distance;

            if (_input.FirstMouseClick)
            {
                _firstTouch = Input.mousePosition.x;
            }
            if (_input.MouseClick)
            {
                currentPosition = Input.mousePosition.x;
                distance = (_firstTouch - currentPosition) / _distanceDecreaser;
                _playerAnimation._animator.SetFloat("Pull", distance);
                
            }
            if (_input.MouseUp)
            {
                _release = true;
                _playerAnimation.TurningAnimation(_release);
                _isBeginning = false;
            }
        }
    }

    
}
