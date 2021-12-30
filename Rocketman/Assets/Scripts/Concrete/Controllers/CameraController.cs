using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] Transform _target;
	[SerializeField] float _changePositionSpeed;
	[SerializeField] float _changeRotationSpeed;

	PlayerController _playerController;

	void Start()
	{
		_playerController = FindObjectOfType<PlayerController>();
		
	}
	void LateUpdate()
	{
		if (_playerController._cameraMover)
		{
			Vector3 currentPosition = transform.position;
			Vector3 targetPosition = _target.position;
			transform.position = Vector3.MoveTowards(currentPosition, targetPosition, _changePositionSpeed);
			

			Vector3 currentRotation = transform.eulerAngles;
			Vector3 targetRotation = _target.eulerAngles;
			transform.eulerAngles= Vector3.MoveTowards(currentRotation, targetRotation, _changeRotationSpeed);


		}
	}
}
