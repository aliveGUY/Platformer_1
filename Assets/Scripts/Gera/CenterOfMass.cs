using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    public Transform CenterOfMassTransform;
    // Start is called before the first frame update
    private void Awake()
    {
        GetComponent<Rigidbody2D>().centerOfMass = Vector2.Scale(CenterOfMassTransform.localPosition, transform.localScale); 
    }
  
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetComponent<Rigidbody2D>().worldCenterOfMass, 0.1f);
    }
}
