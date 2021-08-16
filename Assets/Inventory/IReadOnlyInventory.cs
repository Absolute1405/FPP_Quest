using System.Collections.Generic;

public interface IReadOnlyInventory
{
    IReadOnlyList<ItemData> Items { get; }
    int Capacity { get; }
}
