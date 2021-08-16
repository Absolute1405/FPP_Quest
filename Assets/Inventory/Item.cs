using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private KeyData _data;
    public KeyData Data => _data;
    public void Init(KeyData data)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));

        _data = data;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IAddItem>(out var inventory))
        {
            if (inventory.AddItem(_data))
                Destroy(gameObject);
        }
    }
}
