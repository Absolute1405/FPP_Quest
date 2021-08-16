using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Min(0.1f)]
    private float _speed = 6f;

    private Vector3 moveDirection;

    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    public void Move(float x, float y)
    {
        moveDirection = transform.forward * y + transform.right * x;
        _rigidbody.MovePosition(_rigidbody.position + moveDirection.normalized * _speed * Time.deltaTime);
    }
}
