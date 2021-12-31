using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PullAndThrow
{
    [SerializeField] float _throwPower;
    [SerializeField] float _wingsSpeed;
    [SerializeField] GameObject _rocketmanBody;
    [SerializeField] float _turnSpeed;
    [SerializeField] float _rotateIndex;

    PlayerAnimation _playerAnimation;
    Rigidbody _rigidbody;

    public bool _cameraMover;
    bool _throwed;
    bool _onAir;
    Vector3 _currentMousePos;
    float _mousePosition;

    void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _rigidbody = GetComponent<Rigidbody>();
        _cameraMover = false;
        _throwed = false;
        _onAir = false;
    }

    void Update()
    {
        BeginningAnimations();
        PullThrow();
        AirAnimations();
        MouseDragOnAir();
        

    }

    private void FixedUpdate()
    {
        if (_throwed)
        {
            _rigidbody.useGravity = true;
            if (distance > 0)
            _rigidbody.AddForce(new Vector3(0, 1, 1) * distance * _throwPower);
            _throwed = false;
        }
        if (_onAir && _input.MouseClick)
        {
            _rigidbody.velocity = new Vector3(_mousePosition,0,1) * _wingsSpeed * Time.deltaTime;
        }
    }

    void BeginningAnimations()
    {
        if (_isBeginning)
        {
            if (_input.MouseClick)
            {
                _playerAnimation._animator.SetFloat("Pull", distance);

            }
            if (_input.MouseUp)
            {
                if (distance > 0)
                {
                    _playerAnimation.TurningAnimation(true);
                    _cameraMover = true;
                    _throwed = true;
                    _onAir = true;
                }
            }
        }
    }

    void AirAnimations()
    {
        if(_onAir && _input.MouseClick)
        {
            _playerAnimation.OpeningAnimation(true);
            _playerAnimation.ClosingAnimation(false);
            _rocketmanBody.transform.eulerAngles = new Vector3(90, 0, 0);
        }
        else
        {
            _playerAnimation.ClosingAnimation(true);
            _playerAnimation.OpeningAnimation(false);
        }
    }
    void MouseDragOnAir()
    {
        if (_onAir && _input.FirstMouseClick)
        {
            _currentMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0f, 10f));
        }

        if (_onAir && _input.MouseClick)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0f, 10f));
            _mousePosition = (mousePosition.x - _currentMousePos.x) * _turnSpeed;
            _rocketmanBody.transform.eulerAngles = new Vector3(_rocketmanBody.transform.eulerAngles.x, _rocketmanBody.transform.eulerAngles.y, -_mousePosition * _rotateIndex);
        }
        if (_onAir && _input.MouseUp)
        {
            _rocketmanBody.transform.eulerAngles = Vector3.zero;
        }
    }
}
