using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, IAddItem, IInventoryPresenter, IUseItem, IHandItemUsing
{
    [SerializeField, Min(1)]
    private int _capacity;

    private Inventory _inventory;
    public ItemData ItemInHand { get; private set; }

    public event Action OnItemUsed;

    private void Awake()
    {
        _inventory = new Inventory(_capacity);
    }

    public IReadOnlyInventory Inventory => _inventory;

    public bool AddItem(ItemData item)
    {
        return _inventory.TryAddItem(item);
    }

    public bool RemoveItem(ItemData item)
    {
        if (item == ItemInHand)
            ItemInHand = null;

        return _inventory.TryRemoveItem(item);
    }

    public bool HasItem(ItemData item)
    {
        return _inventory.HasItem(item);
    }

    public void UseItem()
    {
        if (ItemInHand is null)
            return;

        OnItemUsed?.Invoke();
    }

    public void PrepareItem(ItemData item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        if (_inventory.HasItem(item))
            ItemInHand = item;
        else
            throw new InvalidOperationException("Inventory has no item " + item.name);
    }

    public void RemoveItemInHand()
    {
        RemoveItem(ItemInHand);
    }

}
