using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesawatControll : MonoBehaviour
{
        [SerializeField] float movementSpeed;

        [SerializeField] float rollSpeed;
        [SerializeField] float pitchFactor;

        [SerializeField] float xBound;
        [SerializeField] float yBound;

        [SerializeField]
        [Tooltip("The claw transform that will be updated and translated")]
        Transform posisiPesawat;

        [SerializeField]
        [Tooltip("The claw's minimum local position. Used to clamp the claw position")]
        Vector3 m_MinClawPosition;

        [SerializeField]
        [Tooltip("The claw's maximum local position. Used to clamp the claw position")]
        Vector3 m_MaxClawPosition;

    Vector2 m_JoystickValue;

    void UpdateClawPosition(float speed)
        {
            // Get current claw position
            var clawPosition = posisiPesawat.position;

            // Calculate claw velocity and new position
            clawPosition += new Vector3(m_JoystickValue.x * speed * Time.deltaTime, -(m_JoystickValue.y) * speed * Time.deltaTime, 0f);

            // Clamp claw position
            clawPosition.x = Mathf.Clamp(clawPosition.x, m_MinClawPosition.x, m_MaxClawPosition.x);
            clawPosition.z = Mathf.Clamp(clawPosition.z, m_MinClawPosition.y, m_MaxClawPosition.y);
            clawPosition.y = Mathf.Clamp(clawPosition.y, m_MinClawPosition.z, m_MaxClawPosition.z);

            // Update claw position
            posisiPesawat.position = clawPosition;
        }

    float horizontalInput;
    float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // MovePlayer();
        // RotatePlayer();
        UpdateClawPosition(movementSpeed);
    }
    // void MovePlayer()
    // {
    //     horizontalInput = Input.GetAxis("Horizontal");
    //     verticalInput = Input.GetAxis("Vertical");

    //     float xDelta = Time.deltaTime * m_JoystickValue.x * movementSpeed;
    //     float yDelta = Time.deltaTime * m_JoystickValue.y * movementSpeed;

    //     float xPos = transform.position.x + xDelta;
    //     float yPos = transform.position.y + yDelta;

    //     xPos = Mathf.Clamp(xPos, -xBound, xBound);
    //     yPos = Mathf.Clamp(yPos, -yBound, yBound);

    //     transform.position = new Vector3(xPos, yPos, transform.position.z);
    // }

    // void RotatePlayer()
    // {
    //     float roll = rollSpeed * m_JoystickValue.x;
    //     float pitch = pitchFactor * m_JoystickValue.y;
    //     transform.rotation = Quaternion.Euler(pitch, transform.rotation.y, roll);
    // }

    /// <summary>
        /// Gets the X value of the joystick. Called by the <c>XRJoystick.OnValueChangeX</c> event.
        /// </summary>
        /// <param name="x">The joystick's X value</param>
        public void OnJoystickValueChangeX(float x)
        {
            m_JoystickValue.x = x;
        }

        /// <summary>
        /// Gets the Y value of the joystick. Called by the <c>XRJoystick.OnValueChangeY</c> event.
        /// </summary>
        /// <param name="y">The joystick's Y value</param>
        public void OnJoystickValueChangeY(float y)
        {
            m_JoystickValue.y = y;
        }
}
