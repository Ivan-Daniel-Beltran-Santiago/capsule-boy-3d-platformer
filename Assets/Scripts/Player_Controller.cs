using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody rBody;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 6f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rBody.velocity = new Vector3(horizontalInput * movementSpeed, rBody.velocity.y, verticalInput * movementSpeed);

        // Might as well jump, jump!
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
        rBody.velocity = new Vector3(rBody.velocity.x, jumpForce, rBody.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGrounded(){
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
}
