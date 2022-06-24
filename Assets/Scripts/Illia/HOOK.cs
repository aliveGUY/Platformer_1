using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HOOK : MonoBehaviour
{
    DistanceJoint2D joint;
    Vector3 target;
    RaycastHit2D raycast;
    public float distance = 10f;
    public LayerMask mask;
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;

            raycast = Physics2D.Raycast(transform.position, target - transform.position, distance, mask);
            if(raycast.collider != null){
                joint.enabled = true;
                joint.connectedBody = raycast.collider.gameObject.GetComponent<Rigidbody2D>();

                joint.distance = Vector2.Distance(transform.position, raycast.point);
            }
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            joint.enabled = false;
        }
    }
}
