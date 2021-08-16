using System;
using System.Collections.Generic;

public class Inventory : IReadOnlyInventory
{
    public int Capacity { get; private set; }
    private List<ItemData> _items;

    public Inventory(int capacity)
    {
        if (capacity < 1)
            throw new ArgumentOutOfRangeException(nameof(capacity));

        Capacity = capacity;
        _items = new List<ItemData>(capacity);
    }

    public IReadOnlyList<ItemData> Items => _items;

    public bool TryAddItem(ItemData item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        if (_items.Count == Capacity)
            return false;

        _items.Add(item);
        return true;
    }

    public bool TryRemoveItem(ItemData item)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));

        if (HasItem(item) == false)
            return false;

        _items.Remove(item);
        return true;
    }

    public bool HasItem(ItemData item)
    {
        return _items.Contains(item);
    }
}
