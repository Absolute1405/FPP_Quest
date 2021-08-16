using System;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField]
    private KeyData _key;
    [SerializeField]
    private DoorAnimation _animation;

    public UnityEvent OnOpen;
    public bool Opened { get; private set; }
    public KeyData Key => _key;

    private void Awake()
    {
        if (_key is null)
            throw new ArgumentNullException(nameof(_key));

        if (_animation is null)
            throw new ArgumentNullException(nameof(_animation));

        Opened = false;
    }

    public void Open()
    {
        if (Opened)
            return;

        Opened = true;
        _animation.ShowOpened();
        OnOpen?.Invoke();
    }

    public void ShowClosed()
    {
        if (Opened)
            return;

        _animation.ShowClosed();
    }

}
