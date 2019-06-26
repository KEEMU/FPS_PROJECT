using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(AudioSource))]

public class FPSController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> arms;

    private Transform arm;

    public float walkSpeed = 5.0f;
    public float runSpeed = 9.0f;
    public float accel = 0.2f;
    float runningSpeedRel;
    Vector3 direction;

    private Rigidbody _rigidbody;
    private CapsuleCollider _collider;
    private AudioSource _audioSource;
    private bool _isGrounded;

    private float height;

    private float minVerticalAngle = -90f;
    private float maxVerticalAngle = 90f;
    private float jumpForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _audioSource = GetComponent<AudioSource>();
        _rigidbody.freezeRotation = true;
        height = _collider.height;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        arm = arms[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        Swap();
        Crouch();
        //Jump();
        RotateCameraAndCharacter();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
        //CollisionDetect();
        Jump();
        _isGrounded = false;
    }

    private void RotateCameraAndCharacter()
    {
        var rotationX = Input.GetAxis("Mouse X");
        var rotationY = Input.GetAxis("Mouse Y");
        var clampedY = RestrictVerticalRotation(rotationY);
        var worldUp = arm.InverseTransformDirection(Vector3.up);
        var rotation = arm.rotation *
                       Quaternion.AngleAxis(rotationX, worldUp) *
                       Quaternion.AngleAxis(clampedY, Vector3.left);
        transform.eulerAngles = new Vector3(0f, rotation.eulerAngles.y, 0f);
        arm.rotation = rotation;
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
        var currentAngle = NormalizeAngle(arm.eulerAngles.x);
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

    //private void CollisionDetect()
    //{
    //    RaycastHit hit;
    //    Physics.SphereCast(_collider.center, _collider.radius, Vector3.down, out hit, _collider.height / 2 + 0.1f);
    //    if (hit.collider==null)
    //    {
    //        return;
    //    }
    //    _isGrounded = true;
    //    print("on");
    //}

    //private void OnDrawGizmos()
    //{
    //    Ray ray = new Ray(_collider.center, Vector3.down);
    //    Gizmos.DrawRay(ray);
    //    Gizmos.DrawWireSphere(_collider.center, 5);
    //}

    private void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool running = (Input.GetKey(KeyCode.LeftShift) && vertical > 0);
        Vector3 speedDirection = new Vector3(horizontal, 0, vertical).normalized;
        if (speedDirection != Vector3.zero)
        {
            direction += speedDirection * accel * (_isGrounded ? 1f : 0.2f);
        }
        if (direction.magnitude>1)
        {
            direction = direction.normalized;
        }
        if (Mathf.Abs(horizontal) < 0.1f && Mathf.Abs(vertical) < 0.1f)
        {
            direction *= 0.7f;
        }
        if (direction.magnitude<0.01f)
        {
            direction = Vector3.zero;
        }
        if (running)
        {
            runningSpeedRel += accel;
        }
        else
        {
            runningSpeedRel -= accel;
        }
        runningSpeedRel = Mathf.Clamp(runningSpeedRel, 0, 1);
        float speed = Mathf.Lerp(walkSpeed, runSpeed, runningSpeedRel);
        //var worldDirection = transform.TransformDirection(direction);
        //_rigidbody.velocity = direction * speed;  
        transform.Translate(direction * Time.fixedDeltaTime * speed);
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

    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _collider.height = height / 2;
            return;
        }
        _collider.height = height;
    }

    private void Swap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < arms.Count; i++)
            {
                if (i != 0)
                {
                    arms[i].SetActive(false);
                }
                else
                {
                    arms[i].SetActive(true);
                    arm = arms[i].transform;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; i < arms.Count; i++)
            {
                if (i != 1)
                {
                    arms[i].SetActive(false);
                }
                else
                {
                    arms[i].SetActive(true);
                    arm = arms[i].transform;
                }
            }
        }
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
