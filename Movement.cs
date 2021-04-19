using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float mainThrust = 100f ; 
    [SerializeField] float RotationThrust = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        
    }
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            valueRotation(-1f);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            valueRotation(1f);
        }
    }
    void valueRotation(float value)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually roate
        transform.Rotate(-Vector3.forward * value * RotationThrust * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotationso the physics system can take over
    }
}
