using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fukuruma_Illia : MonoBehaviour
{
    public Vector2 center_of_mass;
    void Start(){
        GetComponent<Rigidbody2D>().centerOfMass = center_of_mass;
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetComponent<Rigidbody2D>().worldCenterOfMass, 0.1f);
    }
}
