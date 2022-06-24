using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : MonoBehaviour
{
    DistanceJoint2D joint;

    Vector3 target;

    RaycastHit2D rayCast;

    public float distance = 10f;
    public LayerMask mask;

    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;

            rayCast = Physics2D.Raycast(transform.position, target - transform.position, distance, mask);

            if (rayCast.collider != null)
            {
                joint.enabled = true;
                joint.connectedBody = rayCast.collider.gameObject.GetComponent<Rigidbody2D>();

                joint.distance = Vector2.Distance(transform.position, rayCast.point);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            joint.enabled = false;
        }

    }
}
