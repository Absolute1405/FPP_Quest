using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class DoorAnimation : MonoBehaviour
{
    [SerializeField]
    private float _closedShowDuration = 0.5f;
    [SerializeField]
    private Material _openedMaterial;
    [SerializeField]
    private Material _closedMaterial;

    private Material _simpleMaterial;
    private MeshRenderer _renderer;

    private void Awake()
    {
        if (_openedMaterial is null)
            throw new ArgumentNullException(nameof(_openedMaterial));
        if (_closedMaterial is null)
            throw new ArgumentNullException(nameof(_closedMaterial));

        _renderer = GetComponent<MeshRenderer>();
        _simpleMaterial = _renderer.material;
    }

    public void ShowOpened()
    {
        _renderer.material = _openedMaterial;
    }

    public void ShowClosed()
    {
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        _renderer.material = _closedMaterial;

        for (float i = 0; i < _closedShowDuration; i += Time.deltaTime)
        {
            yield return null;
        }

        _renderer.material = _simpleMaterial;
    }
}
