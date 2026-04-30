using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
  [SerializeField] private float moveSpeed = 5f;

  private PlayerInputActions _inputActions;
  private Rigidbody2D _rb;
  private Vector2 _moveInput;

  private void Awake()
  {
    _rb = GetComponent<Rigidbody2D>();
    _inputActions = new PlayerInputActions();
  }

  private void OnEnable()
  {
    _inputActions.Player.Enable();
  }

  private void OnDisable()
  {
    _inputActions.Player.Disable();
  }

  private void Update()
  {
    _moveInput = _inputActions.Player.Move.ReadValue<Vector2>();
  }

  private void FixedUpdate()
  {
    _rb.linearVelocity = _moveInput * moveSpeed;
  }
}