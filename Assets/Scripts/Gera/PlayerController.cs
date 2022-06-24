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
            //Вычисляем разницу позиций
            Vector3 diff = worldPos - (Vector2)transform.position;
            //И нормализуем её (приводим к значению от -1 до 1)
            diff.Normalize();
            //Заносим её в наши x и y
            anim.SetFloat("x", diff.x);
            anim.SetFloat("y", diff.y);
            //Устанавливаем значение походки в аниматоре
            anim.SetBool("IsWalking", true);
        }
        if (NeedToGo)
        {
            rigidBody2d.MovePosition(Vector2.MoveTowards(transform.position, worldPos, Speed * Time.deltaTime));

            if (Vector2.Distance(transform.position, worldPos) < 0.01)
            {
                NeedToGo = false;
                //Останавливаем анимацию когда дошли
                anim.SetBool("IsWalking", false);
            }
        }
    }
}
