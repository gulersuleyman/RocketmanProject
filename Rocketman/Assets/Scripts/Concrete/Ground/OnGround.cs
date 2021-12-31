using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    [SerializeField] GameObject _failPanelUI;

    PlayerController _playerController;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _failPanelUI.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _failPanelUI.SetActive(true);
        _playerController._gameOver = true;
    }
}
