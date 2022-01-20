using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Attacking
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update

        private Animator m_Animator;
        const float k_Acceleration = 15;
        const float k_Deceleration = 800;
        private float m_desiredSpeed;
        private float m_forwardSpeed;
        private float gravity = 20;
        private float m_forwardMaxSpeed = 8.0f;
        private float m_verticalSpeed;
        private PlayerInput m_playerInput;
        private readonly int m_HashForwardSpeed = Animator.StringToHash("ForwardSpeed");
        private CharacterController m_CharacterController;
        // Update is called once per frame
        private void Awake()
        {
            m_playerInput = GetComponent<PlayerInput>();
            m_Animator = GetComponent<Animator>();
            m_CharacterController = GetComponent<CharacterController>();
        }
        void FixedUpdate()
        {
            computeMovement();
            ComputeVertical();
            //transform.position = new Vector3(transform.position.x + horizontalInput * speed * Time.fixedDeltaTime, 0, transform.position.z + verticalInput * speed * Time.fixedDeltaTime);
            // m_Animator.SetFloat(m_HashForwardSpeed, speed);

        }
        private void OnAnimatorMove()
        {
            Vector3 movement = m_Animator.deltaPosition;
           movement += m_verticalSpeed * Vector3.up * Time.fixedDeltaTime;
            m_CharacterController.Move(movement);
        }
     
        private void ComputeVertical()
        {
            m_verticalSpeed = -gravity;
        }
        private void computeMovement()
        {
            Vector3 MoveInput = m_playerInput.moveInput.normalized;
            m_desiredSpeed = MoveInput.magnitude * m_forwardMaxSpeed;
            float acceleration = m_playerInput.IsMoveInput ? k_Acceleration : k_Deceleration;

            m_forwardSpeed = Mathf.MoveTowards(m_forwardSpeed, m_desiredSpeed, Time.fixedDeltaTime * acceleration);
            m_Animator.SetFloat(m_HashForwardSpeed, m_forwardSpeed);
        }
    }
}