using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float range = 10000;
    public Camera cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }
    void Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * range, Color.yellow);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider);
        }
    }
}
