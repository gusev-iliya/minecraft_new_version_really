using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public float sensitivity = 3; // чувствительность мышки
    private float X, Y;
    public Camera cam;
    void Start()
    {


}

    // Update is called once per frame
    void Update()
    {
        Y += Input.GetAxis("Mouse Y") * sensitivity;
        Y = Mathf.Clamp(Y, -90, 90);
        cam.transform.localEulerAngles = new Vector3(-Y, 0, 0);
    }
}
