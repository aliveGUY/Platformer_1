using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public enum Choose
    {
        trPosition,
        trTranslate,
        rbForce,
        rbVelocity,
        rbMovePosition,
    }
    public Choose ch;
    public float speed;
    private Rigidbody2D m_rb;
    private Transform m_transform;
    private Vector2 m_dir, m_pos;

    private void Start()
    {

        m_rb = GetComponent<Rigidbody2D>();
        m_transform = GetComponent<Transform>();
        m_pos = m_transform.position;
    }

    private void Update()
    {
        InputValue();
        TRMove();
    }
    
    private void FixedUpdate()
    {
        RBMove();
    }

    private void InputValue()
    {
        m_dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        m_pos += m_dir;
    }

    private void TRMove()
    {
        if (ch==Choose.trPosition)
        {
            m_transform.position = m_dir * speed * Time.deltaTime;
        }
        if (ch == Choose.trTranslate)
        {
            m_transform.Translate(m_dir * speed * Time.deltaTime);
        }
    }
    private void RBMove()
    {
        if (ch == Choose.rbForce)
        {
            m_rb.AddForce(m_dir * speed);
        }
        if (ch == Choose.rbVelocity)
        {
            m_rb.velocity = m_dir * speed;
        }
        if (ch == Choose.rbMovePosition)
        {
            m_rb.MovePosition(m_pos);
        }
    }
}
