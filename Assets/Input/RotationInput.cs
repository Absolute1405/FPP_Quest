using System;
using UnityEngine;

public class RotationInput : MonoBehaviour
{
    [SerializeField] 
    private PlayerRotation _player;
    [SerializeField]
    private CameraRotation _playerCamera;

    [SerializeField]
    private float _sensX = 100f;
    [SerializeField]
    private float _sensY = 100f;

    private void Awake()
    {
        if (_player is null)
            throw new ArgumentNullException(nameof(_player));
    }

    private void Update()
    {
        float x = Input.GetAxis("Mouse X") * _sensX;
        float y = Input.GetAxis("Mouse Y") * _sensY;

        _player.Rotate(x);
        _playerCamera.Rotate(x, y);
    }
}
