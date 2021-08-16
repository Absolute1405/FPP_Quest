using System;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;

    private float x;
    private float y;

    private void Awake()
    {
        if (_player is null)
            throw new ArgumentNullException(nameof(_player));
    }

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _player.Move(x,y);
    }
}
