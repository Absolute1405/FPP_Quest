using System;
using UnityEngine;

public class MenuInput : MonoBehaviour
{
    [SerializeField]
    private RotationInput _rotationInput;

    [SerializeField]
    private KeyCode _inventoryKey = KeyCode.Tab;

    private bool _inventoryActive;

    [SerializeField]
    private MonoBehaviour _inventoryMenu;
    private IShowHide InventoryMenu => (IShowHide)_inventoryMenu;

    private void OnValidate()
    {
        if (_inventoryMenu is IShowHide)
            return;

        Debug.LogError(_inventoryMenu.name + " needs to implement " + nameof(IShowHide));
        _inventoryMenu = null;
    }

    private void Awake()
    {
        if (_inventoryMenu is null)
            throw new ArgumentNullException(nameof(_inventoryMenu));
        if (_rotationInput is null)
            throw new ArgumentNullException(nameof(_rotationInput));
    }

    private void Start()
    {
        SetMenuActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_inventoryKey))
            SetMenuActive(!_inventoryActive);
    }

    private void SetMenuActive(bool active)
    {
        if (active)
        {
            InventoryMenu.Show();
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            InventoryMenu.Hide();
            Cursor.lockState = CursorLockMode.Locked;
        }

        _rotationInput.enabled = !active;
        Cursor.visible = active;
        _inventoryActive = active;
    }
}
