using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharControl : MonoBehaviour
{   
    public enum Move
    {
        trPosition,
        trTranslate,
        rbForce,
        rbVelocity,
        rbMovePosition
    }
    
    public Move move; 
    public float speed;
    private Transform m_transform;
    private Rigidbody2D m_rb;
    private Vector2 m_dir, m_pos;
    // Start is called before the first frame update
    void Start()
    {   
        m_rb = GetComponent<Rigidbody2D>();
        m_transform = GetComponent<Transform>();
        m_pos = m_transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");
        //Vector2 position = transform.position;
        //position.x = position.x + speed * horizontal;
        //position.y = position.y + speed * vertical;
        //transform.position = position;
        InputValue();
        TrMove();
        
    }

    private void FixedUpdate()
    {
        RbMove();
    }

    private void InputValue()
    {
        m_dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        m_pos += m_dir;
    
    }

    private void TrMove()
    {
        if(move == Move.trPosition)
        {
            m_transform.position = m_dir * speed * Time.deltaTime;

        }
        if(move == Move.trTranslate)
        {
            m_transform.Translate(m_dir * speed * Time.deltaTime);
        }

        //switch (move)
        //{
        //    case "trPosition": m_transform.position = m_dir * speed * Time.deltaTime; break;
        //    case "trTranslate": m_transform.Translate = m_dir * speed * Time.deltaTime; break;
       
        //}
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
            m_rb.MovePosition(m_pos); 
        }
    }
}
