using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public enum Move
    {
        trPosition,
        trTranslate,
        rbForce,
        rbVelocity,
        rbMovePosition
    }

    private Transform camera;

    public Move move;

    public float speed;

    private Transform m_transform;

    private Rigidbody2D m_rb;

    private Vector2

            m_dir,
            m_pos;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_transform = GetComponent<Transform>();
        m_pos = m_transform.position;
        camera = transform.Find("camera_Illia");
    }

    private void Update()
    {
        InputValue();
        TrMove();
        m_rb.centerOfMass = new Vector2(0, -2);
        camera.rotation = Quaternion.Euler(0, 0, 0);
        camera.position =
            new Vector3(m_transform.position.x, m_transform.position.y + 2, -2);
    }

    private void FixedUpdate()
    {
        RbMove();
    }

    private void InputValue()
    {
        m_dir = new Vector2(Input.GetAxis("Horizontal"), 0);
        m_pos += m_dir;
    }

    private void TrMove()
    {
        if (move == Move.trPosition)
        {
            m_transform.position = m_dir * speed * Time.deltaTime;
        }
        if (move == Move.trTranslate)
        {
            m_transform.Translate(m_dir * speed * Time.deltaTime);
        }
    }

    private void RbMove()
    {
        if (move == Move.rbForce)
        {
            m_rb.AddForce(m_dir * speed);
        }
        if (move == Move.rbVelocity)
        {
            m_rb.velocity = m_dir * speed;
        }
        if (move == Move.rbMovePosition)
        {
            m_rb.MovePosition (m_pos);
        }
    }
}
