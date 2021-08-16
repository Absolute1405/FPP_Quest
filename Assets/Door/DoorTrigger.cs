using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    private Door _door;

    private bool _hasOpened;

    private void Awake()
    {
        if (_door is null)
            throw new ArgumentNullException(nameof(_door));

        if (GetComponent<Collider>().isTrigger == false)
            throw new InvalidOperationException("Collider must be trigger");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IHandItemUsing>(out var player))
        {
            _hasOpened = player.ItemInHand == _door.Key;

            if (_hasOpened)
            {
                player.OnItemUsed += _door.Open;
                player.OnItemUsed += player.RemoveItemInHand;
            }
            else
            {
                player.OnItemUsed += _door.ShowClosed;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<IHandItemUsing>(out var player))
        {
            if (_hasOpened)
            {
                player.OnItemUsed -= player.RemoveItemInHand;
                player.OnItemUsed -= _door.Open;
            }
            else
            {
                player.OnItemUsed -= _door.ShowClosed;
            }
        }
    }
}
