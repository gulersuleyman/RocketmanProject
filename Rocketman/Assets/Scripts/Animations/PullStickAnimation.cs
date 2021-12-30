using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullStickAnimation : MonoBehaviour
{
    [SerializeField] float _distanceDecreaser = 100;

    Animator _animator;
    InputController _input;


    bool _isBeginning;
    bool _release;
    float _firstTouch;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
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
                distance = (_firstTouch - currentPosition)/ _distanceDecreaser;
                _animator.SetFloat("Pull", distance);
            }
            if(_input.MouseUp)
            {
                _release = true;
                ReleaseAnimation(_release);
                _isBeginning = false;
            }
        }
    }

    public void ReleaseAnimation(bool isReleasing)
    {
        if (isReleasing == _animator.GetBool("Release")) return;

        _animator.SetBool("Release", isReleasing);
    }
}
