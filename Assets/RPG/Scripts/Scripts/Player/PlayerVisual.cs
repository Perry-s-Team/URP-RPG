using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
public class PlayerVisual : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private const string IS_RUN = "isRun";
    private const string ATTACK1 = "Atack_1";
    private const string ATTACK2 = "Atack_2";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetBool(IS_RUN, Movement.Instance.IsRunning());
        AdjustPlayerFacingDirection();

        GetLeftMouse();
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = GameInput.Instance.GetMousePosition();
        Vector3 playerPosition = Movement.Instance.GetPlayerScreenPostion();

        if (mousePos.x < playerPosition.x)        
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;  
    }

    private void GetLeftMouse()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RandomAnimation();
        }
    }

    private void RandomAnimation()
    {
        var random = Random.Range(1, 3);
        if (random == 1) {
            //Debug.Log(random.ToString());
            _animator.SetTrigger(ATTACK1); }
        else if (random == 2) {
            //Debug.Log(random.ToString());
            _animator.SetTrigger(ATTACK2); }      
    }
}
