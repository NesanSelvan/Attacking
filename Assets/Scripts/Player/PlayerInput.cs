using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Attacking
{
    public class PlayerInput : MonoBehaviour
    {
        // Start is called before the first frame update

        private Vector3 m_movement;
        public Vector3 moveInput
        {
            get
            {
                return m_movement;
            }
        }
        // Update is called once per frame
        public bool IsMoveInput
        {
            get
            {
                return !Mathf.Approximately(moveInput.magnitude, 0);
            }
        }
        void Update()
        {
            m_movement.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }
}