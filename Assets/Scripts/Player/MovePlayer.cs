using UnityEngine;

namespace Assets.Scripts.Player
{
    public class MovePlayer : MonoBehaviour
    {
        private float speed = 10.0F;
        private float jumpSpeed = 15.0F;
        private float gravity = 20.0F;

        private Vector3 moveDirection = Vector3.zero;

        private CharacterController _characterController;
        private Transform m_transform;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            m_transform = GetComponent<Transform>();
        }

        private void Update()
        {
            if (_characterController.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = m_transform.TransformDirection(moveDirection);
                moveDirection *= speed;

                if (Input.GetAxis("Jump") > 0)
                    moveDirection.y = jumpSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            _characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}
