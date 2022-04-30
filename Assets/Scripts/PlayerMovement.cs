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

    private Vector3 m_movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        m_mainCamera = Camera.main;
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Debug.Log(touchPos);

            Vector3 worldPos = m_mainCamera.ScreenToWorldPoint(touchPos);
            Debug.Log(worldPos);

            m_movementDirection = transform.position - worldPos;
            m_movementDirection.z = 0f;
            m_movementDirection.Normalize();
        }
        else
        {
            m_movementDirection = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if (m_movementDirection == Vector3.zero) return;
        m_rigidbody.AddForce(m_movementDirection * m_forceMagnitude * Time.deltaTime, ForceMode.Force);
        m_rigidbody.velocity = Vector3.ClampMagnitude(m_rigidbody.velocity, m_maxVelocity);
    }
}
