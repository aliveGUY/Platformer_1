using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
    void Shoot() {
        Debug.Log("Shooting...");
        Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
    }
}
