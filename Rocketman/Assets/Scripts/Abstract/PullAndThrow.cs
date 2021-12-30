using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PullAndThrow : MonoBehaviour
{
    public float _distanceDecreaser = 100;

    protected bool _isBeginning;
    protected bool _release;
    protected float _firstTouch;
    protected float distance;

    protected InputController _input;

    void Awake()
    {
        _isBeginning = true;
        _input = new InputController();
    }

    protected void PullThrow()
    {
        if (_isBeginning)
        {

            float currentPosition;
            

            if (_input.FirstMouseClick)
            {
                _firstTouch = Input.mousePosition.x;
            }
            if (_input.MouseClick)
            {
                currentPosition = Input.mousePosition.x;
                distance = (_firstTouch - currentPosition) / _distanceDecreaser;
                

            }
            if (_input.MouseUp)
            {
                _release = true;
                
                _isBeginning = false;
            }
        }
    }
}
