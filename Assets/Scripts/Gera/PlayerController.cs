using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigidBody2d;
    Animator anim;
    private void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    bool NeedToGo = false;
    public float Speed = 0.05f;
    Vector2 worldPos;
    void Update()
    {
        if (Input.GetMouseButtonUp(0) == true)
        {
            Vector2 mousePos = Input.mousePosition;
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            NeedToGo = true;
            //��������� ������� �������
            Vector3 diff = worldPos - (Vector2)transform.position;
            //� ����������� � (�������� � �������� �� -1 �� 1)
            diff.Normalize();
            //������� � � ���� x � y
            anim.SetFloat("x", diff.x);
            anim.SetFloat("y", diff.y);
            //������������� �������� ������� � ���������
            anim.SetBool("IsWalking", true);
        }
        if (NeedToGo)
        {
            rigidBody2d.MovePosition(Vector2.MoveTowards(transform.position, worldPos, Speed * Time.deltaTime));

            if (Vector2.Distance(transform.position, worldPos) < 0.01)
            {
                NeedToGo = false;
                //������������� �������� ����� �����
                anim.SetBool("IsWalking", false);
            }
        }
    }
}
