using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRotation : MonoBehaviour
{
    private float _yRotation;

    public void Rotate(float x)
    {
        _yRotation += x * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
}