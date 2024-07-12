using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerControls _playerControls;
    private void Awake()
    {
        Instance = this;

        _playerControls = new PlayerControls();
        _playerControls.Enable();
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = _playerControls.Player.Move.ReadValue<Vector2>();

        return inputVector;
    }
}