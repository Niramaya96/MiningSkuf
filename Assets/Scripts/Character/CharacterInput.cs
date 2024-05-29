using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour
{
    private Vector3 _moveDirection;
    private GameInput _gameInput;
    private CharacterMovement _characterMovement;

    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Enable();

        _characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void ReadMovement()
    {
        var readDirection = _gameInput.Gameplay.Movement.ReadValue<Vector2>();

        _moveDirection = new Vector3(readDirection.x,0,readDirection.y);

        _characterMovement.ReadMoveDirection(_moveDirection);
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        _characterMovement.Jump();
    }
    private void OnEnable()
    {
        _gameInput.Gameplay.Jump.performed += OnJumpPerformed;
    }

    private void OnDisable()
    {
        _gameInput.Gameplay.Jump.performed -= OnJumpPerformed;
    }
}
