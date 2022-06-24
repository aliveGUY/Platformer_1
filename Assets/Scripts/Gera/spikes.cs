using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        MainCharControl controller = other.GetComponentInChildren<MainCharControl>();
        
        //Destroy(controller);
        Debug.Log("GameObject destroy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
