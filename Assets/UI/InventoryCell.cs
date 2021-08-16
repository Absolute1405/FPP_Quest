using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class InventoryCell : MonoBehaviour, IPointerClickHandler
{
    public ItemData Item { get; private set; }
    private IItemClicked _presenter;

    public void Init(ItemData item, IItemClicked presenter)
    {
        if (item is null)
            throw new ArgumentNullException(nameof(item));
        if (presenter is null)
            throw new ArgumentNullException(nameof(presenter));

        Item = item;
        GetComponent<Image>().sprite = item.Texture;
        _presenter = presenter;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _presenter.ItemClicked(Item);
    }
}
