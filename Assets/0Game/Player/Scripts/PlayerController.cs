using UnityEngine;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private InputManager _inputManager;
    private Transform _cameraTransform;
    private Vector3 _playerStartPos;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    [SerializeField] private float _playerSpeed = 2.0f;
    [SerializeField] private float _jumpHeight = 1.0f;
    [SerializeField] private float _sprintSpeed = 2f;
    private float _gravityValue = -9.81f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _inputManager = InputManager.Instance;
        _cameraTransform = Camera.main.transform;
        _playerStartPos = transform.position;
    }
    void Update()
    {
        if (GameManager.Instance.PlayerMove)
        {
            _groundedPlayer = _controller.isGrounded;
            if (_groundedPlayer && _playerVelocity.y < 0)
                _playerVelocity.y = 0f;

            float sprintSpeed;
            sprintSpeed = _inputManager.IsSprinting ? _sprintSpeed : 1f;
            Vector3 move = _inputManager.GetPlayerMovement();
            move = _cameraTransform.forward * move.z + _cameraTransform.right * move.x;
            move.y = 0;
            _controller.Move(move * Time.deltaTime * _playerSpeed * sprintSpeed);


            if (_inputManager.PlayerJumpedThisFrame() && _groundedPlayer)
                _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);


            _playerVelocity.y += _gravityValue * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime);
        }
        else
        {
            ResetPosition();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            GameManager.Instance.EndingUI();
        }
    }
    public void ResetPosition()
    {
        _playerVelocity = Vector3.zero;
        _controller.enabled = false;
        transform.position = _playerStartPos;
        _controller.enabled = true;
    }
}/**/
