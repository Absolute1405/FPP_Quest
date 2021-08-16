using UnityEngine;

public class ActionInput : MonoBehaviour
{
    [SerializeField]
    private KeyCode _actionKey = KeyCode.E;

    [SerializeField]
    private MonoBehaviour _player;
    private IUseItem Player => (IUseItem)_player;

    private void OnValidate()
    {
        if (_player is IUseItem)
            return;

        Debug.LogError(_player.name + " needs to implement " + nameof(IUseItem));
        _player = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_actionKey))
            Player.UseItem();
    }
}
