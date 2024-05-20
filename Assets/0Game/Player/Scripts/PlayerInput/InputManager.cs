using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance
    {
        get { return _instance; }
    }
    private PlayerInputSystem _playerInputSystem;

    private bool _isSprinting;
    public bool IsSprinting { get => _isSprinting; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        _playerInputSystem = new PlayerInputSystem();

        Cursor.visible = false;

        _playerInputSystem.Player.SprintStart.performed += x => SprintStart();
        _playerInputSystem.Player.SprintFinish.performed += x => SprintFinish();
    }
    private void OnEnable()
    {
        _playerInputSystem.Enable();
    }
    private void OnDisable()
    {
        _playerInputSystem.Disable();
    }
    private void SprintStart()
    {
        _isSprinting = true;
    }
    private void SprintFinish()
    {
        _isSprinting = false;
    }
    public Vector3 GetPlayerMovement()
    {
        return new Vector3(_playerInputSystem.Player.MovementHor.ReadValue<float>(), 0f, _playerInputSystem.Player.MovementVer.ReadValue<float>());
    }
    public Vector2 GetMouseDelta()
    {
        return _playerInputSystem.Player.Look.ReadValue<Vector2>();
    }
    public bool PlayerJumpedThisFrame()
    {
        return _playerInputSystem.Player.Jump.triggered;
    }

    public bool PlayerInteractThisFrame()
    {
        return _playerInputSystem.Player.Interact.triggered;
    }
}/**/
