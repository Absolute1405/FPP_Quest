using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class InventoryUI : MonoBehaviour, IItemClicked, IShowHide
{
    [SerializeField]
    private InventoryCell _cellPrefab;
    [SerializeField]
    private InventoryView _view;

    private List<InventoryCell> _cells;

    [SerializeField]
    private MonoBehaviour _player;
    private IInventoryPresenter Player => (IInventoryPresenter)_player;

    private void OnValidate()
    {
        if (_player is IInventoryPresenter)
            return;

        Debug.LogError(_player.name + " needs to implement " + nameof(IInventoryPresenter));
        _player = null;
    }

    private void Awake()
    {
        if (_cellPrefab is null)
            throw new ArgumentNullException(nameof(_cellPrefab));
        if (_player is null)
            throw new ArgumentNullException(nameof(_player));
        if (_view is null)
            throw new ArgumentNullException(nameof(_view));

        _cells = new List<InventoryCell>();
    }

    private void CreateCells()
    {
        for (int i = 0; i < Player.Inventory.Items.Count; i++)
        {
            InventoryCell cell = Instantiate(_cellPrefab, _view.transform);
            cell.Init(Player.Inventory.Items[i], this);
            _cells.Add(cell);
        }
    }

    private void ClearCells()
    {
        _cells?.ForEach(x => Destroy(x.gameObject));
        _cells = new List<InventoryCell>();
    }

    public void ItemClicked(ItemData item)
    {
        if (Player.ItemInHand == item)
        {
            ThrowItem(item);
            return;
        }

        Player.PrepareItem(item);
    }

    public void Show()
    {
        CreateCells();
        gameObject.SetActive(true);
        StartCoroutine(_view.Load(_cells));
    }

    public void Hide()
    {
        ClearCells();
        gameObject.SetActive(false);
    }

    private void ThrowItem(ItemData item)
    {
        Transform thrownItem = item.CreateInstance().transform;
        thrownItem.position = _player.transform.position + _player.transform.forward * 2;
        Player.RemoveItem(item);

        GameObject emptyCell = _cells.Find(x => x.Item == item).gameObject;
        emptyCell.SetActive(false);
    }
}
