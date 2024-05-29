using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private Transform _pivot;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _checkMask;

    private CharacterController _characterController;
    private Vector3 _moveDirection;

    private float _gravity = -9.8f;
    private float _velocity;
    private bool _isGrounded;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        _isGrounded = IsOnTheGround();

        if (_isGrounded && _velocity < 0)
        {
            _velocity = -2;
        }

        Move();
        DoGravity();

    }
    public void ReadMoveDirection(Vector3 moveDirection)
    {
        _moveDirection = moveDirection;
    }
    private void Move()
    {
        _characterController.Move(_moveDirection * _moveSpeed * Time.fixedDeltaTime);
    }

    public void Jump()
    {
        _velocity = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
    }

    private void DoGravity()
    {
        _velocity += _gravity * Time.fixedDeltaTime;

        _characterController.Move(Vector3.up * _velocity * Time.fixedDeltaTime);
    }

    private bool IsOnTheGround() 
    {
        bool result = Physics.CheckSphere(_pivot.position,_checkRadius,_checkMask);
        return result;
    }
  
    
}
