using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullStickAnimation : PullAndThrow
{

    Animator _animator;
    

    
    void Start()
    {
        _animator = GetComponent<Animator>();

    }

    
    void Update()
    {
        if (_isBeginning)
        {
            if (_input.MouseClick)
            {
                _animator.SetFloat("Pull", distance);
            }
            if(_input.MouseUp)
            {
                ReleaseAnimation(true);
            }
        }
        PullThrow();
    }

    public void ReleaseAnimation(bool isReleasing)
    {
        if (isReleasing == _animator.GetBool("Release")) return;

        _animator.SetBool("Release", isReleasing);
    }
}
