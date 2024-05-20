using UnityEngine;
using Cinemachine;
using System;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField] private float _clampAngle = 80f;
    [SerializeField] private float _horSpeed = 10f;
    [SerializeField] private float _verSpeed = 10f;
    private Vector3 _startingRotation;
    protected override void Awake()
    {
        base.Awake();
        _startingRotation = Vector3.zero;
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                if (_startingRotation == Vector3.zero)
                {
                    _startingRotation = transform.localRotation.eulerAngles;
                }
                Vector2 deltaInput = InputManager.Instance.GetMouseDelta();
                _startingRotation.x += deltaInput.x * _verSpeed * Time.deltaTime;
                _startingRotation.y += deltaInput.y * _horSpeed * Time.deltaTime;
                _startingRotation.y = Mathf.Clamp(_startingRotation.y, -_clampAngle, _clampAngle);
                state.RawOrientation = Quaternion.Euler(-_startingRotation.y, _startingRotation.x, 0f);
            }
        }
    }
}
