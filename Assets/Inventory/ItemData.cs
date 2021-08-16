using UnityEngine;

public class ItemData : ScriptableObject
{
    [SerializeField]
    private Sprite _texture;
    [SerializeField]
    private Item _prefab;

    public Sprite Texture => _texture;

    public GameObject CreateInstance()
    {
        return Instantiate(_prefab).gameObject;
    }
}
