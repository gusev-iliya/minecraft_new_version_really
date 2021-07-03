using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float range = 10000;
    public Camera cam;
    public int gun = 0;
    public List<int> guns = new List<int>() {1,5,10};
    public float firerate = 10;
    private float nt = 0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire1") && Time.time > nt)
        {
            nt = Time.time + firerate;
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
            if (hit.collider.name != "земля")
            {
                Debug.Log(hit.collider.name);
                hit.collider.GetComponent<HP>().hp -= guns[gun];
                if (hit.collider.GetComponent<HP>().hp <= 0)
                {
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }
}
