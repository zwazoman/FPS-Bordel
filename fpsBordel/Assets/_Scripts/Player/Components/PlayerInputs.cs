using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    #region PlayerMain Link

    [SerializeField] PlayerMain _main;

    private void Awake()
    {
        if(_main == null)
            TryGetComponent(out _main);
    }
    #endregion

    public event Action OnStartMoving;
    public event Action<Vector2> OnMove;
    public event Action OnStopMoving;

    public event Action OnMouseStartMoving;
    public event Action<Vector2> OnMouseMove;
    public event Action OnMouseStopMoving;

    public event Action OnInteract;

    public event Action OnJump;

    public event Action OnLock;

    bool _isMoving;
    bool _isMouseMoving;

    Vector2 _moveVector;
    Vector2 _mouseDelta;

    private void Update()
    {
        if (_isMoving)
            OnMove?.Invoke(_moveVector);
        if (_isMouseMoving)
            OnMouseMove?.Invoke(_mouseDelta);
    }

    public void MoveInput(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _isMoving = true;
            OnStartMoving?.Invoke();
        }

        if (ctx.performed)
            _moveVector = ctx.ReadValue<Vector2>();

        if (ctx.canceled)
        {
            _isMoving = false;
            _moveVector = Vector2.zero;
            OnStopMoving?.Invoke();
        }
    }

    public void MouseMoveInput(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _isMouseMoving = true;
            OnMouseStartMoving?.Invoke();
        }

        if (ctx.performed)
            _mouseDelta = ctx.ReadValue<Vector2>();

        if (ctx.canceled)
        {
            _isMouseMoving = false;
            OnMouseStopMoving?.Invoke();
        }
    }

    public void InteractInput(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            OnInteract?.Invoke();
    }

    public void JumpInput(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            OnJump?.Invoke();
    }

    public void LockInput(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            OnLock?.Invoke();
        }
    }

}
