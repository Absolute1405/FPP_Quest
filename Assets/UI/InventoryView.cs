using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class InventoryView : MonoBehaviour
{
    private InventoryGrid _grid;
    private RectTransform _transform;
    private float _cellHeight;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        StartCoroutine(ReadRectSize());
    }

    private IEnumerator ReadRectSize()
    {
        yield return new WaitForEndOfFrame();

        _cellHeight = _transform.rect.height;
    }

    public IEnumerator Load(List<InventoryCell> _cells)
    {
        if (_cells is null)
            throw new ArgumentNullException(nameof(_cells));

        yield return ReadRectSize();

        _grid = new InventoryGrid(_cellHeight, _transform.anchoredPosition);

        foreach (var cell in _cells)
        {
            _grid.PlaceItem(cell.GetComponent<RectTransform>());
        }

        _transform.sizeDelta = new Vector2(_grid.OverallWidth, _transform.sizeDelta.y);
    }
}
