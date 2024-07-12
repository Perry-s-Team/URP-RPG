using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private const string IS_RUN = "isRun";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetBool(IS_RUN, Movement.Instance.IsRunning());
        AdjustPlayerFacingDirection();
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
}
