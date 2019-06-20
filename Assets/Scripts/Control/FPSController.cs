﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(AudioSource))]

public class FPSController : MonoBehaviour
{
    public Transform arms;

    public float walkSpeed = 5.0f;
    public float runSpeed = 9.0f;

    private Rigidbody _rigidbody;
    private CapsuleCollider _collider;
    private AudioSource _audioSource;
    private bool _isGrounded;

    private float minVerticalAngle = -90f;
    private float maxVerticalAngle = 90f;
    private float jumpForce = 35f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _audioSource = GetComponent<AudioSource>();
        _rigidbody.freezeRotation = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        Jump();
        RotateCameraAndCharacter();
    }

    private void RotateCameraAndCharacter()
    {
        var rotationX = Input.GetAxis("Mouse X");
        var rotationY = Input.GetAxis("Mouse Y");
        var clampedY = RestrictVerticalRotation(rotationY);
        var worldUp = arms.InverseTransformDirection(Vector3.up);
        var rotation = arms.rotation *
                       Quaternion.AngleAxis(rotationX, worldUp) *
                       Quaternion.AngleAxis(clampedY, Vector3.left);
        transform.eulerAngles = new Vector3(0f, rotation.eulerAngles.y, 0f);
        arms.rotation = rotation;
    }

    private static float NormalizeAngle(float angleDegrees)
    {
        while (angleDegrees > 180f)
        {
            angleDegrees -= 360f;
        }

        while (angleDegrees <= -180f)
        {
            angleDegrees += 360f;
        }

        return angleDegrees;
    }

    private float RestrictVerticalRotation(float mouseY)
    {
        var currentAngle = NormalizeAngle(arms.eulerAngles.x);
        var minY = minVerticalAngle + currentAngle;
        var maxY = maxVerticalAngle + currentAngle;
        return Mathf.Clamp(mouseY, minY + 0.01f, maxY - 0.01f);
    }

    //copy only
    private readonly RaycastHit[] _groundCastResults = new RaycastHit[8];
    private void OnCollisionStay()
    {
        var bounds = _collider.bounds;
        var extents = bounds.extents;
        var radius = extents.x - 0.01f;
        Physics.SphereCastNonAlloc(bounds.center, radius, Vector3.down,
            _groundCastResults, extents.y - radius * 0.5f, ~0, QueryTriggerInteraction.Ignore);
        if (!_groundCastResults.Any(hit => hit.collider != null && hit.collider != _collider)) return;
        for (var i = 0; i < _groundCastResults.Length; i++)
        {
            _groundCastResults[i] = new RaycastHit();
        }

        _isGrounded = true;
    }

    private void FixedUpdate()
    {
        _isGrounded = false;
    }

    private void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        var worldDirection = transform.TransformDirection(direction);
        transform.Translate(direction * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed));
    }

    private void Jump()
    {
        if (!_isGrounded || Input.GetAxis("Jump").Equals(0))
        {
            return;
        }
        _isGrounded = false;
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    //private void PlayFootstepSounds()
    //{
    //    if (_isGrounded && _rigidbody.velocity.sqrMagnitude > 0.1f)
    //    {
    //        _audioSource.clip = Input.GetAxis("Run").Equals(0) ? walkingSound : runningSound;
    //        if (!_audioSource.isPlaying)
    //        {
    //            _audioSource.Play();
    //        }
    //    }
    //    else
    //    {
    //        if (_audioSource.isPlaying)
    //        {
    //            _audioSource.Pause();
    //        }
    //    }
    //}
}