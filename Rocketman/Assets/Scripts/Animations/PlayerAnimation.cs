using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public Animator _animator;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        
    }

    public void TurningAnimation(bool isTurning)
    {
        if (isTurning == _animator.GetBool("isTurning")) return;

        _animator.SetBool("isTurning", isTurning);
    }
    public void OpeningAnimation(bool isOpening)
    {
        if (isOpening == _animator.GetBool("isOpening")) return;

        _animator.SetBool("isOpening", isOpening);
    }
    public void ClosingAnimation(bool isClosing)
    {
        if (isClosing == _animator.GetBool("isClosing")) return;

        _animator.SetBool("isClosing", isClosing);
    }
}
