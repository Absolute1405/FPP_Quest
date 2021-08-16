using System;

public interface IHandItemUsing 
{
    ItemData ItemInHand { get; }
    event Action OnItemUsed;
    void RemoveItemInHand();
}
