using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public KeyCode PlayerJump;

    public float distToGround = 1f;

    private Vector3 PlayerMovementInut;

    private bool isGrounded;

    [SerializeField] private Rigidbody PlayerBody;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Jumpforce;

    private void Start() 
    {
        PlayerBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementInut = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();

        GroundCheck();
    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInut) * Speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);

        if(Input.GetKeyDown(PlayerJump) && isGrounded)
        {
            PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
        }
    }

    void GroundCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }
}
