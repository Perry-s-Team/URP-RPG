using UnityEngine.InputSystem;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerControls _playerControls;
    [SerializeField] private Animator _animator;


    private void Awake()
    {
        Instance = this;

        _playerControls = new PlayerControls();
        _playerControls.Enable();
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = _playerControls.Player.Move.ReadValue<Vector2>();

        _animator.SetFloat("Horizontal", inputVector.x);
        _animator.SetFloat("Vertical", inputVector.y);
        _animator.SetFloat("Speed", inputVector.sqrMagnitude);

        return inputVector;
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();

        return mousePos;
    }

}