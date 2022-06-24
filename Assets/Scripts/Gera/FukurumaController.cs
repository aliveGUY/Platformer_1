using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FukurumaController : MonoBehaviour
{
    public Vector2 centerOfMass;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().centerOfMass = centerOfMass;
        GetComponent<Rigidbody2D>().WakeUp();
    }

    void OnDrawGizmos()
    {
        //Gizmos.color = color.red;
        Gizmos.DrawSphere(GetComponent<Rigidbody2D>().worldCenterOfMass, 0.1f);
    }
}
