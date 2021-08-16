using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private float _minAngle = -45f;
    [SerializeField]
    private float _maxAngle = 45f;

    private float _xRotation;
    private float _yRotation;

    public void Rotate(float x, float y)
    {
        _yRotation += x * Time.deltaTime;
        _xRotation -= y * Time.deltaTime;

        _xRotation = Mathf.Clamp(_xRotation, _minAngle, _maxAngle);

        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
    }
}
