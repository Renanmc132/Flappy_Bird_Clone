using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Animator _anim;

    private float jumpHeight = 10f;
    private float rotationSpeed = -90f;
    private float jumpRotation = 48f;
    private float moveSpeed = 5f;

    private float gravity = 9.8f;
    private float gravityAcceleration = 2f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Gravity();
        transform.localRotation *= Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotationSpeed * Time.fixedDeltaTime);
        _rb.linearVelocity = new Vector2(moveSpeed, _rb.linearVelocity.y);
    }

    

    private void Jump()
    {
        transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, jumpRotation);
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpHeight);
    }

    private void Gravity()
    { 
        float gravityForce = gravity * gravityAcceleration * Time.fixedDeltaTime;


        _rb.linearVelocity -= new Vector2(0, gravityForce);

    }


}
