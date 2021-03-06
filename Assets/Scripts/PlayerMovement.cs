using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera m_mainCamera;
    private Rigidbody m_rigidbody;
    [SerializeField] private float m_forceMagnitude;
    [SerializeField] private float m_maxVelocity;
    [SerializeField] private float m_rotationSpeed;
    [SerializeField] private float m_speed;
    private Vector3 m_movementDirection;

    private void Awake()
    {
        m_mainCamera = Camera.main;
        m_rigidbody = GetComponent<Rigidbody>();
    }

    public void ProcessInput(Joystick joystick)
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPos = m_mainCamera.ScreenToWorldPoint(touchPos);

            m_movementDirection.x = joystick.Horizontal * m_speed;
            m_movementDirection.y = joystick.Vertical * m_speed;
            m_movementDirection.z = 0f;
            m_movementDirection.Normalize();
        }
        else
        {
            m_movementDirection = Vector3.zero;
        }
    }

    public void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition = m_mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if (viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }

        if (viewportPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if (viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }

        transform.position = newPosition;
    }

    public void RotateToFaceVelocity()
    {
        if (m_rigidbody.velocity == Vector3.zero) { return; }

        Quaternion targetRotation = Quaternion.LookRotation(m_rigidbody.velocity, Vector3.back);

        transform.rotation = Quaternion.Lerp(
            transform.rotation, targetRotation, m_rotationSpeed * Time.deltaTime);
    }

    public void ApplyPhysics()
    {
        if (m_movementDirection == Vector3.zero) return;
        m_rigidbody.AddForce(m_movementDirection * m_forceMagnitude * Time.deltaTime, ForceMode.Force);
        m_rigidbody.velocity = Vector3.ClampMagnitude(m_rigidbody.velocity, m_maxVelocity);
    }

}
