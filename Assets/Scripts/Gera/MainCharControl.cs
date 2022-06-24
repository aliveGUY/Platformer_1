using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

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
    //Animator anim; //
    ////bool NeedToGo = false; //
    //anim = GetComponent();
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
        //transform.position = new Vector2(PlayerPrefs.GetFloat("yPos"));
    }

    // Update is called once per frame
    private void Update()
    {
        //if(Input.GetMouseButtonUp(0) == true) //
        //    Vector2 m_dir = Input.mousePosition;//
        //worldPos = Camera.main.ScreenToWorldPoint(mousePos);//
        //NeedToGo = true;//
        //Vector3 diff = m_dir - (Vector2)transform.position; //

        //diff.Normalize();//
        ////������� � � ���� x � y
        //anim.SetFloat("x", diff.x);//
        //anim.SetFloat("y", diff.y);//
        ////������������� �������� ������� � ���������
        //anim.SetBool("IsWalking", true);//
        InputValue();
        TrMove();
        if (m_transform.position.y < -30f)
        { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    }
     //if (NeedToGo)
     //   {
     //       rigidBody2d.MovePosition(Vector2.MoveTowards(transform.position, worldPos, Speed* Time.deltaTime));
            
     //       if (Vector2.Distance(transform.position, worldPos) < 0.01)
     //       {
     //           NeedToGo = false;
     //           //������������� �������� ����� �����
     //           anim.SetBool("IsWalking", false);
     //       }
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


    //private void OnTriggerStay2D(Collider2D other)//
    //{if (other.tag == "checkpoint")//
    //    { PlayerPrefs.Setfloat("xPos", m_transform.position.x);//
    //        PlayerPrefs.Setfloat("yPos", m_transform.position.y); //
    //    } //
    //} //
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
