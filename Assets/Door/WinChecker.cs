using System;
using System.Collections.Generic;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    [SerializeField]
    private List<Door> _doors;

    [SerializeField]
    private GameObject _winMessage;

    private void Awake()
    {
        if (_doors is null)
            throw new ArgumentNullException(nameof(_doors));
        if (_winMessage is null)
            throw new ArgumentNullException(nameof(_winMessage));

        _winMessage.SetActive(false);
    }

    public void Check()
    {
        foreach(var door in _doors)
        {
            if (door.Opened == false)
                return;
        }

        _winMessage.SetActive(true);
    }
}
