using NUnit.Framework.Constraints;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Components")]
    private Rigidbody2D _rb;
    private Animator _anim;
    private BoxCollider2D _boxCollider;
    public CinemachineCamera _cinemachineCamera;

    [Header("Aúdio")]
    public AudioSource flappyAudio;
    public AudioSource hitAudio;

    [Header("Player Variables")]
    private float jumpHeight = 10f;
    private float rotationSpeed = -90f;
    private float jumpRotation = 48f;
    private float moveSpeed = 5f;
    private bool isDead;

    [Header("Gravity")]
    private float gravity = 9.8f;
    private float gravityAcceleration = 2f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        Gravity();
        if (!isDead)
        {
            transform.localRotation *= Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotationSpeed * Time.fixedDeltaTime);
            _rb.linearVelocity = new Vector2(moveSpeed, _rb.linearVelocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Die();
        }
    }



    private void Jump()
    {
        flappyAudio.Play();
        transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, jumpRotation);
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpHeight);
    }

    private void Gravity()
    { 
        float gravityForce = gravity * gravityAcceleration * Time.fixedDeltaTime;
        _rb.linearVelocity -= new Vector2(0, gravityForce);
    }

    private void Die()
    {
        isDead = true;
        hitAudio.Play();
        _boxCollider.enabled = false;
        _anim.speed = 0;
        _cinemachineCamera.Follow = null;

    }



}
