using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessRotation();
    }

    void ProcessInput()
    {
        if (Input.GetKey (KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust *  Time.deltaTime);  
        }
        
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * mainThrust *  Time.deltaTime);
        }
    
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * mainThrust *  Time.deltaTime);
        }
    }
}
