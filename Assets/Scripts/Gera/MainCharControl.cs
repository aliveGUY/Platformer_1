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
    float horizontal, vertical;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal;
        position.y = position.y + speed * vertical;
        transform.position = position;
    }
}
