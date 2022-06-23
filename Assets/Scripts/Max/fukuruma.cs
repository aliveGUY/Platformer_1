using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fukuruma : MonoBehaviour
{
    public Vector2 centerOfMass;
    void Update()
    {
        GetComponent<Rigidbody2D>().centerOfMass = centerOfMass;
    }
    void OnDrawGizmos ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetComponent<Rigidbody2D>().worldCenterOfMass, 0.1f);
    }
}
