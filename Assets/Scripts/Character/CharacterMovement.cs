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
    private void Update()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = IsOnTheGround();

        if (_isGrounded && _velocity < 0)
        {
            _velocity = -2;
        }

        Move(_moveDirection);
        DoGravity();

    }
    private void Move(Vector3 moveDirection)
    {
        _characterController.Move(moveDirection * _moveSpeed * Time.fixedDeltaTime);
    }

    private void Jump()
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
