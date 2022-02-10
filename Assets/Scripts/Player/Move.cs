using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 10.0F;
    private float jumpSpeed = 15.0F;
    private float gravity = 20.0F;
    private CharacterController _characterController;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>(); 
    }

    private void Update()
    {
        if (_characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetAxis("Jump") > 0)
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        _characterController.Move(moveDirection * Time.deltaTime);
    }
}
