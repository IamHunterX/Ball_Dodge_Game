using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime * rotationInput );
    }
}
