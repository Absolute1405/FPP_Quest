using System;
using UnityEngine;

public class InventoryGrid 
{
    private float _width;
    private Vector2 _zeroPosition;
    private int itemsCount;

    public InventoryGrid(float width, Vector2 zeroPosition)
    {
        if (width < 1f)
            throw new ArgumentOutOfRangeException(nameof(width));

        _width = width;
        _zeroPosition = zeroPosition;
        itemsCount = 0;
    }

    public void PlaceItem(RectTransform item)
    {
        float x = itemsCount * _width + _width / 2;
        item.anchoredPosition = new Vector2(x, 0) + _zeroPosition;
        itemsCount++;
    }

    public float OverallWidth => itemsCount * _width;
}
