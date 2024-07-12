using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance { get; private set; }

    private Rigidbody2D _rigidbody2D;
    private bool isRunning = false;

    [SerializeField] private float _speedPlayer = 10f;

    private void Awake()
    {
        Instance = this;
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        inputVector = inputVector.normalized;
        _rigidbody2D.MovePosition(_rigidbody2D.position + inputVector * (Time.fixedDeltaTime * _speedPlayer));

        if (Mathf.Abs(inputVector.x) > 0.1f || Mathf.Abs(inputVector.y) > 0.1f)
            isRunning = true;
        else
            isRunning = false;
    }

    public bool IsRunning()
    {
        return isRunning;
    }

    public Vector3 GetPlayerScreenPostion()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
}
